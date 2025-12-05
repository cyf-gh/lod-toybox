using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace CampusToolbox.Security {
    static public class AntiXSSHelper {
        public static string HtmlEntitiesEncode( string text ) {
            // 获取文本字符数组
            char[] chars = HttpUtility.HtmlEncode( text ).ToCharArray();

            // 初始化输出结果
            StringBuilder result = new StringBuilder( text.Length + ( int )( text.Length * 0.1 ) );

            foreach( char c in chars ) {
                // 将指定的 Unicode 字符的值转换为等效的 32 位有符号整数
                int value = Convert.ToInt32( c );

                // 内码为127以下的字符为标准ASCII编码，不需要转换，否则做 &#{数字}; 方式转换
                if( value > 127 ) {
                    result.AppendFormat( "&#{0};", value );
                } else {
                    result.Append( c );
                }
            }

            return result.ToString();
        }
    }
}
