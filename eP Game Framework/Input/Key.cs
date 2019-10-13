﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePGameFramework.Input
{
    public enum Key
    {
        LeftButton = 0x01,
        RightButton = 0x02,
        Cancel = 0x03,
        MiddleButton = 0x04,
        XButton1 = 0x05,
        XButton2 = 0x06,
        BackSpace = 0x08,
        Tab = 0x09,
        Clear = 0x0C,
        Return = 0x0D,
        Enter = Return,
        Shift = 0x10,
        Control = 0x11,
        Menu = 0x12,
        Pause = 0x13,
        CapsLock = 0x14,
        IMEKana = 0x15,
        IMEHanguel = IMEKana,
        IMEHangul = IMEKana,
        IMEJunja = 0x17,
        IMEFinal = 0x18,
        IMEHanja = 0x19,
        IMEKanji = IMEHanja,
        Escape = 0x1B,
        IMEConvert = 0x1C,
        IMENonConvvert = 0x1D,
        IMEAccept = 0x1E,
        IMEModeChange = 0x1F,
        SpaceBar = 0x20,
        PageUp = 0x21,
        PageDown = 0x22,
        End = 0x23,
        Home = 0x24,
        Left = 0x25,
        Up = 0x26,
        Right = 0x27,
        Down = 0x28,
        Select = 0x29,
        Print = 0x2A,
        Execute = 0x2B,
        Snapshot = 0x2C,
        Insert = 0x2D,
        Delete = 0x2E,
        Help = 0x2F,
        Key0 = 0x30,
        Key1 = 0x31,
        Key2 = 0x32,
        Key3 = 0x33,
        Key4 = 0x34,
        Key5 = 0x35,
        Key6 = 0x36,
        Key7 = 0x37,
        Key8 = 0x38,
        Key9 = 0x39,
        KeyA = 0x41,
        KeyB = 0x42,
        KeyC = 0x43,
        KeyD = 0x44,
        KeyE = 0x45,
        KeyF = 0x46,
        KeyG = 0x47,
        KeyH = 0x48,
        KeyI = 0x49,
        KeyJ = 0x4A,
        KeyK = 0x4B,
        KeyL = 0x4C,
        KeyM = 0x4D,
        KeyN = 0x4E,
        KeyO = 0x4F,
        KeyP = 0x50,
        KeyQ = 0x51,
        KeyR = 0x52,
        KeyS = 0x53,
        KeyT = 0x54,
        KeyU = 0x55,
        KeyV = 0x56,
        KeyW = 0x57,
        KeyX = 0x58,
        KeyY = 0x59,
        KeyZ = 0x5A,
        LeftWinKey = 0x5B,
        RightWinKey = 0x5C,
        AppsKey = 0x5D,
        Sleep = 0x5F,
        NumPad0 = 0x60,
        NumPad1 = 0x61,
        NumPad2 = 0x62,
        NumPad3 = 0x63,
        NumPad4 = 0x64,
        NumPad5 = 0x65,
        NumPad6 = 0x66,
        NumPad7 = 0x67,
        NumPad8 = 0x68,
        NumPad9 = 0x69,
        Multiply = 0x6A,
        Add = 0x6B,
        Separator = 0x6C,
        Subtract = 0x6D,
        Decimal = 0x6E,
        Divide = 0x6F,
        F1 = 0x70,
        F2 = 0x71,
        F3 = 0x72,
        F4 = 0x73,
        F5 = 0x74,
        F6 = 0x75,
        F7 = 0x76,
        F8 = 0x77,
        F9 = 0x78,
        F10 = 0x79,
        F11 = 0x7A,
        F12 = 0x7B,
        F13 = 0x7C,
        F14 = 0x7D,
        F15 = 0x7E,
        F16 = 0x7F,
        F17 = 0x80,
        F18 = 0x81,
        F19 = 0x82,
        F20 = 0x83,
        F21 = 0x84,
        F22 = 0x85,
        F23 = 0x86,
        F24 = 0x87,
        NumLock = 0x90,
        ScrollLock = 0x91,
        OEM92 = 0x92,
        OEM93 = 0x93,
        OEM94 = 0x94,
        OEM95 = 0x95,
        OEM96 = 0x96,
        LeftShfit = 0xA0,
        RightShfit = 0xA1,
        LeftCtrl = 0xA2,
        RightCtrl = 0xA3,
        LeftMenu = 0xA4,
        RightMenu = 0xA5,
        BrowserBack = 0xA6,
        BrowserForward = 0xA7,
        BrowserRefresh = 0xA8,
        BrowserStop = 0xA9,
        BrowserSearch = 0xAA,
        BrowserFavorites = 0xAB,
        BrowserHome = 0xAC,
        BrowserVolumeMute = 0xAD,
        BrowserVolumeDown = 0xAE,
        BrowserVolumeUp = 0xAF,
        MediaNextTrack = 0xB0,
        MediaPreviousTrack = 0xB1,
        MediaStop = 0xB2,
        MediaPlayPause = 0xB3,
        LaunchMail = 0xB4,
        LaunchMediaSelect = 0xB5,
        LaunchApp1 = 0xB6,
        LaunchApp2 = 0xB7,
        OEM1 = 0xBA,
        OEMPlus = 0xBB,
        OEMComma = 0xBC,
        OEMMinus = 0xBD,
        OEMPeriod = 0xBE,
        OEM2 = 0xBF,
        OEM3 = 0xC0,
        OEM4 = 0xDB,
        OEM5 = 0xDC,
        OEM6 = 0xDD,
        OEM7 = 0xDE,
        OEM8 = 0xDF,
        OEM102 = 0xE2,
        IMEProcess = 0xE5,
        Packet = 0xE7,
        Attn = 0xF6,
        CrSel = 0xF7,
        ExSel = 0xF8,
        EraseEOF = 0xF9,
        Play = 0xFA,
        Zoom = 0xFB,
        PA1 = 0xFD,
        OEMClear = 0xFE
    }
}