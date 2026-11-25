using System;

namespace Buoi07_SapXep
{
    internal class Bai2
    {
        public static void Chay()
        {
            Console.Write("Nhập số lượng sinh viên: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Số lượng sinh viên phải lớn hơn 0!");
                return;
            }

            // Tạo danh sách sinh viên bằng mảng và nhập thông tin
            SinhVien[] ds = new SinhVien[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"--- Nhập sinh viên thứ {i + 1} ---");
                Console.Write("Mã sinh viên: ");
                string ma = Console.ReadLine();

                Console.Write("Họ tên sinh viên: ");
                string ten = Console.ReadLine();

                Console.Write("Điểm môn 1: ");
                double.TryParse(Console.ReadLine(), out double d1);

                Console.Write("Điểm môn 2: ");
                double.TryParse(Console.ReadLine(), out double d2);

                Console.Write("Điểm môn 3: ");
                double.TryParse(Console.ReadLine(), out double d3);

                ds[i] = new SinhVien(ma, ten, d1, d2, d3);
            }

            // Sắp xếp tăng dần theo họ tên (A -> Z) bằng Bubble Sort + string.CompareTo
            BubbleSortTangDanTheoHoTen(ds);

            Console.WriteLine("\nDanh sách sinh viên sau khi sắp xếp theo họ tên (A -> Z):");
            for (int i = 0; i < ds.Length; i++)
            {
                SinhVien sv = ds[i];
                Console.WriteLine($"{i + 1}. Họ tên: {sv.HoTen} | Mã SV: {sv.MaSV} | ĐTB: {sv.DiemTrungBinh():0.00}");
            }
        }

        // So sánh hai chuỗi họ tên bằng string.CompareTo
        private static void BubbleSortTangDanTheoHoTen(SinhVien[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    string ten1 = arr[j].HoTen != null ? arr[j].HoTen.Trim() : "";
                    string ten2 = arr[j + 1].HoTen != null ? arr[j + 1].HoTen.Trim() : "";

                    // Nếu ten1 đứng sau ten2 theo bảng chữ cái (CompareTo > 0) thì đổi chỗ
                    if (string.Compare(ten1, ten2, StringComparison.CurrentCultureIgnoreCase) > 0)
                    {
                        SinhVien tam = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = tam;
                    }
                }
            }
        }
    }
}