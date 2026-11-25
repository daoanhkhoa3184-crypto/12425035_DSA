using System;
using System.Collections.Generic;

namespace Buoi05_Stack_Queue
{
    internal class GoiTin
    {
        public int SoThuTu;
        public string NoiDung;
        public int DoTreMs;
        public bool CoLoi;

        public GoiTin(int stt, string noiDung, int doTreMs, bool coLoi)
        {
            SoThuTu = stt;
            NoiDung = noiDung;
            DoTreMs = doTreMs;
            CoLoi = coLoi;
        }

        public override string ToString()
        {
            string trangThai = CoLoi ? "Lỗi đường truyền" : "Bình thường";
            return $"Packet #{SoThuTu} [\"{NoiDung}\", trễ {DoTreMs}ms, {trangThai}]";
        }
    }

    internal class Bai5
    {
        public static void Chay()
        {
            Queue<GoiTin> duongTruyen = new Queue<GoiTin>(); // Hàng đợi gói tin trên đường truyền

            // Gửi các gói tin vào cuối Queue
            duongTruyen.Enqueue(new GoiTin(1, "SYN_REQUEST", 15, false));
            duongTruyen.Enqueue(new GoiTin(2, "AUTH_TOKEN", 25, false));
            duongTruyen.Enqueue(new GoiTin(3, "DATA_BLOCK_01", 40, true));
            duongTruyen.Enqueue(new GoiTin(4, "DATA_BLOCK_02", 20, false));

            Console.WriteLine($"Đã đưa {duongTruyen.Count} gói tin vào đường truyền. Bắt đầu xử lý theo FIFO:");

            while (duongTruyen.Count > 0) // Lấy từ đầu Queue theo đúng thứ tự đến
            {
                GoiTin pkt = duongTruyen.Dequeue();
                if (pkt.CoLoi)
                {
                    Console.WriteLine($"[Xử lý] {pkt} -> Phát hiện lỗi, yêu cầu gửi lại gói này.");
                }
                else
                {
                    Console.WriteLine($"[Xử lý] {pkt} -> Nhận thành công.");
                }
            }
        }
    }
}