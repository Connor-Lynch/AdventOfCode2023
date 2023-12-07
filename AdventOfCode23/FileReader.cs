using AdventOfCode23.Interfaces;
using Newtonsoft.Json;

namespace AdventOfCode23
{
    public class FileReader : IFileReader
    {
        public List<int> ReadFileToIntArray(string filePath)
        {
            List<int> result;

            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                result = JsonConvert.DeserializeObject<List<int>>(json);
            }

            return result;
        }

        public List<string> ReadFileToStringArray(string filePath)
        {
            List<string> result;

            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                result = JsonConvert.DeserializeObject<List<string>>(json);
            }

            return result;
        }
    }
}
