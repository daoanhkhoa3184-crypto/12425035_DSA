using System;

namespace Buoi03_Stack_Queue
{
    internal class Bai5
    {
        public static void Chay()
        {
            Console.Write("Nhập số nguyên dương n: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Vui lòng nhập số nguyên dương n > 0!");
                return;
            }

            int kq = UocLeMax(n); // Gọi hàm đệ quy tìm ước lẻ lớn nhất
            Console.WriteLine($"Ước số lẻ lớn nhất của {n} là: {kq}");
        }

        private static int UocLeMax(int n)
        {
            if (n % 2 == 1) return n; // Trường hợp suy biến: n lẻ thì chính n là ước lẻ lớn nhất
            return UocLeMax(n / 2); // Trường hợp đệ quy: n chẵn thì chia đôi tìm tiếp
        }
    }
}