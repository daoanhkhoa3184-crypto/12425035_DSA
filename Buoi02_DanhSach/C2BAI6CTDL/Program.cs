using System;
using System.Diagnostics;

namespace BaiTapChuong2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=========================================================");
            Console.WriteLine("     BÀI TẬP 6: SẮP XẾP DÃY SỐ THỰC & SO SÁNH HIỆU NĂNG     ");
            Console.WriteLine("=========================================================\n");

            Console.Write("Nhập số lượng phần tử N của mảng (ví dụ: 5000): ");
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                // Tự động sinh mảng ngẫu nhiên các số thực để test thực nghiệm
                Random rand = new Random();
                double[] mangGoc = new double[n];
                for (int i = 0; i < n; i++)
                {
                    mangGoc[i] = rand.NextDouble() * 10000; // Sinh số thực ngẫu nhiên từ 0 đến 10000
                }

                // In 5 phần tử đầu tiên của mảng ban đầu
                Console.WriteLine("\n[Mảng ban đầu (5 phần tử đầu tiên)]:");
                InMangThu(mangGoc, 5);

                Stopwatch sw = new Stopwatch();

                // 1. Test Sắp xếp nổi bọt (Bubble Sort)
                double[] mang1 = (double[])mangGoc.Clone();
                sw.Start();
                sapxepmang.SapXepNoiBot(mang1);
                sw.Stop();
                double timeNoiBot = sw.Elapsed.TotalMilliseconds;

                // 2. Test Sắp xếp nhanh (Quick Sort)
                double[] mang2 = (double[])mangGoc.Clone();
                sw.Restart();
                sapxepmang.SapXepNhanh(mang2, 0, mang2.Length - 1);
                sw.Stop();
                double timeNhanh = sw.Elapsed.TotalMilliseconds;

                // 3. Test Sắp xếp trộn (Merge Sort)
                double[] mang3 = (double[])mangGoc.Clone();
                sw.Restart();
                sapxepmang.SapXepTron(mang3, 0, mang3.Length - 1);
                sw.Stop();
                double timeTron = sw.Elapsed.TotalMilliseconds;

                // In kết quả sau khi sắp xếp
                Console.WriteLine("\n[Mảng sau khi sắp xếp tăng dần (5 phần tử đầu tiên)]:");
                InMangThu(mang2, 5);

                Console.WriteLine("\n---------------------------------------------------------");
                Console.WriteLine($"[1. Sắp xếp Nổi bọt - O(n^2)]   Thời gian: {timeNoiBot:F4} ms");
                Console.WriteLine($"[2. Sắp xếp Nhanh   - O(nlogn)] Thời gian: {timeNhanh:F4} ms");
                Console.WriteLine($"[3. Sắp xếp Trộn    - O(nlogn)] Thời gian: {timeTron:F4} ms");
                Console.WriteLine("---------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("Số lượng phần tử N không hợp lệ!");
            }

            Console.WriteLine("\nBấm phím bất kỳ để thoát...");
            Console.ReadKey();
        }

        // Hàm hỗ trợ in thử vài phần tử lên màn hình cho gọn
        static void InMangThu(double[] arr, int count)
        {
            int limit = Math.Min(count, arr.Length);
            for (int i = 0; i < limit; i++)
            {
                Console.Write($"{arr[i]:F2}   ");
            }
            Console.WriteLine("...");
        }
    }
}