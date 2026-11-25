using System;
using System.Collections.Generic;

namespace Buoi05_Stack_Queue
{
    internal class YeuCauIn
    {
        public string MaYeuCau;
        public string TenTaiLieu;
        public int SoTrang;

        public YeuCauIn(string ma, string ten, int soTrang)
        {
            MaYeuCau = ma;
            TenTaiLieu = ten;
            SoTrang = soTrang;
        }

        public override string ToString()
        {
            return $"{MaYeuCau} - {TenTaiLieu} ({SoTrang} trang)";
        }
    }

    internal class Bai4
    {
        public static void Chay()
        {
            Queue<YeuCauIn> hangDoiIn = new Queue<YeuCauIn>(); // Hàng đợi lưu các yêu cầu in (FIFO)

            // Thêm các yêu cầu in mới vào cuối Queue (Enqueue)
            ThemYeuCau(hangDoiIn, new YeuCauIn("IN01", "BaoCao_Chuong5.pdf", 6));
            ThemYeuCau(hangDoiIn, new YeuCauIn("IN02", "Slide_ThuyetTrinh.pptx", 12));
            ThemYeuCau(hangDoiIn, new YeuCauIn("IN03", "DeCuong_OnTap.docx", 4));

            // Xử lý lần lượt từ đầu hàng đợi (Dequeue)
            while (hangDoiIn.Count > 0)
            {
                XuLyIn(hangDoiIn);
            }

            Console.WriteLine("Đã xử lý hết toàn bộ yêu cầu trong hàng đợi in.");
        }

        private static void ThemYeuCau(Queue<YeuCauIn> q, YeuCauIn yc)
        {
            q.Enqueue(yc); // Thêm vào cuối Queue
            Console.WriteLine($"[Enqueue] Vào hàng đợi: {yc} (Đang chờ: {q.Count})");
        }

        private static void XuLyIn(Queue<YeuCauIn> q)
        {
            YeuCauIn yc = q.Dequeue(); // Lấy yêu cầu ở đầu Queue ra xử lý
            Console.WriteLine($"[Dequeue] Đang in: {yc} (Còn lại: {q.Count})");
        }
    }
}