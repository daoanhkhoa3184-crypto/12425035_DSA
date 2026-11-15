using System;
using System.Collections.Generic;

namespace BaiTapChuong2
{
    public class FibonacciSolver
    {
        // -------------------------------------------------------------------------
        // GIẢI THUẬT 1: Đệ quy trực tiếp (Direct Recursion)
        // Độ phức tạp thời gian: O(2^n) - Rất chậm khi n lớn (n > 40)
        // -------------------------------------------------------------------------
        public static long Fibonacci_DirectRecursion(int n)
        {
            if (n <= 0) return 0;
            if (n == 1) return 1;
            return Fibonacci_DirectRecursion(n - 1) + Fibonacci_DirectRecursion(n - 2);
        }

        // -------------------------------------------------------------------------
        // GIẢI THUẬT 2: Dùng vòng lặp (Iteration)
        // Độ phức tạp thời gian: O(n), Bộ nhớ: O(1) - Nhanh và tối ưu
        // -------------------------------------------------------------------------
        public static long Fibonacci_Iteration(int n)
        {
            if (n <= 0) return 0;
            if (n == 1) return 1;

            long prev2 = 0; // F(0)
            long prev1 = 1; // F(1)
            long current = 0;

            for (int i = 2; i <= n; i++)
            {
                current = prev1 + prev2;
                prev2 = prev1;
                prev1 = current;
            }
            return current;
        }

        // -------------------------------------------------------------------------
        // GIẢI THUẬT 3: Đệ quy có nhớ - Quy hoạch động (Memoization / DP)
        // Độ phức tạp thời gian: O(n), Bộ nhớ: O(n)
        // -------------------------------------------------------------------------
        private static Dictionary<int, long> memo = new Dictionary<int, long>();

        public static long Fibonacci_Memoization(int n)
        {
            if (n <= 0) return 0;
            if (n == 1) return 1;

            if (memo.ContainsKey(n))
            {
                return memo[n];
            }

            memo[n] = Fibonacci_Memoization(n - 1) + Fibonacci_Memoization(n - 2);
            return memo[n];
        }

        // -------------------------------------------------------------------------
        // GIẢI THUẬT 4: Ma trận nâng cao (Matrix Exponentiation)
        // Độ phức tạp thời gian: O(log n) - Siêu nhanh cho n cực lớn
        // -------------------------------------------------------------------------
        public static long Fibonacci_Matrix(int n)
        {
            if (n <= 0) return 0;
            long[,] F = new long[,] { { 1, 1 }, { 1, 0 } };
            Power(F, n - 1);
            return F[0, 0];
        }

        private static void Multiply(long[,] F, long[,] M)
        {
            long x = F[0, 0] * M[0, 0] + F[0, 1] * M[1, 0];
            long y = F[0, 0] * M[0, 1] + F[0, 1] * M[1, 1];
            long z = F[1, 0] * M[0, 0] + F[1, 1] * M[1, 0];
            long w = F[1, 0] * M[0, 1] + F[1, 1] * M[1, 1];

            F[0, 0] = x;
            F[0, 1] = y;
            F[1, 0] = z;
            F[1, 1] = w;
        }

        private static void Power(long[,] F, int n)
        {
            if (n == 0 || n == 1) return;
            long[,] M = new long[,] { { 1, 1 }, { 1, 0 } };

            Power(F, n / 2);
            Multiply(F, F);

            if (n % 2 != 0)
                Multiply(F, M);
        }
    }
}