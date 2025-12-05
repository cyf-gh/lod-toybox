using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AliveStick.App {
    public class LoggingHelper {
        public TextBox OutputLabel { get; set; } = null;
        public string Context { get; set; } = "";
        public void Info( string name, string description ) {
            // Context += string.Format( "- [{0}] :: {1}\n", name, description );
            Console.WriteLine( string.Format( "- [{0}] :: {1}\n", name, description )  );
            //if( OutputLabel != null ) {
            //    OutputLabel.Text = Context;
            //}
        }
    }
}
