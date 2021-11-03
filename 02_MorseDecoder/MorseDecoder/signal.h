#ifndef SIGNAL_H
#define SIGNAL_H

#include <iterator>
#include <list>
#include "signalinterval.h"
using namespace std;


class Signal
{
public:
    Signal(list<SignalInterval> intervals);

    int Size();

    list<SignalInterval>::iterator GetIterator();

    list<SignalInterval> _intervals;
};

#endif // SIGNAL_H
