# DSA Interview Study Guide

**How to use this guide:** For each section, read the concept, memorize the template(s), then implement each practice problem using the given skeleton. Skeletons give you the function signature and an input/output example — the body is yours to write.

### Common data structures used in skeletons
```python
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next

class GraphNode:
    def __init__(self, val=0, neighbors=None):
        self.val = val
        self.neighbors = neighbors if neighbors is not None else []
```

---

## 1. Recursion (Foundation)

### Concept
Every recursive function needs:
1. **Base case** — the condition that stops recursion.
2. **Recursive case** — how the problem shrinks toward the base case.
3. **Call stack** — each call waits on the stack until its recursive call returns; this is what "unwinds."

Mental trick for converting recursion → iteration: recursion uses the *implicit* call stack; iteration uses an *explicit* stack (or a loop with state variables) to do the same job.

### Template — generic recursive skeleton
```python
def solve(state):
    if is_base_case(state):
        return base_result

    # do work / make choice
    result = solve(next_state(state))
    return combine(result)
```

### Template — backtracking (subsets/permutations style)
```python
def backtrack(path, choices):
    if is_solution(path):
        results.append(path[:])  # copy!
        return

    for choice in choices:
        path.append(choice)
        backtrack(path, remaining_choices(choices, choice))
        path.pop()  # undo the choice
```

### Practice

**Factorial**
```python
def factorial(n: int) -> int:
    """
    Example:
        factorial(5) -> 120
        factorial(0) -> 1
    """
    pass
```

**Fibonacci (with memoization)**
```python
def fibonacci(n: int) -> int:
    """
    Example:
        fibonacci(0) -> 0
        fibonacci(1) -> 1
        fibonacci(10) -> 55
    """
    pass
```

**Subsets — LeetCode 78**
```python
def subsets(nums: list[int]) -> list[list[int]]:
    """
    Example:
        subsets([1, 2, 3]) -> [[], [1], [2], [1,2], [3], [1,3], [2,3], [1,2,3]]
        (order of subsets/elements may vary)
    """
    pass
```

**Permutations — LeetCode 46**
```python
def permute(nums: list[int]) -> list[list[int]]:
    """
    Example:
        permute([1, 2, 3]) -> [[1,2,3], [1,3,2], [2,1,3], [2,3,1], [3,1,2], [3,2,1]]
    """
    pass
```

**Combination Sum — LeetCode 39**
```python
def combination_sum(candidates: list[int], target: int) -> list[list[int]]:
    """
    Example:
        combination_sum([2, 3, 6, 7], 7) -> [[2,2,3], [7]]
        (numbers can be reused unlimited times)
    """
    pass
```

**Generate Parentheses — LeetCode 22**
```python
def generate_parenthesis(n: int) -> list[str]:
    """
    Example:
        generate_parenthesis(3) -> ["((()))","(()())","(())()","()(())","()()()"]
    """
    pass
```

**Merge Sort**
```python
def merge_sort(nums: list[int]) -> list[int]:
    """
    Example:
        merge_sort([5, 2, 4, 6, 1, 3]) -> [1, 2, 3, 4, 5, 6]
    """
    pass
```

---

## 2. Trees

### Concept
- **Traversals:** preorder (root, left, right), inorder (left, root, right — gives sorted order for BST), postorder (left, right, root), level-order (BFS by level).
- **BST property:** left subtree < node < right subtree, recursively.

### Template — recursive traversal
```python
def inorder(node, result):
    if not node:
        return
    inorder(node.left, result)
    result.append(node.val)
    inorder(node.right, result)
```

### Template — level-order (BFS)
```python
from collections import deque

def level_order(root):
    if not root:
        return []
    result, queue = [], deque([root])
    while queue:
        level = []
        for _ in range(len(queue)):
            node = queue.popleft()
            level.append(node.val)
            if node.left:  queue.append(node.left)
            if node.right: queue.append(node.right)
        result.append(level)
    return result
```

