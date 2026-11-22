# Arrays — Interview Patterns

## 1. Two Pointers
- **Use when:** Sorted array, pair/triplet sum, in-place removal, partitioning.
- **Key:** `sum < target → left++`, `sum > target → right--`. For in-place problems, use slow (write) and fast (read) pointers.
- **Gotcha:** In 3Sum/4Sum, sort first and skip duplicates.

## 2. Sliding Window
- **Use when:** Contiguous subarray/substring; longest, shortest, or size K.
- **Key:** Expand `right`; shrink `left` while the window is invalid (longest) or valid (shortest). Window size = `right - left + 1`.
- **Gotcha:** Doesn't work with negative numbers for sum problems; use Prefix Sum instead.

## 3. Traversal
- **Use when:** Max, second max, leaders, rotation, next permutation.
- **Key:** One pass, tracking only the state you need. Rotation = **reverse** parts, then reverse the whole array.
- **Gotcha:** Next permutation: find the first decreasing element from the right, swap, then reverse the suffix.

## 4. Hashing
- **Use when:** Seen-before checks, duplicates, complement lookup (Two Sum), frequency counts.
- **Key:** `HashSet` for existence, `Dictionary` for counts and indices. O(1) lookup.
- **Gotcha:** Values in `1..n`: use index marking (negate `nums[i]`) for O(1) space.

## 5. Prefix Sum
- **Use when:** Count subarrays with sum/XOR = K, including negatives.
- **Key:** Count `map[prefix - K]` and store prefix frequencies. Initialize `map[0] = 1`.
- **Gotcha:** Longest subarray: store the **first** index of each prefix, not its count.

## 6. Intervals
- **Use when:** Overlapping ranges; merging, inserting, removing.
- **Key:** Sort by start. Intervals overlap if `curr.start <= prev.end`.
- **Gotcha:** For minimum removals (non-overlapping intervals), sort by **end** and use greedy.

## 7. Kadane
- **Use when:** Maximum subarray sum or product.
- **Key:** `curr = max(num, curr + num)`, `best = max(best, curr)`.
- **Gotcha:** Product: track both max and min (negative × negative). Circular: `max(normalMax, total - minSubarray)`, unless every number is negative.

## 8. Boyer–Moore Voting
- **Use when:** Majority element (> n/2 or > n/3).
- **Key:** Same as candidate → `count++`, otherwise `count--`; when the count is 0, choose a new candidate.
- **Gotcha:** At most 1 candidate for n/2 and 2 for n/3. Verify in a second pass unless a majority is guaranteed.

## 9. Divide and Conquer
- **Use when:** Count pairs `i < j` with a condition (inversions, reverse pairs).
- **Key:** Count across halves during merge sort; O(n log n).
- **Gotcha:** For reverse pairs, count **before** merging.

## 10. Greedy
- **Use when:** Best arrangement or ordering.
- **Key:** Sort with a custom comparator, e.g. `(b + a).CompareTo(a + b)` for Largest Number.
- **Gotcha:** All zeros → return `"0"`.
