using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example
{
    public class IOEx
    {
        #region FileSystem Examples

        public void RunFileSystemExamples()
        {
            // TODO
            // File
            // Dictionary
            // Path
            // FileInfo            
        }

        #endregion

        #region Stream Examples

        public void RunStreamExamples()
        {
            // TODO
            // Stream
            // FileStream
            // TextReader
            // Encoding
        }

        #endregion

        #region Network Stream Examples

        public  void RunNetworkStreamExamples()
        {
            // TODO

            
            // -----------------------------------------
            // Sockets     
            // - Short socket example (informative only)
            int port = 9977;
            Task serverTask = Task.Run(() =>
            {
                using (Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    // -----------------------------------------
                    // Bind Socket to localgost:9977 and listen
                    serverSocket.Bind(new IPEndPoint(IPAddress.Loopback, port));
                    serverSocket.Listen(15);
                    Console.WriteLine("[Socket] Listening to localhost:{0}.", port);

                    // -----------------------------------------
                    // Acceptiong first incoming connection 
                    using (MemoryStream stream = new MemoryStream(64*1024))
                    using (Socket clientSocket = serverSocket.Accept())
                    {
                        Console.WriteLine("[Socket] Accepting incoming connection from {0}.", clientSocket.RemoteEndPoint);

                        // -----------------------------------------
                        // Retrieve the information
                        int count = 0;
                        byte[] buffer = new byte[clientSocket.SendBufferSize];
                        while ((count = clientSocket.Receive(buffer)) > 0)
                        {
                            stream.Write(buffer, 0, count);
                        }

                        // -----------------------------------------
                        // Decode string and send the length
                        string bible = Encoding.UTF8.GetString(stream.ToArray());
                        Console.WriteLine("[Socket] Retrieved {0} characters from socket.", bible.Length);
                    }
                }
            });
            Task clientTask = Task.Run(() =>
            {
                // -----------------------------------------
                // Prepare data to send 
                byte[] dataFile = Encoding.UTF8.GetBytes(StringData.GetBible());
                using (MemoryStream stream = new MemoryStream(dataFile))
                using (Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    // -----------------------------------------
                    // Connect to a server 
                    clientSocket.Connect(new IPEndPoint(IPAddress.Loopback, port));
                    Console.WriteLine("[Socket] Connected to localhost:{0}.", port);

                    // -----------------------------------------
                    // Send the information
                    int count = 0;
                    byte[] buffer = new byte[clientSocket.SendBufferSize];
                    while ((count = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        clientSocket.Send(buffer, count, SocketFlags.Partial);
                    }
                }
            });

            // -----------------------------------------
            // Wait till both tasks are finished
            Task.WaitAll(serverTask, clientTask);
        }

        #endregion
    }
}