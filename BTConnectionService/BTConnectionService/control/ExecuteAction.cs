using BTConnectionService.model;
using BTConnectionService.utils;
using WindowsInput;
using WindowsInput.Native;

namespace BTConnectionService.control
{
    class ExecuteAction
    { 
        public static void Execute(WinAction action)
        {
            VirtualKeyCode[][] modifierAndKeys = WinActionParser.ParseAction(action);

            InputSimulator simulator = new InputSimulator();
            simulator.Keyboard.ModifiedKeyStroke(modifierAndKeys[0], modifierAndKeys[1]);
        }
    }
}
