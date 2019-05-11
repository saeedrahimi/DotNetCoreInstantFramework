using System;

namespace Core.Domain._Shared.Logger
{

    public enum LogMode
    {
        Non = 0,
        Normal = 2,
        Exception = 3

    }

    public interface ILogger
    {
        void Log(LogMode logMode, string message);


        /// <summary>
        /// Write a log event with the <see cref="F:Serilog.Events.LogEventLevel.Information" /> level.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <example>
        /// Log.Information("Processed {RecordCount} records in {TimeMS}.", records.Length, sw.ElapsedMilliseconds);
        /// </example>
        void Information(string messageTemplate);

        /// <summary>
        /// Write a log event with the <see cref="F:Serilog.Events.LogEventLevel.Information" /> level.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Information("Processed {RecordCount} records in {TimeMS}.", records.Length, sw.ElapsedMilliseconds);
        /// </example>
        void Information<T>(string messageTemplate, T propertyValue);

        /// <summary>
        /// Write a log event with the <see cref="F:Serilog.Events.LogEventLevel.Information" /> level.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Information("Processed {RecordCount} records in {TimeMS}.", records.Length, sw.ElapsedMilliseconds);
        /// </example>
        void Information<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1);

        /// <summary>
        /// Write a log event with the <see cref="F:Serilog.Events.LogEventLevel.Information" /> level.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue2">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Information("Processed {RecordCount} records in {TimeMS}.", records.Length, sw.ElapsedMilliseconds);
        /// </example>
        void Information<T0, T1, T2>(
          string messageTemplate,
          T0 propertyValue0,
          T1 propertyValue1,
          T2 propertyValue2);

        /// <summary>
        /// Write a log event with the <see cref="F:Serilog.Events.LogEventLevel.Information" /> level and associated exception.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValues">Objects positionally formatted into the message template.</param>
        /// <example>
        /// Log.Information("Processed {RecordCount} records in {TimeMS}.", records.Length, sw.ElapsedMilliseconds);
        /// </example>
        void Information(string messageTemplate, params object[] propertyValues);

        /// <summary>
        /// Write a log event with the <see cref="F:Serilog.Events.LogEventLevel.Information" /> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <example>
        /// Log.Information(ex, "Processed {RecordCount} records in {TimeMS}.", records.Length, sw.ElapsedMilliseconds);
        /// </example>
        void Information(Exception exception, string messageTemplate);

        /// <summary>
        /// Write a log event with the <see cref="F:Serilog.Events.LogEventLevel.Information" /> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Information(ex, "Processed {RecordCount} records in {TimeMS}.", records.Length, sw.ElapsedMilliseconds);
        /// </example>
        void Information<T>(Exception exception, string messageTemplate, T propertyValue);

        /// <summary>
        /// Write a log event with the <see cref="F:Serilog.Events.LogEventLevel.Information" /> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Information(ex, "Processed {RecordCount} records in {TimeMS}.", records.Length, sw.ElapsedMilliseconds);
        /// </example>
        void Information<T0, T1>(
          Exception exception,
          string messageTemplate,
          T0 propertyValue0,
          T1 propertyValue1);

        /// <summary>
        /// Write a log event with the <see cref="F:Serilog.Events.LogEventLevel.Information" /> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue2">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Information(ex, "Processed {RecordCount} records in {TimeMS}.", records.Length, sw.ElapsedMilliseconds);
        /// </example>
        void Information<T0, T1, T2>(
          Exception exception,
          string messageTemplate,
          T0 propertyValue0,
          T1 propertyValue1,
          T2 propertyValue2);

        /// <summary>
        /// Write a log event with the <see cref="F:Serilog.Events.LogEventLevel.Information" /> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValues">Objects positionally formatted into the message template.</param>
        /// <example>
        /// Log.Information(ex, "Processed {RecordCount} records in {TimeMS}.", records.Length, sw.ElapsedMilliseconds);
        /// </example>
        void Information(Exception exception, string messageTemplate, params object[] propertyValues);


        /// <summary>
        /// Write a log event with the <see cref="F:Serilog.Events.LogEventLevel.Warning" /> level.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <example>
        /// Log.Warning("Skipped {SkipCount} records.", skippedRecords.Length);
        /// </example>
        void Warning(string messageTemplate);

        /// <summary>
        /// Write a log event with the <see cref="F:Serilog.Events.LogEventLevel.Warning" /> level.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Warning("Skipped {SkipCount} records.", skippedRecords.Length);
        /// </example>
        void Warning<T>(string messageTemplate, T propertyValue);

