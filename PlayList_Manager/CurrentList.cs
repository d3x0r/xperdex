using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using xperdex.core.interfaces;

namespace PlayList_Manager
{
	public class CurrentList: DataGridView, IReflectorCreate
	{

		bool reordering;
        	const int PlayBox = 40;
                const int ColumnPad = 2; // 2 columns, 2 dividers.
                const int FramePad = 2;
                const int HeaderPad = 40;
        
		public CurrentList()

		{
			this.DataSource = Local.CurrentFiles;
			//this.DisplayMember = "Name";
			//this.RowHeadersVisible = false;
			this.AllowUserToAddRows = false;
			this.AllowUserToResizeRows = false;
			this.AllowUserToResizeColumns = false;
			this.AllowUserToDeleteRows = true;
			this.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			ExtendMe();
		}

		protected override void OnRowsAdded( DataGridViewRowsAddedEventArgs e )
		{
			for( int n = 0; n < e.RowCount; n++ )
				this.Rows[e.RowIndex+n].HeaderCell.Value =
					this.Rows[e.RowIndex + n].Cells["Name"].Value.ToString();
			base.OnRowsAdded( e );
		}

		protected override void OnUserDeletingRow( DataGridViewRowCancelEventArgs e )
		{
			DataRow file = (e.Row.DataBoundItem as DataRowView).Row;
			String fname = file["Name"].ToString();
			String name = file["Path"] + "/" + fname;
			if( MessageBox.Show( "Do you want to delete this file?\n" + fname, "Confirm File Delete", MessageBoxButtons.YesNo ) == DialogResult.Yes )
			{
				System.IO.File.Delete( name );
				Local.WritePlayList();
			}
			else
				e.Cancel = true;
			base.OnUserDeletingRow( e );
		}

		protected override void OnColumnAdded( DataGridViewColumnEventArgs e )
		{
			if( e.Column.Name == "Path" )
				e.Column.Visible = false;
			else if( e.Column.Name == "Alias Path" )
				e.Column.Visible = false;
			else if( e.Column.Name == "Play" )
				e.Column.Width = PlayBox;
			else if( e.Column.Name == "Name" )
			{
				e.Column.Visible = false;
				e.Column.ReadOnly = true;
				e.Column.Width = this.Width - (PlayBox+ColumnPad+FramePad+HeaderPad);
			}
			
			e.Column.SortMode = DataGridViewColumnSortMode.Programmatic;

			base.OnColumnAdded( e );
		}

		protected override void OnSizeChanged( EventArgs e )
		{
			this.RowHeadersWidth = this.Width - ( PlayBox + ColumnPad + FramePad );
			/*
			DataGridViewColumn c = this.Columns["Name"];
			if( c != null )
				c.Width = this.Width - ( PlayBox + ColumnPad + FramePad + HeaderPad );
			 * */
			base.OnSizeChanged( e );
		}

        //vars for custom column/row drag/drop operations
        private Rectangle DragDropRectangle;
        private int DragDropSourceIndex;
        private int DragDropTargetIndex;
        private int DragDropCurrentIndex = -1;
        private int DragDropType; //0=column, 1=row
        private DataGridViewColumn DragDropColumn;
        private object[] DragDropColumnCellValue;

        public void ExtendMe()
        {
            this.AllowUserToResizeRows = false;
            this.SelectionMode = DataGridViewSelectionMode.CellSelect;
            this.AllowUserToOrderColumns = false;
            this.AllowDrop = true;
        } //end default constructor

        //protected override void OnColumnAdded(DataGridViewColumnEventArgs e)
		void f()
        {
            //runs when a new column is added to the DGV
            //e.Column.SortMode = DataGridViewColumnSortMode.Programmatic;
            //e.Column.HeaderText = "column " + e.Column.Index;
            //base.OnColumnAdded(e);
        } //end OnColumnAdded

