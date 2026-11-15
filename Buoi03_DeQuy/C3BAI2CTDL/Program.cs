using System;
using System.Diagnostics;

namespace BaiTapChuong3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ghi chú: Thiết lập bảng mã UTF-8 để hiển thị tiếng Việt trên màn hình Console không bị lỗi font
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=========================================================");
            Console.WriteLine("  BÀI TẬP 2 (CHƯƠNG 3): TÍNH TỔNG BÌNH PHƯƠNG S(n) BẰNG ĐỆ QUY ");
            Console.WriteLine("=========================================================\n");

            Console.Write("Nhập số nguyên dương n: ");
            // Ghi chú: Đọc dữ liệu người dùng nhập vào và kiểm tra xem có phải số hợp lệ hay không
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                // Ghi chú: Khởi tạo Stopwatch để đo thời gian chạy thực tế của thuật toán
                Stopwatch sw = new Stopwatch();

                // 1. Đo thời gian giải thuật Đệ quy
                sw.Start();
                long ketQuaDeQuy = tinhtongbinhphuong.TinhTongBinhPhuong_DeQuy(n);
                sw.Stop();
                double timeDeQuy = sw.Elapsed.TotalMilliseconds;

                // 2. Đo thời gian giải thuật Vòng lặp đối chứng
                sw.Restart();
                long ketQuaVongLap = tinhtongbinhphuong.TinhTongBinhPhuong_VongLap(n);
                sw.Stop();
                double timeVongLap = sw.Elapsed.TotalMilliseconds;

                // In kết quả ra màn hình
                Console.WriteLine($"\n--> KẾT QUẢ S({n}) = 1^2 + 2^2 + ... + {n}^2 là: {ketQuaDeQuy}");
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