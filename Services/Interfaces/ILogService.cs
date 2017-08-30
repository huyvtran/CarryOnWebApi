using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ILogService
    {
        /// <summary>
        /// Create a generic log setting level and message
        /// </summary>
        /// <param name="level">Log level</param>
        /// <param name="message">generic message</param>
        void Log(LogLevel level, string message);

        /// <summary>
        /// Create an Error level log
        /// </summary>
        /// <param name="parameters">method paremeters</param>
        /// <param name="ex">Exception</param>
        void Log(string parameters, Exception ex);

        /// <summary>
        /// Create an Info level log
        /// </summary>
        /// <param name="message">generic message</param>
        void Log(string message);

        /// <summary>
        /// Logs the specified methodCall call.
        /// </summary>
        /// <param name="methodCall">The methodCall call.</param>
        void Log(Expression<Action> methodCall);

        /// <summary>
        /// Logs the specified method call with an exception
        /// </summary>
        /// <param name="methodCall">The method call.</param>
        /// <param name="e">The e.</param>
        void Log(Expression<Action> methodCall, Exception e);

        /// <summary>
        /// Logs the specified method call.
        /// </summary>
        /// <param name="methodCall">The method call.</param>
        /// <param name="otherParams">The other parameters.</param>
        /// <param name="e">The e.</param>
        void Log(Expression<Action> methodCall, Dictionary<string, object> otherParams, Exception e);

        /// <summary>
        /// Generic log Api
        /// </summary>
        /// <param name="level"></param>
        /// <param name="message"></param>
        void LogApi(LogLevel level, string message);

        /// <summary>
        /// Create a generic log api setting level, message and user
        /// </summary>
        /// <param name="level">Log level</param>
        /// <param name="message">generic message</param>
        /// <param name="username">username</param>
        void LogApi(LogLevel level, string message, string username);

        /// <summary>
        /// Logs user calls to api
        /// </summary>
        /// <param name="methodCall"></param>
        /// <param name="username"></param>      
        void LogApi(Expression<Action> methodCall, string username);

        /// <summary>
        /// Logs user calls to api setting level type
        /// </summary>
        /// <param name="level"></param>
        /// <param name="methodCall"></param>
        /// <param name="username"></param>     
        void LogApi(LogLevel level, Expression<Action> methodCall, string username);
    }

    public enum LogLevel
    {
        INFO,
        DEBUG,
        ERROR
    }
}
