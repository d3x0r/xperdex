using System;
using System.Collections.Generic;
using System.Text;
using xperdex.classes.Types;

namespace xperdex.classes
{
    class CommontTextConfigurationParser
    {
        class filter_node
        {
            delegate void method( filter_node state_data, XString block );
            object data;
        }

        public enum configuration_types
        {
            CONFIG_UNKNOWN,
                // must match case-insensative exact length.
                // literal text

            CONFIG_TEXT,
                // a yes/no field may be 0/1, y[es]/n[o], on/off
                //
                
            CONFIG_YESNO,
            CONFIG_TRUEFALSE = CONFIG_YESNO,
            CONFIG_ONOFF = CONFIG_YESNO,
            CONFIG_OPENCLOSE = CONFIG_YESNO,
            CONFIG_BOOLEAN = CONFIG_YESNO,

                // may not have a . point - therefore the . is a terminator and needs
                // to match the next word.
            CONFIG_INTEGER,
                // has to be a floating point number (perhaps integral ie. no decimal)
            CONFIG_FLOAT,

                // binary data storage - stored as base64 encoded passed as PDATA
            CONFIG_BINARY,

                // formated number [+/-][[ ]## ]##[/##]
            CONFIG_FRACTION,

                // matches any single word.
            CONFIG_SINGLE_WORD,

                // protocol://[user[:password]](ip/name)[:port][/filepath][?cgi]
                // by convention this will not contain spaces... but perhaps
                // &20; (?)
            CONFIG_URL,

                // matches several words in a row - the end word to match is supplied.
            CONFIG_MULTI_WORD,
                // file name - does not have any path part.
                // the following are all treated like multi_word since file names/paths
                // may contain spaces
            CONFIG_FILE,
                // ends in a / or \,
            CONFIG_PATH,
                // may have path and filename
            CONFIG_FILEPATH,

                // (IP/name)[:port]
            CONFIG_ADDRESS,

                // end of configuration line (match assumed)
            CONFIG_PROCEDURE,
                 CONFIG_COLOR

        };


	// this needs to be the first element - 
	// address of this IS the address of main structure
	ConfigurationTest ConfigTestRoot;

	//FILE *file;
	//gcroot<System::IO::StreamReader^> sr;
	//gcroot<System::IO::FileStream^> fs;
    XString blocks;

	// this should be more than one...
	// and each will be called in order that it was
	// added, very importatn first in first process
	List<filter_node> filters;

    object psvUser;

    public delegate object EndProcessMethod( object );
	public delegate object UnhandledMethod( object, String );

	EndProcessMethod EndProcess;
    UnhandledMethod Unhandled;

	//PCONFIG_ELEMENTSET elements;
	//PCONFIG_TESTSET test_elements;
	bool config_recovered;
	String save_config_as;
	//PLIST states; // history of saved coniguration states...
    //	PDATASTACK ConfigStateStack;

    class configuation_state {
   Boolean recovered;
	String name;
	ConfigurationTest ConfigTestRoot;
	object psvUser;
        EndProcessMethod EndProcess;
        UnhandledMethod Unhandled;
    }

/*
typedef struct global_tag {
   //LOGICAL bSaveMemDebug;
	int _last_allocate_logging;
	int _disabled_allocate_logging;

	struct {
		BIT_FIELD bDisableMemoryLogging : 1;
		BIT_FIELD bLogUnhandled : 1;
	} flags;
} GLOBAL;
*/

        public delegate object HandleConfigurationMethod( object state_object, object[] args );

        void Process( String file )
        {
        }

        void ProcessInput( String content )
        {
        }

        void AddMethod( String format, HandleConfigurationMethod method )
        {
        }







        //---------------------------------------------------------------------

