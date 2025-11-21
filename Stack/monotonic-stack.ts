type Comparator<T> = (a: T, b: T) => boolean;

function monoStack(cmp: Comparator<number>) {

    let st: number[] = [];

    const ar = [7,5,9,4];

    for (let i = 0; i < ar.length; i++) {
        while (st.length > 0 && cmp(ar[i], st[st.length - 1])) {
            st.pop();
        }
        st.push(ar[i]);
    }
    
    console.log(st);

}

monoStack((cur, top) => cur < top); // increasing order
monoStack((cur, top) => cur > top); // decreasing order


// A monotonic stack is a special type of stack data structure where elements are kept in either increasing or decreasing order

// When a new element is pushed, it is compared with the top of the stack. 
// If the order is violated, elements are popped until the property is restored, and then the new element is pushed.

