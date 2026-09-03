"""
DSA Interview Practice — Skeleton File
========================================
Each class below corresponds to a section of the study guide.
Each method is a practice problem: implement the body, use the
docstring example to check your work.

Run this file directly to sanity-check your implementations against
the examples in each docstring (see the __main__ block at the bottom).
"""

from collections import deque, Counter
import heapq


# ---------------------------------------------------------------------------
# Common data structures used across problems
# ---------------------------------------------------------------------------

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


# ---------------------------------------------------------------------------
# 1. Recursion
# ---------------------------------------------------------------------------

class Recursion:

    @staticmethod
    def factorial(n: int) -> int:
        """
        Example:
            factorial(5) -> 120
            factorial(0) -> 1
        """
        pass

    @staticmethod
    def fibonacci(n: int) -> int:
        """
        Example:
            fibonacci(0) -> 0
            fibonacci(1) -> 1
            fibonacci(10) -> 55
        """
        pass

    @staticmethod
    def subsets(nums: list[int]) -> list[list[int]]:
        """
        LeetCode 78
        Example:
            subsets([1, 2, 3]) -> [[], [1], [2], [1,2], [3], [1,3], [2,3], [1,2,3]]
            (order of subsets/elements may vary)
        """
        pass

    @staticmethod
    def permute(nums: list[int]) -> list[list[int]]:
        """
        LeetCode 46
        Example:
            permute([1, 2, 3]) -> [[1,2,3], [1,3,2], [2,1,3], [2,3,1], [3,1,2], [3,2,1]]
        """
        pass

    @staticmethod
    def combination_sum(candidates: list[int], target: int) -> list[list[int]]:
        """
        LeetCode 39
        Example:
            combination_sum([2, 3, 6, 7], 7) -> [[2,2,3], [7]]
            (numbers can be reused unlimited times)
        """
        pass

    @staticmethod
    def generate_parenthesis(n: int) -> list[str]:
        """
        LeetCode 22
        Example:
            generate_parenthesis(3) -> ["((()))","(()())","(())()","()(())","()()()"]
        """
        pass

    @staticmethod
    def merge_sort(nums: list[int]) -> list[int]:
        """
        Example:
            merge_sort([5, 2, 4, 6, 1, 3]) -> [1, 2, 3, 4, 5, 6]
        """
        pass


# ---------------------------------------------------------------------------
# 2. Trees
# ---------------------------------------------------------------------------

class Trees:

    @staticmethod
    def inorder_traversal(root: TreeNode | None) -> list[int]:
        """
        LeetCode 94
        Example:
            Tree as level-order list (None = missing): [1, None, 2, 3]
            inorder_traversal(root) -> [1, 3, 2]
        """
        pass

    @staticmethod
    def preorder_traversal(root: TreeNode | None) -> list[int]:
        """
        LeetCode 144
        Example:
            Tree: [1, None, 2, 3]
            preorder_traversal(root) -> [1, 2, 3]
        """
        pass

    @staticmethod
    def postorder_traversal(root: TreeNode | None) -> list[int]:
        """
        LeetCode 145
        Example:
            Tree: [1, None, 2, 3]
            postorder_traversal(root) -> [3, 2, 1]
        """
        pass

    @staticmethod
    def is_valid_bst(root: TreeNode | None) -> bool:
        """
        LeetCode 98
        Example:
            Tree: [2, 1, 3] -> True
            Tree: [5, 1, 4, None, None, 3, 6] -> False
        """
        pass

    @staticmethod
    def lowest_common_ancestor_bst(root: TreeNode, p: TreeNode, q: TreeNode) -> TreeNode:
        """
        LeetCode 235
        Example:
            Tree: [6, 2, 8, 0, 4, 7, 9, None, None, 3, 5]
            p = node(2), q = node(8) -> node(6)
        """
        pass

    @staticmethod
    def lowest_common_ancestor(root: TreeNode, p: TreeNode, q: TreeNode) -> TreeNode:
        """
        LeetCode 236
        Example:
            Tree: [3, 5, 1, 6, 2, 0, 8, None, None, 7, 4]
            p = node(5), q = node(1) -> node(3)
        """
        pass

    @staticmethod
    def max_depth(root: TreeNode | None) -> int:
        """
        LeetCode 104
        Example:
            Tree: [3, 9, 20, None, None, 15, 7] -> 3
        """
        pass

    @staticmethod
    def diameter_of_binary_tree(root: TreeNode | None) -> int:
        """
        LeetCode 543
        Example:
            Tree: [1, 2, 3, 4, 5] -> 3
        """
        pass

    @staticmethod
    def level_order(root: TreeNode | None) -> list[list[int]]:
        """
        LeetCode 102
        Example:
            Tree: [3, 9, 20, None, None, 15, 7] -> [[3], [9, 20], [15, 7]]
        """
        pass

    @staticmethod
    def serialize(root: TreeNode | None) -> str:
        """
        LeetCode 297 (stretch goal)
        Example:
            Tree: [1, 2, 3, None, None, 4, 5]
            serialize(root) -> some string encoding (format is up to you)
        """
        pass

    @staticmethod
    def deserialize(data: str) -> TreeNode | None:
        """
        LeetCode 297 (stretch goal)
        Example:
            deserialize(serialize(root)) -> tree structurally identical to root
        """
        pass


