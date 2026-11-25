using System;
using System.Diagnostics;

namespace Buoi02_DanhSach
{
    internal class Bai5
    {
        public static void Chay()
        {
            Console.Write("Nhập số nguyên dương n (F0 = 0, F1 = 1, khuyên dùng n <= 35 cho đệ quy thường): ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n < 0) // Kiểm tra n
            {
                Console.WriteLine("Vui lòng nhập số nguyên n >= 0!");
                return;
            }

            long fDeQuy = 0;
            Stopwatch sw1 = new Stopwatch();
            if (n <= 35) // Đệ quy thuần O(2^n) chạy rất chậm nếu n quá lớn
            {
                sw1.Start();
                fDeQuy = Fib_DeQuyThuan(n);
                sw1.Stop();
            }

            Stopwatch sw2 = Stopwatch.StartNew(); // Giải thuật 2: Vòng lặp quy hoạch động dưới lên O(n), không gian O(1)
            long fLap = Fib_Lap(n);
            sw2.Stop();

            long[] memo = new long[n + 1];
            for (int i = 0; i <= n; i++) memo[i] = -1; // -1 nghĩa là chưa tính
            Stopwatch sw3 = Stopwatch.StartNew(); // Giải thuật 3: Đệ quy có nhớ (Memoization) O(n)
            long fMemo = Fib_Memo(n, memo);
            sw3.Stop();

            Stopwatch sw4 = Stopwatch.StartNew(); // Giải thuật 4: Lũy thừa ma trận O(log n)
            long fMaTran = Fib_MaTran(n);
            sw4.Stop();

            Console.WriteLine($"Số Fibonacci thứ {n} là: {fLap}");
            Console.WriteLine($"  1. Đệ quy trực tiếp [O(2^n)]: {(n <= 35 ? $"{fDeQuy} | {sw1.Elapsed.TotalMilliseconds:F4} ms" : "Bỏ qua do n > 35 chạy lâu")}");
            Console.WriteLine($"  2. Vòng lặp [O(n), space O(1)]: {fLap} | {sw2.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine($"  3. Đệ quy có nhớ Memoization [O(n), space O(n)]: {fMemo} | {sw3.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine($"  4. Lũy thừa ma trận [O(log n)]: {fMaTran} | {sw4.Elapsed.TotalMilliseconds:F4} ms");
        }

        private static long Fib_DeQuyThuan(int n)
        {
            if (n == 0) return 0; // F0 = 0
            if (n == 1) return 1; // F1 = 1
            return Fib_DeQuyThuan(n - 1) + Fib_DeQuyThuan(n - 2); // Fn = Fn-1 + Fn-2
        }

        private static long Fib_Lap(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            long prev2 = 0, prev1 = 1, cur = 0;
            for (int i = 2; i <= n; i++)
            {
                cur = prev1 + prev2;
                prev2 = prev1;
                prev1 = cur;
            }
            return cur;
        }

        private static long Fib_Memo(int n, long[] memo)
        {
            if (n <= 1) return n;
            if (memo[n] != -1) return memo[n]; // Trả về ngay nếu đã tính trước đó
            memo[n] = Fib_Memo(n - 1, memo) + Fib_Memo(n - 2, memo);
            return memo[n];
        }

        private static long Fib_MaTran(int n)
        {
            if (n == 0) return 0;
            long[,] baseMat = { { 1, 1 }, { 1, 0 } }; // Ma trận cơ sở [[1,1],[1,0]]
            long[,] res = LuyThuaMaTran(baseMat, n - 1);
            return res[0, 0];
        }

        private static long[,] LuyThuaMaTran(long[,] a, int mu)
        {
            long[,] kq = { { 1, 0 }, { 0, 1 } }; // Ma trận đơn vị
            while (mu > 0)
            {
                if ((mu & 1) == 1) kq = NhanMaTran(kq, a);
                a = NhanMaTran(a, a);
                mu >>= 1; // Chia đôi số mũ -> O(log n)
            }
            return kq;
        }

        private static long[,] NhanMaTran(long[,] x, long[,] y)
        {
            long[,] c = new long[2, 2];
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    c[i, j] = x[i, 0] * y[0, j] + x[i, 1] * y[1, j];
            return c;
        }
    }
}