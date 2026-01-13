// Adjacency List (Directed & Undirected)
function buildGraph(edges: number[][], n: number, directed = true) {
    const graph = new Map<number, number[]>();

    for (let i = 0; i < n; i++) graph.set(i, []);

    for (const [u, v] of edges) {
        graph.get(u)!.push(v);

        if (!directed) {
            graph.get(v)!.push(u); // add the reverse also, if 1 is connected to 2, 2 -> 1 mapping is also needed.
        }
    }

    return graph;
}

const edges = [[0,1],[1,2],[2,3]];
const graph = buildGraph(edges, 4);

console.log("Built Graph", graph);

// DFS Traversal (Recursive)
function dfs(start: number, graph: Map<number, number[]>) {
    const visited = new Set<number>();
    const result: number[] = [];

    function traverse(node: number) {
        if (visited.has(node)) return;

        visited.add(node);
        result.push(node);

        for(const nod of graph.get(node)!) {
            traverse(nod);
        }
    }
    
    traverse(start);
    return result;
}

console.log("DFS", dfs(0, graph));


// BFS Traversal (Queue)
function bfs(start: number, graph: Map<number, number[]>) {
    const queue: number[] = [start];
    const visited = new Set<number>([start]);
    const result: number[] = [];

    while (queue.length) {
        const node = queue.shift();
        result.push(node);

        for (const nod of graph.get(node)!) {
            if(!visited.has(nod)) {
                visited.add(nod);
                queue.push(nod);
            }
        }
    }

    return result;
}

console.log("BFS", bfs(0, graph));