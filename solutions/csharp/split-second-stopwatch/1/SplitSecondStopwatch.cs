using System;
using System.Collections.Generic;
using System.Linq;

public enum StopwatchState
{
    Ready,
    Running,
    Stopped
}

public class SplitSecondStopwatch(TimeProvider time)
{    
    private readonly List<TimeSpan> _previousLaps = new();
    private TimeSpan _accumulatedTimeInCurrentLap = TimeSpan.Zero;
    private DateTimeOffset? _startTime;

    public StopwatchState State { get; private set; } = StopwatchState.Ready;

    public TimeSpan CurrentLap 
    { 
        get 
        {
            if (State == StopwatchState.Running && _startTime.HasValue)
            {
                return _accumulatedTimeInCurrentLap + (time.GetUtcNow() - _startTime.Value);
            }
            return _accumulatedTimeInCurrentLap;
        }
    }

    public TimeSpan Total => PreviousLaps.Aggregate(TimeSpan.Zero, (t, l) => t + l) + CurrentLap;

    public IReadOnlyCollection<TimeSpan> PreviousLaps => _previousLaps.AsReadOnly();

    public void Start()
    {
        // Valid from Ready or Stopped
        if (State == StopwatchState.Running)
        {
            throw new InvalidOperationException("Stopwatch is already running.");
        }

        _startTime = time.GetUtcNow();
        State = StopwatchState.Running;
    }

    public void Stop()
    {
        // Valid only from Running
        if (State != StopwatchState.Running)
        {
            throw new InvalidOperationException("Stopwatch is not running.");
        }

        _accumulatedTimeInCurrentLap = CurrentLap;
        _startTime = null;
        State = StopwatchState.Stopped;
    }

    public void Lap()
    {
        // Valid only from Running
        if (State != StopwatchState.Running)
        {
            throw new InvalidOperationException("Cannot record a lap while stopped.");
        }

        var lapTime = CurrentLap;
        _previousLaps.Add(lapTime);
        
        _accumulatedTimeInCurrentLap = TimeSpan.Zero;
        _startTime = time.GetUtcNow();
    }

    public void Reset()
    {
        // Valid only from Stopped
        if (State != StopwatchState.Stopped)
        {
            throw new InvalidOperationException("Stopwatch must be stopped to reset.");
        }

        _accumulatedTimeInCurrentLap = TimeSpan.Zero;
        _startTime = null;
        _previousLaps.Clear();
        State = StopwatchState.Ready;
    }
}