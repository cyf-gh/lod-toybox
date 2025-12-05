using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpDX.XInput;

namespace AliveStick.App {
    public class StickManager {


        public Controller[] Controllers { get; set; }
        State[] mStates;

        public StickManager() {
            Controllers = new[]
            {
                new Controller( UserIndex.One ),
                new Controller( UserIndex.Two ),
                new Controller( UserIndex.Three ),
                new Controller( UserIndex.Four )
            };
            mStates = new[] {
                new State(),
                new State(),
                new State(),
                new State(),
            };
            Global.Logger.Info( "Initializor", "Initialized XInput successfully." );
        }

        public void Proc( int index ) {
            var controller = Controllers[index];
            //// var res = controller.SetVibration( new Vibration { LeftMotorSpeed = 535, RightMotorSpeed = 535 } );
            //Console.WriteLine(
            //controller.GetBatteryInformation( BatteryDeviceType.Gamepad ).BatteryLevel.ToString() +
            //controller.GetBatteryInformation( BatteryDeviceType.Gamepad ).BatteryType.ToString()
            //);
            // Poll events from joystick
            if( controller.IsConnected ) {
                var state = controller.GetState();
                if( mStates[index].PacketNumber != state.PacketNumber ) {
                    Console.WriteLine( state.Gamepad );
                }
                SimulateButtons( state );
                SimulateSticks( state );
                mStates[index] = state;
            }
        }

        [DllImport( "user32", CharSet = CharSet.Unicode )]
        public static extern int mouse_event( int dwFlags, int dx, int dy, int dwData, int dwExtraInfo );
        //移动鼠标 
        const int MOUSEEVENTF_MOVE = 0x0001;
        //模拟鼠标左键按下 
        const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        //模拟鼠标左键抬起 
        const int MOUSEEVENTF_LEFTUP = 0x0004;
        //模拟鼠标右键按下 
        const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        //模拟鼠标右键抬起 
        const int MOUSEEVENTF_RIGHTUP = 0x0010;
        //模拟鼠标中键按下 
        const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        //模拟鼠标中键抬起 
        const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        //标示是否采用绝对坐标 
        const int MOUSEEVENTF_ABSOLUTE = 0x8000;

        bool isHasteMove = false;
        bool isClickDown = true;
        List<GamepadButtonFlags> buttonsFlags = new List<GamepadButtonFlags>();

        [DllImport( "User32.dll" )]
        public extern static bool GetCursorPos( ref Point pot );

        [DllImport( "User32.dll" )]
        public extern static void SetCursorPos( int x, int y );

        [DllImport( "user32.dll", EntryPoint = "keybd_event", SetLastError = true )]
        public static extern void keybd_event( Keys bVk, byte bScan, uint dwFlags, uint dwExtraInfo );
        [DllImport( "user32.dll", EntryPoint = "ShowCursor", CharSet = CharSet.Auto )]
        public static extern void ShowCursor( int status );//status:0/1 :隐藏/显示


        void SimulateButtons( State state ) {
            // do something
            isHasteMove = false;

            switch( state.Gamepad.Buttons ) {
                case GamepadButtonFlags.None:
                    ReleaseAll();
                    break;
                case GamepadButtonFlags.DPadUp:
                    PressKey( Keys.Up );

                    break;
                case GamepadButtonFlags.DPadDown:
                    PressKey( Keys.Down );

                    break;
                case GamepadButtonFlags.DPadLeft:
                    PressKey( Keys.Left );

                    break;
                case GamepadButtonFlags.DPadRight:
                    PressKey( Keys.Right );

                    break;
                case GamepadButtonFlags.Start:
                    break;
                case GamepadButtonFlags.Back:
                    break;
                case GamepadButtonFlags.LeftThumb:
                    break;
                case GamepadButtonFlags.RightThumb:
                    break;
                case GamepadButtonFlags.LeftShoulder:
                    PressKey( Keys.F5 );
                    break;
                case GamepadButtonFlags.RightShoulder:
                    isHasteMove = true;
                    break;
                case GamepadButtonFlags.A: {
                    if( !isClickDown ) {
                        RightClickWithCursor();
                    }
                }
                break;
                case GamepadButtonFlags.B: {

                    PressKey( Keys.Enter );
                }
                break;
                case GamepadButtonFlags.X: {
                    if( !isClickDown ) {
                        LeftClickWithCursor();
                    }
                }
                break;
                case GamepadButtonFlags.Y:
                    PressKey( Keys.Up );
                    break;
                default:
                    break;
            }
        }
        public const int KEYEVENTF_KEYUP = 2;

        void PressKey( Keys key ) {
            if( !isClickDown ) {
                keybd_event( key, 0, 0, 0 );
                keybd_event( key, 0, KEYEVENTF_KEYUP, 0 );
                isClickDown = true;
            }
        }

        int MoveValue( int v ) => v / 32767 * 6;

        void SimulateSticks( State state ) {
            var ltx = MoveValue( state.Gamepad.LeftThumbX );
            var lty = MoveValue( state.Gamepad.LeftThumbY );
            if( isHasteMove ) {
                ltx /= 3;
                lty /= 3;
            }
            var pt = GetCursorPoint();
            SetCursorPos( pt.X + ltx, pt.Y - lty );
        }
        void LeftClickWithCursor() {
            Point pt = new Point();
            GetCursorPos( ref pt );
            mouse_event( MOUSEEVENTF_LEFTDOWN, pt.X, pt.Y, 0, 0 );
            mouse_event( MOUSEEVENTF_LEFTUP, pt.X, pt.Y, 0, 0 );
            isClickDown = true;
        }

        void RightClickWithCursor() {
            Point pt = new Point();
            GetCursorPos( ref pt );
            mouse_event( MOUSEEVENTF_RIGHTDOWN, pt.X, pt.Y, 0, 0 );
            mouse_event( MOUSEEVENTF_RIGHTUP, pt.X, pt.Y, 0, 0 );
            isClickDown = true;
        }

        void ReleaseAll() {
            isClickDown = false;
        }

        Point GetCursorPoint() {
            Point pt = new Point();
            GetCursorPos( ref pt );
            return pt;
        }

        void LeftClick( Point pt ) {
            mouse_event( MOUSEEVENTF_LEFTDOWN, pt.X, pt.Y, 0, 0 );
            mouse_event( MOUSEEVENTF_LEFTUP, pt.X, pt.Y, 0, 0 );
        }
    }
}
