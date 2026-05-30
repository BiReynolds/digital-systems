using Server;

namespace Router1
{
    public class Router : IRouter
    {
        private Dictionary<string, RequestInfo> RouteMap = new()
        {
            {"/", new RequestInfo("index.html", RequestType.PAGE)},
            {"/index", new RequestInfo("index.html", RequestType.PAGE)},
            {"/test", new RequestInfo("test.html", RequestType.PAGE)}
        };
        public Router() { }

        public RequestInfo GetRequestInfoFromUrl(string url)
        {
            string requestExtension = RequestHelper.GetExtension(url);
            switch(requestExtension)
            {
                case "js":
                    return new RequestInfo(url, RequestType.SCRIPT);
                case "css":
                    return new RequestInfo(url, RequestType.STYLE);
                default:
                    return RouteMap[url];
            }
        }

        public void AddRoute(string url, RequestInfo RequestInfo)
        {
            RouteMap[url] = RequestInfo;
        }
    }
}