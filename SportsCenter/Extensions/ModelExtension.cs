namespace SportsCenter.Extensions
{
    public static class ModelExtension
    {
        public static List<KeyValuePair<string, string>> ToKeyValuePairList<T>(this T model)
        {
            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();

            try
            {
                Type t = model.GetType();
                foreach (var p in t.GetProperties())
                {
                    string name = p.Name;
                    object value = p.GetValue(model, null);
                    if (value != null)
                    {
                        result.Add(new KeyValuePair<string, string>(name, value.ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

            return result;

        }
    }
}