### Template — BST validate
```python
def is_valid_bst(node, low=float('-inf'), high=float('inf')):
    if not node:
        return True
    if not (low < node.val < high):
        return False
    return (is_valid_bst(node.left, low, node.val) and
            is_valid_bst(node.right, node.val, high))
```

### Practice

**Binary Tree Inorder Traversal — LeetCode 94**
```python
def inorder_traversal(root: TreeNode | None) -> list[int]:
    """
    Example:
        Tree:    1
                  \
                   2
                  /
                 3
        Input as list (level-order, None = missing): [1, None, 2, 3]
        inorder_traversal(root) -> [1, 3, 2]
    """
    pass
```

**Binary Tree Preorder Traversal — LeetCode 144**
```python
def preorder_traversal(root: TreeNode | None) -> list[int]:
    """
    Example:
        Same tree as above: [1, None, 2, 3]
        preorder_traversal(root) -> [1, 2, 3]
    """
    pass
```

**Binary Tree Postorder Traversal — LeetCode 145**
```python
def postorder_traversal(root: TreeNode | None) -> list[int]:
    """
    Example:
        Same tree as above: [1, None, 2, 3]
        postorder_traversal(root) -> [3, 2, 1]
    """
    pass
```

**Validate Binary Search Tree — LeetCode 98**
```python
def is_valid_bst(root: TreeNode | None) -> bool:
    """
    Example:
        Tree: [2, 1, 3]        -> True (valid BST)
        Tree: [5, 1, 4, None, None, 3, 6] -> False (4's left child 3 < 5 but is
                                              in right subtree, violates BST)
    """
    pass
```

**Lowest Common Ancestor of a BST — LeetCode 235**
```python
def lowest_common_ancestor_bst(root: TreeNode, p: TreeNode, q: TreeNode) -> TreeNode:
    """
    Example:
        Tree: [6, 2, 8, 0, 4, 7, 9, None, None, 3, 5]
        p = node with val 2, q = node with val 8
        lowest_common_ancestor_bst(root, p, q) -> node with val 6
    """
    pass
```

**Lowest Common Ancestor of a Binary Tree — LeetCode 236**
```python
def lowest_common_ancestor(root: TreeNode, p: TreeNode, q: TreeNode) -> TreeNode:
    """
    Example:
        Tree: [3, 5, 1, 6, 2, 0, 8, None, None, 7, 4]
        p = node with val 5, q = node with val 1
        lowest_common_ancestor(root, p, q) -> node with val 3
    """
    pass
```

**Maximum Depth of Binary Tree — LeetCode 104**
```python
def max_depth(root: TreeNode | None) -> int:
    """
    Example:
        Tree: [3, 9, 20, None, None, 15, 7]
        max_depth(root) -> 3
    """
    pass
```

**Diameter of Binary Tree — LeetCode 543**
```python
def diameter_of_binary_tree(root: TreeNode | None) -> int:
    """
    Example:
        Tree: [1, 2, 3, 4, 5]
        diameter_of_binary_tree(root) -> 3  (path: 4 -> 2 -> 1 -> 3, or 4-2-5)
    """
    pass
```

**Binary Tree Level Order Traversal — LeetCode 102**
```python
def level_order(root: TreeNode | None) -> list[list[int]]:
    """
    Example:
        Tree: [3, 9, 20, None, None, 15, 7]
        level_order(root) -> [[3], [9, 20], [15, 7]]
    """
    pass
```

**Serialize and Deserialize Binary Tree — LeetCode 297 (stretch goal)**
```python
def serialize(root: TreeNode | None) -> str:
    """
    Example:
        Tree: [1, 2, 3, None, None, 4, 5]
        serialize(root) -> "1,2,None,None,3,4,None,None,5,None,None" (format is up to you)
    """
    pass

def deserialize(data: str) -> TreeNode | None:
    """
    Example:
        deserialize(serialize(root)) -> tree structurally identical to root
    """
    pass
```

---

## 3. DFS (Recursive + Iterative)

