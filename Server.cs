using System.Net;
using System.Net.Sockets;
using System.Text;

namespace StunGun;

public class Server
{
    public void Start(string address, int port)
    {
        var udpClient = new UdpClient(new IPEndPoint(IPAddress.Parse(address), port));

        while (true)
        {
            var endpoint = new IPEndPoint(IPAddress.Any, 0);
            _ = udpClient.Receive(ref endpoint);
            var payload = $"Hello! You are {endpoint.Address.ToString()}:{endpoint.Port}";
            udpClient.Send(Encoding.ASCII.GetBytes(payload), endpoint);
        }
    }
}