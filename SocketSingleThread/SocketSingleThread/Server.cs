using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SocketSingleThread
{
    public partial class Server : Form
    {
        // Multiple sockets are declared here to avoid confusion in the functions of connecting,
        // receiving, and sending data, and to facilitate closure
        // Declares the Socket to be used for listening
        public Socket ServerSocket;
        // Creates a list for holding client sockets
        public static List<SingleClientSocketInformation> SocketsList = new List<SingleClientSocketInformation>();
        // Declares _serverListenThread
        private Thread _serverListenThread;

        // Constants
        private const string KConnecting = "connecting...";
        private const string KOne = "1";
        private const string KServerWrong = "There's something wrong with the server";
        private const string KTimeFormat="yyyy-MM-dd HH:mm:ss";
        private const string KConnectSuccess = "Connection successful";
        private const string KNewLine = "\r\n";
        private const string KNoConnection = "No client is connected";
        private const string KCloseFormat = "*close*";
        private const string KClientExit =  "The client has exited";
        private const string KNewN = "\n";
        private const string KFormatX= "*";
        private const string KFormatM = ":";
        private const string KFormatReceive = "Receive";
        private const string KSend = "Send to";
        private const string KNoInformation = "No information received";
        private const string KServerClosed = "The server has been closed";
        private const string KOneSpace = "\u0020";


        public class SingleClientSocketInformation
        {
            public Socket Socket;
            // Link success flag
            public int SFlag = 0;
            // Client shutdown flag
            public int CFlag = 0;
            public Thread ReceiveThread;
        }

        public Server()
        {
            InitializeComponent();
        }

        private void Server_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        #region Connect to Client (Bind button event)
        private void button_Accpet_Click(object sender, EventArgs e)
        {
            // Create sockets for communication
            ServerSocket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            richTextBox_Receive.Text = KConnecting;
            // Disable the connect button
            button_Accpet.Enabled=false;

            // 1.Bind IP and port
            var IP =IPAddress.Parse(textBox_Addr.Text.Trim());
            var Port = int.Parse(textBox_Port.Text.Trim());

            var iPEndPoint = new IPEndPoint(IP, Port);

            try
            {
                // 2. Use Bind() to bind
                ServerSocket.Bind(iPEndPoint);
                // 3.Enable listening
                // Listen(int backlog); backlog:Monitor quantity
                ServerSocket.Listen(10);

                //Accept will block the operation of the main thread, and it has been waiting for
                //the request of the client. If the client does not access, it will be waiting here.
                //The main thread is stuck, so a new thread is started to receive the single request of the client

                // Enable the thread to Accept the client socket for communication
                // The thread binds the Listen function
                _serverListenThread = new Thread(Listen)
                {
                    // The running thread executes in the background
                    IsBackground = true
                };
                //The arguments in Start are required by the Listen function, which passes the Socket object for communication
                _serverListenThread.Start(ServerSocket);
                Console.WriteLine(KOne);
            }
            catch
            {
                MessageBox.Show(KServerWrong);
            }
        }
        #endregion

        #region Establish a connection to the client

        private void Listen(object sk)
        {
            try
            {
                while (true)
                {
                    //If the value of CFlag is 1, the connection is interrupted.
                    //The value of flag is used to ensure that the server can be shut down smoothly.
                    //When the client is shut down once, the absence of this flag will cause the server
                    //to remain stuck in the interrupted position.
                    //If the server is stuck in the interrupted position, the server cannot be shut down smoothly

                    // 4. Block the connection until the client is connected
                    var temp = new SingleClientSocketInformation
                    {
                        // Declares the socket used to communicate with a client
                        Socket = ServerSocket.Accept() 
                    };
                    var client = temp.Socket.RemoteEndPoint.ToString();
                    comBox_Clients.Items.Add(client);
                    comBox_Clients.SelectedIndex = 0;
                    // If the connection is successful, set the client close flag to 0
                    temp.CFlag = 0;
                    //When the connection is successful, set the connection success flag to 1
                    temp.SFlag = 1; 

                    richTextBox_Receive.Text += DateTime.Now.ToString(KTimeFormat) + KOneSpace + client + KOneSpace + KConnectSuccess;
                    richTextBox_Receive.Text += KNewLine;

                    // Start the second thread to receive client data
                    // The thread binds the reception function
                    temp.ReceiveThread = new Thread(Receive)
                    {
                        IsBackground = true
                    };
                    temp.ReceiveThread.Start(temp);
                    // Add the connected client to the List
                    // Obtain client information. Store different clients in comBox
                    SocketsList.Add(temp); 
                }
            }
            catch
            {
                MessageBox.Show(KNoConnection);
            }
        }
        #endregion
        /*****************************************************************/

        /*****************************************************************/
        #region Receive client data
        private void Receive(Object sk)
        {
            var tempReceive = sk as SingleClientSocketInformation;
            // Create a socket for communication (in this case, the client socket passed by the thread)
            if (tempReceive == null)
            {
                return;
            }
            var socket = tempReceive.Socket; 

            while (true)
            {
                try
                {
                    if (tempReceive.CFlag == 0 && tempReceive.SFlag == 1)
                    {
                        // 5. Receive data
                        var receive = new byte[1024];
                        var len = socket.Receive(receive);

                        // 6. Print the received data
                        if (receive.Length > 0)
                        {
                            // If you receive a client stop flag
                            if (Encoding.UTF8.GetString(receive, 0, len) == KCloseFormat)
                            {
                                richTextBox_Receive.Text += DateTime.Now.ToString(KTimeFormat) + KOneSpace +
                                                            tempReceive.Socket.RemoteEndPoint.ToString() + KOneSpace + KClientExit + KNewN;
                                UpdateClientListIndex(tempReceive);
                                // Set the client close flag to 1
                                tempReceive.CFlag = 1; 
                                tempReceive.SFlag = 0;
                                tempReceive.ReceiveThread.Abort();
                                tempReceive.Socket.Close();
                                // Exit loop
                                break; 
                            }

                            // Print received data
                            richTextBox_Receive.Text += KFormatX + DateTime.Now.ToString(KTimeFormat) + KOneSpace;
                            richTextBox_Receive.Text += KFormatReceive + KOneSpace + socket.RemoteEndPoint.ToString() + KFormatM;
                            // Receive Chinese without garbled characters
                            richTextBox_Receive.Text += Encoding.UTF8.GetString(receive, 0, len); 
                            richTextBox_Receive.Text += KNewLine;
                        }
                    }
                    else
                    {
                        // Exit loop
                        break; 
                    }
                }
                catch
                {
                    if (tempReceive.CFlag == 0)
                    {
                        MessageBox.Show(KNoInformation);
                    }
                }
            }
        }
        #endregion

        private void comBox_Clients_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #region 向客户端发送数据
        private void button_Send_Click(object sender, EventArgs e)
        {
            var i = comBox_Clients.SelectedIndex;
            // SFlag indicates that the connection is successful and data can be sent only when the client is open
            if (SocketsList[i].SFlag == 1 && SocketsList[i].CFlag == 0)
            {
                var send = Encoding.UTF8.GetBytes(richTextBox_Send.Text);
                /*
                * The socket information (ip and port number) of each connected client is stored in the combox
                * We can select the client we want to communicate with in combox
                * comboBox_Clients.SelectedIndex gets the selected index, which is for the socket object in List
                * Thus sending information to the selected client
                 */
                var client = comBox_Clients.Text;
                // Call Send() to send data to the client
                SocketsList[i].Socket.Send(send);

                // Print the send time and send data
                richTextBox_Receive.Text += KFormatX + DateTime.Now.ToString(KTimeFormat) + KOneSpace + KSend + KOneSpace + client + KOneSpace + KFormatM;
                richTextBox_Receive.Text += richTextBox_Send.Text + KNewN;
                // Clear the send box
                richTextBox_Send.Clear(); 
            }
        }
        #endregion

        #region Close the server
        private void button_Close_Click(object sender, EventArgs e)
        {
            // Thread 2 and socket need to be closed if the client is connected,
            // _serverListenThread and other sockets should be closed directly if the client is not connected
            if (SocketsList.Count > 0)
            {
                foreach (SingleClientSocketInformation s in SocketsList)
                {
                    // Close the socket used for communication
                    s.Socket.Close();
                    // Reset the client flag to 0 to indicate that it is open when making a connection
                    s.CFlag = 0;
                    // Set the connection success flag program to 0, indicating that the connection is exiting;
                    s.SFlag = 0;  
                }
            }
            // Close the socket used for the connection
            ServerSocket.Close(); 
            _serverListenThread.Abort(); 
            SocketsList.Clear();

            button_Accpet.Enabled = true;
            richTextBox_Receive.Text += DateTime.Now.ToString(KTimeFormat);
            richTextBox_Receive.Text += KOneSpace + KServerClosed + KNewN;
            MessageBox.Show(KServerClosed);
        }
        #endregion

        #region Click enter to send the data
        private void richTextBox_Send_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.button_Send_Click(sender, e);
            }
        }
        #endregion

        #region Click to clear the receive box
        private void button_Clear_Click(object sender, EventArgs e)
        {
            richTextBox_Receive.Clear();
        }
        #endregion

        /// <summary>
        /// Disconnect
        /// </summary>
        /// <param name="tempClientSocketInformation"></param>
        private void UpdateClientListIndex(SingleClientSocketInformation tempClientSocketInformation)
        {
            // Update the client list
            var itemToRemove = SocketsList.Find(client => client.Socket != null && client.Socket.RemoteEndPoint.Equals(tempClientSocketInformation.Socket.RemoteEndPoint));
            if (itemToRemove != null)
            {
                SocketsList.Remove(itemToRemove);
            }
            // Update disconnected clients in the list
            for (var i = comBox_Clients.Items.Count - 1; i >= 0; i--)
            {
                if (comBox_Clients.Items[i].ToString() == tempClientSocketInformation.Socket.RemoteEndPoint.ToString())
                {
                    comBox_Clients.Items.RemoveAt(i);
                }
            }

        }
    }
}
