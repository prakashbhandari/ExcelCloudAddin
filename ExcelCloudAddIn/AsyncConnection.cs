using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;

namespace ExcelCloudAddIn
{
    class AsyncConnection
    {
        public static ManualResetEvent connectDone = new ManualResetEvent(false);
        public static ManualResetEvent sendDone = new ManualResetEvent(false);
        public static ManualResetEvent receiveDone = new ManualResetEvent(false);
        public static String response = String.Empty;
        private static Socket client;

        public static void StartClient(String host, int port)
        {
            try
            {
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ipAddress;

                // If input host is valid ip, use ip as host address
                // however, if host is domain extract the ip
                if (IPAddress.TryParse(host, out ipAddress))
                {
                    ipAddress = Dns.GetHostAddresses(host)[0];
                }
                else
                {
                    IPHostEntry ipHostInfo = Dns.GetHostEntry(host);
                    ipAddress = ipHostInfo.AddressList[0];
                }
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                // Connect to the server
                client.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), client);
            }
            catch (Exception e)
            {
                FrmSettings.SetStatus(5);
                Debug.WriteLine(e.ToString());
            }
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket client = (Socket)ar.AsyncState;

                // Complete the connection
                client.EndConnect(ar);
                Debug.WriteLine("Socket connected to: " + client.RemoteEndPoint.ToString());
                connectDone.Set();
            }
            catch (Exception e)
            {
                FrmSettings.SetStatus(5);
                Debug.WriteLine(e.ToString());
            }
        }

        public static void Send(String data)
        {
            // Convert string data to byte data using ASCII encoding
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending data to remote server
            client.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallBack), client);
            Debug.WriteLine("Sending: " + data);
        }

        private static void SendCallBack(IAsyncResult ar)
        {
            try
            {
                // Retrieve socket from the Socket object
                Socket client = (Socket)ar.AsyncState;

                // Complete sending the data to remote device
                int bytesSent = client.EndSend(ar);
                Debug.WriteLine("Sent " + bytesSent.ToString() + " bytes to server");

                // Signal that all bytes have been sent
                sendDone.Set();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }

        public static void Receive()
        {
            try
            {
                // Create the state object
                StateObject state = new StateObject();
                state.workSocket = client;

                // Begin receiving the response from the server
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallBack), state);
                receiveDone.WaitOne();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }

        private static void ReceiveCallBack(IAsyncResult ar)
        {
            try
            {
                // Retrieve state object for the connection
                StateObject state = (StateObject)ar.AsyncState;
                Socket handler = state.workSocket;

                // Read data from the server
                int bytesRead = handler.EndReceive(ar);

                if (bytesRead > 0)
                {
                    response = Encoding.ASCII.GetString(state.buffer, 0, bytesRead);
                    Debug.WriteLine("Received: " + response);

                    // Signal that bytes have been received
                    receiveDone.Set();
                }
            }
            catch (ObjectDisposedException ode)
            {
                Debug.WriteLine(ode.ToString());
            }
        }

        public static void CloseConnection()
        {
            client.Shutdown(SocketShutdown.Both);
            client.Close();
        }
    }

    //State object for send/receive data from the remote server
    public class StateObject
    {
        public Socket workSocket = null;
        public const int BufferSize = 256;
        public byte[] buffer = new byte[BufferSize];
    }
}
