using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Buoi02_DanhSach
{
    internal class Bai4
    {
        public static void Chay()
        {
            Console.Write("Nhập số nguyên dương N để liệt kê các số hoàn hảo < N: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 1) // Kiểm tra N
            {
                Console.WriteLine("Vui lòng nhập số nguyên dương N > 1!");
                return;
            }

            Stopwatch sw1 = Stopwatch.StartNew(); // Giải thuật 1: Duyệt ước từ 1 đến x/2 -> O(N^2)
            List<int> ds1 = LietKeCoBan(n);
            sw1.Stop();

            Stopwatch sw2 = Stopwatch.StartNew(); // Giải thuật 2: Duyệt ước tới sqrt(x) -> O(N * sqrt(N))
            List<int> ds2 = LietKeCaiTien(n);
            sw2.Stop();

            Console.WriteLine($"Các số hoàn hảo nhỏ hơn {n}: {(ds2.Count > 0 ? string.Join(", ", ds2) : "Không có")}");
            Console.WriteLine($"  1. Giải thuật cơ bản [O(N^2)]: {sw1.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine($"  2. Giải thuật cải tiến duyệt đến căn [O(N*sqrt(N))]: {sw2.Elapsed.TotalMilliseconds:F4} ms");
        }

        private static List<int> LietKeCoBan(int n)
        {
            List<int> ketQua = new List<int>();
            for (int x = 2; x < n; x++) // Xét từng số nguyên dương nhỏ hơn n
            {
                int tongUoc = 0;
                for (int i = 1; i <= x / 2; i++) // Ước thực sự lớn nhất không vượt quá x / 2
                {
                    if (x % i == 0) tongUoc += i;
                }
                if (tongUoc == x) ketQua.Add(x); // Tổng ước đúng bằng chính nó là số hoàn hảo
            }
            return ketQua;
        }

        private static List<int> LietKeCaiTien(int n)
        {
            List<int> ketQua = new List<int>();
            for (int x = 2; x < n; x++)
            {
                int tongUoc = 1; // 1 luôn là ước dương của mọi số x > 1
                int can = (int)Math.Sqrt(x);
                for (int i = 2; i <= can; i++) // Cộng cặp ước (i và x / i) trong 1 lần duyệt
                {
                    if (x % i == 0)
                    {
                        tongUoc += i;
                        int uocDoi = x / i;
                        if (uocDoi != i && uocDoi != x) tongUoc += uocDoi;
                    }
                }
                if (x > 1 && tongUoc == x) ketQua.Add(x);
            }
            return ketQua;
        }
    }
}