### Concept
DFS explores as deep as possible before backtracking. The recursive version relies on the call stack; the iterative version makes that stack explicit. Order of visiting can differ slightly between the two (iterative often reverses child order due to stack LIFO behavior) — don't worry unless the problem cares about exact order.

### Template — recursive DFS
```python
def dfs_recursive(node, visited):
    if node in visited:
        return
    visited.add(node)
    process(node)
    for neighbor in node.neighbors:
        dfs_recursive(neighbor, visited)
```

### Template — iterative DFS (explicit stack)
```python
def dfs_iterative(start):
    visited = set()
    stack = [start]
    while stack:
        node = stack.pop()
        if node in visited:
            continue
        visited.add(node)
        process(node)
        for neighbor in node.neighbors:
            if neighbor not in visited:
                stack.append(neighbor)
```

### Practice

**Number of Islands — LeetCode 200 (do both recursive and iterative DFS)**
```python
def num_islands_recursive(grid: list[list[str]]) -> int:
    """
    Example:
        grid = [
          ["1","1","0","0","0"],
          ["1","1","0","0","0"],
          ["0","0","1","0","0"],
          ["0","0","0","1","1"]
        ]
        num_islands_recursive(grid) -> 3
    """
    pass

def num_islands_iterative(grid: list[list[str]]) -> int:
    """
    Example: same grid as above -> 3
    """
    pass
```

**Path Sum — LeetCode 112**
```python
def has_path_sum(root: TreeNode | None, target_sum: int) -> bool:
    """
    Example:
        Tree: [5, 4, 8, 11, None, 13, 4, 7, 2, None, None, None, 1]
        target_sum = 22
        has_path_sum(root, target_sum) -> True  (5 -> 4 -> 11 -> 2 = 22)
    """
    pass
```

**Path Sum II — LeetCode 113**
```python
def path_sum(root: TreeNode | None, target_sum: int) -> list[list[int]]:
    """
    Example:
        Tree: [5, 4, 8, 11, None, 13, 4, 7, 2, None, None, 5, 1]
        target_sum = 22
        path_sum(root, target_sum) -> [[5,4,11,2], [5,8,4,5]]
    """
    pass
```

**Clone Graph — LeetCode 133**
```python
def clone_graph(node: GraphNode | None) -> GraphNode | None:
    """
    Example:
        Graph adjacency list: {1: [2,4], 2: [1,3], 3: [2,4], 4: [1,3]}
        clone_graph(node_with_val_1) -> a deep copy of the same graph structure
    """
    pass
```

**Same Tree — LeetCode 100**
```python
def is_same_tree(p: TreeNode | None, q: TreeNode | None) -> bool:
    """
    Example:
        p = [1, 2, 3], q = [1, 2, 3] -> True
        p = [1, 2],    q = [1, None, 2] -> False
    """
    pass
```

**Symmetric Tree — LeetCode 101**
```python
def is_symmetric(root: TreeNode | None) -> bool:
    """
    Example:
        Tree: [1, 2, 2, 3, 4, 4, 3] -> True
        Tree: [1, 2, 2, None, 3, None, 3] -> False
    """
    pass
```

**Flood Fill — LeetCode 733**
```python
def flood_fill(image: list[list[int]], sr: int, sc: int, color: int) -> list[list[int]]:
    """
    Example:
        image = [[1,1,1],[1,1,0],[1,0,1]]
        sr, sc, color = 1, 1, 2
        flood_fill(image, sr, sc, color) -> [[2,2,2],[2,2,0],[2,0,1]]
    """
    pass
```

---

## 4. Graph Algorithms

### Concept
- **Representations:** adjacency list (most common in interviews) vs. adjacency matrix (dense graphs).
- **BFS** finds shortest path in unweighted graphs, explores level by level (queue-based).
- **DFS** is better for exploring all paths, detecting cycles, and topological ordering.
- **Cycle detection:** track visiting-state (white/gray/black) for directed graphs; track visited+parent for undirected.
- **Topological sort:** only valid on DAGs — orders nodes so edges point forward.

