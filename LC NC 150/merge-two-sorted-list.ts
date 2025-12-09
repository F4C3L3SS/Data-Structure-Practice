class ListNodeM2 {
    val: number;
    next: ListNodeM2 | null;
    
    constructor(val?: number, next?: ListNodeM2 | null) {
        this.val = val ?? 0;
        this.next = next ?? null;
    }
}

// time complexit - O(N + M). n and m are lengths of 2 linked list
function mergeSortedListM2(list1: ListNodeM2 | null, list2: ListNodeM2 | null): ListNodeM2 | null {

    if (!list1) return list2;
    if (!list2) return list1;
    
    let head : ListNodeM2 | null = null;
    let current: ListNodeM2 | null = null;

    // pick the smallest first node to be head
    if (list1.val < list2.val) {
        head = list1;
        list1 = list1.next;
    } else {
        head = list2;
        list2 = list2.next;
    }

    current = head;

    // iterate the remaining smaller nodes in both lists
    while (list1 !== null && list2 !== null) {

        if (list1.val < list2.val) {
            current.next = list1;
            list1 = list1.next;
        } else {
            current.next = list2;
            list2 = list2.next;
        }
        current = current?.next;
    }

    // finally link the remaining elements in the either linked lists
    current.next = list1 !== null ? list1 : list2;
    
    return head;
}


function recurseMergeSortedListM2(list1: ListNodeM2 | null, list2: ListNodeM2 | null): ListNodeM2 | null {

    if (list1 === null) return list2; // first list is empty
    if (list2 === null) return list1; // second list is empty

    if (list1.val < list2.val) {
        list1.next = recurseMergeSortedListM2(list1.next, list2);
        return list1;
    } else {
        list2.next = recurseMergeSortedListM2(list1, list2.next);
        return list2;
    }
}

function printResultingListM2(head: ListNodeM2 | null) {

    let curr: ListNodeM2|null = head, result = '';
    while (curr !== null) {
        result += curr.val + `->`;
        curr = curr?.next;
    }

    console.log(result);
}

const l1 = new ListNodeM2(1, new ListNodeM2(2, new ListNodeM2(4)));
const l2 = new ListNodeM2(1, new ListNodeM2(3, new ListNodeM2(4)));

// const head = mergeSortedListM2(l1, l2);
// printResultingListM2(head);

const head1 = mergeSortedListM2(l1, l2);
printResultingListM2(head1);

