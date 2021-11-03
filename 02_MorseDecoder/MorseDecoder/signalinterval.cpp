#include "signalinterval.h"

SignalInterval::SignalInterval(double duration, SignalLevel level)
{
    _duration = duration;
    _level = level;
}

double SignalInterval::Duration()
{
    return _duration;
}

SignalLevel SignalInterval::Level()
{
    return _level;
}
