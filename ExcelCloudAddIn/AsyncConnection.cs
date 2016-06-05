//Title        :  AsyncConnection.cs
//Package      :  ExcelCloudAddIn
//Project      :  ExcelCloud
//Description  :  Provides connection to server, to send and receive data.
//Created on   :  June 5, 2016
//Author	   :  Prakash Bhandari

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;

namespace ExcelCloudAddIn
{
    /// <summary>
    /// Class AsyncConnection: Provides an asynchronous Socket
    /// connection to server for sending and receiving data
    /// </summary>
    class AsyncConnection
    {
        /// <summary>
        /// reset event to signal once connection is done
        /// </summary>
        public static ManualResetEvent connectDone = new ManualResetEvent(false);
        /// <summary>
        /// reset event to signal once sending is done
        /// </summary>
        public static ManualResetEvent sendDone = new ManualResetEvent(false);
        /// <summary>
        /// reset event to signal once receiving is done
        /// </summary>
        public static ManualResetEvent receiveDone = new ManualResetEvent(false);
        /// <summary>
        /// response received from server
        /// </summary>
        public static string response = String.Empty;
        /// <summary>
        /// hold the instance of client socket
        /// </summary>
        private static Socket client;
        /// <summary>
        /// Sets connection status to true if connected to server
        /// </summary>
        public static bool connectionStatus = false;

        /// <summary>
        /// Connect to server using the host and port
        /// </summary>
        /// <param name="host">Domain name or IP address of server</param>
        /// <param name="port">Port number server is listening to</param>
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
                Debug.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// Asynchronously try to connect to the server,
        /// if connection can't be made simply trigger 
        /// status update to connection can't be made
        /// </summary>
        /// <param name="ar">Async Result</param>
        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket client = (Socket)ar.AsyncState;

                // Complete the connection
                client.EndConnect(ar);
                Debug.WriteLine("Socket connected to: " + client.RemoteEndPoint.ToString());
                connectionStatus = true;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Server not available: "+e.ToString());
            }
            connectDone.Set();
        }

        /// <summary>
        /// Receives a string data and tries sending the bytes through socket
        /// </summary>
        /// <param name="data">string data to be sent</param>
        public static void Send(string data)
        {
            // Convert string data to byte data using ASCII encoding
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending data to remote server
            client.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallBack), client);
            Debug.WriteLine("Sending: " + data);
        }

        // Asynchronous try sending the data, raise error
        // if cannot send data
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

        /// <summary>
        /// Try receiving data through the socket
        /// </summary>
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

        /// <summary>
        /// Asynchronously receive any data from the socket. 
        /// Once all data is received assign it to response. 
        /// </summary>
        /// <param name="ar"></param>
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

        /// <summary>
        /// Close connetion to server once all data has been
        /// received and a connection close EOF message received
        /// </summary>
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
