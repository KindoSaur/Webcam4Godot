using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Sockets;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace WebcamApp
{
    public partial class GodotWebcamCaptureTool : Form
    {
        private FilterInfoCollection _filterInfoCollection;
        private VideoCaptureDevice _videoCaptureDevice;
        private bool _cameraAvailable = true;
        private int _previousSelectedCamera = -1;

        public GodotWebcamCaptureTool() => InitializeComponent();

        private void OnStart(object sender, EventArgs e)
        {
            CustomTCPClient.UpdatDebugTextBox(debugTextBox, "Application started");
            btnSearch.PerformClick();
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            if (!_cameraAvailable) return;
            if (_videoCaptureDevice.IsRunning) _videoCaptureDevice.Stop();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!_cameraAvailable || cboCamera.SelectedIndex == -1) return;

            if (_videoCaptureDevice.IsRunning) _videoCaptureDevice.Stop();

            CustomTCPClient.UpdatDebugTextBox(debugTextBox, "Recording started");
            _videoCaptureDevice = new VideoCaptureDevice(_filterInfoCollection[cboCamera.SelectedIndex].MonikerString);
            _videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            _videoCaptureDevice.Start();
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Dispose of the previous frame if it exists
            if (VideoFeed.Image != null)
            {
                VideoFeed.Image.Dispose();
            }

            // Clone the new frame
            using (Bitmap frame = (Bitmap)eventArgs.Frame.Clone())
            {
                if (CustomTCPClient.ReturnIsConnected())
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        frame.Save(stream, ImageFormat.Jpeg);
                        byte[] imageData = stream.ToArray();
                        CustomTCPClient.SendImageDataToServer(serverTextBox.Text, int.Parse(portTextBox.Text), imageData);
                    }
                }
                else
                {
                    // Assign the cloned frame to the Image property
                    VideoFeed.Image = (Bitmap)frame.Clone();
                }
            }

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (!_cameraAvailable) return;

            if (_videoCaptureDevice.IsRunning || CustomTCPClient.ReturnIsConnected())
            {
                _videoCaptureDevice.Stop();
                CustomTCPClient.UpdatDebugTextBox(debugTextBox, "Recording stopped");
                CustomTCPClient.Disconnect();
                VideoFeed.Image = null;
            }
        }

        private void connectToGodot_Click(object sender, EventArgs e)
        {
            if (CustomTCPClient.ReturnIsConnected() == true && _cameraAvailable == true) return;

            btnStart.PerformClick();

            CustomTCPClient.UpdatDebugTextBox(debugTextBox, "Connecting to Godot");
            CustomTCPClient.Connect(serverTextBox.Text, int.Parse(portTextBox.Text), "Connection succesful");
            VideoFeed.Image = null;
        }

        private void cboCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCamera.SelectedIndex == _previousSelectedCamera) return;

            CustomTCPClient.UpdatDebugTextBox(debugTextBox, string.Format("Camera switched to: {0}", cboCamera.SelectedItem.ToString()));
            _previousSelectedCamera = cboCamera.SelectedIndex;
        }

        private void SearchForCameras(object sender, EventArgs e)
        {
            _filterInfoCollection = _filterInfoCollection == null ? new FilterInfoCollection(FilterCategory.VideoInputDevice) : _filterInfoCollection;

            foreach (FilterInfo filterInfo in _filterInfoCollection)
            {
                if (!cboCamera.Items.Contains(filterInfo.Name)) cboCamera.Items.Add(filterInfo.Name);
            }

            if (cboCamera.Items.Count == 0)
            {
                CustomTCPClient.UpdatDebugTextBox(debugTextBox, "ERROR: NO CAMERA FOUND");
                _cameraAvailable = false;
                return;
            }

            _cameraAvailable = true;
            CustomTCPClient.UpdatDebugTextBox(debugTextBox, string.Format("Amount of cameras found: {0}", cboCamera.Items.Count));

            _videoCaptureDevice = _videoCaptureDevice == null ? new VideoCaptureDevice() : _videoCaptureDevice;
        }
    }
}

public static class CustomTCPClient
{
    private static bool _connectedToServer = false;
    private static TextBox _internalDebugTextBox;
    private static TcpClient _client;

    public static void Connect(String server, Int32 port, String message)
    {
        _client = new TcpClient();

        try
        {
            _client.Connect(server, port);

            if (_client.Connected)
            {
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                NetworkStream stream = _client.GetStream();
                stream.Write(data, 0, data.Length);

                _connectedToServer = true;
                UpdatDebugTextBox(_internalDebugTextBox, "Connection succesful");
            }
        }
        catch (ArgumentNullException e)
        {
            UpdatDebugTextBox(_internalDebugTextBox, string.Format("ArgumentNullException: {0}", e));
            UpdatDebugTextBox(_internalDebugTextBox, "Connection failed");
            _connectedToServer = false;
        }
        catch (SocketException e)
        {
            UpdatDebugTextBox(_internalDebugTextBox, string.Format("SocketException: {0}", e));
            UpdatDebugTextBox(_internalDebugTextBox, "Connection failed");
            _connectedToServer = false;
        }
        finally
        {
            _client.Close();
        }
    }

    public static void Disconnect()
    {
        if (_client == null) return;

        _connectedToServer = false;
        _client.Close();
    }

    public static void SendImageDataToServer(String server, Int32 port, byte[] imageData)
    {
        try
        {
            using (_client = new TcpClient(server, port))
            {
                NetworkStream stream = _client.GetStream();
                stream.Write(imageData, 0, imageData.Length);
            }
        }
        catch (Exception ex)
        {
            UpdatDebugTextBox(_internalDebugTextBox, string.Format("Error sending image data to the server: " + ex.Message));
        }
    }

    public static void UpdatDebugTextBox(TextBox debug, string message)
    {
        if (_internalDebugTextBox == null) _internalDebugTextBox = debug;

        string formattedTime = $"{DateTime.Now.Hour:D2}:{DateTime.Now.Minute:D2}:{DateTime.Now.Second:D2}";
        debug.AppendText(formattedTime + " " + message + Environment.NewLine);
    }

    public static bool ReturnIsConnected() => _connectedToServer;
}
