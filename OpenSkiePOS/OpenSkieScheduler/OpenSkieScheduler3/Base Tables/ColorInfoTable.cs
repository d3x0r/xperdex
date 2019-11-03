using System;
using System.Data;
using System.Drawing;
using xperdex.classes;
using xperdex.classes.Types;

namespace OpenSkieScheduler3
{
	[SchedulePersistantTable( DefaultFill="FillInitial" )]
	public class ColorInfoTable : MySQLNameTable
	{
		new public static readonly string TableName = "color_info";
		public static readonly string NameColumn = XDataTable.Name( TableName );
		new public static readonly string PrimaryKey = XDataTable.ID( TableName );

		internal class default_data
		{
			internal string name;
			internal XColor color;
            internal int dat_id;
			internal default_data( string s, Color c, int d_id )
			{
				name = s;
				color = c;
                dat_id = d_id;
			}
		}
		public static int Reverse( UInt32 a )
		{
			return (int)(0xFF000000U | ( ( a & 0xFF0000U ) >> 16 ) | ( a & 0xFF00 ) | ( ( a & 0xFF ) << 16 ) );
		}
		static default_data[] defaults = new default_data[] {
			new default_data("RED", Color.FromArgb(Reverse(127)) , 0)
			, new default_data("GREEN", Color.FromArgb(Reverse(32512 ) ), 0 )
			, new default_data("BLUE", Color.FromArgb(Reverse(8323072 ) ), 0 )
			, new default_data("BLACK", Color.FromArgb(Reverse(0 ) ), 0 )
			, new default_data("GRAY", Color.FromArgb(Reverse(2039583 ) ), 0 )
			, new default_data("LIGHT BLUE", Color.FromArgb(Reverse(15708256 ) ), 0 )
			, new default_data("YELLOW", Color.FromArgb(Reverse(65535 ) ), 0 )
			, new default_data("ORANGE", Color.FromArgb(Reverse(8417247 ) ), 0 )
			, new default_data("GOLD", Color.FromArgb(Reverse(32639 ) ), 0 )
			, new default_data("PURPLE", Color.FromArgb(Reverse(8323199 ) ), 0 )
			, new default_data("BROWN", Color.FromArgb(Reverse(7967 ) ), 0 )
			, new default_data("LIME", Color.FromArgb(Reverse(65280 ) ), 0 )
			, new default_data("OLIVE", Color.FromArgb(Reverse(7936 ) ), 0 )
			, new default_data("PINK", Color.FromArgb(Reverse(11513839 ) ), 0 )
		};

        public ColorInfoTable()
            : base( null, TableName )
		{
			base.TableName = "(tmp)" + TableName;
			// UpdateChanges() requires parameterless constructor.
			Columns.Add( "color", typeof( XColor ) );
            Columns.Add( "dat_id", typeof( int ) );
        }

		public void FillInitial()
		{
			if( Rows.Count == 0 )
			{
				DataRow tmp;
				tmp = NewRow();
				if( AutoKeyType == typeof( Guid ) )
					tmp[PrimaryKey] = Guid.Empty;

				tmp[NameColumn] = "No Color";
				tmp["color"] = new XColor( Color.Empty );
				tmp["dat_id"] = 0;

				Rows.Add( tmp );

				foreach( default_data data in defaults )
				{
					tmp = NewRow();
					tmp[NameColumn] = data.name;
					tmp["color"] = data.color;
					tmp["dat_id"] = data.dat_id;
					Rows.Add( tmp );
				}
			}
		}

		public ColorInfoTable( DataSet dataSet )
			: base( Names.schedule_prefix, TableName, true, false )
		{
			dataSet.Tables.Add( this );
			Columns.Add( "color", typeof( XColor ) );
            Columns.Add( "dat_id", typeof(int));
		}

		public DataRow NewColor( string name )
		{
			return NewSimpleName( name );
		}

	}
}
