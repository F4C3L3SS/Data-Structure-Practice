class ListNode {
    val: number;
    next: ListNode | null;
    
    constructor(val?: number, next?: ListNode | null) {
        this.val = val ?? 0;
        this.next = next ?? null;
    }
}

function mergeSortedList(list1: ListNode | null, list2: ListNode | null): ListNode | null {
    if (!list1) return list2;
    if (!list2) return list1;
    
    let head : ListNode | null = null;
    let current: ListNode | null = null;

    if (list1.val < list2.val) {
        head = list1;
        list1 = list1.next;
    } else {
        head = list2;
        list2 = list2.next;
    }

    current = head;

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

    current.next = list1 !== null ? list1 : list2;
    
    return head;
}

function mergeKSortedLists(lists: Array<ListNode | null>): ListNode | null {
    if (lists.length === 0) return null;

    return mergeRange(lists, 0, lists.length - 1);
}

function mergeRange(lists: Array<ListNode | null>, left: number, right: number): ListNode | null {
    if (left === right)
        return lists[left];

    const mid = Math.floor((left + right) / 2);
    const l1 = mergeRange(lists, left, mid);
    const l2 = mergeRange(lists, mid + 1, right);
    return mergeSortedList(l1, l2);
}

function arrayToListNodes(arrayList: number[][]): (ListNode | null)[] {
    const listNodes: (ListNode | null)[] = [];
    for (const arr of arrayList) {
        let head: ListNode | null = null;
        for (let i = arr.length - 1; i >= 0; i--) {
            head = { val: arr[i], next: head };
        }
        listNodes.push(head);
    }
    return listNodes;
}

const arrayList = [[1,4,5],[1,3,4],[2,6]];
const listNodes = arrayToListNodes(arrayList);
mergeKSortedLists(listNodes);
