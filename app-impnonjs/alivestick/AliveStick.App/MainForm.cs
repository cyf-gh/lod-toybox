using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpDX.XInput;

namespace AliveStick.App {
    public partial class MainForm : Form {

        public Thread Thread { get; set; }

        public static StickManager StickManager = new StickManager();

        List<PictureBox> leds = new List<PictureBox>();

        public MainForm() {
            InitializeComponent();
            leds.Add( led0 );
            leds.Add( led1 );
            leds.Add( led2 );
            leds.Add( led3 );
        }

        /// <summary>
        /// 刷新LED指示灯，提示设备数量
        /// </summary>
        public void FreshLeds() {
            for( Int32 i = 0; i < StickManager.Controllers.Length; i++ ) {
                leds[i].BackColor = StickManager.Controllers[i].IsConnected ? Color.Green : Color.Red;
            }
        }

        private void MainForm_Load( Object sender, EventArgs e ) {
            ledBackgroundWorker.RunWorkerAsync();
            stickBackgroundWorker.RunWorkerAsync();
        }

        private void ledBackgroundWorker_DoWork( Object sender, DoWorkEventArgs e ) {
            while( true ) {
                FreshLeds();
                Thread.Sleep( 100 );
            }
        }

        private void stickBackgroundWorker_DoWork( Object sender, DoWorkEventArgs e ) {
            while( true ) {
                for( int i = 0; i < 4; i++ ) {
                    StickManager.Proc( i );
                    Thread.Sleep( 1 );
                }
            }
        }
    }
}
