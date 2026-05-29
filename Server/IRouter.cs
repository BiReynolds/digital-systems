namespace Server
{
    public interface IRouter
    {
        public PageInfo GetPageInfoFromRawUrl(string url);
    }
}