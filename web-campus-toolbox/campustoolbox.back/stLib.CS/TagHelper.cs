using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using stLib.CS.Generic;

namespace stLib.CS {
    public static class TagHelper {
        public const char SplitKey = ',';

        public static List<string> GetTagsFromTagString( string tags ) {
            return new List<string>( tags.Split( SplitKey ) );
        }

        /// <summary>
        /// 目标与源标签只要并集为其中之一，就匹配成功
        /// </summary>
        /// <param name="srcTags"></param>
        /// <param name="tarTags"></param>
        /// <returns></returns>
        public static bool IsTagsFullMatch( List<string> srcTags, List<string> tarTags ) {
            var longerTags = srcTags.Count > tarTags.Count ? srcTags : tarTags;
            var shorterTags = srcTags.Count < tarTags.Count ? srcTags : tarTags;
            return ListHelper.ContainsAll( longerTags, shorterTags );
        }
        /// <summary>
        /// 目标与源标签只要并集为其中之一，就匹配成功
        /// </summary>
        /// <param name="srcTags"></param>
        /// <param name="tarTags"></param>
        /// <returns></returns>
        public static bool IsTagsFullMatch( string srcTag, string tarTag ) {
            var srcTags = GetTagsFromTagString( srcTag );
            var tarTags = GetTagsFromTagString( tarTag );
            var longerTags = srcTags.Count > tarTags.Count ? srcTags : tarTags;
            var shorterTags = srcTags.Count < tarTags.Count ? srcTags : tarTags;
            return ListHelper.ContainsAll( longerTags, shorterTags );
        }
    }
}
