using System;

namespace Buoi03_Stack_Queue
{
    internal class Bai1
    {
        public static void Chay()
        {
            Console.Write("Nhập số nguyên dương n: "); // Nhắc nhập n
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Vui lòng nhập số nguyên dương n > 0!");
                return;
            }

            long kq = TinhTong(n); // Gọi hàm đệ quy
            Console.WriteLine($"S({n}) = 1 + 2 + ... + {n} = {kq}"); // In kết quả
        }

        private static long TinhTong(int n)
        {
            if (n == 1) return 1; // Trường hợp suy biến (cơ sở): n = 1 trả về 1
            return TinhTong(n - 1) + n; // Trường hợp đệ quy: S(n) = S(n - 1) + n
        }
    }
}