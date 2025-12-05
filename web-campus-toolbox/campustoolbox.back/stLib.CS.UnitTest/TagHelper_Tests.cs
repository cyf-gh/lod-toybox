using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace stLib.CS.UnitTest {
    public class TagHelper {
        [Fact]
        public void Full_Contains() {
            List<string> list1 = new List<string> {
                "123",
                "123123",
                "111"
                };
            Assert.True( CS.TagHelper.IsTagsFullMatch( list1, list1 ) );
            List<string> list2 = new List<string> {
                "123",
                "123123",
                "111",
                "22222"
                };
            Assert.True( CS.TagHelper.IsTagsFullMatch( list1, list2 ) );
            Assert.True( CS.TagHelper.IsTagsFullMatch( list2, list1 ) );
        }
    }
}
