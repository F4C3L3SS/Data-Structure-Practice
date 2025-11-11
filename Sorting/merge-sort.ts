function merge(arr: number[], left: number, mid: number, right: number) {

    let n1 = mid - left + 1; // size of left half
    let n2 = right - mid; // size of right half

    // n2 = right - mid + 1 (but mid = mid + 1 in order to get right) n2 = right - (mid + 1) + 1 ~~ right - mid

    // create temp arrays
    const l = new Array(n1);
    const r = new Array(n2);

    for (let i = 0; i < n1; i++) {
        l[i] = arr[left + i];
    }
    for (let j = 0; j < n2; j++) {
        r[j] = arr[mid + 1 + j];
    }

    let i = 0, j = 0, k = left;

    // merge the temp arrays back to the main array
    while (i < n1 && j < n2) {
        if (l[i] < r[j]) {
            arr[k] = l[i];
            i++;
        } else {
            arr[k] = r[j];
            j++;
        }
        k++;
    }

    // add the remaining elements from left to main array
    while ( i < n1 ) {
        arr[k] = l[i];
        i++;
        k++;
    }

    // add the remaining elements from right to main array
    while ( j < n2 ) {
        arr[k] = r[j];
        j++;
        k++;
    }

}


function mergeSort(arr: number[], left: number, right: number) {
    if (left >= right) {
        return;
    }

    const mid = Math.floor( left + (right - left) / 2); // in order to avoid overflow in Low level languages like c++, we do this
    mergeSort(arr, left, mid); // merge sort for left half
    mergeSort(arr, mid + 1, right); // merge sort for right half
    merge(arr, left, mid, right); // merge both the halves
}

const arr = [38, 27, 43, 10];
mergeSort(arr, 0, arr.length - 1);
console.log(arr.join(" "));


// Divide and conquer algorithm
// time complexity - O(N logN) - log N times the array is divided into 2 halves and O(N) time is taken to merge the array
    // worst case and best case - O(N log N)

// space complexity - O(N)