using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace xperdex.classes.networking
{
    public class network_client
    {
        public class StateObject
        {
            // Client socket.
            public network_socket workSocket = null;
            // Size of receive buffer.
            public const int BufferSize = 256;
            // Receive buffer.
            public byte[] buffer = new byte[BufferSize];
            // Received data string.
            public StringBuilder sb = new StringBuilder();
        }

        public class network_socket : Socket
        {
            // one pending read buffer ever...
            //byte[] buffer = new byte[4096];
            AsyncCallback cc;
            AsyncCallback rc;

           
            /// <summary>
            /// 
            /// </summary>
            /// <param name="result"></param>
            void read_complete(IAsyncResult result)
            //stateObject st;
            {

                try
                {
                    StateObject state = (StateObject)result.AsyncState;
                    int bytesRead = this.EndReceive(result);


                    if (result.IsCompleted)
                    {
                        //string hostName = (string)result.AsyncState;
                        //hostNames.Add(hostName);
                        //(byte)result.AsyncState;
                        //state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                        System.Diagnostics.Debug.WriteLine(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                    }

                    BeginReceive(state.buffer
                        , 0
                        , StateObject.BufferSize
                        , SocketFlags.None
                        , rc
                        , state
                        );
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.ToString());
                }

            }

            private void FirstReceive()
            {
                try
                {
                    // Create the state object.
                    StateObject state = new StateObject();
                    //state.workSocket = this;

                    // Begin receiving the data from the remote device.
                    BeginReceive(state.buffer, 0, StateObject.BufferSize, 0
                        , rc, state);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.ToString());
                }
            }


            //AsyncCallback cc = new AsyncCallback(ConnectCallback);
            void ConnectCallback(IAsyncResult result)
            {
                try
                {
                    network_socket me = (network_socket)result.AsyncState;
                    me.EndConnect(result);
                    System.Diagnostics.Debug.WriteLine("blah");
                    FirstReceive();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.ToString());
                }

            }
            public
            network_socket( string Address, int port )
                : base(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            {

				IPHostEntry host = Dns.GetHostEntry( Address );
                IPAddress address = host.AddressList[0];
                IPEndPoint ipep = new IPEndPoint(address, port);
                cc = new AsyncCallback(ConnectCallback);
                rc = new AsyncCallback(read_complete);

                //this.Connect(ipep);
                BeginConnect(ipep, cc, this);


            }

        }

        //XmlReader xr;
        //xr = new XmlReader();

        network_socket ns;
        public
        network_client( string address, int port )
        {
            ns = new network_socket(address, port);
        }
        public Socket GetSocket()
        {
            return (Socket)ns;
        }
		 public void Send( string s )
		 {
			 ns.Send(Encoding.ASCII.GetBytes(s));
		 }
		 public void Send( byte[] buffer )
		 {
			 ns.Send(buffer);
		 }
    }
}
