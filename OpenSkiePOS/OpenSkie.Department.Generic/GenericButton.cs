using OpenSkiePOS;

namespace OpenSkie.Department.Generic
{

	[POS_ItemButton.POSButtonAttribute(Name="Generic Department")]
	public class GenericButton : POSButtonInterface
	{

		public override string ToString()
		{
			return "Generic Item";
		}
		//String sub_dept;
		//String item_name;


		bool POSButtonInterface.Configure()
		{
			bool result = false;
			GenericConfigureButton gcb = new GenericConfigureButton( this );
			gcb.ShowDialog();

			if( gcb.DialogResult == System.Windows.Forms.DialogResult.OK )
				result = true;
			gcb.Dispose();
			return result;
		}

		void POSButtonInterface.Save( System.Xml.XmlWriter w )
		{
		}

		void POSButtonInterface.Load( System.Xml.XPath.XPathNavigator r )
		{
		}

		bool POSButtonInterface.Click( int qty )
		{
			return true;
		}
	}
}
