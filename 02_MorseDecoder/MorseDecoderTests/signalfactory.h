#ifndef SIGNALFACTORY_H
#define SIGNALFACTORY_H


#include <../MorseDecoder/signal.h>

#include <string>
using namespace std;


class SignalFactory
{
public:
    SignalFactory();

    Signal Create(string signalDefinition);
};

#endif // SIGNALFACTORY_H
