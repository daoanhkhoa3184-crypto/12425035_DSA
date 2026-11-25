using System;

namespace Buoi03_Stack_Queue
{
    internal class Bai6
    {
        public static void Chay()
        {
            Console.Write("Nhập số nguyên dương a: ");
            if (!int.TryParse(Console.ReadLine(), out int a) || a <= 0)
            {
                Console.WriteLine("Vui lòng nhập số nguyên dương a > 0!");
                return;
            }

            Console.Write("Nhập số nguyên dương b: ");
            if (!int.TryParse(Console.ReadLine(), out int b) || b <= 0)
            {
                Console.WriteLine("Vui lòng nhập số nguyên dương b > 0!");
                return;
            }

            int kq = UCLN(a, b); // Gọi giải thuật Euclid đệ quy
            Console.WriteLine($"Ước chung lớn nhất của {a} và {b} là: {kq}");
        }

        private static int UCLN(int a, int b)
        {
            if (a % b == 0) return b; // Trường hợp suy biến: a chia hết cho b thì UCLN là b
            return UCLN(b, a % b); // Trường hợp đệ quy: UCLN(a, b) = UCLN(b, a % b)
        }
    }
}