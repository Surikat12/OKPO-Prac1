using System.Collections.Generic;
using System.IO;

namespace Prac1
{
    public class Logic
    {
        public string ReadFromFile(string fileName)
        {
            using (var sr = new StreamReader(fileName))
            {
                return sr.ReadToEnd();
            }
        }

        public void WriteToFile(List<string> strings, string fileName)
        {
            using (var sr = new StreamWriter(fileName))
            {
                foreach (var str in strings)
                {
                    sr.Write(str + '\n');
                }
            }
        }

        public List<string> Filter(string text, int lineLength)
        {
            var res = new List<string>();
            foreach (var line in text.Split('\n'))
            {
                if (line.Length < lineLength)
                {
                    res.Add(line);
                }
            }

            return res;
        }
    }
}