        void LogElementEx( String leader, ConfigurationElement pce )
        {
            if( pce == null )
            {
                Log.log( "Nothing." );
                return;
            }
            switch( pce.type )
            {
            case configuration_types.CONFIG_UNKNOWN:
                Log.log( "This thing was never configured?" );
                break;
            case configuration_types.CONFIG_TEXT:
                Log.log( leader + "text constant: " + pce.data.ToString() );
                break;
            case configuration_types.CONFIG_BOOLEAN:
                Log.log( leader + "a boolean");
                break;
            case configuration_types.CONFIG_INTEGER:
                Log.log( leader + "integer");
                break;
            case configuration_types.CONFIG_COLOR:
                Log.log( leader + "color");
                break;
            case configuration_types.CONFIG_BINARY:
                Log.log( leader + "binary");
                break;
            case configuration_types.CONFIG_FLOAT:
                Log.log( leader + "Floating");
                break;
            case configuration_types.CONFIG_FRACTION:
                Log.log( leader + "fraction");
                break;
            case configuration_types.CONFIG_SINGLE_WORD:
		         Log.log( leader + "a single word:" + pce.data.ToString() );
                break;
            case configuration_types.CONFIG_MULTI_WORD:
                Log.log( leader + "a multi word");
                break;
           case configuration_types.CONFIG_PROCEDURE:
            Log.log( leader + "a procedure to call.");
            break;
           case configuration_types.CONFIG_URL:
            Log.log( leader + "a url?");
            break;
           case configuration_types.CONFIG_FILE:
            Log.log( leader + "a filename");
            break;
           case configuration_types.CONFIG_PATH:
            Log.log( leader + "a path name");
            break;
           case configuration_types.CONFIG_FILEPATH:
            Log.log( leader + "a full path and file name");
            break;
           case configuration_types.CONFIG_ADDRESS:
            Log.log( leader + "an address");
            break;
            default:
                Log.log( "Do not know what this is." );
                break;
            }
        }

//---------------------------------------------------------------------

void DumpConfigurationEvaluator(  )
{
    foreach( ConfigurationElement pce in ConfigTestRoot.pConstElementList )
        LogElementEx( "const", pce );
    foreach( ConfigurationElement pce in ConfigTestRoot.pVarElementList )
        LogElementEx( "var", pce );
}

//---------------------------------------------------------------------

