function binarySearchIterative(arr: number[], target: number) {
    let left = 0, right = arr.length - 1, mid;
    while (left <= right) {

        mid = Math.floor((left + right) / 2);

        if (arr[mid] === target) {
            console.log('iterative:', mid);
            break;
        }
        if (arr[mid] < target) left = mid + 1;
        if (arr[mid] > target) right = mid - 1;
    }
}

function binarySearchRecursive(arr: number[], target: number, left: number, right: number) {

    const mid = Math.floor((left + right) / 2);

    if (arr[mid] === target) {
        console.log('recursive:', mid); 
        return mid;
    }

    if (arr[mid] < target) return binarySearchRecursive(arr, target, mid + 1, right);
    if (arr[mid] > target) return binarySearchRecursive(arr, target, left, mid - 1);
}



const arr = [1, 3, 5, 7, 9, 11];
const target = 7;

binarySearchIterative(arr, target);
binarySearchRecursive(arr, target, 0, arr.length - 1);