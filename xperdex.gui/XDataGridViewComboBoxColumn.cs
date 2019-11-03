using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace xperdex.gui
{
	public class XDataGridViewComboBoxColumn: DataGridViewColumn
	{
		public class XDataGridViewComboBoxCell : DataGridViewTextBoxCell
		{
			public XDataGridViewComboBoxCell()
			{

			}

			public override Type FormattedValueType
			{
				get
				{

					return typeof( String );// base.FormattedValueType;
				}
			}

			public override Type ValueType
			{
				get
				{
					// Return the type of the value that CalendarCell contains.
					return typeof( String );
				}
			}

			public override object DefaultNewRowValue
			{
				get
				{
					// Use the current date and time as the default value.
					return null;
				}
			}

			//override type

			public override Type EditType
			{
				get
				{
					// Return the type of the editing control that CalendarCell uses.
					return typeof( XDataGridViewComboBoxEditingControl );
				}
			}
			public override void InitializeEditingControl( int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle )
			{

				base.InitializeEditingControl( rowIndex, initialFormattedValue, dataGridViewCellStyle );



				XDataGridComboBox ctl = DataGridView.EditingControl as XDataGridComboBox;

				//comment out this line
				//ctl.DropDownStyle = ComboBoxStyle.DropDownList;

				if( ctl != null )
				{
					ctl.SelectedIndex = 0;
				}

			}

			Type value_type;
			object _DataSource;
			public object DataSource
			{
				set
				{
					_DataSource = value;
					if( value != null )
					{
						if( value.GetType().IsSubclassOf( typeof( DataView ) ) )
						{
							value_type = typeof( DataRowView );
						}
						else if( value.GetType().IsSubclassOf( typeof( DataTable ) ) )
						{
							value_type = typeof( DataRow );
						}
						else
							value_type = typeof( int );
					}
				}
				get
				{
					return _DataSource;
				}
			}
		}

		//[ClassInterfaceAttribute( ClassInterfaceType.AutoDispatch )]
		//[ComVisibleAttribute( true )]
		public class XDataGridViewComboBoxEditingControl : ComboBox, IDataGridViewEditingControl
		{

			//private bool tabStop;
			private DataGridView editingControlDataGridView;
			private object editingControlFormattedValue;
			private int editingControlRowIndex;
			private bool editingControlValueChanged;
			private Cursor editingPanelCursor;

			public XDataGridViewComboBoxEditingControl()
			{
				//tabStop = false;
				editingControlValueChanged = false;
			}

			public virtual DataGridView EditingControlDataGridView
			{
				get { return editingControlDataGridView; }
				set { editingControlDataGridView = value; }
			}

			public virtual object EditingControlFormattedValue
			{
				get { return editingControlFormattedValue; }
				set { editingControlFormattedValue = value; }
			}

			public virtual int EditingControlRowIndex
			{
				get { return editingControlRowIndex; }
				set { editingControlRowIndex = value; }
			}

			public virtual bool EditingControlValueChanged
			{
				get { return editingControlValueChanged; }
				set { editingControlValueChanged = value; }
			}

			public virtual Cursor EditingPanelCursor
			{
				get { return editingPanelCursor; }
			}

			public virtual bool RepositionEditingControlOnValueChange
			{
				get { return false; }
			}

			public virtual void ApplyCellStyleToEditingControl( DataGridViewCellStyle dataGridViewCellStyle )
			{
				//throw new NotImplementedException();
			}

			public virtual bool EditingControlWantsInputKey( Keys keyData, bool dataGridViewWantsInputKey )
			{
				// true if the specified key is a regular key that should be handled by the editing control; otherwise, false
				throw new NotImplementedException();
			}

			public virtual object GetEditingControlFormattedValue( DataGridViewDataErrorContexts context )
			{
				//throw new NotImplementedException();
				return "result?";
			}

			public virtual void PrepareEditingControlForEdit( bool selectAll )
			{
				//throw new NotImplementedException();
			}

			protected override void OnSelectedIndexChanged( EventArgs e )
			{
				throw new NotImplementedException();
			}

		}



		public class XDataGridComboBox : XComboBox, IDataGridViewEditingControl
		{
			private int index_ = 0;
			private DataGridView dataGridView_ = null;
			private bool valueChanged_ = false;

			public XDataGridComboBox()
				: base()
			{
				this.SelectedIndexChanged += new EventHandler( ComboBoxControl_SelectedIndexChanged );
			}


			public void ComboBoxControl_SelectedIndexChanged( object sender, EventArgs e )
			{
				//I will add code here
				NotifyDataGridViewOfValueChange();
			}


			protected virtual void NotifyDataGridViewOfValueChange()
			{
				this.valueChanged_ = true;
				if( this.dataGridView_ != null )
				{
					this.dataGridView_.NotifyCurrentCellDirty( true );
				}
			}


			public void ApplyCellStyleToEditingControl( DataGridViewCellStyle dataGridViewCellStyle )
			{
				this.Font = dataGridViewCellStyle.Font;
				this.ForeColor = dataGridViewCellStyle.ForeColor;
				this.BackColor = dataGridViewCellStyle.BackColor;
			}


			public DataGridView EditingControlDataGridView
			{
				get
				{
					return dataGridView_;
				}
				set
				{
					dataGridView_ = value;
				}
			}

			public object EditingControlFormattedValue
			{
				get
				{
					return base.SelectedValue;
				}
				set
				{
					base.SelectedValue = value;
					NotifyDataGridViewOfValueChange();
				}
			}

			public int EditingControlRowIndex
			{
				get
				{
					return index_;
				}
				set
				{
					index_ = value;
				}
			}

			public bool EditingControlValueChanged
			{
				get
				{
					return valueChanged_;
				}
				set
				{
					valueChanged_ = value;
				}
			}

			public bool EditingControlWantsInputKey( Keys keyData, bool dataGridViewWantsInputKey )
			{
				if( keyData == Keys.Return )
					return true;
				switch( keyData & Keys.KeyCode )
				{
				case Keys.Left:
				case Keys.Up:
				case Keys.Down:
				case Keys.Right:
				case Keys.Home:
				case Keys.End:
				case Keys.PageDown:
				case Keys.PageUp:
				case Keys.Return:
					return true;
				default:
					return false;
				}
			}

			public Cursor EditingPanelCursor
			{
				get
				{
					return base.Cursor;
				}
			}

			public object GetEditingControlFormattedValue( DataGridViewDataErrorContexts context )
			{
				return EditingControlFormattedValue.ToString();
			}

			public void PrepareEditingControlForEdit( bool selectAll )
			{
			}

			public bool RepositionEditingControlOnValueChange
			{
				get { return false; }
			}

		}

		public XDataGridViewComboBoxColumn():base( new XDataGridViewComboBoxCell() )
		{
		}


		object _DataSource;
		public object DataSource
		{
			get
			{
				return _DataSource;
			}
			set
			{
				(this.CellTemplate as XDataGridViewComboBoxCell).DataSource = value;
				//this.CellTemplate.
				_DataSource = value;
			}
		}

	}
}
