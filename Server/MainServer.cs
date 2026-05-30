using System.Net;
using System.Text;
using Router1;
using PageService1;

namespace Server
{
    public class MainServer
    {
        readonly static string Url = "http://localhost:8000/";
        readonly static HttpListener Listener = new();
        readonly IRouter Router;
        readonly IPageService PageService;
        bool Running = false;

        public MainServer(string pagesFolder, string scriptsFolder, string stylesFolder)
        {
            Router = new Router();
            PageService = new PageService(pagesFolder, scriptsFolder, stylesFolder);
            Listener.Prefixes.Add(Url);
        }

        public void StartServer()
        {
            Running = true;
            Listener.Start();
            Console.WriteLine($"Server listening at {Url}");
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
                Console.WriteLine($"Request Received: \n {request.RawUrl}");
                // get page info
                RequestInfo RequestInfo = Router.GetRequestInfoFromUrl(request.RawUrl ?? "");
                // get rawHTML as byte[]
                string htmlString = PageService.GetRequestedData(RequestInfo);
                byte[] buffer = Encoding.UTF8.GetBytes(htmlString);
                // make response
                HttpListenerResponse response = ctx.Response;
                response.ContentType = GetContentTypeFromRequestType(RequestInfo.RequestType);
                response.ContentEncoding = Encoding.UTF8;
                response.ContentLength64 = buffer.LongLength;
                // send it
                await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
                response.Close();
            }
        }

        public string GetContentTypeFromRequestType(RequestType requestType)
        {
            switch (requestType)
            {
                case RequestType.SCRIPT:
                    return "text/javascript";
                case RequestType.STYLE:
                    return "text/css";
                default:
                    return "text/html";
            }
        }
    }
}