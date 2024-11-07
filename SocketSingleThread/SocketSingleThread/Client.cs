using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SocketSingleThread
{
    public partial class Client : Form
    {
        // Declare the socket responsible for communication
        public static Socket ClientSocket;
        // Successful connection to server flag
        public static int SFlag = 0;
        // Declare a thread to receive data
        private Thread _threadReceive;

        // Constants
        private const string KConnecting = "connecting...";
        private const string KTimeFormat = "yyyy-MM-dd HH:mm:ss";
        private const string KConnectSuccess = "Connection successful";
        private const string KNewN = "\n";
        private const string KServerClosed = "The server has been closed";
        private const string KFormatReceive = "Receive:";
        private const string KFormatX = "*";
        private const string KNewLine = "\r\n";
        private const string KSend = "Send:";
        private const string KCloseFormat = "*close*";
        private const string KUserClientClose = "User client closed";
        private const string KConnectionClose = "The connection has already broken";
        private const string KOneSpace = "\u0020";

        public Client()
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {

        }
        #region Connect to server
        private void button_Accpet_Click(object sender, EventArgs e)
        {
            // Instantiate the socket responsible for communication
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); 
            richTextBox_Receive.Text += KConnecting;
            // Get the IP and port
            var ip = IPAddress.Parse(textBox_Addr.Text); 
            var port = int.Parse(textBox_Port.Text); 
            // Create a new IPEndPoint object
            IPEndPoint iPEndPoint = new IPEndPoint(ip, port);

            try
            {
                // Use the Connect() method of the socket object to make a connection request to the server,
                // passing in the IPEndPoint object we created above
                ClientSocket.Connect(iPEndPoint);
                // Set the flag to 1 if the connection is successful
                SFlag = 1;
                richTextBox_Receive.Text += DateTime.Now.ToString(KTimeFormat) + KOneSpace + textBox_Addr.Text + KOneSpace + KConnectSuccess + KNewN;
                // Disable the button
                button_Accpet.Enabled = false;
                // Start a thread to receive data
                _threadReceive = new Thread(Receive)
                {
                    IsBackground = true
                };
                _threadReceive.Start(ClientSocket);
            }
            catch
            {
                MessageBox.Show(KServerClosed);
            }
        }
        #endregion

        #region Receive data from server
        void Receive(Object sk)
        {
            Socket socketRec = sk as Socket;

            while (true)
            {
                // 5.Receive data
                byte[] receive = new byte[1024];
                // Call Receive() method to receive data
                ClientSocket.Receive(receive); 

                // 6.Print the received data
                if (receive.Length > 0)
                {
                    // Print the time of receiving data
                    richTextBox_Receive.Text += KFormatX + DateTime.Now.ToString(KTimeFormat) + KOneSpace + KFormatReceive;
                    // Use UTF8, UTF8 can solve the garbled problem
                    richTextBox_Receive.Text += Encoding.UTF8.GetString(receive); 
                    richTextBox_Receive.Text += KNewLine;
                }
            }
        }
        #endregion

        #region Send data to server
        private void button_Send_Click(object sender, EventArgs e)
        {
            // It can send data only when the connection is successful
            // Receive part because it is connected successfully, so no need to use the flag
            if (SFlag == 1)
            {
                byte[] send = new byte[1024];
                // Resolve the Chinese problem
                send = Encoding.UTF8.GetBytes(richTextBox_Send.Text);
                // Call send() to send data
                ClientSocket.Send(send); 
                // Print the send time and send data
                richTextBox_Receive.Text += KFormatX + DateTime.Now.ToString(KTimeFormat) + KOneSpace + KSend;
                richTextBox_Receive.Text += richTextBox_Send.Text + KNewN;
                // Clear the send box
                richTextBox_Send.Clear();
            }
        }
        #endregion
        #region Close user client
        private void button_Close_Click(object sender, EventArgs e)
        {
            // Ensure that the connection is successful before closing
            if (SFlag == 1)
            {
                byte[] send = new byte[1024];
                // Send a close signal to the server
                send = Encoding.ASCII.GetBytes(KCloseFormat);
                ClientSocket.Send(send);
                // Close the thread and socket
                _threadReceive.Abort(); 
                ClientSocket.Close(); 
                // Enable the button
                button_Accpet.Enabled = true; 
                // Set the connection success flag program to 0, indicating that the connection is exiting;
                SFlag = 0;
                richTextBox_Receive.Text += DateTime.Now.ToString(KTimeFormat);
                richTextBox_Receive.Text += KUserClientClose + KNewN;
            }
        }
        #endregion

        #region Click Enter to send
        private void richTextBox_Send_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.button_Send_Click(sender, e);
            }
        }


        #endregion

        #region Click to clear the display box
        private void button_Clear_Click(object sender, EventArgs e)
        {
            richTextBox_Receive.Clear();
        }
        #endregion
    }
}
