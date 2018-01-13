using BTConnectionService.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput.Native;

// TODO unit tests for this...
namespace BTConnectionService.utils
{
    class WinActionParser
    {
        /// <summary>
        /// Returns a multi-dimensional array of VirtualKeyCodes.
        /// This array will have two indices, the first being an 
        /// array of modifier keys, the second being an array of
        /// key presses.
        /// 
        /// Example "CONTROL,SHIFT+S" :
        /// 
        /// [ [VirtualKeyCode.CONTROL, VirtualKeyCode.SHIFT]
        ///   [VirtualKeyCode.VK_S] ]
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static VirtualKeyCode[][] ParseAction(WinAction action)
        {
            string[] splitAction = action.GetActionString().Split('+');

            if (splitAction.Length > 2 || splitAction.Length < 1)
            {
                throw new ArgumentException("Invalid button action definition.", action.GetActionString());
            }

            bool hasModifier = (splitAction.Length == 2);

            VirtualKeyCode[] modifier;
            VirtualKeyCode[] keys;

            if (hasModifier)
            {
                modifier = ParseModifier(splitAction[0]);
                keys = ParseKeys(splitAction[1]);
            }
            else
            {
                modifier = ParseModifier(null);
                keys = ParseKeys(splitAction[0]);
            }

            return new VirtualKeyCode[][] { modifier, keys };
        }

        private static VirtualKeyCode[] ParseModifier(string modifierString)
        {
            if(modifierString == null)
            {
                return new VirtualKeyCode[0];
            }

            List<VirtualKeyCode> keyCodes = new List<VirtualKeyCode>();

            foreach (string modifier in modifierString.Split(','))
            {
                keyCodes.Add(StringToVirtualKeyCode(modifier));
            }

            return keyCodes.ToArray<VirtualKeyCode>();
        }

        private static VirtualKeyCode[] ParseKeys(string keyString)
        {
            if (keyString == null)
            {
                return new VirtualKeyCode[0];
            }

            List<VirtualKeyCode> keyCodes = new List<VirtualKeyCode>();

            foreach (string key in keyString.Split(','))
            {
                keyCodes.Add(StringToVirtualKeyCode(key));
            }

            return keyCodes.ToArray<VirtualKeyCode>();
        }

