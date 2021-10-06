using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;

namespace SmolTAS
{
    public class VirtualInputs
    {
        // Keyboard Input Struct
        [StructLayout(LayoutKind.Sequential)]
        public struct KeyboardInput
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        // Mouse Input Struct
        [StructLayout(LayoutKind.Sequential)]
        public struct MouseInput
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        // Hardware Input struct
        [StructLayout(LayoutKind.Sequential)]
        public struct HardwareInput
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
        }

        // InputUnion
        [StructLayout(LayoutKind.Explicit)]
        public struct InputUnion
        {
            [FieldOffset(0)] public MouseInput mi;
            [FieldOffset(0)] public KeyboardInput ki;
            [FieldOffset(0)] public HardwareInput hi;
        }

        //Input Struct
        public struct Input
        {
            public int type;
            public InputUnion u;
        }

        // Input Type enum
        [Flags]
        public enum InputType
        {
            Mouse = 0,
            Keyboard = 1,
            Hardware = 2
        }

        // Key Event Flag
        [Flags]
        public enum KeyEventF
        {
            KeyDown = 0x0000,
            ExtendedKey = 0x0001,
            KeyUp = 0x0002,
            Unicode = 0x0004,
            Scancode = 0x0008
        }

        // Mouse Event Flag
        [Flags]
        public enum MouseEventF
        {
            Absolute = 0x8000,
            HWheel = 0x01000,
            Move = 0x0001,
            MoveNoCoalesce = 0x2000,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            VirtualDesk = 0x4000,
            Wheel = 0x0800,
            XDown = 0x0080,
            XUp = 0x0100
        }

