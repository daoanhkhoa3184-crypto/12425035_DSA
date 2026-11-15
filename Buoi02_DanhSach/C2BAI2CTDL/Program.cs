using System;
using System.Diagnostics; // Thư viện dùng để đo thời gian chạy của thuật toán

class Program
{
    // Khai báo biến toàn cục để đếm tổng số phép dịch chuyển đĩa
    static long stepCount = 0;

    /// <summary>
    /// Hàm đệ quy giải bài toán Tháp Hà Nội
    /// </summary>
    /// <param name="n">Số lượng đĩa cần chuyển</param>
    /// <param name="fromRod">Cọc nguồn (Nơi chứa đĩa ban đầu)</param>
    /// <param name="toRod">Cọc đích (Nơi cần chuyển đĩa đến)</param>
    /// <param name="auxRod">Cọc trung gian (Cọc phụ dùng để hỗ trợ)</param>
    static void TowerOfHanoi(int n, char fromRod, char toRod, char auxRod)
    {
        // 1. TRƯỜNG HỢP CƠ SỞ (Base Case): T(1) = 1
        // Khi chỉ còn 1 đĩa, ta chuyển trực tiếp từ cọc nguồn sang cọc đích
        if (n == 1)
        {
            stepCount++; // Đếm 1 phép toán dịch chuyển
            Console.WriteLine($"Bước {stepCount}: Chuyển đĩa 1 từ cọc {fromRod} sang cọc {toRod}");
            return;
        }

        // 2. BƯỚC TRUY HỒI (Recursive Case): T(n) = 2*T(n-1) + 1

        // Gọi bài toán con 1: Chuyển (n-1) đĩa từ cọc nguồn sang cọc phụ (dùng cọc đích làm cọc trung gian)
        TowerOfHanoi(n - 1, fromRod, auxRod, toRod);

        // Thực hiện 1 phép toán cơ bản: Chuyển đĩa lớn nhất (đĩa thứ n) từ cọc nguồn sang cọc đích
        stepCount++; // Đếm 1 phép toán
        Console.WriteLine($"Bước {stepCount}: Chuyển đĩa {n} từ cọc {fromRod} sang cọc {toRod}");

        // Gọi bài toán con 2: Chuyển (n-1) đĩa từ cọc phụ sang cọc đích (dùng cọc nguồn làm cọc trung gian)
        TowerOfHanoi(n - 1, auxRod, toRod, fromRod);
    }

    static void Main(string[] args)
    {
        // Cấu hình hiển thị tiếng Việt trên Console
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("=== CHƯƠNG TRÌNH GIẢI BÀI TOÁN THÁP HÀ NỘI (C#) ===");
        Console.Write("Nhập số lượng đĩa (n): ");

        if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
        {
            // Tính số bước lý thuyết theo công thức T(n) = 2^n - 1
            double theoreticalSteps = Math.Pow(2, n) - 1;

            Console.WriteLine($"\n--- CÁC BƯỚC THỰC HIỆN (Lý thuyết: {theoreticalSteps} bước) ---");

            // Khởi tạo bộ đo thời gian
            Stopwatch timer = Stopwatch.StartNew();

            // Gọi hàm thực thi giải bài toán
            TowerOfHanoi(n, 'A', 'C', 'B');

            timer.Stop();

            // In kết quả tổng kết
            Console.WriteLine("\n-------------------------------------------");
            Console.WriteLine($"-> Thực tế đã thực hiện : {stepCount} bước.");
            Console.WriteLine($"-> Độ phức tạp thời gian: O(2^{n}) = O({theoreticalSteps})");
            Console.WriteLine($"-> Thời gian chạy thực tế : {timer.ElapsedMilliseconds} ms");
            Console.WriteLine("-------------------------------------------");
        }
        else
        {
            Console.WriteLine("Vui lòng nhập một số nguyên dương hợp lệ!");
        }

        Console.ReadKey();
    }
}