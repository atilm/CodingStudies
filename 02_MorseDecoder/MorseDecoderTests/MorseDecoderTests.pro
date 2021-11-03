include(gtest_dependency.pri)

TEMPLATE = app
CONFIG += console c++11
CONFIG -= app_bundle
CONFIG += thread
CONFIG -= qt

HEADERS += \
        ../MorseDecoder/morsedecoder.h \
        tst_decodertests.h

SOURCES += \
        ../MorseDecoder/morsedecoder.cpp \
        main.cpp

SUBDIRS += \
    ../MorseDecoder/MorseDecoder.pro

DISTFILES +=
