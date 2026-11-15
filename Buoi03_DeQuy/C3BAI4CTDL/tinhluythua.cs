using System;

namespace BaiTapChuong3
{
    /// <summary>
    /// Class chuyên xử lý tính lũy thừa S(x, n) = x^n bằng đệ quy
    /// </summary>
    public class tinhluythua
    {
        // -------------------------------------------------------------------------
        // HÀM 1: Tính lũy thừa cơ sở LuyThua(X, N) với N >= 0
        // - Điểm dừng (suy biến): N = 0 thì trả về 1.0
        // - Trường hợp đệ quy: N > 0 thì LuyThua(X, N) = LuyThua(X, N - 1) * X
        // -------------------------------------------------------------------------
        public static double LuyThuaDuong(double x, int n)
        {
            // Ghi chú: Điểm dừng của đệ quy, bất kỳ số nào mũ 0 cũng bằng 1
            if (n == 0)
            {
                return 1.0;
            }

            // Ghi chú: Trường hợp đệ quy, nhân thêm x vào kết quả của bậc (n - 1)
            return LuyThuaDuong(x, n - 1) * x;
        }

        // -------------------------------------------------------------------------
        // HÀM 2: Hàm tổng quát S(x, n) xử lý cả trường hợp n âm (theo gợi ý đề bài)
        // Nếu n < 0 thì x^n = 1 / (x^(-n))
        // -------------------------------------------------------------------------
        public static double TinhS(double x, int n)
        {
            // Ghi chú: Nếu số mũ n âm, chuyển về dạng nghịch đảo 1.0 / x^(-n)
            if (n < 0)
            {
                return 1.0 / LuyThuaDuong(x, -n);
            }
            else
            {
                // Ghi chú: Nếu n >= 0, gọi trực tiếp hàm tính lũy thừa dương
                return LuyThuaDuong(x, n);
            }
        }

        // -------------------------------------------------------------------------
        // GIẢI THUẬT 2: Dùng vòng lặp (Iterative) - Chạy đối chứng hiệu năng
        // -------------------------------------------------------------------------
        public static double TinhS_VongLap(double x, int n)
        {
            if (n == 0) return 1.0;

            double ketQua = 1.0;
            int soMu = Math.Abs(n);

            // Ghi chú: Dùng vòng lặp nhân dồn x số lần bằng số mũ
            for (int i = 1; i <= soMu; i++)
            {
                ketQua *= x;
            }

            // Ghi chú: Nếu n âm thì lấy nghịch đảo
            return n < 0 ? 1.0 / ketQua : ketQua;
        }
    }
}