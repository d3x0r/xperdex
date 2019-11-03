using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using xperdex.classes;
using xperdex.core.variables;
using WebInterfaces;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Windows.Forms;
using xperdex.gui;
using OpenSkieScheduler3;
using OpenSkie.Scheduler;

namespace ItemManager
{
	internal static class ItemManagmentState
	{
		static ItemDataSet _item_dataset;
		internal static ItemDataSet item_dataset
		{
			get
			{
				return _item_dataset;
			}
			set
			{
				_item_dataset = value;
			}
		}
		internal static DsnConnection item_dataset_dsn;
		internal static DataSetConnection dataset_state;

		internal static int max_session;
		internal static String Barcode;

		internal class StateFlags
		{
			internal bool filter_assigned;
		}
		internal static StateFlags flags = new StateFlags();

		internal static List<Control> lists = new List<Control>();

		internal static void RefreshLists()
		{
			refreshing_items = true;
			foreach( Control c in lists )
			{
				ListboxItemDescriptions lbid = c as ListboxItemDescriptions;
				if( lbid != null )
					lbid.inventory_type_filter = lbid.inventory_type_filter;
				c.Refresh();
			}
			refreshing_items = false;
		}

		static DataRow _current_session;
		internal static DataRow current_session
		{
			set
			{
				_current_session = value;
				{
					int session_number = Convert.ToInt32( value["session_number"] );
					DataRow session = schedule.GetSession( DateTime.Now, session_number );
					schedule_currents.current_session = session;

					current_macro_items.RowFilter = "session=" + value["session_number"].ToString();
					current_assigned_macro_items.RowFilter = "session=" + value["session_number"].ToString();
					//current_electronic_items.RowFilter = "Parent(session_pack_has_session).session=" + value["session_number"].ToString();
					current_floor_paper_macro_items.RowFilter = "Parent(macro_item_floor_item_map).session=" + value["session_number"].ToString();
				}
			}
			get
			{
				return _current_session;
			}
		}
		static DataRow _current_schedule_session;
		internal static DataRow current_schedule_session
		{
			set
			{
				_current_schedule_session = value;
				{
					schedule_currents.current_session = value;
				}
			}
			get
			{
				return _current_schedule_session;
			}
		}

		static public string current_inventory_type_filter;

		static bool setting_item;
		static bool refreshing_items;
		internal static List<XListbox> item_listboxes;
		static DataRow _current_item;
		/// <summary>
		/// This is the current item_description row
		/// </summary>
		internal static DataRow current_item
		{
			set
			{
				if( setting_item )
					return;
				if( refreshing_items )
					return;
				setting_item = true;
				if( _current_item == null || !_current_item.Equals( value ) )
				{
					int index = item_dataset.item_descriptions.Rows.IndexOf( value );
					_current_item = value;
					foreach( XListbox listbox in item_listboxes )
					{
						ListboxItemDescriptions lbid = listbox as ListboxItemDescriptions;
						if( lbid != null )
						{
							if( lbid.inventory_type_filter == ItemManagmentState.current_inventory_type_filter )
							{
								if( value != null )
								{
									for( int n = 0; n < listbox.Items.Count; n++ )
									{
										DataRowView drv = listbox.Items[n] as DataRowView;
										if( drv.Row == value )
										{
											listbox.SelectedIndex = n;
											break;
										}
									}
								}
								else
								{
									listbox.SelectedIndex = -1;
								}
							}
							else
								listbox.SelectedIndex = -1;
						}
					}
				}
				setting_item = false;
			}
			get
			{
				return _current_item;
			}
		}

		internal static List<XListbox> item_serial_listboxes;
		static DataRow _current_item_serial;
		/// <summary>
		/// This is the current item_description row
		/// </summary>
		internal static DataRow current_item_serial
		{
			set
			{
				if( _current_item_serial == null || !_current_item_serial.Equals( value ) )
				{
					bool found = false;
					int index = 0;
					foreach( DataRowView drv in current_items )
					{
						if( drv.Row.Equals( value ) )
						{
							found = true;
							break;
						}
						index++;
					}
					_current_item_serial = value;
					if( found )
						foreach( XListbox listbox in item_serial_listboxes )
							listbox.SelectedIndex = index;
				}
			}
			get
			{
				return _current_item_serial;
			}
		}

		internal static List<XListbox> inventory_type_listboxes;
		static DataRow _current_inventory_type;
		/// <summary>
		/// This is the current inventory type row
		/// </summary>
		internal static DataRow current_inventory_type
		{
			set
			{
				if( _current_inventory_type == null || !_current_inventory_type.Equals( value ) )
				{
					int index = inventory_types.Rows.IndexOf( value );
					_current_inventory_type = value;
					foreach( XListbox listbox in inventory_type_listboxes )
						listbox.SelectedIndex = index;
				}
			}
			get
			{
				return _current_inventory_type;
			}
		}

