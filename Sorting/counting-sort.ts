function CountingSort(arr: number[]) {

    const max = Math.max(...arr);
    let count = new Array(max + 1), ans = new Array(arr.length);
    count.fill(0);

    // create the count array
    for (let i = 0; i < arr.length; i++) {
        count[arr[i]]++;
    }


    // compute the prefix sum in order to determine the number of elements and its correct position
    for (let i = 1; i < count.length; i++) {
        count[i] = count[i] + count[i - 1];
    }

    // place the elements in correct position using prefix sum
    for ( let i = arr.length - 1; i >= 0; i-- ) {
        ans[--count[arr[i]]] = arr[i];
    }

    console.log(ans);
}

const arr1 = [4, 2, 2, 3, 1, 6, 4, 6, 9, 9, 6];
CountingSort(arr1);


// Time Complexity: O(N+M) in all cases, where N and M are the size of inputArray[] and countArray[] respectively.
// Auxiliary Space: O(N+M), where N and M are the space taken by outputArray[] and countArray[] respectively.
