namespace Router1
{
    public static class RequestHelper
    {
        public static string GetExtension(string url)
        {
            int currIndex = url.Length - 1;
            while (currIndex >= 0 && url[currIndex] != '.')
            {
                currIndex -= 1;
            }
            if (currIndex == -1)
            {
                return "";
            }
            else
            {
                return url.Substring(currIndex + 1);
            }
        }
    }
}