### Template — BFS on graph
```python
from collections import deque

def bfs(graph, start):
    visited = {start}
    queue = deque([start])
    while queue:
        node = queue.popleft()
        process(node)
        for neighbor in graph[node]:
            if neighbor not in visited:
                visited.add(neighbor)
                queue.append(neighbor)
```

### Template — cycle detection (directed graph)
```python
def has_cycle(graph, n):
    WHITE, GRAY, BLACK = 0, 1, 2
    state = [WHITE] * n

    def dfs(node):
        state[node] = GRAY
        for neighbor in graph[node]:
            if state[neighbor] == GRAY:
                return True  # back edge = cycle
            if state[neighbor] == WHITE and dfs(neighbor):
                return True
        state[node] = BLACK
        return False

    return any(state[i] == WHITE and dfs(i) for i in range(n))
```

### Template — topological sort (Kahn's/BFS-based)
```python
from collections import deque

def topo_sort(graph, n):
    indegree = [0] * n
    for node in graph:
        for neighbor in graph[node]:
            indegree[neighbor] += 1

    queue = deque([i for i in range(n) if indegree[i] == 0])
    order = []
    while queue:
        node = queue.popleft()
        order.append(node)
        for neighbor in graph[node]:
            indegree[neighbor] -= 1
            if indegree[neighbor] == 0:
                queue.append(neighbor)
    return order if len(order) == n else []  # empty = cycle exists
```

### Practice

**Number of Islands — LeetCode 200 (graph framing — try again using BFS)**
```python
def num_islands_bfs(grid: list[list[str]]) -> int:
    """
    Example: same grid as DFS section -> 3
    """
    pass
```

**Course Schedule — LeetCode 207**
```python
def can_finish(num_courses: int, prerequisites: list[list[int]]) -> bool:
    """
    Example:
        num_courses = 2, prerequisites = [[1, 0]]  # to take 1, must take 0 first
        can_finish(2, [[1, 0]]) -> True

        prerequisites = [[1, 0], [0, 1]]  # circular dependency
        can_finish(2, [[1, 0], [0, 1]]) -> False
    """
    pass
```

**Course Schedule II — LeetCode 210**
```python
def find_order(num_courses: int, prerequisites: list[list[int]]) -> list[int]:
    """
    Example:
        num_courses = 4, prerequisites = [[1,0],[2,0],[3,1],[3,2]]
        find_order(4, [[1,0],[2,0],[3,1],[3,2]]) -> [0, 1, 2, 3] (one valid order)
    """
    pass
```

**Clone Graph — LeetCode 133 (try again here using BFS instead of DFS)**
```python
def clone_graph_bfs(node: GraphNode | None) -> GraphNode | None:
    """
    Example: same graph as DFS section -> deep copy of the graph
    """
    pass
```

**Word Ladder — LeetCode 127**
```python
def ladder_length(begin_word: str, end_word: str, word_list: list[str]) -> int:
    """
    Example:
        begin_word = "hit", end_word = "cog"
        word_list = ["hot","dot","dog","lot","log","cog"]
        ladder_length("hit", "cog", word_list) -> 5
        (path: "hit" -> "hot" -> "dot" -> "dog" -> "cog")
    """
    pass
```

**Pacific Atlantic Water Flow — LeetCode 417**
```python
def pacific_atlantic(heights: list[list[int]]) -> list[list[int]]:
    """
    Example:
        heights = [
          [1,2,2,3,5],
          [3,2,3,4,4],
          [2,4,5,3,1],
          [6,7,1,4,5],
          [5,1,1,2,4]
        ]
        pacific_atlantic(heights) -> [[0,4],[1,3],[1,4],[2,2],[3,0],[3,1],[4,0]]
        (list of [row, col] cells that can reach both oceans; order may vary)
    """
    pass
```

---

## 5. Hash Maps

### Concept
Use a hash map when you need **O(1) average lookup** to avoid nested loops. Common signals: "have I seen this before," "find the complement," "count frequency," "group by some key."

