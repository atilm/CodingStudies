include(gtest_dependency.pri)

TEMPLATE = app
CONFIG += console c++20
CONFIG -= app_bundle
CONFIG += thread
CONFIG -= qt

HEADERS += \
        ../MorseDecoder/morsedecoder.h \
        ../MorseDecoder/signal.h \
        ../MorseDecoder/signalinterval.h \
        signalfactory.h \
        tst_decodertests.h \
        tst_signalfactorytests.h \
        utilities.h

SOURCES += \
        ../MorseDecoder/morsedecoder.cpp \
        ../MorseDecoder/signal.cpp \
        ../MorseDecoder/signalinterval.cpp \
        main.cpp \
        signalfactory.cpp \
        utilities.cpp

SUBDIRS += \
    ../MorseDecoder/MorseDecoder.pro

DISTFILES +=
