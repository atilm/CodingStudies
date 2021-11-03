#ifndef TST_DECODERTESTS_H
#define TST_DECODERTESTS_H

#include <../MorseDecoder/morsedecoder.h>
#include <gtest/gtest.h>
#include <gmock/gmock-matchers.h>

using namespace testing;

TEST(MorseDecoderTests, DecoderTests)
{
    auto decoder = MorseDecoder();

    auto result = decoder.Add(7, 12);

    EXPECT_EQ(result, 19);
}

#endif // TST_DECODERTESTS_H
