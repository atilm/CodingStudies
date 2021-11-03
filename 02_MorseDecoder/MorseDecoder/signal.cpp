#include "signal.h"

Signal::Signal(list<SignalInterval> intervals)
{
    _intervals = intervals;
}

int Signal::Size()
{
    return _intervals.size();
}

list<SignalInterval>::iterator Signal::GetIterator()
{
    return _intervals.begin();
}
