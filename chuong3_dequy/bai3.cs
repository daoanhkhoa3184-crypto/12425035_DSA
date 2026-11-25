using System;

namespace Buoi03_Stack_Queue
{
    internal class Bai3
    {
        public static void Chay()
        {
            Console.Write("Nhập số nguyên dương n: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Vui lòng nhập số nguyên dương n > 0!");
                return;
            }

            double kq = TinhTongNghichDao(n); // Gọi hàm đệ quy
            Console.WriteLine($"S({n}) = 1 + 1/2 + ... + 1/{n} = {kq:F4}");
        }

        private static double TinhTongNghichDao(int n)
        {
            if (n == 1) return 1.0; // Trường hợp suy biến: n = 1 trả về 1
            return TinhTongNghichDao(n - 1) + 1.0 / n; // Đệ quy: S(n) = S(n - 1) + 1.0 / n
        }
    }
}