function dailyTemperatures(temp: number[]) {

    const n = temp.length;
    const res = new Array<number>(n).fill(0);

    const stack: number[] = [];

    for ( let i = 0; i < n; i++ ) {

        while (stack.length > 0 && temp[i] > temp[stack[stack.length - 1]] ) {
            const prvIdx = stack.pop()!;
            res[prvIdx] = i - prvIdx; // finding the days between for upcoming warmer day
        }

        stack.push(i);
        console.log(res);
    }

    return res;
} 


console.log(dailyTemperatures([73, 74, 75, 71, 69, 72, 76, 73]));