using Router1;

namespace Server
{
    public class RequestInfo
    {
        public RequestType RequestType;
        public string RequestString;
        Dictionary<string, object> DataContext = new();
        public RequestInfo(string requestString, RequestType requestType)
        {
            RequestString = requestString;
            RequestType = requestType;
        }

        public void AddObjectToDataContext(string tagString, Object instance)
        {
            if (DataContext.ContainsKey(tagString))
            {
                throw new Exception($"RequestInfo for {RequestString} already has data under {tagString}");
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

    public enum RequestType
    {
        PAGE,
        SCRIPT,
        STYLE
    }
}