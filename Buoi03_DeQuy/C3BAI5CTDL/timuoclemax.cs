using System;

namespace BaiTapChuong3
{
    /// <summary>
    /// Class chuyên xử lý tìm ước số lẻ lớn nhất của số nguyên dương n bằng đệ quy
    /// </summary>
    public class timuocselemax
    {
        // -------------------------------------------------------------------------
        // GIẢI THUẬT 1: Đệ quy (Recursive) theo đúng gợi ý đề bài
        // - Nếu n là số lẻ (n % 2 == 1): trả về chính n
        // - Nếu n là số chẵn: gọi đệ quy tiếp với n / 2
        // -------------------------------------------------------------------------
        public static long TimUocLeMax_DeQuy(long n)
        {
            // Ghi chú: Trường hợp suy biến, nếu n là số lẻ thì chính nó là ước lẻ lớn nhất
            if (n % 2 != 0)
            {
                return n;
            }

            // Ghi chú: Trường hợp đệ quy, nếu n là số chẵn thì chia đôi n để tìm tiếp
            return TimUocLeMax_DeQuy(n / 2);
        }

        // -------------------------------------------------------------------------
        // GIẢI THUẬT 2: Vòng lặp (Iterative) - Dùng để đối chứng kết quả và hiệu năng
        // -------------------------------------------------------------------------
        public static long TimUocLeMax_VongLap(long n)
        {
            // Ghi chú: Chừng nào n còn là số chẵn thì tiếp tục chia 2
            while (n % 2 == 0)
            {
                n /= 2;
            }
            // Khi n thành số lẻ thì đó chính là ước lẻ lớn nhất cần tìm
            return n;
        }
    }
}