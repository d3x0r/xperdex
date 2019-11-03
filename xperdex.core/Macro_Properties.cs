using System;
using System.Windows.Forms;
using xperdex.core.interfaces;

namespace xperdex.core
{
    public partial class Macro_Properties : Form
    {
		ButtonMacro editing_macro;
        public Macro_Properties( ButtonMacro macro )
        {
			editing_macro = macro;
            InitializeComponent();
			Load += new EventHandler( Macro_Properties_Load );
        }

		void Macro_Properties_Load( object sender, EventArgs e )
		{
			AvailableActions.DataSource = core_common.buttons;
			Actions.DataSource = editing_macro.buttons;
			textboxMacro.Text = editing_macro.Text;

		}
		
		private void BaseProperties_Click( object sender, EventArgs e )
		{
			PSI_ButtonProperties bp = new PSI_ButtonProperties( core_common.current_mouse_control.c as PSI_Button, core_common.current_mouse_page.canvas );
			bp.ShowDialog();
			if( bp.DialogResult == DialogResult.OK )
			{
			}
			bp.Dispose();
		}

		private void buttonAddAction_Click( object sender, EventArgs e )
		{
			Type t = AvailableActions.SelectedItem as Type;
			if( t != null )
			{
				object o = Activator.CreateInstance( t );
				IReflectorButton button = o as IReflectorButton;
				xperdex.core.osalot.AssemblyObject ao = new osalot.AssemblyObject( t, o );
				editing_macro.buttons.Add( ao );
				Actions.DataSource = null;
				Actions.DataSource = editing_macro.buttons;
			}
		}

		private void buttonEdit_Click( object sender, EventArgs e )
		{
			osalot.AssemblyObject o = Actions.SelectedItem as osalot.AssemblyObject;
			if( o == null )
			{
				MessageBox.Show( "Bad element selection" );
				return;
			}
			IReflectorPersistance persis = o.o as IReflectorPersistance;
			if( persis != null )
			{
				persis.Properties();
			}
			// content of the data source (the action item text for instance) may have changed...
			Actions.DataSource = null;
			Actions.DataSource = editing_macro.buttons;
		}

		private void buttonRemove_Click( object sender, EventArgs e )
		{
			osalot.AssemblyObject o = Actions.SelectedItem as osalot.AssemblyObject;
			editing_macro.buttons.Remove( o );
			Actions.DataSource = null;
			Actions.DataSource = editing_macro.buttons;
		}

		private void buttonClone_Click( object sender, EventArgs e )
		{
			IReflectorButton button = core_common.clone_control.o as IReflectorButton;
			if( button != null )
			{
				object o = Activator.CreateInstance( core_common.clone_control.Type );

				//IReflectorButton newbutton = o as IReflectorButton;
				xperdex.core.osalot.AssemblyObject ao = new osalot.AssemblyObject( core_common.clone_control.Type, o );
				editing_macro.buttons.Add( ao );
				Actions.DataSource = null;
				Actions.DataSource = editing_macro.buttons;
			}
		}

		private void buttonDn_Click( object sender, EventArgs e )
		{
			for( int i = 0; i < Actions.Items.Count - 1; i++ )
				if( Actions.GetSelected( i ) )
				{
					osalot.AssemblyObject o = editing_macro.buttons[i];
					editing_macro.buttons.RemoveAt( i );
					editing_macro.buttons.Insert( i + 1, o );
					Actions.DataSource = null;
					Actions.DataSource = editing_macro.buttons;
					Actions.SetSelected( i + 1, true );
					break;
				}
		}

		private void buttonUp_Click( object sender, EventArgs e )
		{
			for( int i = 1; i < Actions.Items.Count; i++ )
				if( Actions.GetSelected( i ) )
				{
					osalot.AssemblyObject o = editing_macro.buttons[i];
					editing_macro.buttons.RemoveAt( i );
					editing_macro.buttons.Insert( i - 1, o );
					Actions.DataSource = null;
					Actions.DataSource = editing_macro.buttons;
					Actions.SetSelected( i-1, true );
					break;
				}

		}
	}
}