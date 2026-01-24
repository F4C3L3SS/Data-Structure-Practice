// From node, for every neighbor: 
// - if not visited - DFS(neighbor, node)
// - if visited and neighbor !== parent -> cycle

function detectCycleUndirected(adj: number[][]): boolean {
    const n = adj.length;
    const visited: boolean[] = new Array(n).fill(false);

    function dfs(node: number, parent: number): boolean {
        visited[node] = true;

        for (const neighbor of adj[node]) {

            if (!visited[neighbor]) {
                if (dfs(neighbor, node)) return true;
            } else if (neighbor !== parent) {
                return true;
            }
        }
        return false;
    }

    for (let i = 0; i < n; i++) {
        if (!visited[i]) {
            if (dfs(i, -1)) return true;
        }
    }

    return false;
}

// From node, for every neighbor
// - if node is found in visited and path arrays, cycle exists
// visited - node has been seen before
// path - node is in the current DFS call stack
function detectCycleDirected(adj: number[][]): boolean {
    const n = adj.length;

    const visited: boolean[] = new Array(n).fill(false);
    const path: boolean[] = new Array(n).fill(false);

    function dfs(node: number): boolean {
        visited[node] = true;
        path[node] = true;

        for (const neighbor of adj[node]) {
            // case 1: neighbor not visited -> DFS
            if (!visited[neighbor]) {
                if (dfs(neighbor)) return true;
            } 
            // case 2: neighbor in current path -> cycle
            else if (path[neighbor]) {
                return true;
            }
        }
        // backtrack, clear the previously visited path, as we may see some undesired cycle
        path[node] = false;

        return false;
    }

    for (let i = 0; i < n; i++) {
        if (!visited[i] && dfs(i)) return true;
    }

    return false;
}
