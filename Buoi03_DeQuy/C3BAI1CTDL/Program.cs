using System;
using System.Diagnostics;

namespace BaiTapChuong3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=========================================================");
            Console.WriteLine("     BÀI TẬP 1 (CHƯƠNG 3): TÍNH TỔNG S(n) BẰNG ĐỆ QUY    ");
            Console.WriteLine("=========================================================\n");

            Console.Write("Nhập số nguyên dương n: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                Stopwatch sw = new Stopwatch();

                // 1. Đo thời gian Giải thuật Đệ quy
                sw.Start();
                long ketQuaDeQuy = tinhtongdequy.TinhTong_DeQuy(n);
                sw.Stop();
                double timeDeQuy = sw.Elapsed.TotalMilliseconds;

                // 2. Đo thời gian Giải thuật Vòng lặp
                sw.Restart();
                long ketQuaVongLap = tinhtongdequy.TinhTong_VongLap(n);
                sw.Stop();
                double timeVongLap = sw.Elapsed.TotalMilliseconds;

                // In kết quả
                Console.WriteLine($"\n--> KẾT QUẢ S({n}) = 1 + 2 + ... + {n} là: {ketQuaDeQuy}");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine($"[1. Giải thuật Đệ quy]   Thời gian: {timeDeQuy:F4} ms");
                Console.WriteLine($"[2. Giải thuật Vòng lặp] Thời gian: {timeVongLap:F4} ms");
                Console.WriteLine("---------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("Giá trị n nhập vào không hợp lệ!");
            }

            Console.WriteLine("\nBấm phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}