        /// <summary>
        /// Returns the string representation of a code to it's actual enum value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static VirtualKeyCode StringToVirtualKeyCode(string value)
        {
            switch(value)
            {
                case "LBUTTON": return VirtualKeyCode.LBUTTON;
                case "RBUTTON": return VirtualKeyCode.RBUTTON;
                case "CANCEL": return VirtualKeyCode.CANCEL;
                case "MBUTTON": return VirtualKeyCode.MBUTTON;
                case "XBUTTON1": return VirtualKeyCode.XBUTTON1;
                case "XBUTTON2": return VirtualKeyCode.XBUTTON2;
                case "BACK": return VirtualKeyCode.BACK;
                case "TAB": return VirtualKeyCode.TAB;
                case "CLEAR": return VirtualKeyCode.CLEAR;
                case "RETURN": return VirtualKeyCode.RETURN;
                case "SHIFT": return VirtualKeyCode.SHIFT;
                case "CONTROL": return VirtualKeyCode.CONTROL;
                case "MENU": return VirtualKeyCode.MENU;
                case "PAUSE": return VirtualKeyCode.PAUSE;
                case "CAPITAL": return VirtualKeyCode.CAPITAL;
                case "KANA": return VirtualKeyCode.KANA;
                case "HANGEUL": return VirtualKeyCode.HANGEUL;
                case "HANGUL": return VirtualKeyCode.HANGUL;
                case "JUNJA": return VirtualKeyCode.JUNJA;
                case "FINAL": return VirtualKeyCode.FINAL;
                case "HANJA": return VirtualKeyCode.HANJA;
                case "KANJI": return VirtualKeyCode.KANJI;
                case "ESCAPE": return VirtualKeyCode.ESCAPE;
                case "CONVERT": return VirtualKeyCode.CONVERT;
                case "NONCONVERT": return VirtualKeyCode.NONCONVERT;
                case "ACCEPT": return VirtualKeyCode.ACCEPT;
                case "MODECHANGE": return VirtualKeyCode.MODECHANGE;
                case "SPACE": return VirtualKeyCode.SPACE;
                case "PRIOR": return VirtualKeyCode.PRIOR;
                case "NEXT": return VirtualKeyCode.NEXT;
                case "END": return VirtualKeyCode.END;
                case "HOME": return VirtualKeyCode.HOME;
                case "LEFT": return VirtualKeyCode.LEFT;
                case "UP": return VirtualKeyCode.UP;
                case "RIGHT": return VirtualKeyCode.RIGHT;
                case "DOWN": return VirtualKeyCode.DOWN;
                case "SELECT": return VirtualKeyCode.SELECT;
                case "PRINT": return VirtualKeyCode.PRINT;
                case "EXECUTE": return VirtualKeyCode.EXECUTE;
                case "SNAPSHOT": return VirtualKeyCode.SNAPSHOT;
                case "INSERT": return VirtualKeyCode.INSERT;
                case "DELETE": return VirtualKeyCode.DELETE;
                case "HELP": return VirtualKeyCode.HELP;
                case "0": return VirtualKeyCode.VK_0;
                case "1": return VirtualKeyCode.VK_1;
                case "2": return VirtualKeyCode.VK_2;
                case "3": return VirtualKeyCode.VK_3;
                case "4": return VirtualKeyCode.VK_4;
                case "5": return VirtualKeyCode.VK_5;
                case "6": return VirtualKeyCode.VK_6;
                case "7": return VirtualKeyCode.VK_7;
                case "8": return VirtualKeyCode.VK_8;
                case "9": return VirtualKeyCode.VK_9;
                case "A": return VirtualKeyCode.VK_A;
                case "B": return VirtualKeyCode.VK_B;
                case "C": return VirtualKeyCode.VK_C;
                case "D": return VirtualKeyCode.VK_D;
                case "E": return VirtualKeyCode.VK_E;
                case "F": return VirtualKeyCode.VK_F;
                case "G": return VirtualKeyCode.VK_G;
                case "H": return VirtualKeyCode.VK_H;
                case "I": return VirtualKeyCode.VK_I;
                case "J": return VirtualKeyCode.VK_J;
                case "K": return VirtualKeyCode.VK_K;
                case "L": return VirtualKeyCode.VK_L;
                case "M": return VirtualKeyCode.VK_M;
                case "N": return VirtualKeyCode.VK_N;
                case "O": return VirtualKeyCode.VK_O;
                case "P": return VirtualKeyCode.VK_P;
                case "Q": return VirtualKeyCode.VK_Q;
                case "R": return VirtualKeyCode.VK_R;
                case "S": return VirtualKeyCode.VK_S;
                case "T": return VirtualKeyCode.VK_T;
                case "U": return VirtualKeyCode.VK_U;
                case "V": return VirtualKeyCode.VK_V;
                case "W": return VirtualKeyCode.VK_W;
                case "X": return VirtualKeyCode.VK_X;
                case "Y": return VirtualKeyCode.VK_Y;
                case "Z": return VirtualKeyCode.VK_Z;
                case "a": return VirtualKeyCode.VK_A;
                case "b": return VirtualKeyCode.VK_B;
                case "c": return VirtualKeyCode.VK_C;
                case "d": return VirtualKeyCode.VK_D;
                case "e": return VirtualKeyCode.VK_E;
                case "f": return VirtualKeyCode.VK_F;
                case "g": return VirtualKeyCode.VK_G;
                case "h": return VirtualKeyCode.VK_H;
                case "i": return VirtualKeyCode.VK_I;
                case "j": return VirtualKeyCode.VK_J;
                case "k": return VirtualKeyCode.VK_K;
                case "l": return VirtualKeyCode.VK_L;
                case "m": return VirtualKeyCode.VK_M;
                case "n": return VirtualKeyCode.VK_N;
                case "o": return VirtualKeyCode.VK_O;
                case "p": return VirtualKeyCode.VK_P;
                case "q": return VirtualKeyCode.VK_Q;
                case "r": return VirtualKeyCode.VK_R;
                case "s": return VirtualKeyCode.VK_S;
                case "t": return VirtualKeyCode.VK_T;
                case "u": return VirtualKeyCode.VK_U;
                case "v": return VirtualKeyCode.VK_V;
                case "w": return VirtualKeyCode.VK_W;
                case "x": return VirtualKeyCode.VK_X;
                case "y": return VirtualKeyCode.VK_Y;
                case "z": return VirtualKeyCode.VK_Z;
                case "LWIN": return VirtualKeyCode.LWIN;
                case "RWIN": return VirtualKeyCode.RWIN;
                case "APPS": return VirtualKeyCode.APPS;
                case "SLEEP": return VirtualKeyCode.SLEEP;
                case "NUMPAD0": return VirtualKeyCode.NUMPAD0;
                case "NUMPAD1": return VirtualKeyCode.NUMPAD1;
                case "NUMPAD2": return VirtualKeyCode.NUMPAD2;
                case "NUMPAD3": return VirtualKeyCode.NUMPAD3;
                case "NUMPAD4": return VirtualKeyCode.NUMPAD4;
                case "NUMPAD5": return VirtualKeyCode.NUMPAD5;
                case "NUMPAD6": return VirtualKeyCode.NUMPAD6;
                case "NUMPAD7": return VirtualKeyCode.NUMPAD7;
                case "NUMPAD8": return VirtualKeyCode.NUMPAD8;
                case "NUMPAD9": return VirtualKeyCode.NUMPAD9;
                case "MULTIPLY": return VirtualKeyCode.MULTIPLY;
                case "ADD": return VirtualKeyCode.ADD;
                case "SEPARATOR": return VirtualKeyCode.SEPARATOR;
                case "SUBTRACT": return VirtualKeyCode.SUBTRACT;
                case "DECIMAL": return VirtualKeyCode.DECIMAL;
                case "DIVIDE": return VirtualKeyCode.DIVIDE;
                case "F1": return VirtualKeyCode.F1;
                case "F2": return VirtualKeyCode.F2;
                case "F3": return VirtualKeyCode.F3;
                case "F4": return VirtualKeyCode.F4;
                case "F5": return VirtualKeyCode.F5;
                case "F6": return VirtualKeyCode.F6;
                case "F7": return VirtualKeyCode.F7;
                case "F8": return VirtualKeyCode.F8;
                case "F9": return VirtualKeyCode.F9;
                case "F10": return VirtualKeyCode.F10;
                case "F11": return VirtualKeyCode.F11;
                case "F12": return VirtualKeyCode.F12;
                case "F13": return VirtualKeyCode.F13;
                case "F14": return VirtualKeyCode.F14;
                case "F15": return VirtualKeyCode.F15;
                case "F16": return VirtualKeyCode.F16;
                case "F17": return VirtualKeyCode.F17;
                case "F18": return VirtualKeyCode.F18;
                case "F19": return VirtualKeyCode.F19;
                case "F20": return VirtualKeyCode.F20;
                case "F21": return VirtualKeyCode.F21;
                case "F22": return VirtualKeyCode.F22;
                case "F23": return VirtualKeyCode.F23;
                case "F24": return VirtualKeyCode.F24;
                case "NUMLOCK": return VirtualKeyCode.NUMLOCK;
                case "SCROLL": return VirtualKeyCode.SCROLL;
                case "LSHIFT": return VirtualKeyCode.LSHIFT;
                case "RSHIFT": return VirtualKeyCode.RSHIFT;
                case "LCONTROL": return VirtualKeyCode.LCONTROL;
                case "RCONTROL": return VirtualKeyCode.RCONTROL;
                case "LMENU": return VirtualKeyCode.LMENU;
                case "RMENU": return VirtualKeyCode.RMENU;
                case "BROWSER_BACK": return VirtualKeyCode.BROWSER_BACK;
                case "BROWSER_FORWARD": return VirtualKeyCode.BROWSER_FORWARD;
                case "BROWSER_REFRESH": return VirtualKeyCode.BROWSER_REFRESH;
                case "BROWSER_STOP": return VirtualKeyCode.BROWSER_STOP;
                case "BROWSER_SEARCH": return VirtualKeyCode.BROWSER_SEARCH;
                case "BROWSER_FAVORITES": return VirtualKeyCode.BROWSER_FAVORITES;
                case "BROWSER_HOME": return VirtualKeyCode.BROWSER_HOME;
                case "VOLUME_MUTE": return VirtualKeyCode.VOLUME_MUTE;
                case "VOLUME_DOWN": return VirtualKeyCode.VOLUME_DOWN;
                case "VOLUME_UP": return VirtualKeyCode.VOLUME_UP;
                case "MEDIA_NEXT_TRACK": return VirtualKeyCode.MEDIA_NEXT_TRACK;
                case "MEDIA_PREV_TRACK": return VirtualKeyCode.MEDIA_PREV_TRACK;
                case "MEDIA_STOP": return VirtualKeyCode.MEDIA_STOP;
                case "MEDIA_PLAY_PAUSE": return VirtualKeyCode.MEDIA_PLAY_PAUSE;
                case "LAUNCH_MAIL": return VirtualKeyCode.LAUNCH_MAIL;
                case "LAUNCH_MEDIA_SELECT": return VirtualKeyCode.LAUNCH_MEDIA_SELECT;
                case "LAUNCH_APP1": return VirtualKeyCode.LAUNCH_APP1;
                case "LAUNCH_APP2": return VirtualKeyCode.LAUNCH_APP2;
                case "OEM_1": return VirtualKeyCode.OEM_1;
                case "OEM_PLUS": return VirtualKeyCode.OEM_PLUS;
                case "OEM_COMMA": return VirtualKeyCode.OEM_COMMA;
                case "OEM_MINUS": return VirtualKeyCode.OEM_MINUS;
                case "OEM_PERIOD": return VirtualKeyCode.OEM_PERIOD;
                case "OEM_2": return VirtualKeyCode.OEM_2;
                case "OEM_3": return VirtualKeyCode.OEM_3;
                case "OEM_4": return VirtualKeyCode.OEM_4;
                case "OEM_5": return VirtualKeyCode.OEM_5;
                case "OEM_6": return VirtualKeyCode.OEM_6;
                case "OEM_7": return VirtualKeyCode.OEM_7;
                case "OEM_8": return VirtualKeyCode.OEM_8;
                case "OEM_102": return VirtualKeyCode.OEM_102;
                case "PROCESSKEY": return VirtualKeyCode.PROCESSKEY;
                case "PACKET": return VirtualKeyCode.PACKET;
                case "ATTN": return VirtualKeyCode.ATTN;
                case "CRSEL": return VirtualKeyCode.CRSEL;
                case "EXSEL": return VirtualKeyCode.EXSEL;
                case "EREOF": return VirtualKeyCode.EREOF;
                case "PLAY": return VirtualKeyCode.PLAY;
                case "ZOOM": return VirtualKeyCode.ZOOM;
                case "NONAME": return VirtualKeyCode.NONAME;
                case "PA1": return VirtualKeyCode.PA1;
                case "OEM_CLEAR": return VirtualKeyCode.OEM_CLEAR;
                default:
                    throw new ArgumentException("Unknown input.", value);
            }
        }
    }
}
