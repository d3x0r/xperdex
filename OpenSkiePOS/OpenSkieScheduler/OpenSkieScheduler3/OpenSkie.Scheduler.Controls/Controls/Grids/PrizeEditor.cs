using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace OpenSkieScheduler.Controls.Grids
{
	public class PrizeEditor: DataGridView
	{

		public class PrizeCell : DataGridViewCell
		{
		}

		public PrizeEditor()
		{
			this.AllowUserToAddRows = false;
			this.AllowUserToDeleteRows = false;
		
			this.AutoGenerateColumns = false;
			Columns.Add( new DataGridViewColumn() );
			Columns.Add( new DataGridViewColumn() );
			Columns[0].HeaderText = "Row Header";
			Columns[0].Name = "Row Header";
			Columns[1].HeaderText = "Row DataRow";
			Columns[1].Name = "Row DataRow";
			this.DataSource = null;// ControlList.data.current_session_game_prize_matrix;
			ControlList.UpdateDataSource += new ControlList.UpdateDataSourceEvent( ControlList_UpdateDataSource );
			//ControlList.data.current_session_game_prize_matrix.ColumnChanged += new System.Data.DataColumnChangeEventHandler( current_session_game_prize_matrix_ColumnChanged );
			FixupColumns();
			this.ColumnAdded += new DataGridViewColumnEventHandler( PrizeEditor_ColumnAdded );
			this.RowsAdded += new DataGridViewRowsAddedEventHandler( PrizeEditor_RowsAdded );
		}

		void PrizeEditor_ColumnAdded( object sender, DataGridViewColumnEventArgs e )
		{
			if( e.Column.Name == "Row DataRow" )
				e.Column.Visible = false;
			if( e.Column.Name == "Row Header" )
				e.Column.Visible = false;
		}

		void PrizeEditor_RowsAdded( object sender, DataGridViewRowsAddedEventArgs e )
		{
			for( int n = 0; n < e.RowCount; n++ )
			{
				if( this.Columns.Contains( "Row DataRow" ) )
				{
					DataGridViewCell cell = this.Rows[e.RowIndex + n].Cells["Row DataRow"];
					DataRow row = cell.Value as DataRow;
					if( row != null )
						this.Rows[e.RowIndex + n].HeaderCell.Value = row["Row Header"];
				}
			}
		}

		void current_session_game_prize_matrix_ColumnChanged( object sender, System.Data.DataColumnChangeEventArgs e )
		{
			if( e.Row.RowState == DataRowState.Detached )
				return;
			if( e.Column.ColumnName == "Row DataRow" )
			{
				foreach( DataGridViewRow drv in this.Rows )
				{
					DataRow row = e.ProposedValue as DataRow;
					if( row == e.Row )
					{
						drv.HeaderCell.ValueType = typeof( string );
						drv.HeaderCell.Value = e.Row["Row Header"];
						break;
					}
				}
			}
			if( e.Column.ColumnName == "Row Header"  )
			{
				foreach( DataGridViewRow drv in this.Rows )
				{
					if( drv.DataGridView.Columns.Contains( "Row DataRow" ) )
					{
						DataRow row = drv.Cells["Row DataRow"].Value as DataRow;
						if( row == e.Row )
						{
							drv.HeaderCell.ValueType = typeof( string );
							drv.HeaderCell.Value = e.Row["Row Header"];
							break;
						}
					}
				}
			}
		}

		void FixupColumns()
		{
			// 0
			if( this.Columns["Row Header"] != null )
				this.Columns["Row Header"].Visible = false;
			// 1
			if( this.Columns["Row DataRow"] != null )
				this.Columns["Row DataRow"].Visible = false;

		}
		void ControlList_UpdateDataSource()
		{
			this.DataSource = null;
			this.AutoGenerateColumns = true;
			this.DataSource = null;// ControlList.data.current_session_game_prize_matrix;
			FixupColumns();
		}

	}

}
