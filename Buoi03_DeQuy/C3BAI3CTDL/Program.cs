using System;
using System.Diagnostics;

namespace BaiTapChuong3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ghi chú: Thiết lập bảng mã hiển thị tiếng Việt trên Console
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=========================================================");
            Console.WriteLine("  BÀI TẬP 3 (CHƯƠNG 3): TÍNH TỔNG PHÂN SỐ S(n) BẰNG ĐỆ QUY  ");
            Console.WriteLine("=========================================================\n");

            Console.Write("Nhập số nguyên dương n: ");
            // Ghi chú: Kiểm tra dữ liệu người dùng nhập vào có hợp lệ hay không
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                // Ghi chú: Khởi tạo Stopwatch để đo thời gian chạy
                Stopwatch sw = new Stopwatch();

                // 1. Đo thời gian giải thuật Đệ quy
                sw.Start();
                double ketQuaDeQuy = tinhtongphanso.TinhTongPhanSo_DeQuy(n);
                sw.Stop();
                double timeDeQuy = sw.Elapsed.TotalMilliseconds;

                // 2. Đo thời gian giải thuật Vòng lặp đối chứng
                sw.Restart();
                double ketQuaVongLap = tinhtongphanso.TinhTongPhanSo_VongLap(n);
                sw.Stop();
                double timeVongLap = sw.Elapsed.TotalMilliseconds;

                // In kết quả ra màn hình (lấy 4 chữ số thập phân cho đẹp)
                Console.WriteLine($"\n--> KẾT QUẢ S({n}) = {ketQuaDeQuy:F4}");
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