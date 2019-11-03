using System;
using System.ServiceModel;
using System.Windows.Forms;
using WebInterfaces;

namespace MobilePOS
{
	public partial class ClientForm : Form
	{
		ChannelFactory<IKioskFrontend> factory;
		IKioskFrontend channel;

		ChannelFactory<ISaleModule> factory2;
		ISaleModule channel2;

		public ClientForm()
		{
			InitializeComponent();
			//xperdex.classes.StaticDsnConnection.KindExecuteReader( "select 1+1" );

		}

		void OpenChannel()
		{
			if( factory == null )
			{
				BasicHttpBinding binding = new BasicHttpBinding();
				EndpointAddress address = new EndpointAddress( "http://" + textBox4.Text + "/KioskService" );
				factory = new ChannelFactory<IKioskFrontend>( binding, address );
				channel = factory.CreateChannel();
			}
		}

		void OpenChannel2()
		{
			if( factory2 == null )
			{
				BasicHttpBinding binding = new BasicHttpBinding();
				EndpointAddress address = new EndpointAddress( "http://" + textBox4.Text + "/KioskSalesService" );
				factory2 = new ChannelFactory<ISaleModule>( binding, address );
				channel2 = factory2.CreateChannel();
			}
		}

		private void ClientForm_FormClosing( object sender, FormClosingEventArgs e )
		{
			if( factory != null )
				factory.Close();
		}

		private void button1_Click( object sender, EventArgs e )
		{
			OpenChannel();
			channel.SetPlayer( textBox1.Text );
		}

		private void button2_Click( object sender, EventArgs e )
		{
			OpenChannel();
			channel.AddMoney( Convert.ToInt32( textBox2.Text ) );
		}

		private void button3_Click( object sender, EventArgs e )
		{
			OpenChannel();
			channel.AddProduct( 1, Convert.ToInt32( textBoxItemID.Text ), textBox3.Text, Convert.ToInt32( textBox5.Text ) );
		}

		private void button4_Click( object sender, EventArgs e )
		{
			OpenChannel2();
			channel2.Start();
		}

		private void button5_Click( object sender, EventArgs e )
		{
			OpenChannel2();
			channel2.SetBingoday( DateTime.Now );
		}

		private void button6_Click( object sender, EventArgs e )
		{
			OpenChannel2();
			channel2.BeginTransaction( 1234 );
		}

		private void button7_Click( object sender, EventArgs e )
		{
			OpenChannel2();
			channel2.EndTransaction();
		}

		private void button8_Click( object sender, EventArgs e )
		{
			OpenChannel();
			channel.Restart();

		}

		private void button9_Click( object sender, EventArgs e )
		{
			OpenChannel2();
			channel2.ClearItem( Convert.ToInt32( textBoxItemID.Text ) );
		}

		private void buttonBarcodeEvent_Click( object sender, EventArgs e )
		{
			OpenChannel2();
            MessageBox.Show( "Posting barcode event this direction has been depricated." );
			//channel2.HandleBarcode( textBoxBarcodeString.Text );
		}

        private void buttonRegisterDept_Click( object sender, EventArgs e )
        {
            OpenChannel();
            object result = channel.RegisterDepartment( textBoxDeptName.Text );
            if( result == null )
                MessageBox.Show( "Failure to register department" );
            else
                MessageBox.Show( "Result was " + result.ToString() + "." );
        }

	}
}
