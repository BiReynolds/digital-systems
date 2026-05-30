namespace Server
{
    public interface IRouter
    {
        public RequestInfo GetRequestInfoFromUrl(string url);
    }
}