#pragma once
#include <memory>
#include <iostream>
#include <string.h>
#define PP_SWAP( a, b ) if ( &a != &b ) { a ^= b; b ^= a; a ^= b; }
#define PP_SWAPR( a, b ) int c = a; a = b; b = c

#define PP_FUNC_HEADER_ITERATION static inline
#define PP_FUNC_ARG_OUT_ARY  int **out_ppar
#define PP_FUNC_ARG_PP_LEN  PP_FUNC_ARG_OUT_ARY, const unsigned int len
#define PP_SHOWME( name, v ) printf("%s: %d!!!",name, v)
namespace ppalgor {
    /// \brief insertion sort
    /// \note ascend version 
    ///     Focus on where j stops.
    ///     elements rightside of j is absolutly sorted.
    ///     and cur will replace at j
    ///     -- e.g:
    ///         1 3 4 (2)
    ///     ->  1 3 4 4
    ///     ->  1 3 3 4
    ///     ->  1 (2) 3 4
    static inline int* insertion_sort( int **out_ppar, const unsigned int len ) {
        int j = 0;
        int * ar = *out_ppar;
        for( int i = 1; i < len; i++ ) {
            int cur = ar[i];
            for( j = i - 1; j >= 0 && ar[j] > /* change to < then you will get descend version */ cur; j-- ) {
                ar[j+1]=ar[j];
            }
            ar[j+1]=cur;            
        }
        return *out_ppar;
    }

    /// \brief rescursion helper
    static /* inline */ int * insertion_sort_rec_sca( int **out_ppar, const int j, const int cur ) {
        if ( j >= 0 && ( *out_ppar )[j] > cur ) { 
            ( *out_ppar )[j + 1] = ( *out_ppar )[j];
            return insertion_sort_rec_sca( out_ppar, j - 1, cur ); 
        } else {
            ( *out_ppar )[j + 1] = cur; 
            return *out_ppar; 
        }
    }

    /// \breif bubble sort rescursion version
    static /* inline */ int * insertion_sort_rec( int **out_ppar, const unsigned int len, const int n = 0) {
        if ( n < len ) { 
                insertion_sort_rec_sca( out_ppar, n - 1, ( *out_ppar )[n] );
            insertion_sort_rec( out_ppar, len, n + 1 );    
        }
        return *out_ppar;
    }

    /*
    pseudocode

    procedure bubbleSort(A : list of sortable items )
        n = length(A)
        repeat
        swapped = false
        for i = 1 to n-1 inclusive do
            if this pair is out of order
            if A[i] > A[i+1] then
                swap them and remember something changed
                    swap (A[i], A[i+1] )
                    swapped = true
                end if
            end for
        until not swapped
    end procedure
    */
   /// \breif bubble sort
   /// \note ascend version
   ///      which compares the neighbor elements and make sure them in current order
   ///      the last loop must be 0 .. n and no swap operation
   static inline int * bubble_sort( int **out_ppar, const unsigned int len ) {
       int *ar = *out_ppar;
       bool swapped = false;
       
       FROM_BEGIN:
       swapped = false;
       for(size_t i = 0; i < len - 1; i++) {
           if ( ar[i] > ar[i+1] ) {
               // std::cout<< "at ["<< i << "] "<< std::endl << ar[i] << " " << ar[i+1] <<std::endl;
               PP_SWAP( ar[i], ar[i+1] );
               // std::cout<< ar[i] << " " << ar[i+1] << std::endl;
               swapped = true;
           }
       }
       if ( swapped == true ) {
           goto FROM_BEGIN; 
       }
       return ar;
   }

    /// \brief bubble optimisted version
    /// \note bubble sort makes elements right always have been sorted
    ///     the sorted element count is FROM_BEGIN times + 1 and it's at the end of array
    static inline int * bubble_sort_opt( int **out_ppar, const unsigned int len ) {
       int *ar = *out_ppar;
       bool swapped = false;
       int l = len;

       FROM_BEGIN:
       swapped = false;
       for(size_t i = 0; i < l - 1; i++) {
           if ( ar[i] > ar[i+1] ) {
               // std::cout<< "at ["<< i << "] "<< std::endl << ar[i] << " " << ar[i+1] <<std::endl;
               PP_SWAP( ar[i], ar[i+1] );
               // std::cout<< ar[i] << " " << ar[i+1] << std::endl;
               swapped = true;
           }
       }
       if ( swapped == true ) {
           --l;
           goto FROM_BEGIN; 
       }
       return ar;
   }

