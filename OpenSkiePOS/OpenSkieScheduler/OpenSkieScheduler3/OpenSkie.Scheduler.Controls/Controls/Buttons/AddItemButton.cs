using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using OpenSkieScheduler3.Controls.Lists;

namespace OpenSkie.Scheduler.Controls.Controls.Buttons
{


	/// <summary>
	/// Used as a button to add to a set.  Adds a relation.  Set MemberList to the target relation listbox.
	/// </summary>
	public class AddItemToSet : Button
	{

		public AddItemToSet()
		{
            Click += new EventHandler( AddItemToSet_Click );
			Text = ">>";
			Size = new Size( 38, 33 );
		}

        /// <summary>
        /// This is a property to be set in the designer, it is the name of the members that could be in group listbox...
        /// </summary>
        string _member_list;
		public string MemberList
		{
			get
			{
				return _member_list;
			}
			set
			{
				_member_list = value;
			}
		}

		public delegate void OnUpdateNewRow( DataRow row );
		public event OnUpdateNewRow UpdateNewRow;

        void AddItemToSet_Click( object sender, EventArgs e )
		{
			ListBox member_list = this.Parent.Controls[_member_list] as ListBox;
            if( member_list != null )
            {
				DataRow newrow = MyListBox.AddSelected( member_list );
				if( UpdateNewRow != null )
					UpdateNewRow( newrow );
            }
            else
                MessageBox.Show( "Could not find member list" );
		}
	}

    public class AddItemToTargetTable : Button
    {

        public AddItemToTargetTable()
        {
            Click += new EventHandler( AddSessionToSessionMacro_Click );
            Text = ">>";
            Size = new Size( 38, 33 );
        }

        string _target_table;
        /// <summary>
        /// This is a property to be set in the designer, 
        /// It is the listbox of members that can be added to a group 
        /// (that listbox indicates what group listbox is)
        /// </summary>
        public string TableTarget
        {
            get
            {
                return _target_table;
            }
            set
            {
                _target_table = value;
            }
        }
#if lists_connect_also
        string _child_table;
        public string TableChild
        {
            get
            {
                return _child_table;
            }
            set
            {
                _child_table = value;
            }
        }
        string _parent_table;
        public string TableParent
        {
            get
            {
                return _parent_table;
            }
            set
            {
                _parent_table = value;
            }
        }
#endif
        void AddSessionToSessionMacro_Click( object sender, EventArgs e )
        {
            MyListBox list = this.Parent.Controls[_target_table] as MyListBox;

			if( list != null )
                list.AddSelected();
            else
                MessageBox.Show( "Could not find target list" );
        }
    }

    public class RemoveItemFromSet : Button
	{


		public RemoveItemFromSet()
		{
            Click += new EventHandler( RemoveItemFromSet_Click );
			Text = "<<";
			Size = new Size( 38, 33 );
		}
		string _group_list;
        /// <summary>
        /// This is a property to be set in the designer, it is the name of the current group's members listbox (which has a datasource...)
        /// </summary>
        public string GroupList
		{
			get
			{
				return _group_list;
			}
			set
			{
				_group_list = value;
			}
		}


        void RemoveItemFromSet_Click( object sender, EventArgs e )
		{
			ListBox list = this.Parent.Controls[_group_list] as ListBox;
            if( list != null )
			    MyListBox.RemoveSelected( list );
		}
	}

    public class InsertItemIntoSet : Button
    {
        public InsertItemIntoSet()
        {
            Click += new EventHandler( InsertItemIntoSet_Click );
            Text = "->_";
            Size = new Size( 38, 33 );
        }

        string _member_list;
        /// <summary>
        /// This is a property to be set in the designer, it is the name of the listbox of members to insert into the group (which has a datasource...)
        /// </summary>
        public string MemberList
        {
            get
            {
                return _member_list;
            }
            set
            {
                _member_list = value;
            }
        }

		string _target_list;
		/// <summary>
		/// This is a property to be set in the designer, it is the name of the target listbox (which has a datasource...)
		/// </summary>
		public string TargetList
		{
			get
			{
				return _target_list;
			}
			set
			{
				_target_list = value;
			}
		}


        void InsertItemIntoSet_Click( object sender, EventArgs e )
        {
            MyListBox member_list = this.Parent.Controls[_member_list] as MyListBox;
            if( member_list != null )
            {
				ListBox target_list = this.Parent.Controls[_target_list] as ListBox;
                if( target_list != null )
                {
                    //object selection = target_list.SelectedItem;
                    DataRow newrow = member_list.InsertSelected();
                    if( newrow != null )
                        target_list.SelectedIndex = newrow.Table.Rows.IndexOf( newrow );
                }
                else
                {
                    member_list.InsertSelected();
                }
            }
        }
    }

    public class ReplaceItemIntoSet : Button
    {
        public ReplaceItemIntoSet()
        {
            Click += new EventHandler( ReplaceItemIntoSet_Click );
            Text = "> <";
            Size = new Size( 38, 33 );
        }

        string _member_list;
        /// <summary>
        /// This is a property to be set in the designer, it is the name of the target listbox (which has a datasource...)
        /// </summary>
        public string MemberList
        {
            get
            {
                return _member_list;
            }
            set
            {
                _member_list = value;
            }
        }


        void ReplaceItemIntoSet_Click( object sender, EventArgs e )
        {
            MyListBox member_list = this.Parent.Controls[_member_list] as MyListBox;
            if( member_list != null )
            {
                member_list.ReplaceSelected();
            }
        }
    }
	
}
