namespace OpenSkiePOS
{
	public interface POSButtonInterface
	{

		bool Configure();

		void Save( System.Xml.XmlWriter w );

		void Load( System.Xml.XPath.XPathNavigator r );

		bool Click( int qty );
	}
}
