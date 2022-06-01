using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NHibernate;
using NHibernate.SqlCommand;
using NLog;
using NLog.Extensions.Logging;
using Task18.Domain;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;
namespace Task18;

public class CustomInterceptor : EmptyInterceptor
{
    private IConfigurationRoot _config;
    private ServiceProvider _serviceProvider;

    public CustomInterceptor()
    {
        _config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .Build();
        _serviceProvider = new ServiceCollection()
            .AddTransient<Worker>()
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
        var fluenter = _serviceProvider.GetRequiredService<Worker>();
        logger.Debug(sql.ToString());

        return base.OnPrepareStatement(sql);
    }

    public override void AfterTransactionCompletion(ITransaction tx)
    {
        Console.WriteLine($"Transaction Completed");
    }
}