### Template — complement lookup (two-sum style)
```python
def two_sum(nums, target):
    seen = {}  # value -> index
    for i, num in enumerate(nums):
        complement = target - num
        if complement in seen:
            return [seen[complement], i]
        seen[num] = i
    return []
```

### Template — frequency map
```python
from collections import Counter

def frequency_map(items):
    return Counter(items)
```

### Practice

**Two Sum — LeetCode 1**
```python
def two_sum(nums: list[int], target: int) -> list[int]:
    """
    Example:
        two_sum([2, 7, 11, 15], 9) -> [0, 1]  (2 + 7 = 9)
    """
    pass
```

**Group Anagrams — LeetCode 49**
```python
def group_anagrams(strs: list[str]) -> list[list[str]]:
    """
    Example:
        group_anagrams(["eat","tea","tan","ate","nat","bat"])
        -> [["eat","tea","ate"], ["tan","nat"], ["bat"]]
        (order of groups/elements may vary)
    """
    pass
```

**Longest Substring Without Repeating Characters — LeetCode 3**
```python
def length_of_longest_substring(s: str) -> int:
    """
    Example:
        length_of_longest_substring("abcabcbb") -> 3  ("abc")
        length_of_longest_substring("bbbbb") -> 1      ("b")
    """
    pass
```

**Valid Anagram — LeetCode 242**
```python
def is_anagram(s: str, t: str) -> bool:
    """
    Example:
        is_anagram("anagram", "nagaram") -> True
        is_anagram("rat", "car") -> False
    """
    pass
```

**Subarray Sum Equals K — LeetCode 560**
```python
def subarray_sum(nums: list[int], k: int) -> int:
    """
    Example:
        subarray_sum([1, 1, 1], 2) -> 2  (subarrays [1,1] at indices [0,1] and [1,2])
        subarray_sum([1, 2, 3], 3) -> 2  ([1,2] and [3])
    """
    pass
```

**Top K Frequent Elements — LeetCode 347**
```python
def top_k_frequent(nums: list[int], k: int) -> list[int]:
    """
    Example:
        top_k_frequent([1,1,1,2,2,3], 2) -> [1, 2]
    """
    pass
```

---

## 6. Binary Search

### Concept
Binary search isn't just "search a sorted array" — it's **search space reduction**: any monotonic condition (true/false split point) can be binary searched. Common pitfalls: off-by-one on `left`/`right`, infinite loops when `mid` calculation doesn't shrink the space.

### Template — standard binary search
```python
def binary_search(nums, target):
    left, right = 0, len(nums) - 1
    while left <= right:
        mid = left + (right - left) // 2
        if nums[mid] == target:
            return mid
        elif nums[mid] < target:
            left = mid + 1
        else:
            right = mid - 1
    return -1
```

### Template — search on answer (binary search over a range of possible answers)
```python
def search_on_answer(lo, hi, feasible):
    while lo < hi:
        mid = lo + (hi - lo) // 2
        if feasible(mid):
            hi = mid       # mid works, try smaller
        else:
            lo = mid + 1
    return lo
```

### Template — find first/last occurrence (boundary search)
```python
def find_first(nums, target):
    left, right, result = 0, len(nums) - 1, -1
    while left <= right:
        mid = left + (right - left) // 2
        if nums[mid] == target:
            result = mid
            right = mid - 1  # keep searching left
        elif nums[mid] < target:
            left = mid + 1
        else:
            right = mid - 1
    return result
```

### Practice

**Binary Search — LeetCode 704**
```python
def search(nums: list[int], target: int) -> int:
    """
    Example:
        search([-1, 0, 3, 5, 9, 12], 9) -> 4
        search([-1, 0, 3, 5, 9, 12], 2) -> -1
    """
    pass
```

**Search in Rotated Sorted Array — LeetCode 33**
```python
def search_rotated(nums: list[int], target: int) -> int:
    """
    Example:
        search_rotated([4,5,6,7,0,1,2], 0) -> 4
        search_rotated([4,5,6,7,0,1,2], 3) -> -1
    """
    pass
```

