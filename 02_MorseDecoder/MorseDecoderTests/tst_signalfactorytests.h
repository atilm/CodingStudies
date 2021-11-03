#ifndef TST_SIGNALFACTORYTESTS_H
#define TST_SIGNALFACTORYTESTS_H

#include <../MorseDecoder/signalinterval.h>
#include <signalfactory.h>
#include <gtest/gtest.h>
#include <gmock/gmock-matchers.h>

#include <vector>
#include <tuple>
using namespace std;
using namespace testing;

TEST(SignalFactoryTests, CreateFromString)
{
    auto dot = SignalInterval(1, On);
    auto sep = SignalInterval(1, Off);
    auto dash = SignalInterval(3, Off);
    auto letterSep = SignalInterval(3, Off);

    auto factory = SignalFactory();

    auto signal = factory.Create("._ _.");

    auto expectedSignal = list<SignalInterval> {
            dot,
            sep,
            dash,
            letterSep,
            dash,
            sep,
            dot
    };

    EXPECT_EQ(expectedSignal.size(), signal.Size());

    auto actualIter = signal.GetIterator();
    for (auto expected : expectedSignal) {
        auto actual = *actualIter;

        EXPECT_DOUBLE_EQ(actual.Duration(), expected.Duration());
        EXPECT_EQ(actual.Level(), expected.Level());

        actualIter++;
    }
}

#endif // TST_SIGNALFACTORYTESTS_H
