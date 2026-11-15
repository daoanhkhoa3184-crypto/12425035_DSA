using System;

namespace BaiTapChuong3
{
    /// <summary>
    /// Class chuyên xử lý giải thuật tính tổng phân số S(n) = 1 + 1/2 + 1/3 + ... + 1/n
    /// </summary>
    public class tinhtongphanso
    {
        // -------------------------------------------------------------------------
        // GIẢI THUẬT 1: Đệ quy (Recursive)
        // Gợi ý từ đề bài:
        // - Điểm dừng (suy biến): n = 1 thì trả về 1.0
        // - Trường hợp đệ quy: n > 1 thì S(n) = S(n-1) + 1.0 / n
        // -------------------------------------------------------------------------
        public static double TinhTongPhanSo_DeQuy(int n)
        {
            // Ghi chú: Điểm dừng của đệ quy, khi n = 1 thì tổng là 1.0
            if (n <= 1)
            {
                return 1.0;
            }

            // Ghi chú: Gọi đệ quy tính S(n-1) rồi cộng thêm phân số 1.0 / n 
            // (Phải dùng 1.0 để ép kiểu số thực, tránh bị chia nguyên làm mất phần thập phân)
            return TinhTongPhanSo_DeQuy(n - 1) + 1.0 / n;
        }

        // -------------------------------------------------------------------------
        // GIẢI THUẬT 2: Vòng lặp (Iterative) - Dùng để đối chứng kết quả và hiệu năng
        // -------------------------------------------------------------------------
        public static double TinhTongPhanSo_VongLap(int n)
        {
            double sum = 0.0;
            // Ghi chú: Dùng vòng lặp cộng dồn từng phân số từ i = 1 đến n
            for (int i = 1; i <= n; i++)
            {
                sum += 1.0 / i;
            }
            return sum;
        }
    }
}