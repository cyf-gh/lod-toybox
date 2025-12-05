using stLib.CS.Generic;
using System;
using System.Collections.Generic;
using Xunit;

namespace stLib.CS.UnitTest {
    public class Generic {
        [Fact]
        public void List_Equals() {
            List<string> list1 = new List<string> { 
                "123",
                "123123",
                "111"
                };
            Assert.True( ListHelper.ContainsAll( list1, list1 ) );
            List<string> list2 = new List<string> {
                "123",
                "123123",
                "111",
                "22222"
                };
            Assert.True( ListHelper.ContainsAll( list2, list1 ) );
        }
    }
}
