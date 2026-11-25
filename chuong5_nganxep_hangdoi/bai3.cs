using System;
using System.Collections.Generic;

namespace Buoi05_Stack_Queue
{
    internal class StackFrame // Đại diện cho một khung ngăn xếp của hàm đang hoạt động
    {
        public string TenHam;
        public string ThamSo;
        public string DiaChiTraVe;

        public StackFrame(string tenHam, string thamSo, string diaChiTraVe)
        {
            TenHam = tenHam;
            ThamSo = thamSo;
            DiaChiTraVe = diaChiTraVe;
        }

        public override string ToString()
        {
            return $"{TenHam}({ThamSo}) [Return -> {DiaChiTraVe}]";
        }
    }

    internal class Bai3
    {
        public static void Chay()
        {
            Stack<StackFrame> callStack = new Stack<StackFrame>(); // Ngăn xếp lời gọi hàm

            // Mô phỏng gọi hàm (Push) và kết thúc/trả về từ hàm (Pop)
            GoiHam(callStack, new StackFrame("Main", "args[]", "OS"));
            GoiHam(callStack, new StackFrame("TinhTong", "n = 5", "Main:line 12"));
            GoiHam(callStack, new StackFrame("CongDon", "a = 3, b = 2", "TinhTong:line 8"));

            KetThucHam(callStack); // CongDon trả về
            KetThucHam(callStack); // TinhTong trả về

            GoiHam(callStack, new StackFrame("InKetQua", "tong = 5", "Main:line 15"));
            KetThucHam(callStack); // InKetQua trả về
            KetThucHam(callStack); // Main kết thúc
        }

        private static void GoiHam(Stack<StackFrame> callStack, StackFrame frame)
        {
            callStack.Push(frame); // Đẩy khung ngăn xếp mới vào đỉnh Stack
            Console.WriteLine($"[Gọi hàm]   Push: {frame} | Độ sâu Stack: {callStack.Count}");
        }

        private static void KetThucHam(Stack<StackFrame> callStack)
        {
            if (callStack.Count == 0)
            {
                Console.WriteLine("[Trả về]    Call Stack đang rỗng.");
                return;
            }
            StackFrame frameKetThuc = callStack.Pop(); // Lấy khung ngăn xếp của hàm kết thúc ra khỏi Stack
            string hamTiepTheo = callStack.Count > 0 ? callStack.Peek().TenHam : "Kết thúc chương trình";
            Console.WriteLine($"[Trả về]    Pop : {frameKetThuc.TenHam} -> Quay về: {hamTiepTheo}");
        }
    }
}