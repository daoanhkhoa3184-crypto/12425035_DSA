using System;
using System.Diagnostics;

namespace Buoi02_DanhSach
{
    internal class Bai1
    {
        public static void Chay()
        {
            Console.Write("Nhập số đĩa n của bài toán Tháp Hà Nội (khuyên dùng n <= 15 để tránh chạy lâu): ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0) // Kiểm tra n hợp lệ
            {
                Console.WriteLine("Vui lòng nhập số nguyên dương n > 0!");
                return;
            }

            long soBuocLyThuyet = (1L << n) - 1; // T(n) = 2^n - 1 với T(1) = 1
            Console.WriteLine($"Trường hợp cơ sở: T(1) = 1 (1 đĩa cần 1 bước chuyển).");
            Console.WriteLine($"Hệ thức truy hồi: T(n) = 2*T(n-1) + 1 -> T({n}) = {soBuocLyThuyet} bước.");
            Console.WriteLine("Độ phức tạp thời gian: O(2^n), Theta(2^n), Omega(2^n).");

            if (n <= 10) // Chỉ in từng bước chuyển khi n nhỏ để màn hình không bị tràn
            {
                Console.WriteLine("Các bước di chuyển đĩa (từ cọc A sang cọc C, trung gian B):");
                GiaiThapHaNoi(n, 'A', 'C', 'B');
            }

            Stopwatch sw = Stopwatch.StartNew(); // Đo thời gian thực thi đệ quy
            long demBuoc = 0;
            DemBuocThapHaNoi(n, ref demBuoc);
            sw.Stop();

            Console.WriteLine($"Thực nghiệm đếm được: {demBuoc} bước | Thời gian chạy: {sw.Elapsed.TotalMilliseconds:F4} ms");
        }

        private static void GiaiThapHaNoi(int n, char nguon, char dich, char trungGian)
        {
            if (n == 1) // Trường hợp cơ sở: còn 1 đĩa thì chuyển thẳng sang cọc đích
            {
                Console.WriteLine($"  Chuyển đĩa 1 từ {nguon} -> {dich}");
                return;
            }

            GiaiThapHaNoi(n - 1, nguon, trungGian, dich); // Chuyển n-1 đĩa sang cọc trung gian
            Console.WriteLine($"  Chuyển đĩa {n} từ {nguon} -> {dich}"); // Chuyển đĩa lớn nhất sang đích
            GiaiThapHaNoi(n - 1, trungGian, dich, nguon); // Chuyển n-1 đĩa từ trung gian sang đích
        }

        private static void DemBuocThapHaNoi(int n, ref long dem)
        {
            if (n == 1) // Mỗi lần gọi cơ sở tốn 1 phép toán/bước
            {
                dem++;
                return;
            }

            DemBuocThapHaNoi(n - 1, ref dem); // T(n-1)
            dem++; // + 1 phép toán cơ bản
            DemBuocThapHaNoi(n - 1, ref dem); // T(n-1)
        }
    }
}