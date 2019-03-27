using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BeautyCenter.Common.Infra.Logger
{
    public interface ICommonLogger
    {

        //
        // Summary:
        //     Gets a value indicating whether logging is enabled for the Debug level.
        //
        // Returns:
        //     A value of true if logging is enabled for the Debug level, otherwise it returns
        //     false.
        bool IsDebugEnabled { get; }
        //
        // Summary:
        //     Gets a value indicating whether logging is enabled for the Error level.
        //
        // Returns:
        //     A value of true if logging is enabled for the Error level, otherwise it returns
        //     false.
        bool IsErrorEnabled { get; }
        //
        // Summary:
        //     Gets a value indicating whether logging is enabled for the Fatal level.
        //
        // Returns:
        //     A value of true if logging is enabled for the Fatal level, otherwise it returns
        //     false.
        bool IsFatalEnabled { get; }
        //
        // Summary:
        //     Gets a value indicating whether logging is enabled for the Info level.
        //
        // Returns:
        //     A value of true if logging is enabled for the Info level, otherwise it returns
        //     false.
        bool IsInfoEnabled { get; }
        //
        // Summary:
        //     Gets a value indicating whether logging is enabled for the Trace level.
        //
        // Returns:
        //     A value of true if logging is enabled for the Trace level, otherwise it returns
        //     false.
        bool IsTraceEnabled { get; }
        //
        // Summary:
        //     Gets a value indicating whether logging is enabled for the Warn level.
        //
        // Returns:
        //     A value of true if logging is enabled for the Warn level, otherwise it returns
        //     false.
        bool IsWarnEnabled { get; }
        void Error(params object[] query);
        void Error(Exception exception, params object[] query);
        void Error([Localizable(false)] string message, Exception exception, params object[] query);
        void Error([Localizable(false)] string message, params object[] query);
        void Warn([Localizable(false)] string message, Exception exception, params object[] query);
        void Warn([Localizable(false)] string message, params object[] query);
        void Info([Localizable(false)] string message);
        void Info([Localizable(false)] string message, params object[] query);
        void Fatal([Localizable(false)] string message, params object[] query);
        void Fatal([Localizable(false)] string message, Exception exception, params object[] query);

    }
}
