using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel; 
using System.ServiceModel.Description;
using WebInterface;

namespace WebService
{
	public partial class Form1 : Form
	{
		ServiceHost host;
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click( object sender, EventArgs e )
		{
			 string baseaddr = "http://0.0.0.0:8080/HelloWorldService"; 
			Uri baseAddress = new Uri(baseaddr); 
 
			host = new ServiceHost( typeof(HelloWorldService), baseAddress);

			// Enable metadata publishing. 
			ServiceMetadataBehavior smb;
			smb = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
			if( smb == null )
				smb = new ServiceMetadataBehavior();
			smb.HttpGetEnabled = true;
			smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
			host.Description.Behaviors.Add( smb );


			host.AddServiceEndpoint( typeof( IHelloWorldService ), new BasicHttpBinding(), "" );
			//host.AddServiceEndpoint( typeof( IHelloWorldService ), new BasicHttpBinding(), baseaddr + "/SayHello" );

			//host.AddServiceEndpoint( typeof( IHelloWorldService ), new WSHttpBinding(), "myendpoint" );
			//host.AddServiceEndpoint(  ServiceMetadataBehavior.MexContractName,  MetadataExchangeBindings.CreateMexHttpBinding(),  "mex" );

			//host.AddDefaultEndpoints();


			//for some reason a default endpoint does not get created here 
			host.Open();

			foreach( ServiceEndpoint se in host.Description.Endpoints )
				listBox1.Items.Add( String.Format( "A: {0}, B: {1}, C: {2}",
					se.Address, se.Binding.Name, se.Contract.Name ) );

			label1.Text = "The service is ready at " + baseAddress;
			//Console.WriteLine( "Press &lt;Enter&gt; to stop the service." );
			//Console.ReadLine(); 
 

		}
	}
}
