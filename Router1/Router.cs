using Server;

namespace Router1
{
    public class Router : IRouter
    {
        private Dictionary<string, PageInfo> RouteMap = new()
        {
            {"/", new PageInfo("index.html")},
            {"/index", new PageInfo("index.html")},
            {"/test", new PageInfo("test.html")}
        };
        public Router() { }

        public PageInfo GetPageInfoFromRawUrl(string url)
        {
            return RouteMap[url];
        }

        public void AddRoute(string url, PageInfo pageInfo)
        {
            RouteMap[url] = pageInfo;
        }
    }
}