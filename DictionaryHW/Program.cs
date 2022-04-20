using System;
using System.Text;
using NLog;
using Unity;

namespace DictionaryExam
{
    class Program
    {
        public static UnityContainer Container { get; set; }

        public static async Task Main(string[] args)
        {
            Container = new UnityContainer();
            var nlogConfig = new NLog.Config.LoggingConfiguration();
            nlogConfig.AddRule(LogLevel.Trace, LogLevel.Fatal,
                new NLog.Targets.FileTarget("fileTarget")
                {
                    FileName = "log.txt"
                });

            NLog.LogManager.Configuration = nlogConfig;
            Logger logger = NLog.LogManager.GetCurrentClassLogger();
            // Register logger;
            Container.RegisterInstance(logger);

            new DictionaryEX(logger).Run();
            //  foreach (var dic in dict)
            //  {
            //      Console.WriteLine(dic);
            //  }
        }
    }


}