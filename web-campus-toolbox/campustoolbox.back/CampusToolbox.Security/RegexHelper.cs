using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CampusToolbox.Security {
    public class RegexHelper {
        public static bool IsEmail( string checkStr) {
            Match match = Regex.Match( checkStr, @"^\w + ([-+.]\w +) *@\w + ([-.]\w +)*\.\w + ([-.]\w +)*$");
            return match.Success;
        }
    }
}
