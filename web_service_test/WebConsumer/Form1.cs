using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using WebInterface;
using System.ServiceModel.Channels;

namespace WebConsumer
{
	public partial class Form1 : Form
	{
		WebInterface.ClientIHelloService client;

		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click( object sender, EventArgs e )
		{
			BasicHttpBinding binding = new BasicHttpBinding();
			EndpointAddress address = new EndpointAddress( "http://10.17.20.2:8080/HelloWorldService" );

			ChannelFactory<IHelloWorldService> factory =
				new ChannelFactory<IHelloWorldService>( binding, address );

			IHelloWorldService channel = factory.CreateChannel();

			label1.Text = channel.SayHello( textBox1.Text );

			factory.Close();


		}


	}
}
