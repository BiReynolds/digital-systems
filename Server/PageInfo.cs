namespace Server
{
    public class PageInfo
    {
        public string PageTemplateFile;
        Dictionary<string, object> DataContext = new();
        public PageInfo(string pageTemplateFile)
        {
            PageTemplateFile = pageTemplateFile;
        }

        public void AddObjectToDataContext(string tagString, Object instance)
        {
            if (DataContext.ContainsKey(tagString))
            {
                throw new Exception($"PageInfo for {PageTemplateFile} already has data under {tagString}");
            }
            DataContext[tagString] = instance;
        }

        public void ReplaceObjectInDataContext(string tagstring, Object newInstance)
        {
            DataContext[tagstring] = newInstance;
        }

        public object GetDataForTag(string tagString)
        {
            return DataContext[tagString];
        }
    }
}