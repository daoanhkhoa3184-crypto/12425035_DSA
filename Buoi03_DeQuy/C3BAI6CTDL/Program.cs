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
            Console.WriteLine("  BÀI TẬP 6 (CHƯƠNG 3): TÌM ƯỚC CHUNG LỚN NHẤT BẰNG ĐỆ QUY ");
            Console.WriteLine("=========================================================\n");

            Console.Write("Nhập số nguyên dương a: ");
            // dòng dưới chức năng kiểm tra đầu vào có phải là số nguyên dương hay không
            if (long.TryParse(Console.ReadLine(), out long a) && a > 0)
            {
                // dòng dưới chức năng kiểm tra đầu vào có phải là số nguyên dương hay không
                Console.Write("Nhập số nguyên dương b: ");
                // dòng dưới chức năng kiểm tra đầu vào có phải là số nguyên dương hay không
                if (long.TryParse(Console.ReadLine(), out long b) && b > 0)
                {
                    // Ghi chú: Khởi tạo Stopwatch để đo thời gian thực thi của các thuật toán
                    Stopwatch sw = new Stopwatch();

                    // 1. Đo thời gian giải thuật Đệ quy Euclid
                    sw.Start();
                    long ketQuaDeQuy = timuocchunglonnhat.TimUCLN_DeQuy(a, b);
                    sw.Stop();
                    double timeDeQuy = sw.Elapsed.TotalMilliseconds;

                    // 2. Đo thời gian giải thuật Vòng lặp đối chứng
                    sw.Restart();
                    long ketQuaVongLap = timuocchunglonnhat.TimUCLN_VongLap(a, b);
                    sw.Stop();
                    double timeVongLap = sw.Elapsed.TotalMilliseconds;

                    // In kết quả ra màn hình
                    Console.WriteLine($"\n--> Ước chung lớn nhất của {a} và {b} là: {ketQuaDeQuy}");
                    Console.WriteLine("---------------------------------------------------------");
                    Console.WriteLine($"[1. Giải thuật Đệ quy]   Thời gian: {timeDeQuy:F4} ms");
                    Console.WriteLine($"[2. Giải thuật Vòng lặp] Thời gian: {timeVongLap:F4} ms");
                    Console.WriteLine("---------------------------------------------------------");
                }
                // điều kiện dưới để làm rõ nếu người dùng nhập vào giá trị b không hợp lệ (không phải số nguyên dương)
                else
                {
                    Console.WriteLine("Giá trị b nhập vào không hợp lệ (phải là số nguyên dương)!");
                }
            }

            // dòng dưới để làm rõ nếu người dùng nhập vào giá trị a không hợp lệ (không phải số nguyên dương)
            else
            {
                Console.WriteLine("Giá trị a nhập vào không hợp lệ (phải là số nguyên dương)!");
            }
            //in thông báo cho người dùng để bấm phím bất kỳ để thoát chương trình
            Console.WriteLine("\nBấm phím bất kỳ để thoát...");
            // dòng dưới để giữ màn hình console mở cho đến khi người dùng bấm phím bất kỳ
            Console.ReadKey();
        }
    }
}