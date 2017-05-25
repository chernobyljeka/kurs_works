using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MetriCam;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO.Compression;
using System.Threading.Tasks;
using NAudio.Wave;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using NAudio;

namespace MetriCam_v_1._0
{
    public partial class Form1 : Form
    {
        private WebCam camera;
        private byte[] bytes;
        private bool connected = false;
        Socket client;
        WaveIn input;
        BufferedWaveProvider bufferStream;
        bool alive = false;
        UdpClient client1;
        const int LOCALPORT = 8001;
        const int REMOTEPORT = 8001; 
        const int TTL = 20;
        const string HOST = "235.5.5.1";
        IPAddress groupAddress; 
        string userName;

        public Form1()
        {
            InitializeComponent();
            camera = new WebCam();
            input = new WaveIn();
            input.WaveFormat = new WaveFormat(8000, 16, 1);
            input.DataAvailable += Voice_Input; ;
            bufferStream = new BufferedWaveProvider(new WaveFormat(8000, 16, 1));
            client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            connected = true;
            //
            loginButton.Enabled = true;
            logoutButton.Enabled = false;
            sendButton.Enabled = false;
            chatTextBox.ReadOnly = true;

            groupAddress = IPAddress.Parse(HOST);
        }
        //
        private void loginButton_Click(object sender, EventArgs e)
        {
            userName = userNameTextBox.Text;
            userNameTextBox.ReadOnly = true;

            try
            {
                client1 = new UdpClient(LOCALPORT);
                client1.JoinMulticastGroup(groupAddress, TTL);
                Task receiveTask = new Task(ReceiveMessages);
                receiveTask.Start();
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
        //
        private void Voice_Input(object sender, WaveInEventArgs e)
        {
            try
            {
                IPEndPoint remote_point = new IPEndPoint(IPAddress.Parse("192.168.137.48"), 5555);
                client.SendTo(e.Buffer, remote_point);
                remote_point = new IPEndPoint(IPAddress.Parse("192.168.137.78"), 5555);
                client.SendTo(e.Buffer, remote_point);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private ImageCodecInfo GetEncoder(ImageFormat format)
        {

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            connected = false;
            client.Close();
            client.Dispose();

            if (input != null)
            {
                input.Dispose();
                input = null;
            }
            Application.Exit();
        }
        //

        private void button1_Click(object sender, EventArgs e)
        {
            if (!camera.IsConnected())
            {
                camera.Connect();
                button1.Text = "&Disconnect";
                backgroundWorker1.RunWorkerAsync();
                input.StartRecording();
            }
            else
            {
                backgroundWorker1.CancelAsync();
                input.StopRecording();
            }
        }
        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {
            while (!backgroundWorker1.CancellationPending)
            {
                camera.Update();
                pictureBox1.Image = camera.CalcBitmap();
                Bitmap b = (Bitmap)camera.CalcBitmap();

                ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 25L);
                myEncoderParameters.Param[0] = myEncoderParameter;

                b.Save("1.bmp", jpgEncoder, myEncoderParameters);
                FileStream stream = new FileStream("1.bmp", FileMode.Open);
                byte[] bytes = new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);
                stream.Close();
                File.Delete("1.bmp");
                UdpClient senderr = new UdpClient();
                senderr.Send(bytes, bytes.Length, "192.168.137.48", 8002);
                senderr.Send(bytes, bytes.Length, "192.168.137.78", 8002);
                senderr.Close();
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            camera.Disconnect();
            button1.Text = "&Connect";
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var n = new _2();
            n.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}