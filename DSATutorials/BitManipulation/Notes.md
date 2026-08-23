# Bit Manipulation — Notes

## Lowest Set Bit via Two's Complement

In two's complement, negating a number is: `-x = (~x) + 1` (flip all bits, then add 1).

Because of this, `x & (-x)` isolates the **lowest (rightmost) set bit** of `x`.

### Example

```
 x  =  0000 0110   (6)
~x  =  1111 1001
-x  = ~x + 1 = 1111 1010
------------------------
x & (-x) = 0000 0010   ← only the lowest set bit remains
```

### Related bit tricks

| Trick          | Effect                          | Example (`0110`) |
| -------------- | ------------------------------- | ---------------- |
| `x & (-x)`     | Isolate lowest set bit          | `0010`           |
| `x & (x - 1)`  | Clear lowest set bit            | `0100`           |
| `x \| (x + 1)` | Set lowest unset (0) bit        | `0111`           |

### Caveats

- Works for any `x != 0`. For `x == 0`, `0 & -0 == 0` (no set bit exists).
- Avoid on `int.MinValue`, since `-x` overflows for the most-negative integer.

### Where it's used

- `BitCounting/SingleNumber3.cs` — uses `xorResult & (-xorResult)` to pick a
  differentiating bit that splits numbers into two groups.
