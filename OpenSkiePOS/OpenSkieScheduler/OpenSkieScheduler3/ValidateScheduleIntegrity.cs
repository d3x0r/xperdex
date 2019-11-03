using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using xperdex.classes;

namespace OpenSkieScheduler
{
    public partial class ValidateScheduleIntegrity : Form
    {
        public ValidateScheduleIntegrity()
        {
            InitializeComponent();
        }

        private void button1_Click( object sender, EventArgs e )
        {

            MySQLDataTable table = new MySQLDataTable( StaticDsnConnection.dsn
                , "select item_name,series,series_from,series_to,face_skip,page_skip,faces_across,faces_down from items join item_descriptions using(item_description_id) where retire=0"
					 );
            if( table.Rows.Count == 0 )
            {   
                listBox1.Items.Add( "There are no invoiced, non-retired items." );
                
            }
            else foreach( DataRow row in table.Rows )
            {
                if( row["faces_across"] == null || row["faces_across"] == DBNull.Value || Convert.ToInt32( row["faces_across"] ) == 0 )
                    listBox1.Items.Add( row["item_name"] + "[" + row["series"] + "] has bad item_description.faces_across:" + row["faces_across"] );

                if( row["faces_down"] == null || row["faces_down"] == DBNull.Value || Convert.ToInt32( row["faces_down"] ) == 0 )
                    listBox1.Items.Add( row["item_name"] + "[" + row["series"] + "] has bad item_description.faces_down:" + row["faces_down"] );

                if( row["series_from"] == null || row["series_from"] == DBNull.Value || Convert.ToInt32( row["series_from"] ) == 0 )
                    listBox1.Items.Add( row["item_name"] + "[" + row["series"] + "] has bad items.series_from:" + row["series_from"] );
                if( row["series_to"] == null || row["series_to"] == DBNull.Value || Convert.ToInt32( row["series_to"] ) == 0 )
                    listBox1.Items.Add( row["item_name"] + "[" + row["series"] + "] has bad items.series_to:" + row["series_to"] );

                if( row["face_skip"] == null || row["face_skip"] == DBNull.Value || Convert.ToInt32( row["face_skip"] ) == 0 )
                {
                    listBox1.Items.Add( row["item_name"] + "[" + row["series"] + "] has bad item_description.face_skip:" + row["face_skip"] );
                    if( checkBox1.Checked )
                    {
                        if( ( String.Compare( row["item_name"].ToString(), "Bonus RB" ) == 0 )
                            || ( String.Compare( row["item_name"].ToString(), "Large Rainbow" ) == 0 ) )
                        {
                            StaticDsnConnection.dsn.ExecuteNonQuery( "update item_descriptions set face_skip=50 where item_name='" + row["item_name"] + "'" );
                        }
                        else
                            StaticDsnConnection.dsn.ExecuteNonQuery( "update item_descriptions set face_skip=50 where item_name='" + row["item_name"] + "'" );
                        listBox1.Items.Add( "Fixed" );
                    }
                }
                if( row["page_skip"] == null || row["page_skip"] == DBNull.Value || Convert.ToInt32( row["page_skip"] ) == 0 )
                {
                    listBox1.Items.Add( row["item_name"] + "[" + row["series"] + "] has bad item_description.page_skip:" + row["page_skip"] );
                    if( checkBox1.Checked )
                    {
                        StaticDsnConnection.dsn.ExecuteNonQuery( "update item_descriptions set page_skip=1 where item_name='" + row["item_name"] + "'" );
                        listBox1.Items.Add( "Fixed" );
                    }
                }
            }

        
        }

        private void button2_Click( object sender, EventArgs e )
        {
            MySQLDataTable table1 = new MySQLDataTable( StaticDsnConnection.dsn
                , "select name from floor_paper_names" );
            MySQLDataTable table2 = new MySQLDataTable( StaticDsnConnection.dsn
                , "select item_name from item_descriptions"
                     );
            MySQLDataTable table3 = new MySQLDataTable( StaticDsnConnection.dsn
                , "select paper_item_name,floor_name from floor_item_map"
                     );
            foreach( DataRow row in table2.Rows )
            {
                DataRow[] rows = table1.Select( "name='" + row["item_name"] +"'");
                if( rows.Length == 0 )
                {
                    rows = table3.Select( "paper_item_name='" + row["item_name"] + "'" );
                    if( rows.Length == 0 )
                    {
                        listBox1.Items.Add( "Item " + row["item_name"] + " does not map to a floor_paper_name and cannot be sold" );
                    }
                    else
                    {
                        foreach( DataRow row2 in rows )
                        {
                            DataRow[] floor_rows = table1.Select( "name='" + row2["floor_name"] +"'" );
                            if( floor_rows.Length == 0 )
                            {
                                listBox1.Items.Add( "Item " + row["item_name"] + " Is mapped to floor_name " + row2["floor_name"] + " But that floor name does not exist." );
                            }
                        }
                    }
                }
            }
        }
    }
}
