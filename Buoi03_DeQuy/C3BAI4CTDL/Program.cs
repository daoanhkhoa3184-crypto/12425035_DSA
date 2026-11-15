using System;
using System.Diagnostics;

namespace BaiTapChuong3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ghi chú: Cấu hình bảng mã hiển thị tiếng Việt trên Console
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=========================================================");
            Console.WriteLine("  BÀI TẬP 4 (CHƯƠNG 3): TÍNH LŨY THỪA S(x, n) = x^n BẰNG ĐỆ QUY");
            Console.WriteLine("=========================================================\n");

            Console.Write("Nhập cơ số thực x: ");
            if (double.TryParse(Console.ReadLine(), out double x))
            {
                Console.Write("Nhập số nguyên n (có thể âm hoặc dương): ");
                if (int.TryParse(Console.ReadLine(), out int n))
                {
                    // Ghi chú: Khởi tạo Stopwatch để đo thời gian thực thi
                    Stopwatch sw = new Stopwatch();

                    // 1. Đo thời gian giải thuật Đệ quy
                    sw.Start();
                    double ketQuaDeQuy = tinhluythua.TinhS(x, n);
                    sw.Stop();
                    double timeDeQuy = sw.Elapsed.TotalMilliseconds;

                    // 2. Đo thời gian giải thuật Vòng lặp đối chứng
                    sw.Restart();
                    double ketQuaVongLap = tinhluythua.TinhS_VongLap(x, n);
                    sw.Stop();
                    double timeVongLap = sw.Elapsed.TotalMilliseconds;

                    // In kết quả ra màn hình
                    Console.WriteLine($"\n--> KẾT QUẢ S({x}, {n}) = {ketQuaDeQuy:F4}");
                    Console.WriteLine("---------------------------------------------------------");
                    Console.WriteLine($"[1. Giải thuật Đệ quy]   Thời gian: {timeDeQuy:F4} ms");
                    Console.WriteLine($"[2. Giải thuật Vòng lặp] Thời gian: {timeVongLap:F4} ms");
                    Console.WriteLine("---------------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("Giá trị số mũ n không hợp lệ!");
                }
            }
            else
            {
                Console.WriteLine("Giá trị cơ số x không hợp lệ!");
            }

            Console.WriteLine("\nBấm phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}