        // Importing SendInput Function
        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint nInputs, Input[] pInputs, int cbSize);

        // Importing the GetMessageExtraInfo Function
        [DllImport("user32.dll")]
        private static extern IntPtr GetMessageExtraInfo();


        // Inputs for Pressing W
        private static Input[] WPressed = new Input[]
        {
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0,
                        wScan = 0x11, // W
                        dwFlags = (uint)(KeyEventF.KeyDown | KeyEventF.Scancode),
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

        // Inputs for Releasing W
        private static Input[] WReleased = new Input[]
        {
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0,
                        wScan = 0x11, // W
                        dwFlags = (uint)(KeyEventF.KeyUp | KeyEventF.Scancode),
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

        // Inputs for Pressing A
        private static Input[] APressed = new Input[]
        {
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0,
                        wScan = 0x1E, // A
                        dwFlags = (uint)(KeyEventF.KeyDown | KeyEventF.Scancode),
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

        // Inputs for Releasing A
        private static Input[] AReleased = new Input[]
        {
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0,
                        wScan = 0x1E, // A
                        dwFlags = (uint)(KeyEventF.KeyUp | KeyEventF.Scancode),
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

        // Inputs for Pressing S
        private static Input[] SPressed = new Input[]
        {
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0,
                        wScan = 0x1F, // S
                        dwFlags = (uint)(KeyEventF.KeyDown | KeyEventF.Scancode),
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

        // Inputs for Releasing S
        private static Input[] SReleased = new Input[]
        {
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0,
                        wScan = 0x1F, // S
                        dwFlags = (uint)(KeyEventF.KeyUp | KeyEventF.Scancode),
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

        // Inputs for Pressing D
        private static Input[] DPressed = new Input[]
        {
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0,
                        wScan = 0x20, // D
                        dwFlags = (uint)(KeyEventF.KeyDown | KeyEventF.Scancode),
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

        // Inputs for Releasing D
        private static Input[] DReleased = new Input[]
        {
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0,
                        wScan = 0x20, // D
                        dwFlags = (uint)(KeyEventF.KeyUp | KeyEventF.Scancode),
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

        // Inputs for Pressing UP
        private static Input[] UpPressed = new Input[]
        {
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0,
                        wScan = 0xC8, // Up
                        dwFlags = (uint)(KeyEventF.KeyDown | KeyEventF.Scancode),
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

        // Inputs for Releasing UP
        private static Input[] UpReleased = new Input[]
        {
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0,
                        wScan = 0xC8, // Up 
                        dwFlags = (uint)(KeyEventF.KeyUp | KeyEventF.Scancode),
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

        // Inputs for Pressing DOWN
        private static Input[] DownPressed = new Input[]
        {
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0,
                        wScan = 0xD0, // Down
                        dwFlags = (uint)(KeyEventF.KeyDown | KeyEventF.Scancode),
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

        // Inputs for Releasing DOWN
        private static Input[] DownReleased = new Input[]
        {
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0,
                        wScan = 0xD0, // Down
                        dwFlags = (uint)(KeyEventF.KeyUp | KeyEventF.Scancode),
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

        // Inputs for Pressing LEFT
        private static Input[] LeftPressed = new Input[]
        {
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0,
                        wScan = 0xCB, // Left
                        dwFlags = (uint)(KeyEventF.KeyDown | KeyEventF.Scancode),
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

        // Inputs for Releasing LEFT
        private static Input[] LeftReleased = new Input[]
        {
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0,
                        wScan = 0xCB, // Left
                        dwFlags = (uint)(KeyEventF.KeyUp | KeyEventF.Scancode),
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

        // Inputs for Pressing RIGHT
        private static Input[] RightPressed = new Input[]
        {
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0,
                        wScan = 0xCD, // Right
                        dwFlags = (uint)(KeyEventF.KeyDown | KeyEventF.Scancode),
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

        // Inputs for Releasing RIGHT
        private static Input[] RightReleased = new Input[]
        {
            new Input
            {
                type = (int)InputType.Keyboard,
                u = new InputUnion
                {
                    ki = new KeyboardInput
                    {
                        wVk = 0,
                        wScan = 0xCD, // Right
                        dwFlags = (uint)(KeyEventF.KeyUp | KeyEventF.Scancode),
                        dwExtraInfo = GetMessageExtraInfo()
                    }
                }
            }
        };

        //Methods for pressing keys start
        public static void SendWPressed()
        {
            SendInput((uint)WPressed.Length, WPressed, Marshal.SizeOf(typeof(Input)));
        }

        public static void SendWReleased()
        {
            SendInput((uint)WReleased.Length, WReleased, Marshal.SizeOf(typeof(Input)));
        }

        public static void SendAPressed()
        {
            SendInput((uint)APressed.Length, APressed, Marshal.SizeOf(typeof(Input)));
        }

        public static void SendAReleased()
        {
            SendInput((uint)AReleased.Length, AReleased, Marshal.SizeOf(typeof(Input)));
        }

        public static void SendSPressed()
        {
            SendInput((uint)SPressed.Length, SPressed, Marshal.SizeOf(typeof(Input)));
        }

        public static void SendSReleased()
        {
            SendInput((uint)SReleased.Length, SReleased, Marshal.SizeOf(typeof(Input)));
        }

        public static void SendDPressed()
        {
            SendInput((uint)DPressed.Length, DPressed, Marshal.SizeOf(typeof(Input)));
        }

        public static void SendDReleased()
        {
            SendInput((uint)DReleased.Length, DReleased, Marshal.SizeOf(typeof(Input)));
        }

        public static void SendUpPressed()
        {
            SendInput((uint)UpPressed.Length, UpPressed, Marshal.SizeOf(typeof(Input)));
        }

        public static void SendUpReleased()
        {
            SendInput((uint)UpReleased.Length, UpReleased, Marshal.SizeOf(typeof(Input)));
        }

        public static void SendDownPressed()
        {
            SendInput((uint)DownPressed.Length, DownPressed, Marshal.SizeOf(typeof(Input)));
        }

        public static void SendDownReleased()
        {
            SendInput((uint)DownReleased.Length, DownReleased, Marshal.SizeOf(typeof(Input)));
        }

        public static void SendLeftPressed()
        {
            SendInput((uint)LeftPressed.Length, LeftPressed, Marshal.SizeOf(typeof(Input)));
        }

        public static void SendLeftReleased()
        {
            SendInput((uint)LeftReleased.Length, LeftReleased, Marshal.SizeOf(typeof(Input)));
        }

        public static void SendRightPressed()
        {
            SendInput((uint)RightPressed.Length, RightPressed, Marshal.SizeOf(typeof(Input)));
        }

        public static void SendRightReleased()
        {
            SendInput((uint)RightReleased.Length, RightReleased, Marshal.SizeOf(typeof(Input)));
        }
        // Methods For Pressing Keys End
    }
}