		static DataRow _current_misc;
		internal static DataRow current_misc
		{
			set
			{
				_current_misc = value;
			}
			get
			{
				return _current_misc;
			}
		}


		static DataRow _current_paper;
		internal static DataRow current_paper
		{
			set
			{
				_current_paper = value;
			}
			get
			{
				return _current_paper;
			}
		}

		public static List<ListboxCurrentMacroItems> macro_item_list = new List<ListboxCurrentMacroItems>();
		static DataRow _current_macro;
		internal static DataRow current_macro
		{
			set
			{
				_current_macro = value;
			}
			get
			{
				return _current_macro;
			}
		}

		static DataRow _current_electronic;
		internal static DataRow current_electronic
		{
			set
			{
				_current_electronic = value;
			}
			get
			{
				return _current_electronic;
			}
		}

		static DataRow _current_assigned_electronic;
		internal static DataRow current_assigned_electronic
		{
			set
			{
				_current_assigned_electronic = value;
			}
			get
			{
				return _current_assigned_electronic;
			}
		}


		internal static DataView current_unassigned_items;
		internal static DataView current_items;
		internal static DataView current_item_descriptions;
		internal static DataView current_macro_items;
		internal static DataView current_assigned_macro_items;
		internal static DataViewManager dvm_schedule;
		internal static DataView current_electronic_items;
		internal static DataView current_misc_items;
		internal static DataView current_floor_paper_macro_items;
		internal static DataView current_floor_paper_paper_items;
		internal static DataView current_floor_paper_misc_items;
		internal static DataView current_floor_paper_elec_items;

		internal static DataTable floor_item_map;
		internal static DataTable macro_item_map;
		internal static DataTable electronic_item_map;
		internal static DataTable misc_item_map;

		internal static DataTable inventory_types;

		internal static BarcodeScanner scanner;

		internal static ScheduleDataSet schedule;
		internal static ScheduleCurrents schedule_currents;

		static ItemManagmentState()
		{
			item_dataset = new ItemDataSet();
			item_dataset.Init();
			item_dataset_dsn = StaticDsnConnection.dsn;
			dataset_state = new DataSetConnection( item_dataset );

			dataset_state.Create( item_dataset_dsn );
			dataset_state.Fill( item_dataset_dsn );

			schedule = new ScheduleDataSet();
			schedule_currents = new ScheduleCurrents( schedule );
			dvm_schedule = new DataViewManager( schedule );
			schedule.schedule_dsn = item_dataset_dsn;
			schedule.Create();
			schedule.Fill();

			current_electronic_items = schedule_currents.current_bundles;

			//current_macro_items = new DataView( item_dataset.macro_item_assignments, "Table1_meta_pos_macro_items.session=0", "name1", DataViewRowState.CurrentRows );
			current_assigned_macro_items = new DataView( item_dataset.macro_item_assignments, "session=0", "name1,name2,receipt_string", DataViewRowState.CurrentRows );
			current_macro_items = new DataView( item_dataset.pos_macro_items, "session=0", "name1", DataViewRowState.CurrentRows );
			current_floor_paper_macro_items = new DataView( item_dataset.floor_item_map
				, "macro_item<>0 and Parent(macro_item_floor_item_map).session=0"
				, null
				, DataViewRowState.CurrentRows );
			current_floor_paper_paper_items = new DataView( item_dataset.floor_item_map
				, "paper_item<>0 or ( macro_item=0 and electronic_item=0 and misc_item=0) and floor_name<>'-None-'"
				, null
				, DataViewRowState.CurrentRows );
			current_floor_paper_misc_items = new DataView( item_dataset.floor_item_map
				, "misc_item<>0"
				, null
				, DataViewRowState.CurrentRows );
			current_floor_paper_elec_items = new DataView( item_dataset.floor_item_map
				, "electronic_item<>0"
				, null
				, DataViewRowState.CurrentRows );
			current_floor_paper_elec_items.Sort = "paper_item_name";
			inventory_types = item_dataset.item_descriptions.DefaultView.ToTable( true, new string[]{"inv_type"} );

			current_items = new ItemDataView();


			current_item_descriptions = new DataView( ItemManagmentState.item_dataset.item_descriptions
				, ""
				, "item_name"
				, DataViewRowState.CurrentRows );

			current_unassigned_items = new DataView( item_dataset.items
				, "item_description_id is NULL"
				, null
				, DataViewRowState.CurrentRows );

			object x = item_dataset.pos_macro_items.Compute( "max(session)", null );
			if( x != null && DBNull.Value != x )
				SetMaxSession( Convert.ToInt32( item_dataset.pos_macro_items.Compute( "max(session)", null ) ) );

			scanner = new BarcodeScanner();  // later someone will register for the read data
			scanner.DataReceived += new BarcodeScanner.CallThisWithData( scanner_DataReceived );

			item_listboxes = new List<XListbox>();
			item_serial_listboxes = new List<XListbox>();
			inventory_type_listboxes = new List<XListbox>();

			InitWebInterface();

		}


