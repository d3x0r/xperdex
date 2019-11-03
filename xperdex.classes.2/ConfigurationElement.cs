using System;
using System.Collections.Generic;
using System.Text;

namespace xperdex.classes
{
    class ConfigurationElement
    {
        internal CommontTextConfigurationParser.configuration_types type;
        ConfigurationTest next;// if a match is found, follow this to next.
	    ConfigurationElement prior;
        [FlagsAttribute]
        enum config_flags {
            vector, multiword_terminator, singleword_terminator;
        }

        config_flags flags;
        UInt32 element_count; // used with vector fields.
        object data;
        /*
    union {
        PTEXT pText;
        struct {
            LOGICAL bTrue;
        } truefalse;
        _64 integer_number;
		  double float_number;
		  TEXTSTR pWord; // also pFilename, pPath, pURL
		  struct {
			  TEXTSTR pWord; // also pFilename, pPath, pURL
           struct config_element_tag *pEnd; // also this ends single word...
		  } singleword;
        // maybe pURL should be burst into
        //   ( address, user, password, path, page, params )
        SOCKADDR *psaSockaddr;
        struct {
            TEXTSTR pWords;
     // next thing to match...
     // this is probably a constant text thing, but
     // may be say an integer, filename, or some known
     // format thing...
            struct config_element_tag *pEnd;
        } multiword;
        FRACTION fraction;
        USER_CONFIG_HANDLER Process;
		  CDATA Color;
		  struct {
			  UInt32 length;
			  POINTER data;
		  } binary;
    } data[1]; // these are value holders... if there is a vector field,
            // either the count will be specified, or this will have to
            // be auto expanded....
        */
    }
}
