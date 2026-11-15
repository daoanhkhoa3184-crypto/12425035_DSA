using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace BaiTapChuong2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cấu hình hiển thị tiếng Việt trên Console
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=========================================================");
            Console.WriteLine("     BÀI TẬP 4: LIỆT KÊ SỐ HOÀN HẢO & SO SÁNH HIỆU NĂNG     ");
            Console.WriteLine("=========================================================\n");

            Console.Write("Nhập giới hạn số nguyên dương N (Khuyên dùng N <= 50000): ");
            if (long.TryParse(Console.ReadLine(), out long n) && n > 0)
            {
                Stopwatch sw = new Stopwatch();

                // 1. Đo thời gian Giải thuật Cơ bản O(N^2)
                sw.Start();
                List<long> listBasic = timsohoanhao.FindBasic(n);
                sw.Stop();
                double timeBasic = sw.Elapsed.TotalMilliseconds;

                // 2. Đo thời gian Giải thuật Cải tiến O(N * sqrt(N))
                sw.Restart();
                List<long> listOptimized = timsohoanhao.FindOptimized(n);
                sw.Stop();
                double timeOptimized = sw.Elapsed.TotalMilliseconds;

                // In kết quả ra màn hình
                Console.WriteLine($"\nCác số hoàn hảo nhỏ hơn {n}:");
                Console.WriteLine(string.Join(", ", listOptimized));
                Console.WriteLine("\n---------------------------------------------------------");
                Console.WriteLine($"[Giải thuật 1 - O(N^2)]       Thời gian: {timeBasic:F4} ms");
                Console.WriteLine($"[Giải thuật 2 - O(N*sqrtN)]   Thời gian: {timeOptimized:F4} ms");
                Console.WriteLine("---------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("Giá trị N không hợp lệ!");
            }

            Console.WriteLine("\nBấm phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}