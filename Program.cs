using Server;

public static class Program
{
    public static void Main()
    {
        MainServer server = new("./Pages", "./Pages/Scripts", "./Pages/Styles");
        server.StartServer();
    }
}