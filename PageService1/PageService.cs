using Server;

namespace PageService1
{
    public class PageService : IPageService
    {
        readonly string PagesFolder;
        readonly string ScriptsFolder;
        readonly string StylesFolder;
        public PageService(string pagesFolder, string scriptsFolder, string stylesFolder)
        {
            PagesFolder = pagesFolder;
            ScriptsFolder = scriptsFolder;
            StylesFolder = stylesFolder;
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

        public string GetScriptString(string requestUrl)
        {
            string result;
            using (StreamReader reader = new(Path.Join(ScriptsFolder, requestUrl)))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }
        public string GetStyleString(string requestUrl)
        {
            string result;
            using (StreamReader reader = new(Path.Join(StylesFolder, requestUrl)))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }
    }
}