        /// <summary>
        /// Write a log event with the <see cref="F:Serilog.Events.LogEventLevel.Warning" /> level.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Warning("Skipped {SkipCount} records.", skippedRecords.Length);
        /// </example>
        void Warning<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1);

        /// <summary>
        /// Write a log event with the <see cref="F:Serilog.Events.LogEventLevel.Warning" /> level.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue2">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Warning("Skipped {SkipCount} records.", skippedRecords.Length);
        /// </example>
        void Warning<T0, T1, T2>(
          string messageTemplate,
          T0 propertyValue0,
          T1 propertyValue1,
          T2 propertyValue2);

        /// <summary>
        /// Write a log event with the <see cref="F:Serilog.Events.LogEventLevel.Warning" /> level and associated exception.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValues">Objects positionally formatted into the message template.</param>
        /// <example>
        /// Log.Warning("Skipped {SkipCount} records.", skippedRecords.Length);
        /// </example>
        void Warning(string messageTemplate, params object[] propertyValues);

        /// <summary>
        /// Write a log event with the <see cref="F:Serilog.Events.LogEventLevel.Warning" /> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <example>
        /// Log.Warning(ex, "Skipped {SkipCount} records.", skippedRecords.Length);
        /// </example>
        void Warning(Exception exception, string messageTemplate);

        /// <summary>
        /// Write a log event with the <see cref="F:Serilog.Events.LogEventLevel.Warning" /> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Warning(ex, "Skipped {SkipCount} records.", skippedRecords.Length);
        /// </example>
        void Warning<T>(Exception exception, string messageTemplate, T propertyValue);

        /// <summary>
        /// Write a log event with the <see cref="F:Serilog.Events.LogEventLevel.Warning" /> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Warning(ex, "Skipped {SkipCount} records.", skippedRecords.Length);
        /// </example>
        void Warning<T0, T1>(
          Exception exception,
          string messageTemplate,
          T0 propertyValue0,
          T1 propertyValue1);

        /// <summary>
        /// Write a log event with the <see cref="F:Serilog.Events.LogEventLevel.Warning" /> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue2">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Warning(ex, "Skipped {SkipCount} records.", skippedRecords.Length);
        /// </example>
        void Warning<T0, T1, T2>(
          Exception exception,
          string messageTemplate,
          T0 propertyValue0,
          T1 propertyValue1,
          T2 propertyValue2);

        /// <summary>
        /// Write a log event with the <see cref="F:Serilog.Events.LogEventLevel.Warning" /> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValues">Objects positionally formatted into the message template.</param>
        /// <example>
        /// Log.Warning(ex, "Skipped {SkipCount} records.", skippedRecords.Length);
        /// </example>
        void Warning(Exception exception, string messageTemplate, params object[] propertyValues);

        /// <summary>
        /// Write a log event with the <see cref="F:Serilog.Events.LogEventLevel.Error" /> level.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <example>
        /// Log.Error("Failed {ErrorCount} records.", brokenRecords.Length);
        /// </example>
        void Error(string messageTemplate);

        /// <summary>
        /// Write a log event with the <see cref="F:Serilog.Events.LogEventLevel.Error" /> level.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Error("Failed {ErrorCount} records.", brokenRecords.Length);
        /// </example>
        void Error<T>(string messageTemplate, T propertyValue);

        /// <summary>
        /// Write a log event with the <see cref="F:Serilog.Events.LogEventLevel.Error" /> level.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Error("Failed {ErrorCount} records.", brokenRecords.Length);
        /// </example>
        void Error<T0, T1>(string messageTemplate, T0 propertyValue0, T1 propertyValue1);

        /// <summary>
        /// Write a log event with the <see cref="F:Serilog.Events.LogEventLevel.Error" /> level.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue2">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Error("Failed {ErrorCount} records.", brokenRecords.Length);
        /// </example>
        void Error<T0, T1, T2>(
          string messageTemplate,
          T0 propertyValue0,
          T1 propertyValue1,
          T2 propertyValue2);

        /// <summary>
        /// Write a log event with the <see cref="F:Serilog.Events.LogEventLevel.Error" /> level and associated exception.
        /// </summary>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValues">Objects positionally formatted into the message template.</param>
        /// <example>
        /// Log.Error("Failed {ErrorCount} records.", brokenRecords.Length);
        /// </example>
        void Error(string messageTemplate, params object[] propertyValues);

        /// <summary>
        /// Write a log event with the <see cref="F:Serilog.Events.LogEventLevel.Error" /> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <example>
        /// Log.Error(ex, "Failed {ErrorCount} records.", brokenRecords.Length);
        /// </example>
        void Error(Exception exception, string messageTemplate);

        /// <summary>
        /// Write a log event with the <see cref="F:Serilog.Events.LogEventLevel.Error" /> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Error(ex, "Failed {ErrorCount} records.", brokenRecords.Length);
        /// </example>
        void Error<T>(Exception exception, string messageTemplate, T propertyValue);

        /// <summary>
        /// Write a log event with the <see cref="F:Serilog.Events.LogEventLevel.Error" /> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Error(ex, "Failed {ErrorCount} records.", brokenRecords.Length);
        /// </example>
        void Error<T0, T1>(
          Exception exception,
          string messageTemplate,
          T0 propertyValue0,
          T1 propertyValue1);

        /// <summary>
        /// Write a log event with the <see cref="F:Serilog.Events.LogEventLevel.Error" /> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValue0">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue1">Object positionally formatted into the message template.</param>
        /// <param name="propertyValue2">Object positionally formatted into the message template.</param>
        /// <example>
        /// Log.Error(ex, "Failed {ErrorCount} records.", brokenRecords.Length);
        /// </example>
        void Error<T0, T1, T2>(
          Exception exception,
          string messageTemplate,
          T0 propertyValue0,
          T1 propertyValue1,
          T2 propertyValue2);

        /// <summary>
        /// Write a log event with the <see cref="F:Serilog.Events.LogEventLevel.Error" /> level and associated exception.
        /// </summary>
        /// <param name="exception">Exception related to the event.</param>
        /// <param name="messageTemplate">Message template describing the event.</param>
        /// <param name="propertyValues">Objects positionally formatted into the message template.</param>
        /// <example>
        /// Log.Error(ex, "Failed {ErrorCount} records.", brokenRecords.Length);
        /// </example>
        void Error(Exception exception, string messageTemplate, params object[] propertyValues);
    }
}
