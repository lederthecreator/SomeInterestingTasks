using NHibernate;
using NLog;

namespace Task18.Repositories;

public class NLogLoggerFactory : INHibernateLoggerFactory
{
    private readonly LogFactory _factory;

    public NLogLoggerFactory(LogFactory logFactory = null)
    {
        _factory = logFactory ?? LogManager.LogFactory;
    }

    public INHibernateLogger LoggerFor(string keyName)
    {
        return new NLogLogger(_factory.GetLogger(keyName));
    }

    public INHibernateLogger LoggerFor(Type type)
    {
        return new NLogLogger(_factory.GetLogger(type.ToString()));
    }
}

public class NLogLogger : INHibernateLogger
{
    private ILogger _logger;
    
    private readonly Dictionary<NHibernateLogLevel, LogLevel> _levelMapping = new Dictionary<NHibernateLogLevel, LogLevel>() {
        { NHibernateLogLevel.Trace, LogLevel.Trace },
        { NHibernateLogLevel.Debug, LogLevel.Debug },
        { NHibernateLogLevel.Info, LogLevel.Info },
        { NHibernateLogLevel.Warn, LogLevel.Warn },
        { NHibernateLogLevel.Error, LogLevel.Error },
        { NHibernateLogLevel.Fatal, LogLevel.Fatal },
        { NHibernateLogLevel.None, LogLevel.Off },
    };
    
    public NLogLogger(ILogger logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public bool IsEnabled(NHibernateLogLevel logLevel)
    {
        return _logger.IsEnabled(_levelMapping[NHibernateLogLevel.Debug]);
    }

    public void Log(NHibernateLogLevel logLevel, NHibernateLogValues state, Exception exception)
    {
        _logger.Log(_levelMapping[NHibernateLogLevel.Debug], exception, state.Format, state.Args);
    }
}