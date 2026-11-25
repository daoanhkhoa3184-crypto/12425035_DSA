using System;

namespace Buoi03_Stack_Queue
{
    internal class Bai7
    {
        public static void Chay()
        {
            Console.Write("Nhập số nguyên dương n: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Vui lòng nhập số nguyên dương n > 0!");
                return;
            }

            int kq = SoChuSo(n); // Gọi hàm đệ quy đếm chữ số
            Console.WriteLine($"Số {n} có {kq} chữ số.");
        }

        private static int SoChuSo(int n)
        {
            if (n == 0) return 0; // Trường hợp suy biến: n = 0 trả về 0
            return SoChuSo(n / 10) + 1; // Trường hợp đệ quy: bỏ chữ số cuối và cộng thêm 1
        }
    }
}