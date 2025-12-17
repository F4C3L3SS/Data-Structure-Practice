// A memoize function is a higher-order function that takes in a function 
// and returns a memoized version of it. The memoized function caches the 
// results of expensive function calls and returns the cached result when 
// it receives the same inputs again. This can significantly improve the 
// performance of functions that involve complex processing / significant 
// latency and are called with the same arguments repeatedly.

// Implement a function memoize(func) that takes in a function parameter 
// func and returns a memoized version of the function. You may assume that 
// func only accepts a string or number as its only argument.


function expensiveFunction(n) {
  console.log('Computing...');
  return n * 2;
}

const memoizedExpensiveFunction = memoize(expensiveFunction);

function memoize(func) {
    let cache = new Map();

    return (...args) => {
        let key = hash(args);
        if (cache.has(key)) {
            return cache.get(key);
        }

        let result = func(...args);

        cache.set(key, result);
        return result;
    }
}

function hash(args) {
    return args[0];
}

// First call (computes and caches the result).
console.log(memoizedExpensiveFunction(5)); // Output: Computing... 10

// Second call with the same argument (returns the cached result).
console.log(memoizedExpensiveFunction(5)); // Output: 10

// Third call with a different argument (computes and caches the new result).
console.log(memoizedExpensiveFunction(10)); // Output: Computing... 20

// Fourth call with the same argument as the third call (returns the cached result).
console.log(memoizedExpensiveFunction(10)); // Output: 20