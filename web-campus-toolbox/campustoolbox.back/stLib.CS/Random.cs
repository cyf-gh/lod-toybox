using System;
using System.Collections.Generic;
using System.Text;

namespace stLib.CS {
    static public class Random {
        static public string Number4() {
            System.Random random = new System.Random();
            return random.Next( 1000, 10000 ).ToString();
        }
    }
}
