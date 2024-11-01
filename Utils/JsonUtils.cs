using Newtonsoft.Json;


namespace IntroductionCSharp.Utils
{
    public class JsonUtils
    {
        public static T Deserialize<T>(string content)
        {

            ArgumentNullException.ThrowIfNull(content);

            var json = JsonConvert.DeserializeObject<T>(content);

            ArgumentNullException.ThrowIfNull(json);

            return json;
        }
    }
}
