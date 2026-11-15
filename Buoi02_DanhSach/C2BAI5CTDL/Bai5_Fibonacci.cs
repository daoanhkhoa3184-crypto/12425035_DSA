using System;
using System.Diagnostics;

namespace BaiTapChuong2
{
    public class Bai5_Fibonacci
    {
        public static void Run()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=========================================================");
            Console.WriteLine("    BÀI TẬP 5: TÌM SỐ FIBONACCI THỨ N & SO SÁNH HIỆU NĂNG     ");
            Console.WriteLine("=========================================================\n");

            Console.Write("Nhập số nguyên n cần tìm (Gợi ý: n <= 40 nếu chạy đệ quy thường): ");
            if (int.TryParse(Console.ReadLine(), out int n) && n >= 0)
            {
                Stopwatch sw = new Stopwatch();

                // 1. Giải thuật 1: Đệ quy trực tiếp O(2^n) - Chỉ test n nhỏ để tránh đơ máy
                long res1 = -1;
                double time1 = 0;
                if (n <= 40)
                {
                    sw.Start();
                    res1 = FibonacciSolver.Fibonacci_DirectRecursion(n);
                    sw.Stop();
                    time1 = sw.Elapsed.TotalMilliseconds;
                }

                // 2. Giải thuật 2: Vòng lặp O(n)
                sw.Restart();
                long res2 = FibonacciSolver.Fibonacci_Iteration(n);
                sw.Stop();
                double time2 = sw.Elapsed.TotalMilliseconds;

                // 3. Giải thuật 3: Đệ quy có nhớ O(n)
                sw.Restart();
                long res3 = FibonacciSolver.Fibonacci_Memoization(n);
                sw.Stop();
                double time3 = sw.Elapsed.TotalMilliseconds;

                // 4. Giải thuật 4: Ma trận O(log n)
                sw.Restart();
                long res4 = FibonacciSolver.Fibonacci_Matrix(n);
                sw.Stop();
                double time4 = sw.Elapsed.TotalMilliseconds;

                // In kết quả
                Console.WriteLine($"\n--> KẾT QUẢ SỐ FIBONACCI F({n}) = {res2}");
                Console.WriteLine("---------------------------------------------------------");
                if (n <= 40)
                    Console.WriteLine($"[1. Đệ quy trực tiếp O(2^n)]  Thời gian: {time1:F4} ms");
                else
                    Console.WriteLine("[1. Đệ quy trực tiếp O(2^n)]  Bỏ qua (n quá lớn gây tràn stack/treo máy)");

                Console.WriteLine($"[2. Vòng lặp O(n)]            Thời gian: {time2:F6} ms");
                Console.WriteLine($"[3. Đệ quy có nhớ O(n)]       Thời gian: {time3:F6} ms");
                Console.WriteLine($"[4. Ma trận O(log n)]         Thời gian: {time4:F6} ms");
                Console.WriteLine("---------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("Giá trị n không hợp lệ!");
            }
        }
    }
}