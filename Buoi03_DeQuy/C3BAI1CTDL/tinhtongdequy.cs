using System;

namespace BaiTapChuong3
{
    /// <summary>
    /// Class chứa các hàm tính tổng S(n) = 1 + 2 + ... + n
    /// </summary>
    public class tinhtongdequy
    {
        // -------------------------------------------------------------------------
        // GIẢI THUẬT 1: Đệ quy (Recursive)
        // Công thức: S(n) = S(n-1) + n với n > 1; S(1) = 1
        // Độ phức tạp thời gian: O(n), Bộ nhớ: O(n) do stack đệ quy
        // -------------------------------------------------------------------------
        public static long TinhTong_DeQuy(int n)
        {
            // Trường hợp suy biến (điểm dừng)
            if (n <= 1) return 1;

            // Trường hợp đệ quy
            return TinhTong_DeQuy(n - 1) + n;
        }

        // -------------------------------------------------------------------------
        // GIẢI THUẬT 2: Vòng lặp (Iterative) - Dùng để đối chứng hiệu năng
        // Độ phức tạp thời gian: O(n), Bộ nhớ: O(1)
        // -------------------------------------------------------------------------
        public static long TinhTong_VongLap(int n)
        {
            long sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += i;
            }
            return sum;
        }
    }
}