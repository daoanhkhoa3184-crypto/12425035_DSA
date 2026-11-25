using System;

namespace Buoi04_DanhSach
{
    internal class Bai3
    {
        public static void Chay()
        {
            Console.Write("Nhập cấp n của ma trận vuông (1 <= n < 100): ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0 || n >= 100)
            {
                Console.WriteLine("Vui lòng nhập 1 <= n < 100!");
                return;
            }

            int[,] a = new int[n, n];
            Random rd = new Random();
            Console.WriteLine("Ma trận vuông sinh ngẫu nhiên:");
            for (int i = 0; i < n; i++) // Khởi tạo và in ma trận
            {
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = rd.Next(-20, 50); // Có cả số âm, 0 và dương để test đủ câu b
                    Console.Write($"{a[i, j],5}");
                }
                Console.WriteLine();
            }

            long tong = 0; // a. Tính tổng tất cả phần tử
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    tong += a[i, j];
            Console.WriteLine($"a. Tổng tất cả phần tử của ma trận: {tong}");

            int minDuong = int.MaxValue; // b. Tìm giá trị dương nhỏ nhất (> 0)
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (a[i, j] > 0 && a[i, j] < minDuong)
                        minDuong = a[i, j];
            Console.WriteLine("b. Giá trị dương nhỏ nhất: " + (minDuong == int.MaxValue ? "Không có số dương" : minDuong.ToString()));

            long tongCheoPhu = 0; // c. Tính tổng đường chéo phụ: j = (n - 1) - i
            for (int i = 0; i < n; i++)
            {
                int j = (n - 1) - i;
                tongCheoPhu += a[i, j];
            }
            Console.WriteLine($"c. Tổng các phần tử trên đường chéo phụ: {tongCheoPhu}");

            int[] tg = new int[n]; // d. Lưu đường chéo chính (i == j) vào mảng tg và kiểm tra tăng dần
            for (int i = 0; i < n; i++)
            {
                tg[i] = a[i, i];
            }
            bool tangDan = true;
            for (int i = 0; i <= n - 2; i++)
            {
                for (int j = i + 1; j <= n - 1; j++)
                {
                    if (!(tg[i] < tg[j])) // Nếu không nhỏ hơn phần tử kế tiếp thì không tăng dần
                    {
                        tangDan = false;
                        break;
                    }
                }
                if (!tangDan) break;
            }
            Console.WriteLine($"d. Đường chéo chính [{string.Join(", ", tg)}] có tăng dần không? {(tangDan ? "Có (True)" : "Không (False)")}");
        }
    }
}