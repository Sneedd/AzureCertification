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

        /// <summary>
        /// Example for using the file system methods, here an example of the lesser used classes.
        /// </summary>
        public void RunFileSystemExamples()
        {
            // --------------------------------------------------------------------------------------------
            // - File class https://docs.microsoft.com/en-us/dotnet/api/system.io.file
            //   The File class is a collection of useful file operation functions. The OpenXzy() Methods are 
            //   altogether easier to use than using the Constructors of the respective classes.
            //
            // - Dictionary class https://docs.microsoft.com/en-us/dotnet/api/system.io.directory
            //   The Directory class is a   
            // 
            // - Path class https://docs.microsoft.com/en-us/dotnet/api/system.io.path
            //
            // - FileInfo class https://docs.microsoft.com/en-us/dotnet/api/system.io.fileinfo
            //    
            // - DriveInfo class https://docs.microsoft.com/en-us/dotnet/api/system.io.driveinfo
            //

            // --------------------------------------------------------------------------------------------
            // The following example combines some of the classes from before to create a simple 
            // filesystem overview.
            Console.WriteLine("[FileSystem] Example output:");

            // -----------------------------------------
            // Get all drives 
            DriveInfo[] drives = DriveInfo.GetDrives();
            for (int driveIndex = 0; driveIndex < drives.Length; ++driveIndex)
            {
                // -----------------------------------------
                // Check if a drive is ready and output some information
                DriveInfo drive = drives[driveIndex];
                if (!drive.IsReady)
                {
                    continue;
                }
                Console.WriteLine("\t{0,-4} {1,-16}         Free {2:n0} MB ({3:n0})", drive.RootDirectory, drive.VolumeLabel, drive.AvailableFreeSpace / 1024 / 1024, drive.AvailableFreeSpace);

                // -----------------------------------------
                // Get files and directories in one go in the base class of FileInfo and DirectoryInfo
                FileSystemInfo[] entries = drive.RootDirectory.GetFileSystemInfos("*.*", SearchOption.TopDirectoryOnly);
                Array.Sort(entries, (a, b) => string.Compare(a.Name, b.Name, true));
                foreach (FileSystemInfo entry in entries)
                {
                    // -----------------------------------------
                    // Read the attributes of a file
                    StringBuilder attributes = new StringBuilder("----");
                    if (entry.Attributes.HasFlag(FileAttributes.Archive))
                    {
                        attributes[0] = 'A';
                    }
                    if (entry.Attributes.HasFlag(FileAttributes.ReadOnly))
                    {
                        attributes[1] = 'R';
                    }
                    if (entry.Attributes.HasFlag(FileAttributes.Hidden))
                    {
                        attributes[2] = 'H';
                    }
                    if (entry.Attributes.HasFlag(FileAttributes.System))
                    {
                        attributes[2] = 'S';
                    }

                    // -----------------------------------------
                    // Output the filesystem object information 
                    if (entry is DirectoryInfo directory)
                    {
                        Console.WriteLine("\t\t[{0,-18}]  <DIRECTORY>  {1}", directory.Name.Cut(18), attributes);
                    }
                    else if (entry is FileInfo file)
                    {
                        Console.WriteLine("\t\t{0,-18}    {1,11:0}  {2}", file.Name.Cut(18), file.Length, attributes);
                    }
                }
            }
        }

        #endregion

        #region Stream Examples

        public void RunStreamExamples()
        {
            // - Stream class https://docs.microsoft.com/en-us/dotnet/api/system.io.stream
            //   The base class of every stream. It is IDisposable so that every stream should be Disposed.
            //   
            // - FileStream class https://docs.microsoft.com/en-us/dotnet/api/system.io.filestream
            //   To read and write to a file within the filesystem use this stream, best combined with an
            //   appropriate reader or writer implementation. Also best created with the File.OpenXyz() methods.
            //
            // - MemoryStream class https://docs.microsoft.com/en-us/dotnet/api/system.io.memorystream
            //   The only stream which don't need be disposed, but anyway dispose it.
            //
            // - TextReader class https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader
            //   TextWriter class https://docs.microsoft.com/en-us/dotnet/api/system.io.textwriter
            //   These base classes are for easily reading and writing from and to text files. 
            //   There is an implementation for Streams called StreamReader and StreamWriter.
            //   And there is an implementation for Strings clled StringReader and StringWriter.
            //   While StringWriter is just a wrapper arround StringBuilder.
            // 
            // - BinaryReader class https://docs.microsoft.com/en-us/dotnet/api/system.io.binaryreader
            //   BinaryWriter class https://docs.microsoft.com/en-us/dotnet/api/system.io.binarywriter
            //   In order to read and write from a binary file one can use BinaryReader and BinaryWriter,
            //   which makes the reading and writing of a binary file a lot easier than using only the 
            //   Stream class.
            // 
            // - Encoding class https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding
            //   Different encodings can easily be converted, parsed or created by the Encoding 
            //   class. Where GetBytes() and GetString() will normaly be all you need. One can 
            //   use also the Encoding.Convert() Method to convert instantly to a different encoding.
            // 

            // --------------------------------------------------------------------------------------------
            // FileStream and TextReader example
            string filename = StringData.CreateTemporaryFile();

            // -----------------------------------------
            // Open the FileStream in read mode here the long version of File.OpenRead(filename)
            using (Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (TextReader reader = new StreamReader(stream, Encoding.Default))
            {
                // -----------------------------------------
                // Simply count the number of lines
                int count = 0;
                string line = null;
                while ((line = reader.ReadLine()) != null)
                {
                    count += 1;
                }
                Console.WriteLine("[TextReader] The given text file have {0} lines.", count);
            }

            // --------------------------------------------------------------------------------------------
            // FileStream and MemoryStream example
            using (Stream inputStream = File.OpenRead(filename))
            using (Stream outputStream = new MemoryStream(64 * 1024))
            {
                // -----------------------------------------
                // Just copy the stuff around
                int overall = 0;
                int count = 0;
                byte[] buffer = new byte[4 * 1024];
                while ((count = inputStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    overall += count;
                    outputStream.Write(buffer, 0, count);
                }
                Console.WriteLine("[MemoryStream] Written {0} bytes from file into the memory.", overall);
            }

            // --------------------------------------------------------------------------------------------
            // Encoding 
            byte[] defaultEncodedText = File.ReadAllBytes(filename);
            byte[] utf8EncodedText = Encoding.Convert(Encoding.Default, Encoding.UTF8, defaultEncodedText);
            File.WriteAllBytes(filename, utf8EncodedText);
            Console.WriteLine("[Encoding] Conversion from Default encoding ({0} bytes) to UTF8 encoding ({1} bytes) created a difference of {2} bytes.", 
                defaultEncodedText.Length, utf8EncodedText.Length, defaultEncodedText.Length - utf8EncodedText.Length);
        }

        #endregion

        #region Network Stream Examples

        /// <summary>
        /// The NetworkStream Examples here are just a simple comparison between Socket and TcpListener and TcpClient.
        /// </summary>
        public void RunNetworkStreamExamples()
        {
            // --------------------------------------------------------------------------------------------
            // - Socket class https://docs.microsoft.com/en-us/dotnet/api/system.net.sockets.socket
            //   The lowest level of creating a network connection is the Berkley Socket Implementation, which from the Socket
            //   class goes almost directly to the unmanged functions.
            // 
            // - TcpListener class https://docs.microsoft.com/en-us/dotnet/api/system.net.sockets.tcplistener
            //   TcpClient class https://docs.microsoft.com/en-us/dotnet/api/system.net.sockets.tcpclient
            //   The difference between in using TcpListener and TcpClient instead of Sockets is that the initialization is a little 
            //   easier and with TcpListener you could only use the TCP protocol.
            // 
            // - NetworkStream class https://docs.microsoft.com/en-us/dotnet/api/system.net.sockets.networkstream
            //   Can be used to read or write to a Socket in blocking mode, which not applies to asynchronous designed Methods. 
            //   Blocking mode means that a method call waiting till it is finished, which of course not apply to async Methods.
            //   Other than that all NetworkStream asynchronous Methods using subsequently asynchronous Methods from the Socket class.
            //   One big advantage of using the NetworkStream class is that it can be easily paired with SslStream for encryption.
            // 


            // --------------------------------------------------------------------------------------------
            // TcpClient TcpListener
            // - Short example 
            int port = 9966;
            Task serverTask = Task.Run(() =>
            {
                TcpListener listener = null;
                try
                {
                    // -----------------------------------------
                    // Bind Socket to localhost:9966 and listen
                    listener = new TcpListener(IPAddress.Loopback, port);
                    listener.Start();
                    Console.WriteLine("[TcpListener] Listening to localhost:{0}.", port);

                    // -----------------------------------------
                    // Accepting first incoming connection 
                    using (TcpClient client = listener.AcceptTcpClient())
                    using (NetworkStream stream = client.GetStream())
                    using (MemoryStream resultStream = new MemoryStream(64 * 1024))
                    {
                        Console.WriteLine("[TcpListener] Accepting incoming connection from {0}.", client.Client.RemoteEndPoint);

                        // -----------------------------------------
                        // Retrieve the information
                        int count = 0;
                        byte[] buffer = new byte[client.SendBufferSize];
                        while ((count = stream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            resultStream.Write(buffer, 0, count);
                        }

                        // -----------------------------------------
                        // Decode string and send the length
                        string bible = Encoding.UTF8.GetString(resultStream.ToArray());
                        Console.WriteLine("[TcpListener] Retrieved {0} characters from socket.", bible.Length);
                    }
                }
                finally
                {
                    listener.Stop();
                }
            });
            Task clientTask = Task.Run(() =>
            {
                // -----------------------------------------
                // Prepare data to send 
                using (MemoryStream memoryStream = StringData.CreateMemoryStream())
                using (TcpClient client = new TcpClient())
                {
                    // -----------------------------------------
                    // Connect to a server 
                    client.Connect(IPAddress.Loopback, port);
                    Console.WriteLine("[TcpClient] Connected to localhost:{0}.", port);

                    using (NetworkStream stream = client.GetStream())
                    {
                        // -----------------------------------------
                        // Send the information
                        byte[] buffer = new byte[4 * 1024];
                        int count = 0;
                        while ((count = memoryStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            stream.Write(buffer, 0, count);
                        }
                        Console.WriteLine("[TcpClient] Send {0} bytes.", memoryStream.Length);
                    }
                }
            });
            // -----------------------------------------
            // Wait till both tasks are finished
            Task.WaitAll(serverTask, clientTask);


            // --------------------------------------------------------------------------------------------
            // Sockets     
            // - Short socket example (informative only)
            port = 9977;
            serverTask = Task.Run(() =>
            {
                using (Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    // -----------------------------------------
                    // Bind Socket to localhost:9977 and listen
                    serverSocket.Bind(new IPEndPoint(IPAddress.Loopback, port));
                    serverSocket.Listen(15);
                    Console.WriteLine("[Socket] Listening to localhost:{0}.", port);

                    // -----------------------------------------
                    // Accepting first incoming connection 
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
            clientTask = Task.Run(() =>
            {
                // -----------------------------------------
                // Prepare data to send 
                using (MemoryStream stream = StringData.CreateMemoryStream())
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
                    Console.WriteLine("[TcpClient] Send {0} bytes.", stream.Length);
                }
            });

            // -----------------------------------------
            // Wait till both tasks are finished
            Task.WaitAll(serverTask, clientTask);
        }

        #endregion
    }
}