	class my_scratch_data {
		internal int skip;
        internal bool lastread;
        internal XString linebuf;
        internal my_scratch_data()
        {
        }
	};
// man what a friggin mess just to deal with ANY
// kind of mangled input and spit out some kinda lines
// uhmm...
static XString FilterLines( ref object scratch, XString buffer )
{
        //*data = (struct my_scratch_data*)scratch[0];
    my_scratch_data data = scratch as my_scratch_data;
	int total_length;
	int n;
	int thisskip;
	if( data == null )
	{
		data = new my_scratch_data();
		data.skip = 0;
		data.linebuf = null;
        data.lastread = false;
        scratch = data;
	}
	thisskip = data.skip; // skip N characters in first buffer.
	if( buffer != null )
	{
        data.lastread = false;
		data.linebuf.Add( buffer );
	}
	else if( buffer == null )
	{
		if( data.lastread )
		{
			XString final = null;
			if( data.linebuf != null )
				final = new XString( data.linebuf.firstseg.Text.Substring( data.skip ) );
            data.linebuf = null;
			scratch = null;
#if LOG_LINES_READ
			Log.log(  "Returning buffer [%s]" , GetText( final ) );
#endif
            return final;
		}
	}

	buffer = data.linebuf;
	total_length = 0;
	while( buffer != null )
	{
		// full new buffer, which may or may not add to prior segments...
		int end = 0;
		int length = buffer.firstseg.Text.Length;
		String chardata = buffer.firstseg.Text;
      //Log.log(  "Considering buffer %s" , GetText( buffer ) + data.skip );
		if( (length-thisskip) == 0 )
        {
            //buffer
            buffer.Remove( buffer.firstseg );
        }
		else for( n = thisskip; n < length; n++ )
		{
			if( chardata[n] == '\n' ||
				chardata[n] == '\r' )
			{
				if( chardata[n] == '\n' )
				{
                    end = 1;
					n++; // include this character.
					//Log.log( "BLANK LINE - CONSUMED" );
					break;
				}
				if( end > 0 ) // \r\r is two lines too
				{
					break;
				}
				end = 1;
			}
			else if( end > 0 )
			{
				// any other character... after a \r.. don't include the character.
				break;
			}
		}
		total_length += n - thisskip;
		if( end > 0 )
		{
			// new character, trim at -1 from here...
			result = SegCreate( total_length );
			int ofs;
			buffer = data.linebuf;
			thisskip = data.skip;
			n = thisskip;
			ofs = 0;
			while( ofs < total_length )
			{
				int len = GetTextSize( buffer );
				if( len > ( len - thisskip ) )
					len = len - thisskip;
				if( len > ( total_length - ofs ) )
					len = total_length - ofs;

				MemCpy( GetText( result ) + ofs
					, GetText( buffer ) + thisskip
					, sizeof( TEXTCHAR)*len );
				ofs += len;
				n += len;
				if( ofs < total_length )
				{
					n = 0;
					thisskip = 0;
					buffer = NEXTLINE( buffer );
				}
			}
			if( buffer )
			{
				data.skip = n;
				LineRelease( SegBreak( buffer ) );
				data.linebuf = buffer;
			}
			else
				data.skip = 0;
			GetText(result)[total_length] = 0;
			//Log.log( "Considering buffer %s", GetText( result ) );
#ifdef LOG_LINES_READ
			Log.log(  "Returning buffer [%s]" , GetText( result ) );
#endif
			return result;
		}
		else
		{
			//Log.log( "Had no end within the buffer, waiting for another..." );
		}
		thisskip = 0; // no more skips.
		buffer = NEXTLINE( buffer );
	}
   data.lastread = TRUE;
	return NULL;
}

//---------------------------------------------------------------------

static PTEXT CPROC FilterTerminators( POINTER *scratch, PTEXT buffer )
{
	struct my_scratch_data {
      PTEXT newline;
	} *data = (struct my_scratch_data*)scratch[0];
	if( !data )
	{
		scratch[0] = data = New( struct my_scratch_data );
      data[0].newline = NULL;
	}
   if( !buffer )
	{
		if( data[0].newline )
		{
			PTEXT tmp = data[0].newline;
         data[0].newline = NULL;
			return tmp;
		}
		else
         return NULL;
	}
	{
		int modified;
		int end = TRUE;
		// filter \r\n\\ just cause...
		data[0].newline = SegAppend( data[0].newline, buffer );
		while( buffer )
		{
			TEXTSTR chardata = GetText( buffer );
			int length = GetTextSize( buffer );
         //LogBinary( chardata, length );
			do
			{
				modified = 0;
				if( length && chardata[length-1] == '\n' )
				{
					//Log( "Removing newline..." );
					end = TRUE;
					length--;
					modified = 1;
				}
				if( length && chardata[length-1] == '\r' )
				{
					//Log( "Removing cr..." );
					end = TRUE;
					length--;
					modified = 1;
				}
				if( length && chardata[length-1] == '\\' )
				{
					if( ( length > 1 ) && ( chardata[length-2] != '\\' ) )
					{
						//Log( "Removing continue slash..." );
						end = FALSE;
						length--;
						modified = 1;
					}
				}
			} while( modified );
			if( !length )
			{
				LineRelease( SegGrab( buffer ) );
				data[0].newline = NULL;
				return NULL;
			}
			chardata[length] = 0;
			//Log.log( "Resulting line: %s", chardata );
			SetTextSize( buffer, length );
			buffer = NEXTLINE( buffer );
		}

		if( end )
		{
			PTEXT result = data[0].newline;
         data[0].newline = NULL;
			return result;
		}
	}
   return NULL;
}

//---------------------------------------------------------------------------

/* does not need scratch buffer... */
static PTEXT CPROC FilterEscapesAndComments( POINTER *scratch, PTEXT pText )
{
	CTEXTSTR text = GetText( pText );
	PTEXT pNewText;
	if( text /*&& strchr( text, '\\' )*/ )
	{
		PTEXT tmp;
		tmp = pNewText = TextDuplicate( pText, FALSE );
		while( tmp )
		{
			int dest = 0, src = 0;
			TEXTSTR text = GetText( tmp );
			while( text && text[src] )
			{
				if( text[src] == '\\' )
				{
					src++;
					switch( text[src] )
					{
					case 0:
                  Log.log(  "Continuation at end of line... save this and append next line please."  );
                  break;
					default:
						text[dest++] = text[src];
						break;
					}
				}
				else
				{
					if( text[src] == '#' )
                  break;
					text[dest++] = text[src];
				}
				src++;
			}
			text[dest] = 0;
			SetTextSize( tmp, dest );
			tmp = NEXTLINE( tmp );
		}
		LineRelease( pText );
	}
	else
		pNewText = pText;
	return pNewText;
}




    }
}
