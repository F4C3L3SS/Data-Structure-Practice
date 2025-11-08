function selectionSort(arr: number[]) {

    const n = arr.length;
    for (let i = 0; i < n - 1; i++) { // n - 1 coz last element will be largest when every element is placed correctly before this
        let min_idx = i;

        for (let j = i + 1; j < n; j++) {
            if ( arr[j] < arr[min_idx] ) {
                min_idx = j;
            }
        }

        // swap min with current
        let temp = arr[i];
        arr[i] = arr[min_idx];
        arr[min_idx] = temp;
    }

} 

function printArr(arr: number[]) {
    console.log(arr);
}

let arr = [11, 62, 25, 13, 22];
selectionSort(arr);

printArr(arr);


// Time Complexity: O(n2) ,as there are two nested loops:
// One loop to select an element of Array one by one = O(n)
// Another loop to compare that element with every other Array element = O(n)
// Therefore overall complexity = O(n) * O(n) = O(n*n) = O(n2)

// Auxiliary Space: O(1) as the only extra memory used is for temporary variables.