**Find First and Last Position of Element in Sorted Array — LeetCode 34**
```python
def search_range(nums: list[int], target: int) -> list[int]:
    """
    Example:
        search_range([5,7,7,8,8,10], 8) -> [3, 4]
        search_range([5,7,7,8,8,10], 6) -> [-1, -1]
    """
    pass
```

**Koko Eating Bananas — LeetCode 875**
```python
def min_eating_speed(piles: list[int], h: int) -> int:
    """
    Example:
        min_eating_speed([3, 6, 7, 11], 8) -> 4
        min_eating_speed([30, 11, 23, 4, 20], 5) -> 30
    """
    pass
```

**Capacity to Ship Packages Within D Days — LeetCode 1011**
```python
def ship_within_days(weights: list[int], days: int) -> int:
    """
    Example:
        ship_within_days([1,2,3,4,5,6,7,8,9,10], 5) -> 15
    """
    pass
```

**Median of Two Sorted Arrays — LeetCode 4 (hard, stretch goal)**
```python
def find_median_sorted_arrays(nums1: list[int], nums2: list[int]) -> float:
    """
    Example:
        find_median_sorted_arrays([1, 3], [2]) -> 2.0
        find_median_sorted_arrays([1, 2], [3, 4]) -> 2.5
    """
    pass
```

---

## 7. Queues

### Concept
FIFO structure — first in, first out. Central to BFS. **Monotonic queue** (usually implemented with a deque) keeps elements in increasing/decreasing order to answer "max/min in a sliding window" efficiently.

### Template — basic queue ops
```python
from collections import deque
q = deque()
q.append(x)       # enqueue
q.popleft()        # dequeue
q[0]                # peek front
```

### Template — monotonic deque (sliding window maximum)
```python
from collections import deque

def sliding_window_max(nums, k):
    dq = deque()  # stores indices, values decreasing
    result = []
    for i, num in enumerate(nums):
        while dq and nums[dq[-1]] < num:
            dq.pop()
        dq.append(i)
        if dq[0] <= i - k:
            dq.popleft()
        if i >= k - 1:
            result.append(nums[dq[0]])
    return result
```

### Practice

**Sliding Window Maximum — LeetCode 239**
```python
def max_sliding_window(nums: list[int], k: int) -> list[int]:
    """
    Example:
        max_sliding_window([1,3,-1,-3,5,3,6,7], 3) -> [3,3,5,5,6,7]
    """
    pass
```

**Task Scheduler — LeetCode 621**
```python
def least_interval(tasks: list[str], n: int) -> int:
    """
    Example:
        least_interval(["A","A","A","B","B","B"], 2) -> 8
        (e.g. A -> B -> idle -> A -> B -> idle -> A -> B)
    """
    pass
```

**Implement Queue using Stacks — LeetCode 232**
```python
class MyQueue:
    def __init__(self):
        pass

    def push(self, x: int) -> None:
        pass

    def pop(self) -> int:
        pass

    def peek(self) -> int:
        pass

    def empty(self) -> bool:
        pass

"""
Example:
    q = MyQueue()
    q.push(1); q.push(2)
    q.peek()   -> 1
    q.pop()    -> 1
    q.empty()  -> False
"""
```

**Design Circular Queue — LeetCode 622**
```python
class MyCircularQueue:
    def __init__(self, k: int):
        pass

    def enQueue(self, value: int) -> bool:
        pass

    def deQueue(self) -> bool:
        pass

    def Front(self) -> int:
        pass

    def Rear(self) -> int:
        pass

    def isEmpty(self) -> bool:
        pass

    def isFull(self) -> bool:
        pass

"""
Example:
    cq = MyCircularQueue(3)
    cq.enQueue(1) -> True
    cq.enQueue(2) -> True
    cq.enQueue(3) -> True
    cq.enQueue(4) -> False  (queue is full)
    cq.Rear()     -> 3
    cq.isFull()   -> True
"""
```

