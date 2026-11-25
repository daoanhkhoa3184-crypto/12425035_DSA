using System;
using System.Collections.Generic;

namespace Buoi05_Stack_Queue
{
    internal class KhachHang
    {
        public string SoThuTuVe;
        public string HoTen;
        public string ThoiGianDen;
        public string LoaiDichVu;

        public KhachHang(string stt, string hoTen, string thoiGianDen, string loaiDichVu)
        {
            SoThuTuVe = stt;
            HoTen = hoTen;
            ThoiGianDen = thoiGianDen;
            LoaiDichVu = loaiDichVu;
        }

        public override string ToString()
        {
            return $"[{SoThuTuVe}] {HoTen} | Đến: {ThoiGianDen} | Dịch vụ: {LoaiDichVu}";
        }
    }

    internal class Bai6
    {
        public static void Chay()
        {
            Queue<KhachHang> hangDoiKhach = new Queue<KhachHang>(); // Hàng đợi khách hàng (FIFO)

            // Khách mới đến -> thêm vào cuối hàng đợi (Enqueue)
            KhachDen(hangDoiKhach, new KhachHang("KH01", "Lê Minh Đức", "08:05", "Mở tài khoản"));
            KhachDen(hangDoiKhach, new KhachHang("KH02", "Phạm Thu Hà", "08:08", "Nộp tiền"));
            KhachDen(hangDoiKhach, new KhachHang("KH03", "Hoàng Quốc Việt", "08:12", "Tư vấn thẻ"));

            HienThiTrangThai(hangDoiKhach);

            // Nhân viên rảnh -> phục vụ khách ở đầu hàng đợi (Dequeue)
            PhucVuKhach(hangDoiKhach, "Quầy 01");
            PhucVuKhach(hangDoiKhach, "Quầy 02");

            KhachDen(hangDoiKhach, new KhachHang("KH04", "Đỗ Khánh Linh", "08:15", "Rút tiền"));
            HienThiTrangThai(hangDoiKhach);

            PhucVuKhach(hangDoiKhach, "Quầy 01");
            PhucVuKhach(hangDoiKhach, "Quầy 02");
            HienThiTrangThai(hangDoiKhach);
        }

        private static void KhachDen(Queue<KhachHang> q, KhachHang kh)
        {
            q.Enqueue(kh); // Thêm vào cuối hàng đợi
            Console.WriteLine($"[Đến]     {kh}");
        }

        private static void PhucVuKhach(Queue<KhachHang> q, string quay)
        {
            if (q.Count == 0)
            {
                Console.WriteLine($"[{quay}]  Không có khách đang chờ.");
                return;
            }
            KhachHang kh = q.Dequeue(); // Phục vụ khách ở đầu hàng đợi
            Console.WriteLine($"[{quay}]  Đang phục vụ: {kh} (Còn {q.Count} khách chờ)");
        }

        private static void HienThiTrangThai(Queue<KhachHang> q)
        {
            Console.WriteLine($"--- Trạng thái hàng đợi: {q.Count} khách đang chờ ---");
        }
    }
}