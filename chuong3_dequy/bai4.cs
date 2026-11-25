using System;

namespace Buoi03_Stack_Queue
{
    internal class Bai4
    {
        public static void Chay()
        {
            Console.Write("Nhập cơ số x (số thực): ");
            if (!double.TryParse(Console.ReadLine(), out double x))
            {
                Console.WriteLine("Giá trị x không hợp lệ!");
                return;
            }

            Console.Write("Nhập số mũ n (số nguyên): ");
            if (!int.TryParse(Console.ReadLine(), out int n))
            {
                Console.WriteLine("Giá trị n không hợp lệ!");
                return;
            }

            double kq = S(x, n); // Gọi hàm S(x, n) hỗ trợ cả mũ âm và dương
            Console.WriteLine($"S({x}, {n}) = {x}^{n} = {kq}");
        }

        private static double LuyThua(double x, int n)
        {
            if (n == 0) return 1; // Trường hợp suy biến: N = 0 trả về 1
            return LuyThua(x, n - 1) * x; // Đệ quy: LuyThua(X, N) = LuyThua(X, N - 1) * X
        }

        private static double S(double x, int n)
        {
            if (n < 0) return 1.0 / LuyThua(x, -n); // Mũ âm thì nghịch đảo lũy thừa dương
            return LuyThua(x, n); // Mũ không âm tính trực tiếp
        }
    }
}