**Rotting Oranges — LeetCode 994**
```python
def oranges_rotting(grid: list[list[int]]) -> int:
    """
    Example:
        grid = [[2,1,1],[1,1,0],[0,1,1]]
        oranges_rotting(grid) -> 4  (minutes until all oranges rot)

        grid = [[0,2]]
        oranges_rotting(grid) -> 0
    """
    pass
```

**Walls and Gates — LeetCode 286**
```python
def walls_and_gates(rooms: list[list[int]]) -> None:
    """
    Fills each empty room (INF) in-place with distance to nearest gate (0).
    -1 = wall, 0 = gate, 2147483647 (INF) = empty room.

    Example:
        rooms = [
          [2147483647, -1, 0, 2147483647],
          [2147483647, 2147483647, 2147483647, -1],
          [2147483647, -1, 2147483647, -1],
          [0, -1, 2147483647, 2147483647]
        ]
        walls_and_gates(rooms) -> modifies rooms in place to:
        [
          [3, -1, 0, 1],
          [2, 2, 1, -1],
          [1, -1, 2, -1],
          [0, -1, 3, 4]
        ]
    """
    pass
```

---

## 8. Heaps

### Concept
Use a heap when you repeatedly need the **min or max** of a changing collection — "top K," "kth largest," "merge K sorted things," "running median." Min-heap: smallest on top. Max-heap: negate values in Python's `heapq` (which is min-heap only).

### Template — heap basics
```python
import heapq

min_heap = []
heapq.heappush(min_heap, val)
smallest = heapq.heappop(min_heap)

# max-heap trick: negate values
max_heap = []
heapq.heappush(max_heap, -val)
largest = -heapq.heappop(max_heap)
```

### Template — top-K pattern
```python
import heapq

def top_k_frequent(nums, k):
    counts = Counter(nums)
    return heapq.nlargest(k, counts.keys(), key=counts.get)

# or maintain a heap of size k:
def kth_largest(nums, k):
    heap = []
    for num in nums:
        heapq.heappush(heap, num)
        if len(heap) > k:
            heapq.heappop(heap)
    return heap[0]
```

### Template — two-heap pattern (running median)
```python
import heapq

class MedianFinder:
    def __init__(self):
        self.small = []  # max-heap (negated), lower half
        self.large = []  # min-heap, upper half

    def add_num(self, num):
        heapq.heappush(self.small, -num)
        heapq.heappush(self.large, -heapq.heappop(self.small))
        if len(self.large) > len(self.small):
            heapq.heappush(self.small, -heapq.heappop(self.large))

    def find_median(self):
        if len(self.small) > len(self.large):
            return -self.small[0]
        return (-self.small[0] + self.large[0]) / 2
```

### Practice

**Kth Largest Element in an Array — LeetCode 215**
```python
def find_kth_largest(nums: list[int], k: int) -> int:
    """
    Example:
        find_kth_largest([3,2,1,5,6,4], 2) -> 5
        find_kth_largest([3,2,3,1,2,4,5,5,6], 4) -> 4
    """
    pass
```

**Top K Frequent Elements — LeetCode 347 (try again here using a heap instead of `Counter.most_common`)**
```python
def top_k_frequent_heap(nums: list[int], k: int) -> list[int]:
    """
    Example: top_k_frequent_heap([1,1,1,2,2,3], 2) -> [1, 2]
    """
    pass
```

**Merge K Sorted Lists — LeetCode 23**
```python
def merge_k_lists(lists: list[ListNode | None]) -> ListNode | None:
    """
    Example:
        lists = [[1,4,5], [1,3,4], [2,6]]  (each is a sorted linked list)
        merge_k_lists(lists) -> linked list representing [1,1,2,3,4,4,5,6]
    """
    pass
```

**Find Median from Data Stream — LeetCode 295**
```python
class MedianFinder:
    def __init__(self):
        pass

    def add_num(self, num: int) -> None:
        pass

    def find_median(self) -> float:
        pass

"""
Example:
    mf = MedianFinder()
    mf.add_num(1)
    mf.add_num(2)
    mf.find_median() -> 1.5
    mf.add_num(3)
    mf.find_median() -> 2.0
"""
```

