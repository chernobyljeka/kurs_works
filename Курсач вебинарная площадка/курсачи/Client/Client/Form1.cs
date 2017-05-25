using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
using NAudio.Wave;

namespace Client
{
    public partial class Form1 : Form
    {
        private bool connected = false;
        Socket client;
        WaveIn input;
        WaveOut output;
        BufferedWaveProvider bufferStream;
        Thread in_thread;
        Socket listeningSocket;
        static TcpListener listener;
        bool alive = false; // будет ли работать поток для приема
        UdpClient client1;
        const int LOCALPORT = 8001; // порт для приема сообщений
        const int REMOTEPORT = 8001; // порт для отправки сообщений
        const int TTL = 20;
        const string HOST = "235.5.5.1"; // хост для групповой рассылки
        IPAddress groupAddress; // адрес для групповой рассылки

        string userName; // имя пользователя в чате
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
          
                input = new WaveIn();
                output = new WaveOut();
                bufferStream = new BufferedWaveProvider(new WaveFormat(8000, 16, 1));
                output.Init(bufferStream);
                client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                connected = true;
                listeningSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                in_thread = new Thread(new ThreadStart(Listening));
                in_thread.Start();
                listener = new TcpListener(IPAddress.Parse("192.168.137.80"), 5556);
                listener.Start();
                backgroundWorker1.RunWorkerAsync();

                //
                loginButton.Enabled = true;
                logoutButton.Enabled = false;
                sendButton.Enabled = false;
                chatTextBox.ReadOnly = true;

                groupAddress = IPAddress.Parse(HOST);
           
        }
        private void loginButton_Click(object sender, EventArgs e)
        {
            userName = userNameTextBox.Text;
            userNameTextBox.ReadOnly = true;

            try
            {
                client1 = new UdpClient(LOCALPORT);
                // присоединяемся к групповой рассылке
                client1.JoinMulticastGroup(groupAddress, TTL);

                // запускаем задачу на прием сообщений
                Task receiveTask = new Task(ReceiveMessages);
                receiveTask.Start();

                // отправляем первое сообщение о входе нового пользователя
                string message = userName + " вошел в чат";
                byte[] data = Encoding.Unicode.GetBytes(message);
                client1.Send(data, data.Length, HOST, REMOTEPORT);

                loginButton.Enabled = false;
                logoutButton.Enabled = true;
                sendButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ReceiveMessages()
        {
            alive = true;
            try
            {
                while (alive)
                {
                    IPEndPoint remoteIp = null;
                    byte[] data = client1.Receive(ref remoteIp);
                    string message = Encoding.Unicode.GetString(data);

                    this.Invoke(new MethodInvoker(() =>
                    {
                        string time = DateTime.Now.ToShortTimeString();
                        chatTextBox.Text = time + " " + message + "\r\n" + chatTextBox.Text;
                    }));
                }
            }
            catch (ObjectDisposedException)
            {
                if (!alive)
                    return;
                throw;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void sendButton_Click(object sender, EventArgs e)
        {
            try
            {
                string message = String.Format("{0}: {1}", userName, messageTextBox.Text);
                byte[] data = Encoding.Unicode.GetBytes(message);
                client1.Send(data, data.Length, HOST, REMOTEPORT);
                messageTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void logoutButton_Click(object sender, EventArgs e)
        {
            ExitChat();
        }
        private void ExitChat()
        {
            string message = userName + " покидает чат";
            byte[] data = Encoding.Unicode.GetBytes(message);
            client1.Send(data, data.Length, HOST, REMOTEPORT);
            client1.DropMulticastGroup(groupAddress);

            alive = false;
            client1.Close();

            loginButton.Enabled = true;
            logoutButton.Enabled = false;
            sendButton.Enabled = false;
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            UdpClient client2 = new UdpClient(8002);
            IPEndPoint remoteIp = null;
            while (connected)
            {
                byte[] data = client2.Receive(ref remoteIp);
                var ms = new MemoryStream(data);
                System.Drawing.Image image = Image.FromStream(ms);
                pictureBox1.Image = image;
            }
        }

        private void Listening()
        {
            IPEndPoint localIP = new IPEndPoint(IPAddress.Parse("192.168.137.80"), 5555);
            listeningSocket.Bind(localIP);
            output.Play();
            EndPoint remoteIp = new IPEndPoint(IPAddress.Any, 0);
            while (connected == true)
            {
                try
                {
                    byte[] data = new byte[65535];
                    int received = listeningSocket.ReceiveFrom(data, ref remoteIp);
                    bufferStream.AddSamples(data, 0, received);
                }
                catch (SocketException ex)
                { }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (output != null)
            {
                output.Stop();
                output.Dispose();
            }
            if (input != null)
            {
                input.Dispose();
            }
            if (in_thread != null)
            {
                in_thread.Abort();
            }
            if (listeningSocket != null)
            {
                listeningSocket.Dispose();
            }
            backgroundWorker1.CancelAsync();
            backgroundWorker1.Dispose();
            connected = false;
            client.Close();
            Application.Exit();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var n = new AboutBox1();
            n.ShowDialog();
        }
    }
}
