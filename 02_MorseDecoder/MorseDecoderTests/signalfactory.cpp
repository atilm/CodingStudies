#include "signalfactory.h"

SignalFactory::SignalFactory()
{
}

Signal SignalFactory::Create(string signalDefinition)
{
    auto dot = SignalInterval(1, On);
    auto sep = SignalInterval(1, Off);
    auto dash = SignalInterval(3, Off);
    auto letterSep = SignalInterval(3, Off);

    auto intervals = list<SignalInterval> {
            dot,
            sep,
            dash,
            letterSep,
            dash,
            sep,
            dot
    };

    return Signal(intervals);
}
