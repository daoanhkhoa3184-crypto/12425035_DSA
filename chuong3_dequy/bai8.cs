using System;

namespace Buoi03_Stack_Queue
{
    internal class Bai8
    {
        public static void Chay()
        {
            Console.Write("Nhập số nguyên dương n: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Vui lòng nhập số nguyên dương n > 0!");
                return;
            }

            double kq = S(n); // Gọi hàm tính tổng căn lồng nhau
            Console.WriteLine($"S({n}) = {kq:F4}");
        }

        private static double Can(int i, int n)
        {
            if (i == n) return Math.Sqrt(n); // Trường hợp suy biến: căn trong cùng là sqrt(n)
            return Math.Sqrt(i + Can(i + 1, n)); // Đệ quy lồng từ ngoài vào trong: sqrt(i + Can(i+1, n))
        }

        private static double S(int n)
        {
            return Can(1, n); // Bắt đầu từ lớp căn ngoài cùng i = 1
        }
    }
}