**K Closest Points to Origin — LeetCode 973**
```python
def k_closest(points: list[list[int]], k: int) -> list[list[int]]:
    """
    Example:
        k_closest([[1,3],[-2,2]], 1) -> [[-2,2]]
        k_closest([[3,3],[5,-1],[-2,4]], 2) -> [[3,3],[-2,4]]
    """
    pass
```

---

## 9. 2D Matrix Traversal

### Concept
Treat a grid as an implicit graph — each cell is a node, adjacent cells (usually 4-directional) are edges. Key ingredients: direction vectors, boundary checks, a visited set (or mutate the grid in place).

### Template — 4-direction traversal setup
```python
directions = [(-1, 0), (1, 0), (0, -1), (0, 1)]  # up, down, left, right

def in_bounds(r, c, rows, cols):
    return 0 <= r < rows and 0 <= c < cols
```

### Template — BFS/DFS on grid
```python
from collections import deque

def bfs_grid(grid, start_r, start_c):
    rows, cols = len(grid), len(grid[0])
    visited = {(start_r, start_c)}
    queue = deque([(start_r, start_c)])
    while queue:
        r, c = queue.popleft()
        for dr, dc in directions:
            nr, nc = r + dr, c + dc
            if in_bounds(nr, nc, rows, cols) and (nr, nc) not in visited and grid[nr][nc] != 'blocked':
                visited.add((nr, nc))
                queue.append((nr, nc))
```

### Template — spiral traversal
```python
def spiral_order(matrix):
    result = []
    top, bottom = 0, len(matrix) - 1
    left, right = 0, len(matrix[0]) - 1
    while top <= bottom and left <= right:
        for c in range(left, right + 1): result.append(matrix[top][c])
        top += 1
        for r in range(top, bottom + 1): result.append(matrix[r][right])
        right -= 1
        if top <= bottom:
            for c in range(right, left - 1, -1): result.append(matrix[bottom][c])
            bottom -= 1
        if left <= right:
            for r in range(bottom, top - 1, -1): result.append(matrix[r][left])
            left += 1
    return result
```

### Practice

**Number of Islands — LeetCode 200 (see DFS section, already covered)**

**Flood Fill — LeetCode 733 (see DFS section, already covered)**

**Rotting Oranges — LeetCode 994 (see Queues section, already covered)**

**Spiral Matrix — LeetCode 54**
```python
def spiral_order(matrix: list[list[int]]) -> list[int]:
    """
    Example:
        matrix = [[1,2,3],[4,5,6],[7,8,9]]
        spiral_order(matrix) -> [1,2,3,6,9,8,7,4,5]
    """
    pass
```

**Word Search — LeetCode 79**
```python
def exist(board: list[list[str]], word: str) -> bool:
    """
    Example:
        board = [
          ["A","B","C","E"],
          ["S","F","C","S"],
          ["A","D","E","E"]
        ]
        exist(board, "ABCCED") -> True
        exist(board, "SEE") -> True
        exist(board, "ABCB") -> False
    """
    pass
```

**Set Matrix Zeroes — LeetCode 73**
```python
def set_zeroes(matrix: list[list[int]]) -> None:
    """
    Modifies matrix in-place: if a cell is 0, its entire row and column become 0.

    Example:
        matrix = [[1,1,1],[1,0,1],[1,1,1]]
        set_zeroes(matrix) -> modifies matrix in place to:
        [[1,0,1],[0,0,0],[1,0,1]]
    """
    pass
```

---

## Suggested Study Order
1. Recursion → 2. Trees → 3. DFS → 4. Graphs (these build on each other)
5. Hash Maps → 6. Binary Search → 7. Queues → 8. Heaps (these are more independent)
9. 2D Matrix Traversal last, since it draws on DFS/BFS/queues from earlier sections.
