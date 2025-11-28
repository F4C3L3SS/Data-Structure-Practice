class ListNode {
    val: number;
    next: ListNode | null;
    
    constructor(val?: number, next?: ListNode | null) {
        this.val = val ?? 0;
        this.next = next ?? null;
    }
}

// time complexit - O(N + M). n and m are lengths of 2 linked list
function mergeSortedList(list1: ListNode | null, list2: ListNode | null): ListNode | null {

    if (!list1) return list2;
    if (!list2) return list1;
    
    let head : ListNode | null = null;
    let current: ListNode | null = null;

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


function recurseMergeSortedList(list1: ListNode | null, list2: ListNode | null): ListNode | null {

    if (list1 === null) return list2; // first list is empty
    if (list2 === null) return list1; // second list is empty

    if (list1.val < list2.val) {
        list1.next = recurseMergeSortedList(list1.next, list2);
        return list1;
    } else {
        list2.next = recurseMergeSortedList(list1, list2.next);
        return list2;
    }
}

function printResultingList(head: ListNode | null) {

    let curr: ListNode|null = head, result = '';
    while (curr !== null) {
        result += curr.val + `->`;
        curr = curr?.next;
    }

    console.log(result);
}

const l1 = new ListNode(1, new ListNode(2, new ListNode(4)));
const l2 = new ListNode(1, new ListNode(3, new ListNode(4)));

// const head = mergeSortedList(l1, l2);
// printResultingList(head);

const head1 = mergeSortedList(l1, l2);
printResultingList(head1);

