using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using xperdex.core.interfaces;

namespace xperdex.core.common
{
	[ControlAttribute( Name="Keypad" )]

	public partial class PSI_Keypad : TableLayoutPanel, IReflectorPersistance
	{

		private GlareSet gs;

		//These might be a mistake...
		private string ClearText;
		private string EnterText;
		private int local_rows;
		private int local_columns;
		private PSI_Button[,] button_grid;
		Control accumulator;
		//private buttons_class buttons;
		//System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;


		/// <summary>
		/// Quick little summary of what I'm about to do, why I'm going to do it, 
		/// and we'll see if it makes sense.
		/// 
		/// What this will be:  A little 12to15-key keypad, with a clear and an enter
		/// hopefully tied-to some common control
		/// 
		/// How to get this done.  The first thing that jumps-out at a person is,
		/// "hey, we could use buttons, and that would be AWESOME."  
		/// 
		/// The next thing, do a table layout of sorts.  Each button takes
		/// up the full thing.  Shouldn't be too bad.
		///
		/// 
		/// </summary>
		
		public PSI_Keypad()
		{
			bool enable_accumulator_display = true;

			// 4 is enough for normal keypad
			local_rows = enable_accumulator_display?5:4;
			local_columns = 3; //someday in the near future, we may change this.
			
			gs = new GlareSet( "default" );
			gs.attrib.Primary = Color.Blue;// Color.FromArgb( 64, Color.Blue );
			gs.attrib.Secondary = Color.SkyBlue;
			gs.attrib.TextColor = Color.White;

			InitializeComponent();

			if( enable_accumulator_display )
			{
				accumulator = new TextBox();
				Controls.Add( accumulator, 0, 0 );
				SetColumnSpan( accumulator, 3 );
				accumulator.Dock = DockStyle.Fill;
			}

			ColumnCount = local_columns;
			for( int i = 0; i < local_columns; i++ )
			{
				ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 100F / (float)local_columns ) );
			}
			Location = new System.Drawing.Point( 0, 0 );
			Name = "tableLayoutPanel1";
			RowCount = local_rows;
			if( enable_accumulator_display )
				RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 100F / (float)(local_rows*2) ) );
			for( int i = enable_accumulator_display ? 1 : 0; i < local_rows; i++ )
			{
				RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 100F / (float)local_rows ) );
			}
			Size = this.Size; //new System.Drawing.Size(529, 419); 
			TabIndex = 0;

			//And now, for the buttons
			button_grid = new PSI_Button[local_columns, local_rows];

			for( int i = 0; i < local_columns; i++ )
				for( int j = enable_accumulator_display ? 1 : 0; j < local_rows; j++ )
				{
					button_grid[i, j] = new PSI_Button(this.Parent as Canvas);
					Controls.Add( button_grid[i, j], i, j );
					this.button_grid[i, j].Dock = System.Windows.Forms.DockStyle.Fill;
					this.button_grid[i, j].Name = "button" + i.ToString() + j.ToString();
					this.button_grid[i, j].TabIndex = 0;
					this.button_grid[i, j].Text = i.ToString() + "," + j.ToString();
					//this.button_grid[i, j].UseVisualStyleBackColor = true;
				}
		}

		void IReflectorPersistance.Save( XmlWriter w )
		{
			gs.Save( w );
			w.WriteStartElement( "PSI_Keypad" );
			w.WriteAttributeString( "text", Text );  //everything else gets a text, why not this?
			w.WriteAttributeString( "clear_text", ClearText );
			w.WriteAttributeString( "enter_text", EnterText );
			w.WriteAttributeString( "keypad_columns", local_columns.ToString() );
			w.WriteAttributeString( "keypad_rows", local_rows.ToString() );
			w.WriteEndElement();
		}

		bool IReflectorPersistance.Load( XPathNavigator r )
		{
			if( gs.Load( r ) )
			{
				// previous will result in the same position as it started (almost)
				r.MoveToNext();
				if( r.NodeType == XPathNodeType.Element )
				{
					if( String.Compare( r.Name, "PSI_Keypad", true ) == 0 )
					{
						bool okay;
						for( okay = r.MoveToFirstAttribute(); okay; okay = r.MoveToNextAttribute() )
						{
							if( String.Compare( r.Name, "text", true ) == 0 )
								Text = r.Value;
							if( String.Compare( r.Name, "clear_text", true ) == 0 )
								ClearText = r.Value;
							if( String.Compare( r.Name, "enter_text", true ) == 0 )
								EnterText = r.Value;
						}
						r.MoveToParent();
						return true;
					}
				}
				return true;
			}
			return false;
		}

		void IReflectorPersistance.Properties()
		{
			Keypad_Configurator config = new Keypad_Configurator( this );
			config.ShowDialog();
			config.Dispose();
		}
	}
}
