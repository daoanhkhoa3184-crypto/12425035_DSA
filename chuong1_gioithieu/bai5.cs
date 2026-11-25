using System;

namespace Buoi01_DeQuy
{
    internal class Bai5
    {
        public static void Chay()
        {
            Console.Write("Nhập số nguyên dương n (tính từ F(0) = 0, F(1) = 1): "); // Nhắc nhập n
            if (!int.TryParse(Console.ReadLine(), out int n) || n < 0) // Kiểm tra đầu vào hợp lệ
            {
                Console.WriteLine("Vui lòng nhập số nguyên dương hợp lệ!");
                return;
            }

            long fib = Fibonacci(n); // Tính số Fibonacci thứ n (dùng long tránh tràn số)
            Console.WriteLine($"Số Fibonacci thứ {n} là: {fib}"); // In kết quả
        }

        private static long Fibonacci(int n) // Tính Fibonacci theo vòng lặp (nhanh, không tràn stack)
        {
            if (n == 0) return 0; // Phần tử thứ 0 là 0
            if (n == 1) return 1; // Phần tử thứ 1 là 1

            long truoc2 = 0; // F(i - 2)
            long truoc1 = 1; // F(i - 1)
            long hienTai = 0; // F(i)

            for (int i = 2; i <= n; i++) // Tính dần từ vị trí 2 đến n
            {
                hienTai = truoc1 + truoc2; // Số sau bằng tổng 2 số trước
                truoc2 = truoc1; // Dịch sang phải 1 bước
                truoc1 = hienTai; // Cập nhật số liền trước mới
            }

            return hienTai; // Trả về số Fibonacci thứ n
        }
    }
}