		static bool _ShowRetiredItems = false;
		public static bool ShowRetiredItems
		{
			get
			{
				return _ShowRetiredItems;
			}
			set
			{
				if( value )
					current_items.RowFilter = "";
				else
					current_items.RowFilter = "retire=0";

				_ShowRetiredItems = value;
			}
		}

		static ServiceHost BarcodeInterface;

		static void InitWebInterface()
		{
			if( BarcodeInterface == null )
			{
				string baseaddr = "http://0.0.0.0:8080/BarcodeService";
				Uri baseAddress = new Uri( baseaddr );

				BarcodeInterface = new ServiceHost( typeof( BarcodeReceiverInterface ), baseAddress );

				// Enable metadata publishing. 
				ServiceMetadataBehavior smb;
				smb = BarcodeInterface.Description.Behaviors.Find<ServiceMetadataBehavior>();
				if( smb == null )
					smb = new ServiceMetadataBehavior();
				smb.HttpGetEnabled = true;
				smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
				BarcodeInterface.Description.Behaviors.Add( smb );

				BarcodeInterface.AddServiceEndpoint( typeof( IBarcodeReceiver ), new BasicHttpBinding(), "" );

				try
				{
					//for some reason a default endpoint does not get created here 
					BarcodeInterface.Open();
				}
				catch( Exception e2 )
				{
					Log.log( e2.Message );
					BarcodeInterface = null;
				}
			}

		}

		internal static DataRow scanned_item;
		internal static DataRow scanned_item_description;

		internal static void FindCurrentItem()
		{
			scanned_item = null;
			scanned_item_description = null;

			foreach( DataRow item in item_dataset.items.Rows )
			{
				if( Convert.ToInt32( item["retire"] ) == 0 )
				{
					int length = Convert.ToInt32( item["serial_length"] );
					if( length == 0 )
						length = 8;
					if( String.Compare( Barcode, 0, item["series"].ToString(), 0, length, true ) == 0 )
					{
						scanned_item = item;
						scanned_item_description = item.GetParentRow( "FK_item_descriptions_items" );
						_current_serial_length = length;
						break;
					}
					int series1;
					if( Int32.TryParse( item["series"].ToString(), out series1 ) )
					{
						try
						{
							int series2;
							if( Barcode.Length >= length )
								series2 = Convert.ToInt32( Barcode.Substring( 0, length ) );
							else
							{
								if( !Int32.TryParse( Barcode, out series2 ) )
									continue;
							}
							if( series1 == series2 )
							{
								scanned_item = item;
								scanned_item_description = item.GetParentRow( "FK_item_descriptions_items" );
								_current_serial_length = length;
								break;
							}
						}
						catch
						{
						}

					}
				}
			}

			Variables.UpdateVariable( "<Scanned Item Name>" );
			Variables.UpdateVariable( "<Scanned Item Serial>" );
		}

		internal static void scanner_DataReceived( string s )
		{
			if( s.Length >= 8 )
				_current_serial_length = 8;
			else
				_current_serial_length = s.Length;
			
			Barcode = s;

			Variables.UpdateVariable( "<Barcode>" );
			Variables.UpdateVariable( "<Barcode Serial>" );
			FindCurrentItem();
		}

		internal static void Init()
		{
			
		}

		internal static void SetMaxSession( int session )
		{
			if( session > max_session )
			{
				int n;
				for( n = max_session; n < session; n++ )
				{
					DataRow session_row = item_dataset.sessions.NewRow();
					session_row["session_number"] = n + 1;
					item_dataset.sessions.Rows.Add( session_row );
				}
				max_session = session;
			}

		}

		static int _current_serial_length = 8;
		public static int current_serial_length
		{
			get
			{
				return _current_serial_length;
			}
			set
			{
				if( value >= 0 )
				{
					if( Barcode == null )
						return;
					if( value <= Barcode.Length )
					{
						_current_serial_length = value;
						Variables.UpdateVariable( "<Barcode Serial>" );
					}
				}
			}

		}

	}
}
