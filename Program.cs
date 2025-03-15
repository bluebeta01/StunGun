using StunGun;

internal class Program
{
    public static void Main(string[] args)
    {
        var command = args.ElementAtOrDefault(0)?.ToLower();

        switch (command)
        {
            case "server":
                var serverAddress = args.ElementAtOrDefault(1);
                var serverPort = args.ElementAtOrDefault(2);
                if (serverAddress is null || serverPort is null)
                {
                    PrintUsage();
                    return;
                }

                int port;
                if (!int.TryParse(serverPort, out port))
                {
                    Console.WriteLine($"Could not parse port {serverPort}");
                    PrintUsage();
                    return;
                }

                var server = new Server();
                server.Start(serverAddress, port);
                break;
            case "client":
                var firstAddress = args.ElementAtOrDefault(1);
                var firstPort = args.ElementAtOrDefault(2);
                var secondAddress = args.ElementAtOrDefault(3);
                var secondPort = args.ElementAtOrDefault(4);
                if (firstAddress is null || firstPort is null || secondAddress is null || secondPort is null)
                {
                    PrintUsage();
                    return;
                }
                
                int firstPortParsed;
                int secondPortParsed;
                if (!int.TryParse(firstPort, out firstPortParsed))
                {
                    Console.WriteLine($"Could not parse port {firstPort}");
                    PrintUsage();
                    return;
                }
                if (!int.TryParse(secondPort, out secondPortParsed))
                {
                    Console.WriteLine($"Could not parse port {secondPort}");
                    PrintUsage();
                    return;
                }

                var client = new Client();
                client.Start(firstAddress, firstPortParsed, secondAddress, secondPortParsed);
                break;
            default:
                PrintUsage();
                return;
        }
    }

    private static void PrintUsage()
    {
        Console.WriteLine("stungun server <address> <port>");
        Console.WriteLine("stungun client <address1> <port1> <address2> <port2>");
    }
}
