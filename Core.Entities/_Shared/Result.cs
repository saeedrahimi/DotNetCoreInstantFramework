namespace Core.Domain._Shared
{
    public class Result
    {
   
        public bool Success { get; set; }

        public dynamic Data { private get; set; }

        public string Message { get; set; }

        public T GetData<T>()
        {
            //for redsi cached data 
            //if (Data is JArray array)
            //{
            //    var output = array.ToObject<T>();
            //    return output;

            //}
            //if (Data is JObject obj)
            //{
            //    var output = obj.ToObject<T>();
            //    return output;
            //}

            return Data;
        }
    }
}
