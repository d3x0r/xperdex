using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using xperdex.classes;
using System.Collections.Generic;
using xperdex.core.interfaces;

namespace xperdex.gui
{
	public class XDataGridView : DataGridView, IReflectorScale
	{
		protected Fraction scale_x = new Fraction( 1, 1 );
		protected Fraction scale_y = new Fraction( 1, 1 );

		class ColumnWidthTracker
		{
			internal int original_width;
			internal DataGridViewColumn column;
			internal ColumnWidthTracker( DataGridViewColumn column )
			{
				this.column = column;
				this.original_width = column.Width;
			}
		}


		List<ColumnWidthTracker> original_column_widths;

		ColumnWidthTracker get_column( DataGridViewColumn column )
		{
			foreach( ColumnWidthTracker tracker in original_column_widths )
				if( tracker.column.Equals( column ) )
					return tracker;
			return null;
		}

		public XDataGridView()
		{
			original_column_widths = new List<ColumnWidthTracker>();

			this.FontChanged += new EventHandler( XDataGridView_FontChanged );
			this.CellPainting += new DataGridViewCellPaintingEventHandler( XDataGridView_CellPainting );
			this.RowsAdded += new DataGridViewRowsAddedEventHandler( XDataGridView_RowsAdded );
			this.SizeChanged += new EventHandler( XDataGridView_SizeChanged );
			this.ColumnAdded += new DataGridViewColumnEventHandler( XDataGridView_ColumnAdded );
			this.ColumnRemoved += new DataGridViewColumnEventHandler( XDataGridView_ColumnRemoved );
			this.ColumnWidthChanged += new DataGridViewColumnEventHandler( XDataGridView_ColumnWidthChanged );
		}

		void XDataGridView_ColumnRemoved( object sender, DataGridViewColumnEventArgs e )
		{
			ColumnWidthTracker tracker = get_column( e.Column );
			if( tracker != null )
			{
				original_column_widths.Remove( tracker );
			}
			
		}

		bool updating_size;

		void XDataGridView_ColumnWidthChanged( object sender, DataGridViewColumnEventArgs e )
		{
			if( !updating_size )
			{
				ColumnWidthTracker tracker = get_column( e.Column );
				if( tracker != null )
					tracker.original_width = e.Column.Width / scale_x;
			}
		}

		void XDataGridView_ColumnAdded( object sender, DataGridViewColumnEventArgs e )
		{			
			original_column_widths.Add( new ColumnWidthTracker( e.Column ) );	
		}

		void UpdateColumnWidths()
		{
			foreach( ColumnWidthTracker tracker in original_column_widths )
			{
				updating_size = true;
				tracker.column.Width = tracker.original_width * scale_x;
				updating_size = false;
			}
		}

		void XDataGridView_SizeChanged( object sender, EventArgs e )
		{
			UpdateColumnWidths();			
		}

		void XDataGridView_RowsAdded( object sender, DataGridViewRowsAddedEventArgs e )
		{
			SizeF szf = this.CreateGraphics().MeasureString( "X", Font );
			FontHeight = (int)( scale_y * szf.Height );
			for( int n = 0; n < e.RowCount; n++ )
			{
				Rows[e.RowIndex + n].Height = FontHeight;
			}
		}

		protected override void OnDragDrop( DragEventArgs drgevent )
		{
			base.OnDragDrop( drgevent );
		}
		protected override void OnDragOver( DragEventArgs drgevent )
		{
			base.OnDragOver( drgevent );
		}
		protected override void OnDragLeave( EventArgs e )
		{
			base.OnDragLeave( e );
		}

		void XDataGridView_FontChanged( object sender, EventArgs e )
		{
			SizeF szf = this.CreateGraphics().MeasureString( "X", Font );
			FontHeight = (int)( scale_y * szf.Height );
			foreach( DataGridViewRow dgvr in Rows )
				dgvr.Height = FontHeight;
			//ItemHeight = (int)( scale_y * szf.Height );
		}

		void IReflectorScale.SetScale( Fraction scale_x, Fraction scale_y )
		{
			this.scale_x = scale_x;
			this.scale_y = scale_y;
			SizeF szf = this.CreateGraphics().MeasureString( "X", Font );
			FontHeight = (int)( scale_y * szf.Height );
			foreach( DataGridViewRow dgvr in Rows )
				dgvr.Height = FontHeight;
			if( FontHeight > 4 ) // has to be 4 or more (hard coded exception?)
				ColumnHeadersHeight = FontHeight;
		}


		void XDataGridView_CellPainting( object sender, DataGridViewCellPaintingEventArgs e )
		{
			
			object display_member = e.FormattedValue;
			if( display_member == null )
				return;
			String output = display_member.ToString();
			//String output = this.Items[e.Index].ToString();
			SizeF szf = e.Graphics.MeasureString( output, Font );

			if( e.State.HasFlag( DataGridViewElementStates.Selected ) )
				e.Graphics.FillRectangle( SystemBrushes.Highlight, e.CellBounds );
			else
				e.Graphics.FillRectangle( SystemBrushes.Control, e.CellBounds );

			// bounds should be the result of the measure, and the measure should be resulting in real size.
			GraphicsContainer gc = e.Graphics.BeginContainer();

			e.Graphics.TranslateTransform( e.CellBounds.X - ( scale_x * e.CellBounds.X )
				, e.CellBounds.Y - ( scale_y * e.CellBounds.Y ) );
			e.Graphics.ScaleTransform( scale_x.ToFloat(), scale_y.ToFloat() );

			//Rectangle actual = Fraction.Scale( e.Bounds, scale_x, scale_y );

			try
			{
				if( e.State.HasFlag( DataGridViewElementStates.Selected ) )
				{
					e.Graphics.DrawString( output
						, Font
						, SystemBrushes.HighlightText
						, e.CellBounds.X
						, e.CellBounds.Y );
				}
				else
				{
					e.Graphics.DrawString( output
						, Font
						, new SolidBrush( this.ForeColor )
						, e.CellBounds.X
						, e.CellBounds.Y );

				}
			}
			catch
			{
			}
			e.Graphics.EndContainer( gc );
			e.Handled = true;
		}

	}
}
