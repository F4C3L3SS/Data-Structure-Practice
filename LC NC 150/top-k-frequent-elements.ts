function topKFrequent(nums: number[], k: number): number[] {
    
    let count: Record<number, number> = {};

    // create the count record
    for (const num of nums) {
        count[num] = (count[num] || 0) + 1;
    }
    console.log(count);

    // create an array of arrays which has number and its respective frequency using count record
    const arr: Array<[number, number]> = Object.entries(count).map(
        ([num, freq]) => [freq, Number(num)]
    );
    
    // sort descending and return the first k element with just the keys.
    arr.sort((a, b) => b[0] - a[0]);

    return arr.slice(0, k).map((pair) => pair[1]);
}

topKFrequent([1, 2, 1, 1, 2, 3], 2);