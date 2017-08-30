using log4net;
using log4net.Config;
using log4net.Core;
using Services.Helpers;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Log4NetLogService : ILogService
    {
        private static readonly ILog logger = LogManager.GetLogger("RollingFileAppender");
        private static readonly ILog loggerApi = LogManager.GetLogger("RollingFileAppenderApi");
        private IConfigurationProvider CurrentConfig;

        /// <summary>
        /// Initializes the <see cref="Log4NetLogService"/> class.
        /// </summary>
        static Log4NetLogService()
        {
            XmlConfigurator.Configure();
        }

        public Log4NetLogService(IConfigurationProvider conf)
        {
            CurrentConfig = conf;
        }

        /// <summary>
        /// Create a generic log setting level and message
        /// </summary>
        /// <param name="level">Log level</param>
        /// <param name="message">generic message</param>
        public void Log(LogLevel level, string message)
        {
            var logData = new LoggingEventData();
            logData.Level = GetLog4NetLevel(level);
            logData.Message = message;
            logData.TimeStamp = DateTime.Now;
            logger.Logger.Log(new LoggingEvent(logData));

        }
        /// <summary>
        /// Create an Info level log
        /// </summary>
        /// <param name="message">generic message</param>
        public void Log(string message)
        {
            Log(LogLevel.INFO, message);
        }

        /// <summary>
        /// Create an Error level log
        /// </summary>
        /// <param name="parameters">method paremeters</param>
        /// <param name="ex">Exception</param>
        public void Log(string parameters, Exception ex)
        {
            if (ex.InnerException != null)
            {
                //if inner exception exists we have to write it
                Log(LogLevel.ERROR, ex.Message + "INNER :" + ex.InnerException + ", PARAMETERS:" + parameters + ",STACKTRACE :" + ex.StackTrace);
            }
            else
            {
                Log(LogLevel.ERROR, ex.Message + ", PARAMETERS:" + parameters + ", STACKTRACE :" + ex.StackTrace);
            }
        }

        /// <summary>
        /// Coversion to Log4Net level enumeration
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        private Level GetLog4NetLevel(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.INFO:
                    return Level.Info;
                case LogLevel.DEBUG:
                    return Level.Debug;
                case LogLevel.ERROR:
                    return Level.Error;
                default:
                    return Level.Error;
            }
        }

        /// <summary>
        /// Logs the specified mathod call.
        /// </summary>
        /// <param name="methodCall">The mathod call.</param>
        public void Log(Expression<Action> methodCall)
        {
            if (CurrentConfig.EnableTracing)
            {
                var logMessage = new StringBuilder();
                LogMessage(methodCall, logMessage);
            }
        }

        /// <summary>
        /// Create a generic log api setting level and message
        /// </summary>
        /// <param name="level">Log level</param>
        /// <param name="message">generic message</param>
        public void LogApi(LogLevel level, string message)
        {
            var logData = new LoggingEventData();
            logData.Level = GetLog4NetLevel(level);
            logData.Message = message;
            logData.TimeStamp = DateTime.Now;
            loggerApi.Logger.Log(new LoggingEvent(logData));

        }

        /// <summary>
        /// Create a generic log api setting level, message and user
        /// </summary>
        /// <param name="level">Log level</param>
        /// <param name="message">generic message</param>
        /// <param name="username">username</param>
        public void LogApi(LogLevel level, string message, string username)
        {
            var logMessage = new StringBuilder();
            logMessage.Append("Username: " + username + "; ");
            logMessage.Append(message);
            LogApi(level, logMessage.ToString());
        }

        /// <summary>
        /// Log api method called and username
        /// </summary>
        /// <param name="methodCall"></param>
        /// <param name="username"></param>
        public void LogApi(Expression<Action> methodCall, string username)
        {
            LogApi(LogLevel.INFO, methodCall, username);
        }

        /// <summary>
        /// Log api method called and username with specific log level
        /// </summary>
        /// <param name="level"></param>
        /// <param name="methodCall"></param>
        /// <param name="username"></param>
        public void LogApi(LogLevel level, Expression<Action> methodCall, string username)
        {
            if (CurrentConfig.EnableApiTracing)
            {
                var logMessage = new StringBuilder();
                logMessage.Append("Username: " + username + "; ");
                LogMessage(methodCall, logMessage, true);
            }
        }

        private void LogMessage(Expression<Action> methodCall, StringBuilder logMessage, bool isApiLog = false, Exception e = null)
        {
            try
            {
                if (methodCall == null) return;

                var body = (MethodCallExpression)methodCall.Body;

                logMessage.Append("CALL TO: " + body.Method.DeclaringType.ToString() + "." + body.Method.Name);

                logMessage.Append(", PARAMETERS:");
                if (body.Arguments.Count > 0)
                {
                    foreach (Expression a in body.Arguments)
                    {
                        var member = a as MemberExpression;
                        if (member != null)
                        {
                            if (((ConstantExpression)member.Expression) != null)
                            {
                                logMessage.Append(((FieldInfo)member.Member).Name + "=" + LogHelper.Inspect(((FieldInfo)member.Member).GetValue(((ConstantExpression)member.Expression).Value)) + LogHelper.PARAMETER_SEPARATOR);
                            }
                            else
                            {
                                logMessage.Append(((FieldInfo)member.Member).Name + "=" + "NO VALUE" + LogHelper.PARAMETER_SEPARATOR);
                            }
                        }
                    }
                    logMessage.Remove(logMessage.Length - LogHelper.PARAMETER_SEPARATOR.Length, LogHelper.PARAMETER_SEPARATOR.Length);//Remove the last PARAMETER_SEPARATOR character
                }
                else
                {
                    logMessage.Append(" no");
                }


                if (e != null)
                {
                    logMessage.Append(e.Message);
                    if (e.InnerException != null)
                    {
                        //if inner exception exists we have to write it
                        logMessage.Append(e.Message + "INNER :" + e.InnerException);
                    }

                    logMessage.Append(", STACKTRACE :" + e.StackTrace);

                }

                // isApiLog = flag of log type, if is true then it is writting the log of type api (user access API )
                if (e != null)
                {
                    Log(LogLevel.ERROR, logMessage.ToString());
                }
                else if (isApiLog)
                {
                    LogApi(LogLevel.INFO, logMessage.ToString());
                }
                else
                {
                    Log(LogLevel.DEBUG, logMessage.ToString());
                }

            }
            catch (Exception ex)
            {
                Log(LogLevel.ERROR, "Unable to trace method call: " + ex.Message);
            }
        }

        /// <summary>
        /// Logs the specified methodCall call with exceptions.
        /// </summary>
        /// <param name="methodCall">The methodCall call.</param>
        /// <param name="e"></param>
        public void Log(Expression<Action> methodCall, Exception e)
        {
            var logMessage = new StringBuilder();
            LogMessage(methodCall, logMessage, false, e);
        }


        /// <summary>
        /// Logs the specified method call.
        /// </summary>
        /// <param name="methodCall">The method call with parameters</param>
        /// <param name="otherParams">The other parameters.</param>
        /// <param name="e">The exception</param>
        public void Log(Expression<Action> methodCall, Dictionary<string, object> otherParams, Exception e)
        {
            var logMessage = new StringBuilder();
            if (otherParams != null)
            {
                logMessage.Append("OTHER PARAMETERS: ");
                foreach (var ele in otherParams)
                {
                    logMessage.Append(ele.Key + "=" + LogHelper.Inspect(ele.Value) + LogHelper.PARAMETER_SEPARATOR);
                }
                logMessage.Remove(logMessage.Length - LogHelper.PARAMETER_SEPARATOR.Length, LogHelper.PARAMETER_SEPARATOR.Length);//Remove the last PARAMETER_SEPARATOR character
            }
            LogMessage(methodCall, logMessage, false, e);
        }


    }
}
