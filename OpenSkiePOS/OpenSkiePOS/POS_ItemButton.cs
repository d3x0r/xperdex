using System;
using xperdex.classes;
using xperdex.core.interfaces;

namespace OpenSkiePOS
{
	[ButtonAttribute( Name="POS Item Button" )]
	public class POS_ItemButton : ButtonWithLabelAreas, IReflectorButton, IReflectorPersistance
    {
		public Money cost;
		public Int16 quantity;

		internal DepartmentInterface department;
		internal POSButtonInterface button;

		public override string ToString()
		{
			if( button != null )
				return button.ToString();
			return "Uninitialized POS Button";
		}

		public POS_ItemButton(): base( "POS Sale Button" ) 
		{
			layout["Quantity"] = quantity.ToString();
			layout["Item Name 1"] = "Some";
			layout["Item Name 2"] = "Name";
			cost = new Money( 100 );
			layout["Price"] = cost.ToString();
			Click += new ClickProc(POS_Item_Click);
		}

		void POS_Item_Click( object sender, xperdex.core.PSI_Button.ReflectorButtonEventArgs args )
		{
			if( button != null )
				if( button.Click( 1 ) )
				{
					quantity++;
					layout["Quantity"] = quantity.ToString();
				}
		}

		public class POSButtonAttribute : Attribute
		{
			string DisplayName = "Button";
			public string Name
			{
				get { return DisplayName; }
				set { DisplayName = value; }
			}
		}

		bool IReflectorPersistance.Load( System.Xml.XPath.XPathNavigator r )
		{
			if( r.Name == "Department" )

			{
				foreach( DepartmentInterface dept in POS.Local.Departments )
				{
					if( dept.ToString() == r.Value )
					{
						department = dept;
						break;
					}
				}
				if( r.MoveToFirstChild() )
				{
					button = department.GetItemForButton( this );
					button.Load( r );
					r.MoveToParent();
				}
				return true;
			}
			return false;

		}

		void IReflectorPersistance.Save( System.Xml.XmlWriter w )
		{
			if( department != null )
			{
				w.WriteStartElement( "Department" );
				w.WriteString( department.ToString() );
				button.Save( w );
				w.WriteEndElement();
				w.WriteRaw( "\r\n" );
			}
		}

		void IReflectorPersistance.Properties()
		{
			ConfigureItemButton cib = new ConfigureItemButton( this, department, button );
			cib.ShowDialog();
			cib.Dispose();
		}


	}


}
