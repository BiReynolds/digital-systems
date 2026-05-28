using Server;

public static class Program
{
    public static void Main()
    {
        MainServer server = new("./Pages");
        server.StartServer();
    }
}