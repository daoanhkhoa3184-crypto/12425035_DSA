using System;

namespace Buoi07_SapXep
{
    internal class SinhVien
    {
        public string MaSV;
        public string HoTen;
        public double Diem1;
        public double Diem2;
        public double Diem3;

        public SinhVien(string maSV, string hoTen, double d1, double d2, double d3)
        {
            MaSV = maSV;
            HoTen = hoTen;
            Diem1 = d1;
            Diem2 = d2;
            Diem3 = d3;
        }

        // Bước 3: Tính điểm trung bình của từng sinh viên
        public double DiemTrungBinh()
        {
            return (Diem1 + Diem2 + Diem3) / 3.0;
        }
    }

    internal class Bai1
    {
        public static void Chay()
        {
            Console.Write("Nhập số lượng sinh viên: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Số lượng sinh viên phải lớn hơn 0!");
                return;
            }

            // Bước 1 & 2: Tạo danh sách sinh viên bằng mảng và nhập thông tin
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

            // Bước 3: Sắp xếp điểm trung bình từ cao xuống thấp bằng Selection Sort
            SelectionSortGiamDanTheoDTB(ds);

            Console.WriteLine("\nDanh sách sinh viên sau khi sắp xếp điểm trung bình (cao -> thấp):");
            for (int i = 0; i < ds.Length; i++)
            {
                SinhVien sv = ds[i];
                Console.WriteLine($"{i + 1}. Mã SV: {sv.MaSV} | Họ tên: {sv.HoTen} | M1: {sv.Diem1}, M2: {sv.Diem2}, M3: {sv.Diem3} | ĐTB: {sv.DiemTrungBinh():0.00}");
            }
        }

        // Thuật toán Selection Sort sắp xếp giảm dần theo điểm trung bình
        private static void SelectionSortGiamDanTheoDTB(SinhVien[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int viTriMax = i; // Tìm phần tử có ĐTB lớn nhất trong đoạn [i .. n-1]
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j].DiemTrungBinh() > arr[viTriMax].DiemTrungBinh())
                    {
                        viTriMax = j;
                    }
                }

                // Hoán đổi vị trí i và viTriMax nếu tìm được phần tử cao hơn
                if (viTriMax != i)
                {
                    SinhVien tam = arr[i];
                    arr[i] = arr[viTriMax];
                    arr[viTriMax] = tam;
                }
            }
        }
    }
}