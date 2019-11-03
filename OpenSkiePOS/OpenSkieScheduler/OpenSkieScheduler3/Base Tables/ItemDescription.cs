using System.Data;
using xperdex.classes;

namespace OpenSkieScheduler3
{
	[SchedulePersistantTable]
	public class ItemDescription : MySQLDataTable
    {
        new public readonly static string TableName = "item_descriptions";
        public readonly static string NameColumn = "item_name";
        new public readonly static string PrimaryKey = "item_description_id";
        void AddColumns()
        {
            this.AddDefaultColumns( true, true, true );
            this.Columns.Add( "faces_across", typeof( int ) );
            this.Columns.Add( "faces_down", typeof( int ) );
            this.Columns.Add( "page_skip", typeof( int ) );
            this.Columns.Add( "face_skip", typeof( int ) );
            this.Columns.Add( "paper_group_size", typeof( int ) );
            this.Columns.Add( "default_series_from", typeof( int ) );
            this.Columns.Add( "default_series_to", typeof( int ) );
            
        }

        public ItemDescription()
        {
            AddColumns();
        }

        public ItemDescription( DataSet dataSet, DsnConnection dsn ): base( dsn )
        {
            AddColumns();
            dataSet.Tables.Add( this );
        }
    }
}