# ---------------------------------------------------------------------------
# 3. DFS (recursive + iterative)
# ---------------------------------------------------------------------------

class DFS:

    @staticmethod
    def num_islands_recursive(grid: list[list[str]]) -> int:
        """
        LeetCode 200 (recursive DFS)
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

    @staticmethod
    def num_islands_iterative(grid: list[list[str]]) -> int:
        """
        LeetCode 200 (iterative DFS)
        Example: same grid as above -> 3
        """
        pass

    @staticmethod
    def has_path_sum(root: TreeNode | None, target_sum: int) -> bool:
        """
        LeetCode 112
        Example:
            Tree: [5, 4, 8, 11, None, 13, 4, 7, 2, None, None, None, 1]
            target_sum = 22 -> True  (5 -> 4 -> 11 -> 2 = 22)
        """
        pass

    @staticmethod
    def path_sum(root: TreeNode | None, target_sum: int) -> list[list[int]]:
        """
        LeetCode 113
        Example:
            Tree: [5, 4, 8, 11, None, 13, 4, 7, 2, None, None, 5, 1]
            target_sum = 22 -> [[5,4,11,2], [5,8,4,5]]
        """
        pass

    @staticmethod
    def clone_graph(node: GraphNode | None) -> GraphNode | None:
        """
        LeetCode 133
        Example:
            Graph: {1: [2,4], 2: [1,3], 3: [2,4], 4: [1,3]}
            clone_graph(node_with_val_1) -> deep copy of the same graph
        """
        pass

    @staticmethod
    def is_same_tree(p: TreeNode | None, q: TreeNode | None) -> bool:
        """
        LeetCode 100
        Example:
            p = [1, 2, 3], q = [1, 2, 3] -> True
            p = [1, 2], q = [1, None, 2] -> False
        """
        pass

    @staticmethod
    def is_symmetric(root: TreeNode | None) -> bool:
        """
        LeetCode 101
        Example:
            Tree: [1, 2, 2, 3, 4, 4, 3] -> True
            Tree: [1, 2, 2, None, 3, None, 3] -> False
        """
        pass

    @staticmethod
    def flood_fill(image: list[list[int]], sr: int, sc: int, color: int) -> list[list[int]]:
        """
        LeetCode 733
        Example:
            image = [[1,1,1],[1,1,0],[1,0,1]]
            sr, sc, color = 1, 1, 2
            flood_fill(image, sr, sc, color) -> [[2,2,2],[2,2,0],[2,0,1]]
        """
        pass


# ---------------------------------------------------------------------------
# 4. Graph Algorithms
# ---------------------------------------------------------------------------

class Graphs:

    @staticmethod
    def num_islands_bfs(grid: list[list[str]]) -> int:
        """
        LeetCode 200 (redo with BFS)
        Example: same grid as DFS.num_islands_recursive -> 3
        """
        pass

    @staticmethod
    def can_finish(num_courses: int, prerequisites: list[list[int]]) -> bool:
        """
        LeetCode 207
        Example:
            can_finish(2, [[1, 0]]) -> True
            can_finish(2, [[1, 0], [0, 1]]) -> False
        """
        pass

    @staticmethod
    def find_order(num_courses: int, prerequisites: list[list[int]]) -> list[int]:
        """
        LeetCode 210
        Example:
            find_order(4, [[1,0],[2,0],[3,1],[3,2]]) -> [0, 1, 2, 3] (one valid order)
        """
        pass

    @staticmethod
    def clone_graph_bfs(node: GraphNode | None) -> GraphNode | None:
        """
        LeetCode 133 (redo with BFS)
        Example: same graph as DFS.clone_graph -> deep copy of the graph
        """
        pass

    @staticmethod
    def ladder_length(begin_word: str, end_word: str, word_list: list[str]) -> int:
        """
        LeetCode 127
        Example:
            begin_word = "hit", end_word = "cog"
            word_list = ["hot","dot","dog","lot","log","cog"]
            ladder_length("hit", "cog", word_list) -> 5
        """
        pass

    @staticmethod
    def pacific_atlantic(heights: list[list[int]]) -> list[list[int]]:
        """
        LeetCode 417
        Example:
            heights = [
              [1,2,2,3,5],
              [3,2,3,4,4],
              [2,4,5,3,1],
              [6,7,1,4,5],
              [5,1,1,2,4]
            ]
            pacific_atlantic(heights) -> [[0,4],[1,3],[1,4],[2,2],[3,0],[3,1],[4,0]]
        """
        pass


# ---------------------------------------------------------------------------
# 5. Hash Maps
# ---------------------------------------------------------------------------

class HashMaps:

    @staticmethod
    def two_sum(nums: list[int], target: int) -> list[int]:
        """
        LeetCode 1
        Example:
            two_sum([2, 7, 11, 15], 9) -> [0, 1]
        """
        pass

    @staticmethod
    def group_anagrams(strs: list[str]) -> list[list[str]]:
        """
        LeetCode 49
        Example:
            group_anagrams(["eat","tea","tan","ate","nat","bat"])
            -> [["eat","tea","ate"], ["tan","nat"], ["bat"]]
        """
        pass

    @staticmethod
    def length_of_longest_substring(s: str) -> int:
        """
        LeetCode 3
        Example:
            length_of_longest_substring("abcabcbb") -> 3
            length_of_longest_substring("bbbbb") -> 1
        """
        pass

    @staticmethod
    def is_anagram(s: str, t: str) -> bool:
        """
        LeetCode 242
        Example:
            is_anagram("anagram", "nagaram") -> True
            is_anagram("rat", "car") -> False
        """
        pass

    @staticmethod
    def subarray_sum(nums: list[int], k: int) -> int:
        """
        LeetCode 560
        Example:
            subarray_sum([1, 1, 1], 2) -> 2
            subarray_sum([1, 2, 3], 3) -> 2
        """
        pass

    @staticmethod
    def top_k_frequent(nums: list[int], k: int) -> list[int]:
        """
        LeetCode 347
        Example:
            top_k_frequent([1,1,1,2,2,3], 2) -> [1, 2]
        """
        pass


# ---------------------------------------------------------------------------
# 6. Binary Search
# ---------------------------------------------------------------------------

class BinarySearch:

    @staticmethod
    def search(nums: list[int], target: int) -> int:
        """
        LeetCode 704
        Example:
            search([-1, 0, 3, 5, 9, 12], 9) -> 4
            search([-1, 0, 3, 5, 9, 12], 2) -> -1
        """
        pass

    @staticmethod
    def search_rotated(nums: list[int], target: int) -> int:
        """
        LeetCode 33
        Example:
            search_rotated([4,5,6,7,0,1,2], 0) -> 4
            search_rotated([4,5,6,7,0,1,2], 3) -> -1
        """
        pass

    @staticmethod
    def search_range(nums: list[int], target: int) -> list[int]:
        """
        LeetCode 34
        Example:
            search_range([5,7,7,8,8,10], 8) -> [3, 4]
            search_range([5,7,7,8,8,10], 6) -> [-1, -1]
        """
        pass

    @staticmethod
    def min_eating_speed(piles: list[int], h: int) -> int:
        """
        LeetCode 875 (search on answer)
        Example:
            min_eating_speed([3, 6, 7, 11], 8) -> 4
            min_eating_speed([30, 11, 23, 4, 20], 5) -> 30
        """
        pass

    @staticmethod
    def ship_within_days(weights: list[int], days: int) -> int:
        """
        LeetCode 1011 (search on answer)
        Example:
            ship_within_days([1,2,3,4,5,6,7,8,9,10], 5) -> 15
        """
        pass

    @staticmethod
    def find_median_sorted_arrays(nums1: list[int], nums2: list[int]) -> float:
        """
        LeetCode 4 (hard, stretch goal)
        Example:
            find_median_sorted_arrays([1, 3], [2]) -> 2.0
            find_median_sorted_arrays([1, 2], [3, 4]) -> 2.5
        """
        pass


# ---------------------------------------------------------------------------
# 7. Queues
# ---------------------------------------------------------------------------

class Queues:

    @staticmethod
    def max_sliding_window(nums: list[int], k: int) -> list[int]:
        """
        LeetCode 239
        Example:
            max_sliding_window([1,3,-1,-3,5,3,6,7], 3) -> [3,3,5,5,6,7]
        """
        pass

    @staticmethod
    def least_interval(tasks: list[str], n: int) -> int:
        """
        LeetCode 621
        Example:
            least_interval(["A","A","A","B","B","B"], 2) -> 8
        """
        pass

    @staticmethod
    def oranges_rotting(grid: list[list[int]]) -> int:
        """
        LeetCode 994
        Example:
            grid = [[2,1,1],[1,1,0],[0,1,1]] -> 4
            grid = [[0,2]] -> 0
        """
        pass

    @staticmethod
    def walls_and_gates(rooms: list[list[int]]) -> None:
        """
        LeetCode 286 (modifies rooms in place)
        -1 = wall, 0 = gate, 2147483647 (INF) = empty room.
        Example:
            rooms = [
              [2147483647, -1, 0, 2147483647],
              [2147483647, 2147483647, 2147483647, -1],
              [2147483647, -1, 2147483647, -1],
              [0, -1, 2147483647, 2147483647]
            ]
            walls_and_gates(rooms) -> rooms becomes:
            [
              [3, -1, 0, 1],
              [2, 2, 1, -1],
              [1, -1, 2, -1],
              [0, -1, 3, 4]
            ]
        """
        pass


class MyQueue:
    """
    LeetCode 232 — Implement Queue using Stacks
    Example:
        q = MyQueue()
        q.push(1); q.push(2)
        q.peek()   -> 1
        q.pop()    -> 1
        q.empty()  -> False
    """

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


class MyCircularQueue:
    """
    LeetCode 622 — Design Circular Queue
    Example:
        cq = MyCircularQueue(3)
        cq.enQueue(1) -> True
        cq.enQueue(2) -> True
        cq.enQueue(3) -> True
        cq.enQueue(4) -> False  (full)
        cq.Rear()     -> 3
        cq.isFull()   -> True
    """

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


# ---------------------------------------------------------------------------
# 8. Heaps
# ---------------------------------------------------------------------------

class Heaps:

    @staticmethod
    def find_kth_largest(nums: list[int], k: int) -> int:
        """
        LeetCode 215
        Example:
            find_kth_largest([3,2,1,5,6,4], 2) -> 5
            find_kth_largest([3,2,3,1,2,4,5,5,6], 4) -> 4
        """
        pass

    @staticmethod
    def top_k_frequent_heap(nums: list[int], k: int) -> list[int]:
        """
        LeetCode 347 (redo with a heap instead of Counter.most_common)
        Example:
            top_k_frequent_heap([1,1,1,2,2,3], 2) -> [1, 2]
        """
        pass

    @staticmethod
    def merge_k_lists(lists: list[ListNode | None]) -> ListNode | None:
        """
        LeetCode 23
        Example:
            lists = [[1,4,5], [1,3,4], [2,6]]
            merge_k_lists(lists) -> linked list representing [1,1,2,3,4,4,5,6]
        """
        pass

    @staticmethod
    def k_closest(points: list[list[int]], k: int) -> list[list[int]]:
        """
        LeetCode 973
        Example:
            k_closest([[1,3],[-2,2]], 1) -> [[-2,2]]
            k_closest([[3,3],[5,-1],[-2,4]], 2) -> [[3,3],[-2,4]]
        """
        pass


class MedianFinder:
    """
    LeetCode 295 — Find Median from Data Stream
    Example:
        mf = MedianFinder()
        mf.add_num(1)
        mf.add_num(2)
        mf.find_median() -> 1.5
        mf.add_num(3)
        mf.find_median() -> 2.0
    """

    def __init__(self):
        pass

    def add_num(self, num: int) -> None:
        pass

    def find_median(self) -> float:
        pass


# ---------------------------------------------------------------------------
# 9. 2D Matrix Traversal
# ---------------------------------------------------------------------------

class Matrix:

    @staticmethod
    def spiral_order(matrix: list[list[int]]) -> list[int]:
        """
        LeetCode 54
        Example:
            matrix = [[1,2,3],[4,5,6],[7,8,9]]
            spiral_order(matrix) -> [1,2,3,6,9,8,7,4,5]
        """
        pass

    @staticmethod
    def exist(board: list[list[str]], word: str) -> bool:
        """
        LeetCode 79
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

    @staticmethod
    def set_zeroes(matrix: list[list[int]]) -> None:
        """
        LeetCode 73 (modifies matrix in place)
        Example:
            matrix = [[1,1,1],[1,0,1],[1,1,1]]
            set_zeroes(matrix) -> matrix becomes [[1,0,1],[0,0,0],[1,0,1]]
        """
        pass


# ---------------------------------------------------------------------------
# Quick manual check — run this file directly to try things out as you
# implement them. Nothing is asserted automatically; just print and compare
# against the docstring examples above.
# ---------------------------------------------------------------------------

if __name__ == "__main__":
    print(Recursion.factorial(5))          # expect 120
    print(HashMaps.two_sum([2, 7, 11, 15], 9))  # expect [0, 1]
    print(BinarySearch.search([-1, 0, 3, 5, 9, 12], 9))  # expect 4
