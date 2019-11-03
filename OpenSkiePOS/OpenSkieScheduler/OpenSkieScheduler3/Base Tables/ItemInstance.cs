using System.Data;
using xperdex.classes;

namespace OpenSkieScheduler3
{
	[SchedulePersistantTable]
    class ItemInstance : MySQLDataTable
    {
        new public readonly static string TableName = "items";

        void AddColumns()
        {
            this.AddDefaultColumns( true, true, false );
			this.Columns.Add( XDataTable.ID( typeof( ItemDescription ) ), typeof( int ) );
            this.Columns.Add( "series", typeof( int ) );
            this.Columns.Add( "series_from", typeof( int ) );
            this.Columns.Add( "series_to", typeof( int ) );
            
        }

        //static new public string TableName
        public ItemInstance()
        {
            AddColumns();
        }

        public ItemInstance( DataSet dataSet, DsnConnection dsn )
            : base( dsn )
        {
            AddColumns();
            dataSet.Tables.Add( this );
            DataTable descip = dataSet.Tables[ItemDescription.TableName];
            if( descip != null )
            {
                if( dataSet.Tables.Contains( ItemDescription.TableName ) )
                {
                    dataSet.Relations.Add(
                    new DataRelation( "item_is_item_description"
						, descip.Columns[XDataTable.ID( descip )]
						, this.Columns[XDataTable.ID( descip )] ) );
                }
            }
        }
    }
}
