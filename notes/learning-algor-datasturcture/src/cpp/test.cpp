#include <iostream>
using namespace std;
#include "./sort.h"

#define arr_len_int( arr ) sizeof(arr)/sizeof( int )

void TEST_INSERTIONSORT() {
    int arr[] = { 1, 3, 4, 2, 9, 8, 7 };
    int * pa = arr;
    ppalgor::insertion_sort_rec( &pa, arr_len_int( arr ) );
    for(size_t i = 0; i < arr_len_int(arr); i++)
    {
        cout<< arr[i] << ", ";
    }
    cout<< endl;
}

void TEST_BUBBLESORT() {
    int arr[] = { 1, 3, 4, 2, 9, 8, 7 };
    int * pa = arr;
    ppalgor::bubble_sort_opt_2( &pa, arr_len_int( arr ) );
    for(size_t i = 0; i < arr_len_int(arr); i++)
    {
        cout<< arr[i] << ", ";
    }
    cout<< endl;
}

void TEST_MERGESORT() {
    int arr[] = { 1, 3, 4, 2, 9, 8, 7 };
    int * pa = arr;
    ppalgor::merge_sort( &pa, arr_len_int( arr ), 0, arr_len_int( arr ) - 1 );
    for(size_t i = 0; i < arr_len_int(arr); i++)
    {
        cout<< arr[i] << ", ";
    }
    cout<< endl;  
}

void TEST_SHELLSORT() {
    int arr[] = { 1, 3, 4, 2, 9, 8, 7 };
    int * pa = arr;
    ppalgor::shell_sort( &pa, arr_len_int( arr ) );
    for(size_t i = 0; i < arr_len_int(arr); i++)
    {
        cout<< arr[i] << ", ";
    }
    cout<< endl;  
}

void TEST_QUICKSORT() {
    int arr[] = { 1, 3, 4, 2, 9, 8, 7 };
    int * pa = arr;
    ppalgor::quick_sort( &pa, 0, arr_len_int( arr ) - 1 );
    for(size_t i = 0; i < arr_len_int(arr); i++)
    {
        cout<< arr[i] << ", ";
    }
    cout<< endl;      
}

int main() {
    
    TEST_QUICKSORT();
    return 0;   
}
