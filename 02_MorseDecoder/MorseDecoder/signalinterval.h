#ifndef SIGNALINTERVAL_H
#define SIGNALINTERVAL_H

enum SignalLevel {
    On,
    Off
};

class SignalInterval
{
public:
    SignalInterval(double duration, SignalLevel level);

    double Duration();
    SignalLevel Level();

private:
    double _duration;
    SignalLevel _level;
};

#endif // SIGNALINTERVAL_H
