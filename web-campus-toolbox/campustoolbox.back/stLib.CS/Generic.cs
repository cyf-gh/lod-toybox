using System.Collections.Generic;
using System.Linq;

namespace stLib.CS.Generic {
    public static class ListHelper {
        public static bool IsIn<T>( List<T> list, T item ) {
            for( int i = 0; i < list.Count; ++i ) {
                if( list[i].Equals( item ) ) {
                    return true;
                }
            }
            return false;
        }
        public static bool RemoveIn<T>( List<T> list, T item ) {
            for( int i = 0; i < list.Count; ++i ) {
                if( list[i].Equals( item ) ) {
                    list.RemoveAt( i );
                    return true;
                }
            }
            return false;
        }

        public static bool ContainsAll<Class>( List<Class> big, List<Class> small ) {
            return small.All( b => big.Any( a => a.Equals( b ) ) );
        }
    }
}
