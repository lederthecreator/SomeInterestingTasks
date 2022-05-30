using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NHibernate;
using NHibernate.SqlCommand;
using NLog;
using NLog.Extensions.Logging;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace Task20;

public class MyInterceptor : EmptyInterceptor
{
    private IConfigurationRoot _config;
    private ServiceProvider _serviceProvider;

    public MyInterceptor()
    {
        _config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional:true, reloadOnChange:true)
            .Build();
        _serviceProvider = new ServiceCollection()
            .AddTransient<Fluenter>()
            .AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.SetMinimumLevel(LogLevel.Trace);
                loggingBuilder.AddNLog(_config);
            }).BuildServiceProvider();
    }
    public override SqlString OnPrepareStatement(SqlString sql)
    {
        var logger = LogManager.GetCurrentClassLogger();
        var fluenter = _serviceProvider.GetRequiredService<Fluenter>();
        logger.Debug(sql.ToString());

        return base.OnPrepareStatement(sql);
    }

    public override void AfterTransactionCompletion(ITransaction tx)
    {
        Console.WriteLine($"Transaction Completed");
    }
}