        protected override void OnColumnHeaderMouseClick(DataGridViewCellMouseEventArgs e)
        {
            //runs when the mouse is clicked over a column header cell
            if (e.ColumnIndex > -1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    //single-click left mouse button
                    if (this.SelectionMode != DataGridViewSelectionMode.ColumnHeaderSelect)
                    {
                        this.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
                        this.Columns[e.ColumnIndex].Selected = true;
                    } //end if
                }
                else if (e.Button == MouseButtons.Right)
                {
                    //single-click right mouse button
                    if (this.SelectionMode != DataGridViewSelectionMode.ColumnHeaderSelect)
                    {
                        this.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
                    } //end if
                    if (this.SelectedColumns.Count <= 1)
                    {
                        this.ClearSelection();
                        this.Columns[e.ColumnIndex].Selected = true;
                        //show column right-click menu here
                        MessageBox.Show("show column right-click menu");
                    }
                    else //more than one column is selected
                    {
                        //show column right-click menu here
                        MessageBox.Show("show column right-click menu");
                    } //end if
                } //end if
            } //end if
            base.OnColumnHeaderMouseClick(e);
        } //end OnColumnHeaderMouseClick

        protected override void OnRowHeaderMouseClick(DataGridViewCellMouseEventArgs e)
        {
            //runs when the mouse is clicked over a row header cell
            if (e.RowIndex > -1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    //single-click left mouse button
                    if (this.SelectionMode != DataGridViewSelectionMode.RowHeaderSelect)
                    {
                        this.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                        this.Rows[e.RowIndex].Selected = true;
                        this.CurrentCell = this["Play", e.RowIndex];
                    } //end if
                }
                else if (e.Button == MouseButtons.Right)
                {
                    //single-click right mouse button
                    if (this.SelectionMode != DataGridViewSelectionMode.RowHeaderSelect)
                    {
                        this.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                    } //end if 
                    if (this.SelectedRows.Count <= 1)
                    {
                        this.ClearSelection();
                        this.Rows[e.RowIndex].Selected = true;
						this.CurrentCell = this["Play", e.RowIndex];
                        //show row right-click menu here
                        MessageBox.Show("show row right-click menu");
                    }
                    else //more than one row is selected
                    {
                        //show row right-click menu here
                        MessageBox.Show("show row right-click menu");
                    } //end if
                } //end if
            } //end if
            base.OnRowHeaderMouseClick(e);
        } //end OnRowHeaderMouseClick

        protected override void OnCellMouseClick(DataGridViewCellMouseEventArgs e)
        {
            //runs when the mouse is clicked over a cell
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    //single-click left mouse button
                    if (this.SelectionMode != DataGridViewSelectionMode.CellSelect)
                    {
                        this.SelectionMode = DataGridViewSelectionMode.CellSelect;
                    } //end if
                }
                else if (e.Button == MouseButtons.Right)
                {
                    //single-click right mouse button
                    if (this.SelectionMode != DataGridViewSelectionMode.CellSelect)
                    {
                        this.SelectionMode = DataGridViewSelectionMode.CellSelect;
                    } //end if
                    if (this.SelectedCells.Count <= 1)
                    {
                        this.ClearSelection();
                        this[e.ColumnIndex, e.RowIndex].Selected = true;
                        this.CurrentCell = this[e.ColumnIndex, e.RowIndex];
                        //show cell right-click menu here
                        MessageBox.Show("show cell right-click menu");
                    }
                    else //more than one cell is selected
                    {
                        //show cell right-click menu here
                        MessageBox.Show("show cell right-click menu");
                    } //end if
                } //end if

            } //end if
            base.OnCellMouseClick(e);
        } //end OnCellMouseClick

        protected override void OnMouseDown(MouseEventArgs e)
        {
            //stores values for drag/drop operations if necessary
            if (this.AllowDrop)
            {
                if (this.HitTest(e.X, e.Y).ColumnIndex == -1 && this.HitTest(e.X, e.Y).RowIndex > -1)
                {
                    //if this is a row header cell
                    if (this.Rows[this.HitTest(e.X, e.Y).RowIndex].Selected)
                    {
                        //if this row is selected
                        DragDropType = 1;
                        Size DragSize = SystemInformation.DragSize;
                        DragDropRectangle = new Rectangle(new Point(e.X - (DragSize.Width / 2), e.Y - (DragSize.Height / 2)), DragSize);
                        DragDropSourceIndex = this.HitTest(e.X, e.Y).RowIndex;
                    }
                    else
                    {
                        DragDropRectangle = Rectangle.Empty;
                    } //end if
                }
                else if (this.HitTest(e.X, e.Y).ColumnIndex > -1 && this.HitTest(e.X, e.Y).RowIndex == -1)
                {
                    //if this is a column header cell
                    if (this.Columns[this.HitTest(e.X, e.Y).ColumnIndex].Selected)
                    {
                        DragDropType = 0;
                        DragDropSourceIndex = this.HitTest(e.X, e.Y).ColumnIndex;
                        Size DragSize = SystemInformation.DragSize;
                        DragDropRectangle = new Rectangle(new Point(e.X - (DragSize.Width / 2), e.Y - (DragSize.Height / 2)), DragSize);
                    }
                    else
                    {
                        DragDropRectangle = Rectangle.Empty;
                    } //end if
                }
                else
                {
                    DragDropRectangle = Rectangle.Empty;
                } //end if
            }
            else
            {
                DragDropRectangle = Rectangle.Empty;
            }//end if
            base.OnMouseDown(e);
        } //end OnMouseDown

        protected override void OnMouseMove(MouseEventArgs e)
        {
            //handles drag/drop operations if necessary
            if (this.AllowDrop)
            {
                if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                {
                    if (DragDropRectangle != Rectangle.Empty && !DragDropRectangle.Contains(e.X, e.Y))
                    {
                        if (DragDropType == 0)
                        {
                            //column drag/drop
                            DragDropEffects DropEffect = this.DoDragDrop(this.Columns[DragDropSourceIndex], DragDropEffects.Move);
                        }
                        else if (DragDropType == 1)
                        {
                            //row drag/drop
                            DragDropEffects DropEffect = this.DoDragDrop(this.Rows[DragDropSourceIndex], DragDropEffects.Move);
                        } //end if
                    } //end if
                } //end if
            } //end if
            base.OnMouseMove(e);
        } //end OnMouseMove

        protected override void OnDragOver(DragEventArgs e)
        {
            //runs while the drag/drop is in progress
            if (this.AllowDrop)
            {
                e.Effect = DragDropEffects.Move;
                if (DragDropType == 0)
                {
                    //column drag/drop
                    int CurCol = this.HitTest(this.PointToClient(new Point(e.X, e.Y)).X, this.PointToClient(new Point(e.X, e.Y)).Y).ColumnIndex;
                    if (DragDropCurrentIndex != CurCol)
                    {
                        DragDropCurrentIndex = CurCol;
                        this.Invalidate(); //repaint
                    } //end if
                }
                else if (DragDropType == 1)
                {
                    //row drag/drop
                    int CurRow = this.HitTest(this.PointToClient(new Point(e.X, e.Y)).X, this.PointToClient(new Point(e.X, e.Y)).Y).RowIndex;
                    if (DragDropCurrentIndex != CurRow)
                    {
                        DragDropCurrentIndex = CurRow;
                        this.Invalidate(); //repaint
                    } //end if
                } //end if
            } //end if
            base.OnDragOver(e);
        } //end OnDragOver

        protected override void OnDragDrop(DragEventArgs drgevent)
        {

            //runs after a drag/drop operation for column/row has completed
            if (this.AllowDrop)
            {
                if (drgevent.Effect == DragDropEffects.Move)
                {
                    Point ClientPoint = this.PointToClient(new Point(drgevent.X, drgevent.Y));
                    if (DragDropType == 0)
                    {
                        //if this is a column drag/drop operation
                        DragDropTargetIndex = this.HitTest(ClientPoint.X, ClientPoint.Y).ColumnIndex;
                        if (DragDropTargetIndex > -1 && DragDropCurrentIndex < this.ColumnCount - 1)
                        {
                            DragDropCurrentIndex = -1;
                            //holds the appearance of the source column
                            DragDropColumn = this.Columns[DragDropSourceIndex];
                            //holds the values of the cells in the source column
                            DragDropColumnCellValue = new object[this.RowCount - 1];
                            for (int i = 0; i < this.RowCount; i++)
                            {
                                //for each cell in the source column
                                if (this.Rows[i].Cells[DragDropSourceIndex].Value != null)
                                {
                                    //if this cell has a value, store it in the object array
                                    DragDropColumnCellValue[i] = this.Rows[i].Cells[DragDropSourceIndex].Value;
                                } //end if
                            } //next i
                            //remove the source column
                            this.Columns.RemoveAt(DragDropSourceIndex);
                            //insert a new column at the target index using the source column as a template
                            this.Columns.Insert(DragDropTargetIndex, new DataGridViewColumn(DragDropColumn.CellTemplate));
                            //copy the source column's header cell to the new column
                            this.Columns[DragDropTargetIndex].HeaderCell = DragDropColumn.HeaderCell;
                            //select the newly-inserted column
                            this.Columns[DragDropTargetIndex].Selected = true;
                            //update the position of the cuurent cell in the DGV
                            this.CurrentCell = this[DragDropTargetIndex, 0];
                            for (int i = 0; i < this.RowCount; i++)
                            {
                                //for each cell in the new column
                                if (DragDropColumnCellValue[i] != null)
                                {
                                    //set the cell's value equal to that of the corresponding cell in the source column
                                    this.Rows[i].Cells[DragDropTargetIndex].Value = DragDropColumnCellValue[i];
                                } //end if
                            } //next i
                            //release resources
                            DragDropColumnCellValue = null;
                            DragDropColumn = null;
                        } //end if
                    }
                    else if (DragDropType == 1)
                    {
                        //if this is a row drag/drop operation
                        DragDropTargetIndex = this.HitTest(ClientPoint.X, ClientPoint.Y).RowIndex;
                        if (DragDropTargetIndex > -1 && DragDropCurrentIndex < this.RowCount )
                        {
                            DragDropCurrentIndex = -1;
                            DataGridViewRow SourceRow = drgevent.Data.GetData(typeof(DataGridViewRow)) as DataGridViewRow;
							DataRow sRow = Local.CurrentFiles.Rows[DragDropSourceIndex];
							DataRow cRow = Local.CurrentFiles.NewRow();
							int range = sRow.Table.Columns.Count;
							for( int n = 0; n < range; n++ )
								cRow[n] = sRow[n];
							reordering = true;
							Local.CurrentFiles.Rows.RemoveAt( DragDropSourceIndex );
							Local.CurrentFiles.Rows.InsertAt( cRow, DragDropTargetIndex );
							Local.CurrentFiles.AcceptChanges();
							reordering = false;
                            //this.Rows.RemoveAt(DragDropSourceIndex);
                            //this.Rows.Insert(DragDropTargetIndex, SourceRow);
                            this.Rows[DragDropTargetIndex].Selected = true;
                            this.CurrentCell = this[0, DragDropTargetIndex];
                        } //end if
                    } //end if
                } //end if
            } //end if
            base.OnDragDrop(drgevent);
        } //end OnDragDrop

        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            //draws red drag/drop target indicator lines if necessary
            if (DragDropCurrentIndex > -1)
            {
                if (DragDropType == 0)
                {
                    //column drag/drop
                    if (e.ColumnIndex == DragDropCurrentIndex && DragDropCurrentIndex < this.ColumnCount - 1)
                    {
                        //if this cell is in the same column as the mouse cursor
                        Pen p = new Pen(Color.Red, 1);
                        e.Graphics.DrawLine(p, e.CellBounds.Left - 1, e.CellBounds.Top, e.CellBounds.Left - 1, e.CellBounds.Bottom);
                    } //end if
                }
                else if (DragDropType == 1)
                {
                    //row drag/drop
                    if (e.RowIndex == DragDropCurrentIndex && DragDropCurrentIndex < this.RowCount )
                    {
                        //if this cell is in the same row as the mouse cursor
                        Pen p = new Pen(Color.Red, 1);
                        e.Graphics.DrawLine(p, e.CellBounds.Left, e.CellBounds.Top - 1, e.CellBounds.Right, e.CellBounds.Top - 1);
                    } //end if
                } //end if
            } //end if
            base.OnCellPainting(e);
        } //end OnCellPainting


		public void OnCreate( Control pc )
		{
			
		}
	}
}
