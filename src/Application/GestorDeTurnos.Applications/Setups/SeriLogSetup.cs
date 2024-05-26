using GestorDeTurnos.Application.Constants;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Formatting;
using Serilog.Formatting.Json;
using Serilog.Templates;

namespace GestorDeTurnos.Application.Setups
{
    /// <summary>
    /// Static class for setting up Serilog logging options.
    /// </summary>
    public static class SeriLogSetup
    {
        private static readonly ITextFormatter consoleFormatter = new ExpressionTemplate(OutputTemplate.Console);

        /// <summary>
        /// Configures Serilog logging.
        /// </summary>
        public static readonly Action<HostBuilderContext, LoggerConfiguration> Configure = (hostBuilderContext, loggerConfiguration) =>
        {
            loggerConfiguration
                // Sets the minimum log event level to Information.
                .MinimumLevel.Information()
                // Overrides log event levels for specific namespaces.
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("Serilog.AspNetCore.RequestLoggingMiddleware", LogEventLevel.Fatal)
                .MinimumLevel.Override("System.Net.Http.HttpClient", LogEventLevel.Warning)
                // Configures separate loggers for different log event levels.
                .WriteTo.Logger(options =>
                {
                    options.Filter.ByIncludingOnly(filterOptions =>
                        filterOptions.Level == LogEventLevel.Information)
                        .WriteTo.File(
                            path: "./Logs/Info/log-.json",
                            rollingInterval: RollingInterval.Day,
                            retainedFileCountLimit: 7,
                            formatter: new JsonFormatter()
                        );
                })
                .WriteTo.Logger(options =>
                {
                    options.Filter.ByIncludingOnly(filterOptions =>
                        filterOptions.Level == LogEventLevel.Error)
                        .WriteTo.File(
                            path: "./Logs/Errors/error-.json",
                            rollingInterval: RollingInterval.Day,
                            retainedFileCountLimit: 7,
                            formatter: new JsonFormatter()
                        );
                })
                // Writes log events to the console.
                .WriteTo.Console(formatter: consoleFormatter)
                // Enriches log events with additional information from the logging context.
                .Enrich.FromLogContext();
        };
    }
}