    /// \brief bubble one more step optimisted version
    /// \note bubble sort makes elements right of the STOPPED POSITION always have been sorted
    static inline int * bubble_sort_opt_2( int **out_ppar, const unsigned int len ) {
       int *ar = *out_ppar;
       int l = len, newn = 0;

        while( l > 1 ){
            for( int i = 0; i < l - 1; i++) {
                if ( ar[i] > ar[i+1] ) {
                    PP_SWAP( ar[i], ar[i+1] );
                    newn = i;                    
                    printf("%d newn: %d\n", i, newn );
                }
            }
            l = newn;
        }
       return ar;
   }

    /// \brief
    /// \param[in_out] out_ppar 
    /// \param[in] p    left most
    /// \param[in] q    center
    /// \param[in] r    right most
    PP_FUNC_HEADER_ITERATION int *merge_sort_merger( int **out_ppar, const int p, const int q, const int r ) {
        int left_len = q - p + 1;
        int right_len = r - q;
        auto phead = *out_ppar;

        // optimistic dual element situation
        if ( left_len == 1 && right_len == 1 && phead[p] > phead[r] ) {
            PP_SWAP( phead[p], phead[r] );
            return *out_ppar;
        }

        int *pL = new int[left_len];
        int *pR = new int[right_len];
        memcpy( pL, phead + p, left_len* sizeof(int) );
        memcpy( pR, phead + q + 1, right_len* sizeof(int) );

        int i = 0, j = 0;
        size_t k;
        for(k = p; k <= r;)
        {
            if ( pL[i] <= pR[j] && i < left_len ) {
                phead[k] = pL[i]; ++i;  k++;
                continue;
            } else { 
                if ( j < right_len ) {
                    phead[k] = pR[j]; ++j;  k++;
                    continue;
                }
            }
            break;
        }

        // attach the rest elements
        for( ;i < left_len; i++, k++)
        {
            phead[k] = pL[i];
        }
        
        for( ;j < right_len; j++, k++)
        {
            phead[k] = pR[j];
        }

        delete [] pL;
        delete [] pR;
        return phead;
    }

    PP_FUNC_HEADER_ITERATION int *merge_sort( PP_FUNC_ARG_PP_LEN, int p = 0, int r = 0 ) {
        if ( p >= r ) { return *out_ppar; }
        int q = ( p + r ) / 2;
        merge_sort( out_ppar, len, p, q );
        merge_sort( out_ppar, len, q + 1, r );
        merge_sort_merger( out_ppar, p, q, r );
        return *out_ppar;
    }

    /// \brief shell gap
    #define PP_ALG_SHELL_GAP( ary_len )  int gap = ary_len / 2; gap > 0; gap /= 2 

    /// \brief shell sort
    PP_FUNC_HEADER_ITERATION int *shell_sort( PP_FUNC_ARG_PP_LEN ) {
        auto phead = *out_ppar;
        for ( PP_ALG_SHELL_GAP( len ) ) {
            for ( int i = gap; i < len; ++i ) {
                //                                      V~~ ascent descent controller
                for( int j = i; j - gap > 0 && phead[j] < phead[j-gap]; j -= gap ) {
                    PP_SWAP( phead[j], phead[j-gap] );
                    // or move element
                }
            }
        }
        return phead;
    }

    /// \brief Lomuto partition scheme
    /// \param[in] lo   default 0
    /// \param[in] hi   default len - 1
    PP_FUNC_HEADER_ITERATION int quick_sort_partition( PP_FUNC_ARG_OUT_ARY, const int lo, const int hi ) {
        auto phead = *out_ppar;
        int pivot = phead[hi];
        int i = lo; // what is i? 

        if ( ( lo == hi - 1 ) && ( phead[lo] < phead[hi] ) ) {
            return i;
        }

        for( size_t j = lo; j < hi -1; j++)
        {
            if ( phead[j] < pivot ) {
                PP_SWAPR( phead[i], phead[j] );
                ++i;
            }
        }

        PP_SWAPR( phead[i], phead[hi] );
        return i;
    }   
    PP_FUNC_HEADER_ITERATION int *quick_sort( PP_FUNC_ARG_OUT_ARY, const int lo, const int hi ) {
        auto phead = *out_ppar;
        if ( lo >= hi ) { return phead; }
        else {  
            int p = quick_sort_partition( out_ppar, lo, hi );
            // quick_sort_partition makes a array which 
            // any of lo to p - 1 < p < any of p + 1 to hi 
            quick_sort( out_ppar, lo, p -1  );
            quick_sort( out_ppar, p + 1, hi );
        }
        return phead;  
    }
}