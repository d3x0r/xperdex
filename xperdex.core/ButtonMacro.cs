using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using xperdex.core.interfaces;

namespace xperdex.core
{
	[ButtonAttribute( Name="Core.Macro" ) ]
	public partial class ButtonMacro: IReflectorCreate, IReflectorButton, IReflectorPersistance
	{
		internal List<xperdex.core.osalot.AssemblyObject> buttons;
		Control button;
		String _Text;
		internal String Text
		{
			get
			{
				if( button != null )
					return button.Text;
				return _Text;
			}
			set
			{
				if( button != null )
					button.Text = value;
				else
					_Text = value;
			}
		}
		public override string ToString()
		{
			if( Text != null )
				return Text;
			return "Macro Element";
			//return base.ToString();
		}

		public ButtonMacro()
		{
			buttons = new List<osalot.AssemblyObject>();
		}

		void IReflectorCreate.OnCreate( Control button )
		{
			this.button = button;
			button.Text = "Macro";
		}

		void IReflectorPersistance.Save( XmlWriter w )
		{
			w.WriteStartElement( "Macro" );
			//w.WriteAttributeString( "Text", (Text!=null)?Text:"" );
			foreach( osalot.AssemblyObject button in buttons )
			{
				w.WriteStartElement( "Element" );
				w.WriteAttributeString( "Assembly", core_common.GetRelativePath( button.t.Assembly.Location ) );
				w.WriteAttributeString( "Type", button.t.FullName );
				IReflectorPersistance persis = button.o as IReflectorPersistance;
				if( persis != null )
				{
					persis.Save( w );
				}
				w.WriteEndElement();
				w.WriteRaw( "\r\n" );
			}
			w.WriteEndElement();
			w.WriteRaw( "\r\n" );
		}

		bool IReflectorPersistance.Load( XPathNavigator r )
		{
			if( String.Compare( r.Name, "Macro" ) == 0 )
			{
				Object o;
				Assembly a = null;
				bool everokay = false;
				{
					// total violation of logic so far... but this is text...
					if( r.MoveToFirstAttribute() )
					{
						if( String.Compare( r.Name, "Text" ) == 0 )
						{
							// ignore this, don't save it, would be redundant with button text...
						//	Text = r.Value;
						}
						r.MoveToParent();
					}
				}
				for( bool okay2 = r.MoveToFirstChild(); okay2; okay2 = r.MoveToNext() )
				{
					everokay = true;
					switch( r.Name )
					{
					case "Element":
						for( bool okay = r.MoveToFirstAttribute(); okay; okay = r.MoveToNextAttribute() )
						{
							switch( r.Name )
							{
							case "Assembly":
								a = osalot.LoadAssembly( r.Value );
								break;
							case "Type":
								Type t = osalot.findtype( a, r.Value );

								o = Activator.CreateInstance( t );

								IReflectorPersistance persis = o as IReflectorPersistance;
								r.MoveToParent(); // out of attributes...
								if( persis != null )
								{
									r.MoveToFirstChild();
									if( persis.Load( r ) )
									{
										// return from my move to child...
										r.MoveToParent();
									}
									// return from my move to attribute
								}
								osalot.AssemblyObject ao = new osalot.AssemblyObject( t, o );
								buttons.Add( ao );
								//r.MoveToParent();
								break;
							}
						}
						break;
					}
				}
				// return from my move to child....
				if( everokay )
					r.MoveToParent();
				return true;
			}
			return false;
		}
		void IReflectorPersistance.Properties()
		{
			Macro_Properties macro_prop = new Macro_Properties( this );
			macro_prop.ShowDialog();
			if( macro_prop.DialogResult == DialogResult.OK )
			{
				Text = macro_prop.textboxMacro.Text;
			}
		}

		#region ReflectorButton Members

		bool IReflectorButton.OnClick()
		{
			foreach( osalot.AssemblyObject o in buttons )
			{
				IReflectorButton i = o.o as IReflectorButton;
				if( !i.OnClick() )
				{
					// execute macro backwards?!
					return false;
					// abort?
				}
			}
			return true;
			//throw new Exception( "The method or operation is not implemented." );
		}

		#endregion


	}
}

