using System;
using System.Diagnostics;

namespace Buoi02_DanhSach
{
    internal class Bai3
    {
        public static void Chay()
        {
            Console.Write("Nhập số nguyên dương n cần kiểm tra nguyên tố: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0) // Kiểm tra đầu vào
            {
                Console.WriteLine("Vui lòng nhập số nguyên dương hợp lệ!");
                return;
            }

            Stopwatch sw1 = Stopwatch.StartNew(); // Giải thuật 1: Duyệt từ 2 đến n - 1 -> O(n)
            bool kq1 = NguyenTo_DuyetDenNTru1(n);
            sw1.Stop();

            Stopwatch sw2 = Stopwatch.StartNew(); // Giải thuật 2: Duyệt đến căn bậc 2 của n -> O(sqrt(n))
            bool kq2 = NguyenTo_DuyetDenCanN(n);
            sw2.Stop();

            Stopwatch sw3 = Stopwatch.StartNew(); // Giải thuật 3: Kiểm tra bước nhảy 6k +- 1 -> O(sqrt(n)) nhưng ít phép chia hơn
            bool kq3 = NguyenTo_BuocNhay6(n);
            sw3.Stop();

            Console.WriteLine($"Kết quả kiểm tra {n}: {(kq2 ? "Là số nguyên tố" : "Không phải số nguyên tố")}");
            Console.WriteLine($"  1. Duyệt 2..n-1 [O(n)]: {kq1} | {sw1.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine($"  2. Duyệt 2..sqrt(n) [O(sqrt(n))]: {kq2} | {sw2.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine($"  3. Bước nhảy 6k+-1 [O(sqrt(n)) tối ưu]: {kq3} | {sw3.Elapsed.TotalMilliseconds:F4} ms");
        }

        private static bool NguyenTo_DuyetDenNTru1(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= n - 1; i++) // Kiểm tra chia hết cho mọi số từ 2 đến n - 1
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        private static bool NguyenTo_DuyetDenCanN(int n)
        {
            if (n < 2) return false;
            int limit = (int)Math.Sqrt(n); // Nếu n có ước > sqrt(n) thì ắt có ước < sqrt(n)
            for (int i = 2; i <= limit; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        private static bool NguyenTo_BuocNhay6(int n)
        {
            if (n <= 1) return false;
            if (n == 2 || n == 3) return true;
            if (n % 2 == 0 || n % 3 == 0) return false; // Loại nhanh bội của 2 và 3

            for (int i = 5; (long)i * i <= n; i += 6) // Chỉ kiểm tra các số dạng 6k - 1 và 6k + 1
            {
                if (n % i == 0 || n % (i + 2) == 0) return false;
            }
            return true;
        }
    }
}