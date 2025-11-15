function quickSort(arr: number[], low: number, high: number) {

    if (low >= high) return;

    // const pIndex = getPartitionIndexUsingFirst(arr, low, high);
    const pIndex = getPartitionIndexUsingFirst1(arr, low, high);

    quickSort(arr, low, pIndex - 1);
    quickSort(arr, pIndex + 1, high);

}

// find the partition index 
function getPartitionIndexUsingFirst(arr: number[], low: number, high: number): number {
    const pivot = arr[low];
    let i = low, j = high;

    while (i < j) {

        // find the number larger or equal to pivot from left side
        while (arr[i] <= pivot && i <= high - 1) {
            i++;
        }

        // find the number smaller than pivot from right side
        while (arr[j] >= pivot && j >= low + 1) {
            j--;
        }

        // if j has crossed i, swap arr[i] & arr[j]
        if (i < j) {
            swap(arr, i, j);
        }

    }

    // finally swap the pivot with the j
    swap(arr, low, j);

    return j;
}


/**
 * Partition the subarray arr[low..high] using the first element (arr[low]) as the pivot,
 * and return the final index of the pivot after partitioning.
 *
 * Logic:
 * - The pivot is chosen as the first element (arr[low]).
 * - We maintain an index i initialized to low. Elements at indices <= i are guaranteed
 *   to be <= pivot (except pivot itself initially).
 * - Iterate j from low + 1 to high:
 *   - If arr[j] <= pivot, increment i and swap arr[i] with arr[j], expanding the
 *     region of elements less than or equal to the pivot.
 * - Finally swap the pivot (arr[low]) with arr[i] so the pivot is placed in its
 *   correct sorted position, and return i.
 *
 */
function getPartitionIndexUsingFirst1(arr: number[], low: number, high: number): number {
    const pivot = arr[low];
    let i = low;

    for (let j = low + 1; j <= high; j++) {
        if (arr[j] <= pivot) {
            i++;
            swap(arr, i, j);
        }
    }

    swap(arr, low, i);
    return i;
}

function swap(arr: number[], index1: number, index2: number) {
    let temp = arr[index1];
    arr[index1] = arr[index2];
    arr[index2] = temp;
}


const quickSortArr = [4, 6, 2, 5, 7, 9, 1, 3];
quickSort(quickSortArr, 0, quickSortArr.length - 1);
console.log(quickSortArr);