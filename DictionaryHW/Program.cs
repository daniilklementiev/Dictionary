using System;
using System.Text;

namespace DictionaryExam
{
    class Program
    {
        private static String pathEng = "dictionary.ini";
        private static async Task<String> ReadFileAsync(string path)
        {

            return await Task.Run(() =>
            {
                var sb = new StringBuilder();
                using (var reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {
                        sb.AppendLine(reader.ReadLine());
                    }
                }
                return sb.ToString();
            });
        }

        private static async Task<dynamic?> ParseIniAsync(string str)
        {
            return await Task.Run(() =>
            {
                if (str == null)
                {
                    return null;
                }
                var lines = str.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                var ret = new Dictionary<String, String>();
                foreach (var line in lines)
                {
                    var data = line.Split('-');
                    if (data.Length != 2) throw new Exception("Invalid ini format");
                    ret[data[0].Trim()] = data[1].Trim();
                }
                return ret;
            });
        }

        public static async Task Main(string[] args)
        {
            var task = ReadFileAsync("./dictionary.ini")
                      .ContinueWith(task => ParseIniAsync(task.Result).Result) ;
            var dict = await task;
            foreach (var dic in dict)
            {
                Console.WriteLine(dic);
            }
        }
    }


}