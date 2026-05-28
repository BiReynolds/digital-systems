using Server;

namespace PageService1
{
    public class PageService : IPageService
    {
        readonly string PagesFolder;
        public PageService(string pagesFolder)
        {
            PagesFolder = pagesFolder;
        }

        public string GetPageString(PageInfo pageInfo)
        {
            string result;
            using (StreamReader reader = new(Path.Join(PagesFolder, pageInfo.PageTemplateFile)))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }
    }
}