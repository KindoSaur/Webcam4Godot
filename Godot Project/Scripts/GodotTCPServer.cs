using Godot;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public partial class GodotTCPServer : Node
{
    private TcpListener _server;
    [Export] private int _port = 13000;
    [Export] private int _kiloBytesAmount;      // The higher this value is the more the image data can be processed at once
    [Export] public TextureRect _liveFeed;      // The image sent by the Camera 4 Godot application will be outputted here.

    public override void _Ready() => SetupServer();

    private void SetupServer()
    {
        _server = new TcpListener(IPAddress.Any, _port);
        _server.Start();
        GD.Print("Server started on port " + _port);
        StartListening();
    }

    private async void StartListening()
    {
        while (true)
        {
            try
            {
                TcpClient client = await _server.AcceptTcpClientAsync();
                ProcessClientRequest(client);
            }
            catch (Exception ex)
            {
                GD.Print("Error accepting client connection: " + ex.Message);
            }
        }
    }

    private void ProcessClientRequest(TcpClient client)
    {
        NetworkStream stream = client.GetStream();
        int bufferSize = 1024 * _kiloBytesAmount;
        byte[] buffer = new byte[bufferSize];
        int bytesRead;

        // Read data sent by the client
        try { bytesRead = stream.Read(buffer, 0, buffer.Length); }
        catch (Exception ex){
            GD.Print("Error reading data from client: " + ex.Message);
            return;
        }

        // If the client has data to read > decode it
        if (bytesRead > 0)
        {
            string receivedData = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            if (receivedData == "Connection succesful")
            {
                client.Close();
                return;
            }
            else
            {
                Image receivedImage = new Image();
                receivedImage.LoadJpgFromBuffer(buffer);
                ImageTexture imageTexture = new ImageTexture();
                imageTexture.SetImage(receivedImage);
                _liveFeed.Texture = imageTexture;
            }
        }
        client.Close();
    }
}
