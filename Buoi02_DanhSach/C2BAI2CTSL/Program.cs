using System;
using System.Diagnostics;

class Program
{
    // =========================================================================
    // GIẢI THUẬT 1: TÌM KIẾM NHỊ PHÂN DÙNG VÒNG LẶP (Iterative Binary Search)
    // Độ phức tạp thời gian: O(log n)
    // Độ phức tạp bộ nhớ: O(1)
    // =========================================================================
    static int BinarySearchIterative(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2; // Tránh tràn số nguyên khi left, right lớn

            if (arr[mid] == target)
                return mid; // Tìm thấy phần tử

            if (arr[mid] < target)
                left = mid + 1; // Tìm ở nửa bên phải
            else
                right = mid - 1; // Tìm ở nửa bên trái
        }

        return -1; // Không tìm thấy
    }

    // =========================================================================
    // GIẢI THUẬT 2: TÌM KIẾM NHỊ PHÂN DÙNG ĐỆ QUY (Recursive Binary Search)
    // Độ phức tạp thời gian: O(log n)
    // Độ phức tạp bộ nhớ: O(log n) - do bộ nhớ Call Stack
    // =========================================================================
    static int BinarySearchRecursive(int[] arr, int left, int right, int target)
    {
        if (left > right)
            return -1; // Trường hợp cơ sở: Không tìm thấy

        int mid = left + (right - left) / 2;

        if (arr[mid] == target)
            return mid;

        if (arr[mid] > target)
            return BinarySearchRecursive(arr, left, mid - 1, target);

        return BinarySearchRecursive(arr, mid + 1, right, target);
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("=======================================================================");
        Console.WriteLine(" BÀI TẬP 2: ĐÁNH GIÁ VÀ SO SÁNH GIẢI THUẬT TÌM KIẾM NHỊ PHÂN (C#)");
        Console.WriteLine("=======================================================================\n");

        // Các kích thước mảng n đủ lớn để thử nghiệm thực nghiệm
        int[] sizes = { 100000, 1000000, 10000000, 50000000 };
        int target = -1; // Tìm giá trị không tồn tại để ép thuật toán chạy trường hợp xấu nhất O(log n)

        // In bảng so sánh thời gian thực thi (Thực nghiệm)
        Console.WriteLine("{0,-15} | {1,-22} | {2,-22}", "Kích thước (N)", "Thời gian Lặp (ms)", "Thời gian Đệ quy (ms)");
        Console.WriteLine(new string('-', 68));

        Stopwatch timer = new Stopwatch();

        foreach (int size in sizes)
        {
            // Khởi tạo mảng đã sắp xếp từ 0 đến size - 1
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = i;
            }

            // Đo thời gian Giải thuật Lặp
            timer.Restart();
            BinarySearchIterative(arr, target);
            timer.Stop();
            double timeIterative = timer.Elapsed.TotalMilliseconds;

            // Đo thời gian Giải thuật Đệ quy
            timer.Restart();
            BinarySearchRecursive(arr, 0, arr.Length - 1, target);
            timer.Stop();
            double timeRecursive = timer.Elapsed.TotalMilliseconds;

            Console.WriteLine("{0,-15:N0} | {1,-22:F4} | {2,-22:F4}", size, timeIterative, timeRecursive);
        }

        Console.WriteLine(new string('-', 68));
        Console.WriteLine("\n--> NHẬN XÉT THỰC NGHIỆM:");
        Console.WriteLine("1. Cả 2 giải thuật đều có thời gian chạy cực kỳ nhanh ngay cả khi N = 50,000,000 (dưới 1ms).");
        Console.WriteLine("2. Giải thuật Lặp tiết kiệm bộ nhớ hơn O(1) so với Đệ quy O(log n).");

        Console.ReadKey();
    }
}