using System.Net;
using System.Text;

namespace Server
{
    public class MainServer
    {
        bool Running = false;
        readonly static string Url = "http://localhost:8000/";
        readonly static HttpListener Listener = new();
        public MainServer()
        {
            Init();
        }

        private void Init()
        {
            Listener.Prefixes.Add(Url);
        }

        public void StartServer()
        {
            Running = true;
            Listener.Start();
            Task listenTask = HandleRequests();
            listenTask.GetAwaiter().GetResult();
            Listener.Close();
        }

        public async Task HandleRequests()
        {
            while (Running)
            {
                // wait for a request
                HttpListenerContext ctx = await Listener.GetContextAsync();
                // get request info from context
                HttpListenerRequest request = ctx.Request;
                // get response info from request info
                Console.WriteLine($"Request: {request.Url}");
                byte[] data = Encoding.UTF8.GetBytes("test");
                // make response
                HttpListenerResponse response = ctx.Response;
                response.ContentType = "text/html";
                response.ContentEncoding = Encoding.UTF8;
                response.ContentLength64 = data.LongLength;
                await response.OutputStream.WriteAsync(data, 0, data.Length);
                response.Close();
            }
        }
    }
}