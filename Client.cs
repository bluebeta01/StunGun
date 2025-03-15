using System.Net;
using System.Net.Sockets;
using System.Text;

namespace StunGun;

public class Client
{
    public void Start(string firstAddress, int firstPort, string secondAddress, int secondPort)
    {
        var client = new UdpClient();
        client.Send([0], new IPEndPoint(IPAddress.Parse(firstAddress), firstPort));
        client.Send([0], new IPEndPoint(IPAddress.Parse(secondAddress), secondPort));

        while (true)
        {
            var endpoint = new IPEndPoint(IPAddress.Any, 0);
            var bytes = client.Receive(ref endpoint);
            var payload = Encoding.ASCII.GetString(bytes);
            Console.WriteLine(payload);
        }
    }
}