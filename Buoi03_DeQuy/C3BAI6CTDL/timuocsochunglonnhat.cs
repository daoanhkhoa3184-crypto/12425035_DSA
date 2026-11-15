using System;

namespace BaiTapChuong3
{
    /// <summary>
    /// Class chuyên xử lý tìm Ước chung lớn nhất (ƯCLN) của 2 số nguyên dương a, b
    /// </summary>
    public class timuocchunglonnhat
    {

        // GIẢI THUẬT 1: Đệ quy theo giải thuật Euclid (Recursive)
        // Gợi ý từ đề bài:
        // Điểm dừng (suy biến): Nếu a % b == 0 thì trả về b
        //  Trường hợp đệ quy: Ngược lại thì gọi UCLN(b, a % b)

        public static long TimUCLN_DeQuy(long a, long b)
        {
            // Ghi chú: Trường hợp suy biến (điểm dừng), khi a chia hết cho b thì b chính là ƯCLN
            if (a % b == 0)
            {
                return b;
            }

            // Ghi chú: Trường hợp đệ quy, gọi lại hàm với tham số mới là (b) và số dư (a % b)
            return TimUCLN_DeQuy(b, a % b);
        }

        // GIẢI THUẬT 2: Vòng lặp Euclid (Iterative) - Dùng để chạy đối chứng hiệu năng
       
        public static long TimUCLN_VongLap(long a, long b) // dòng này để chạy đối chứng hiệu năng
        {
            // Lặp đến khi số dư bằng 0
            while (b != 0)
            {
                // các dòng này để chạy đối chứng hiệu năng
                long temp = a % b;
                a = b;
               
                b = temp;
            }
            return a;
        }
    }
}