using System;

namespace BaiTapChuong3
{
    /// <summary>
    /// Class chuyên xử lý các giải thuật tính tổng bình phương S(n) = 1^2 + 2^2 + ... + n^2
    /// </summary>
    public class tinhtongbinhphuong
    {
        // -------------------------------------------------------------------------
        // GIẢI THUẬT 1: Đệ quy (Recursive)
        // Gợi ý từ đề bài:
        // - Điểm dừng (suy biến): n = 1 thì trả về 1
        // - Trường hợp đệ quy: n > 1 thì S(n) = S(n-1) + n^2
        // -------------------------------------------------------------------------
        public static long TinhTongBinhPhuong_DeQuy(int n)
        {
            // Ghi chú: Kiểm tra điều kiện điểm dừng của đệ quy
            if (n <= 1)
            {
                return 1; // Khi n = 1, giá trị trả về cơ sở là 1
            }

            // Ghi chú: Gọi lại chính hàm này với giá trị nhỏ hơn (n - 1) 
            // và cộng thêm bình phương của n hiện tại (n * n)
            return TinhTongBinhPhuong_DeQuy(n - 1) + (long)n * n;
        }

        // -------------------------------------------------------------------------
        // GIẢI THUẬT 2: Vòng lặp (Iterative) - Dùng để chạy đối chứng hiệu năng
        // -------------------------------------------------------------------------
        public static long TinhTongBinhPhuong_VongLap(int n)
        {
            long sum = 0;
            // Ghi chú: Dùng vòng lặp từ 1 đến n để cộng dồn bình phương từng số
            for (int i = 1; i <= n; i++)
            {
                sum += (long)i * i;
            }
            return sum;
        }
    }
}