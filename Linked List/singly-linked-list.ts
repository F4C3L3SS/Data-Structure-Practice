class SLLNode<T> {

    value: T;
    next: SLLNode<T> | null = null;

    constructor(value: T) {
        this.value = value;
    }
}

export class SinglyLinkedList<T> {

    private head: SLLNode<T> | null = null;
    private tail: SLLNode<T> | null = null;
    private _size = 0;

    get size() { return this._size }
    get isEmpty() { return this._size === 0; }
    get first() { return this.head?.value ?? null }
    get last() { return this.tail?.value ?? null }

    // add elements at last
    push(value: T) {
        const node = new SLLNode(value);

        if (!this.head) {
            this.head = this.tail = node;
        } else {
            this.tail!.next = node;
            this.tail = node;
        }
        this._size++;
    }

    // pop from tail O(n)
    pop(): T | null {
        // empty linked list
        if (!this.head) return null;

        // only 1 element
        if (this.head === this.tail) {
            const v = this.head.value;
            this.head = this.tail = null;
            this._size = 0;
            return v;
        }

        // more than one element, walk to the node before tail
        let cur = this.head;
        while(cur.next !== this.tail) {
            cur = cur.next!;
        }

        const v = this.tail!.value;
        cur.next = null;
        this.tail = cur;
        this._size--;
        return v;
    }

    // unshift - add to head
    unshift(value: T) {
        const node = new SLLNode(value);

        if (!this.head) {
            this.head = this.tail = node;
        } else {
            node.next = this.head;
            this.head = node;
        }
        this._size++;
    }

    // shift - remove from head
    shift(): T | null {
        if (!this.head) return null;
        const v = this.head.value;
        this.head = this.head.next;

        if (!this.head) this.tail = null;
        this._size--;
        return v;
    }

    // insert at index (0...size) - O(n)
    insertAt(index: number, value: T): boolean {
        if (index < 0 || index > this._size) return false;

        if (index === 0) {
            this.unshift(value);
            return true;
        }

        if (index === this._size) {
            this.push(value);
            return true;
        }

        let prev = this.head!;
        for (let i = 0; i < index - 1; i++) {
            prev = prev.next!;
        }
        const node = new SLLNode(value);
        node.next = prev.next;
        prev.next = node;
        this._size++;
        return true;
    }

    // remove at index - returns remove value or null
    removeAt(index: number): T | null {
        if ( index < 0 || index > this._size || !this.head ) return null;

        if ( index === 0 ) return this.shift();

        let prev = this.head!;
        for (let i = 0; i < index - 1; i++ ) {
            prev = prev.next!;
        }

        const removed = prev.next!;
        prev.next = removed.next;
        if (removed === this.tail) {
            this.tail = prev;
        }
        this._size--;
        return removed.value;
    }

    // find by predicate
    find(predicate: (val: T) => boolean): T | null {
        let cur = this.head;

        while (cur) {
            if (predicate(cur.value)) return cur.value;
            cur = cur.next;
        }

        return null;
    }

    // reverse list in-place O(n)
    reverse() {
        let prev: SLLNode<T> | null = null;

        let cur = this.head;
        this.tail = this.head;

        while(cur) {
            const next = cur.next;
            cur.next = prev;
            prev = cur;
            cur = next;
        }
        this.head = prev;
    }


    print() {
        let cur = this.head;
        let out = '';

        while (cur) {
            out+= `[${cur.value}] -> `;
            cur = cur.next;
        }
        out += 'null';
        console.log(out);
    }

}

const s = new SinglyLinkedList<number>();
s.push(1);
s.push(4);
s.pop();

s.push(12);
s.unshift(14);
s.print();

s.shift();
s.print();

s.insertAt(1, 34);
s.print();

s.removeAt(1);
s.print();

s.push(44);
s.push(123);
s.reverse();
s.print();
