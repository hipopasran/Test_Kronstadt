namespace Test_Kronstadt
{
    using System.IO;
    using Newtonsoft.Json;

    public class Parser
    {
        public RailRoadData ReadAndFill(string fileName)
        {
            RailRoadData data;

            using (StreamReader file = File.OpenText(fileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                data = JsonConvert.DeserializeObject<RailRoadData>(file.ReadToEnd());
            }

            return data;
        }
    }
}
