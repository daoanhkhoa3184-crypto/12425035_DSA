using System;
using System.Diagnostics;

namespace Buoi02_DanhSach
{
    internal class Bai2
    {
        public static void Chay()
        {
            Console.WriteLine("Hệ thức truy hồi Binary Search: T(n) = T(n/2) + 1, T(1) = 1.");
            Console.WriteLine("Độ phức tạp lý thuyết: Tốt nhất O(1) | Trung bình & Xấu nhất Theta(log n), O(log n), Omega(1).");

            int n = 1000000; // Kích thước mảng lớn để đo thực nghiệm
            int[] arr = new int[n];
            for (int i = 0; i < n; i++) // Tạo mảng đã sắp xếp tăng dần
            {
                arr[i] = i * 2;
            }

            int canTim = arr[n - 1]; // Tìm phần tử cuối mảng (trường hợp xấu nhất cho tìm kiếm tuyến tính)

            Stopwatch sw1 = Stopwatch.StartNew(); // Giải thuật 1: Tìm kiếm tuyến tính O(n)
            int viTri1 = TimKiemTuyenTinh(arr, canTim);
            sw1.Stop();

            Stopwatch sw2 = Stopwatch.StartNew(); // Giải thuật 2: Tìm kiếm nhị phân lặp O(log n)
            int viTri2 = TimKiemNhiPhanLap(arr, canTim);
            sw2.Stop();

            Stopwatch sw3 = Stopwatch.StartNew(); // Giải thuật 3: Tìm kiếm nhị phân đệ quy O(log n)
            int viTri3 = TimKiemNhiPhanDeQuy(arr, canTim, 0, arr.Length - 1);
            sw3.Stop();

            Console.WriteLine($"Mảng n = {n}, tìm giá trị {canTim}:");
            Console.WriteLine($"  1. Tuyến tính O(n): vị trí {viTri1} | {sw1.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine($"  2. Nhị phân lặp O(log n): vị trí {viTri2} | {sw2.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine($"  3. Nhị phân đệ quy O(log n): vị trí {viTri3} | {sw3.Elapsed.TotalMilliseconds:F4} ms");
        }

        private static int TimKiemTuyenTinh(int[] a, int x)
        {
            for (int i = 0; i < a.Length; i++) // Duyệt lần lượt từng phần tử
            {
                if (a[i] == x) return i;
            }
            return -1;
        }

        private static int TimKiemNhiPhanLap(int[] a, int x)
        {
            int left = 0, right = a.Length - 1;
            while (left <= right) // Thu hẹp nửa mảng sau mỗi bước
            {
                int mid = left + (right - left) / 2;
                if (a[mid] == x) return mid;
                if (a[mid] < x) left = mid + 1;
                else right = mid - 1;
            }
            return -1;
        }

        private static int TimKiemNhiPhanDeQuy(int[] a, int x, int left, int right)
        {
            if (left > right) return -1; // Trường hợp cơ sở: không tìm thấy
            int mid = left + (right - left) / 2;
            if (a[mid] == x) return mid;
            if (a[mid] < x) return TimKiemNhiPhanDeQuy(a, x, mid + 1, right);
            return TimKiemNhiPhanDeQuy(a, x, left, mid - 1);
        }
    }
}