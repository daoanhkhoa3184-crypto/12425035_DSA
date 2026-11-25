using System;

namespace Buoi03_Stack_Queue
{
    internal class Bai2
    {
        public static void Chay()
        {
            Console.Write("Nhập số nguyên dương n: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Vui lòng nhập số nguyên dương n > 0!");
                return;
            }

            long kq = TinhTongBinhPhuong(n); // Gọi hàm đệ quy
            Console.WriteLine($"S({n}) = 1 + 2^2 + ... + {n}^2 = {kq}");
        }

        private static long TinhTongBinhPhuong(int n)
        {
            if (n == 1) return 1; // Trường hợp suy biến: n = 1 trả về 1
            return TinhTongBinhPhuong(n - 1) + (long)n * n; // Đệ quy: S(n) = S(n - 1) + n^2
        }
    }
}