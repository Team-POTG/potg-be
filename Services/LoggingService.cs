using NLog;

namespace potg.Services;

public class LoggingService
{
    private readonly Logger _logger = LogManager.GetLogger("general_logger");
    private readonly Logger _errorLogger = LogManager.GetLogger("exceiption_logger");

    public LoggingService()
    {
        LogManager.LoadConfiguration("NLog.config");
    }

    public Logger GetLogger() => _logger;

    public Logger GetExceptionLogger() => _errorLogger;
}