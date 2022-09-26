namespace Clients;

using Microsoft.Extensions.DependencyInjection;

using SimpleRpc.Serialization.Hyperion;
using SimpleRpc.Transports;
using SimpleRpc.Transports.Http.Client;

using NLog;

using Services;

/// <summary>
/// Client example.
/// </summary>
class Client
{
    /// <summary>
    /// Logger for this class.
    /// </summary>
    Logger log = LogManager.GetCurrentClassLogger();

    /// <summary>
    /// Configures logging subsystem.
    /// </summary>
    private void ConfigureLogging()
    {
        var config = new NLog.Config.LoggingConfiguration();

        var console =
            new NLog.Targets.ConsoleTarget("console")
            {
                Layout = @"${date:format=HH\:mm\:ss}|${level}| ${message} ${exception}"
            };
        config.AddTarget(console);
        config.AddRuleForAllLevels(console);

        LogManager.Configuration = config;
    }

    /// <summary>
    /// Program body.
    /// </summary>
    private void Run()
    {
        //configure logging
        ConfigureLogging();

        //run everythin in a loop to recover from connection errors
        while (true)
        {
            try
            {
                //connect to the server, get service client proxy
                var sc = new ServiceCollection();
                sc
                    .AddSimpleRpcClient(
                        "service",
                        new HttpClientTransportOptions
                        {
                            Url = "http://127.0.0.1:5000/simplerpc",
                            Serializer = "HyperionMessageSerializer"
                        }
                    )
                    .AddSimpleRpcHyperionSerializer();

                sc.AddSimpleRpcProxy<IService>("service");

                var sp = sc.BuildServiceProvider();

                var service = sp.GetService<IService>();

                //use service
                var rnd = new Random();
                while (true)
                {
                    var structure = new WaterContainer();
                    var filledStructure = service.GetBounds(structure);
                    log.Info($"Upper bound - {filledStructure.UpperBound}\nLower bound - {filledStructure.LowerBound}");
                    var newCapacity = service.SubtractLiquid();

                    // paklausia ar gali nupilti
                    // jeigu gali nupilti, tai nupila sugeneruota kieki, taciau jeigu sugeneruotas kiekis yra didesnis
                    // tai nupila tiek kiek gali, o likusi kieki išlog'ina: 
                    // "Sugeneruotas kiekis - 15L, užpiltas kiekis - 10L, riba viršyta - 5L"

                    Thread.Sleep(2000);

                    if (newCapacity == 0)
                    {
                        log.Info("I did not need to pump out the liquid");
                    }
                    else
                    {
                        log.Info($"I pumped out the liquid, new capacity is {newCapacity}");
                    }
                    log.Info("---");

                    Thread.Sleep(2000);
                }
            }
            catch (Exception e)
            {
                //log whatever exception to console
                log.Warn(e, "Unhandled exception caught. Will restart main loop.");

                //prevent console spamming
                Thread.Sleep(2000);
            }
        }
    }

    /// <summary>
    /// Program entry point.
    /// </summary>
    /// <param name="args">Command line arguments.</param>
    static void Main(string[] args)
    {
        var self = new Client();
        self.Run();
    }
}
