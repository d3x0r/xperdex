using System.Drawing;
using System.Windows.Forms;
using xperdex.core.interfaces;

namespace xperdex.core
{
    static class ButtonQuit
    {
		[ButtonAttribute( Name="Core.Quit" )]
		class Quit : IReflectorButton, IReflectorCreate
		{

			#region IReflectorButton Members

			bool IReflectorButton.OnClick()
			{
				Application.Exit();
				return true;
			}

			#endregion

			public void OnCreate( Control pc )
			{
				pc.Text = "Quit";
				PSI_Button button = pc as PSI_Button;
				if( button != null )
				{
					core_common.GetGlareSetAttributes( "Quit Button", DefaultAttributes );
					button.gs = new GlareSet( "Default", "Quit Button" );							
				}
			}

			void DefaultAttributes( GlareSetAttributes attrib )
			{
				attrib.SetColor( Color.Red );
				attrib.SetColor2( Color.Black );
				attrib.TextColor = Color.White;
			}
		}
    }

	static class ButtonEditOptions
	{
		[ButtonAttribute( Name = "Edit Options" )]
		class EditOptions : IReflectorButton, IReflectorCreate
		{

			#region IReflectorButton Members

			bool IReflectorButton.OnClick()
			{
				xperdex.classes.OptionEditor oe = new xperdex.classes.OptionEditor();
				oe.ShowDialog();
				return true;
			}

			#endregion

			public void OnCreate( Control pc )
			{
				pc.Text = "Edit_Options";
				PSI_Button button = pc as PSI_Button;
				if( button != null )
				{
					core_common.GetGlareSetAttributes( "Utility Button", DefaultAttributes );
					button.gs = new GlareSet( "Default", "Utility Button" );
				}
			}

			void DefaultAttributes( GlareSetAttributes attrib )
			{
				attrib.SetColor( Color.Red );
				attrib.SetColor2( Color.Black );
				attrib.TextColor = Color.White;
			}
		}
	}

}