using System;

// Task 1 & 2 & 3: Define the enum with explicit values
enum LogLevel
{
    Unknown = 0,
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42
}

static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine)
    {
        // Extract the code between the brackets: [TRC] -> TRC
        string code = logLine.Substring(1, 3);

        // Task 1 & 2: Map the string code to the Enum
        return code switch
        {
            "TRC" => LogLevel.Trace,
            "DBG" => LogLevel.Debug,
            "INF" => LogLevel.Info,
            "WRN" => LogLevel.Warning,
            "ERR" => LogLevel.Error,
            "FTL" => LogLevel.Fatal,
            _     => LogLevel.Unknown
        };
    }

    public static string OutputForShortLog(LogLevel logLevel, string message)
    {
        // Task 3: Cast the enum to an int to get its numeric value
        int numericLevel = (int)logLevel;
        return $"{numericLevel}:{message}";
    }
}