using System;
using System.Collections.Generic;

namespace Buoi05_Stack_Queue
{
    internal class Bai2
    {
        public static void Chay()
        {
            Stack<string> backStack = new Stack<string>(); // Lưu các trang đã truy cập trước đó
            Stack<string> forwardStack = new Stack<string>(); // Lưu các trang có thể chuyển tiếp đến
            string trangHienTai = "https://home.local"; // Trang khởi đầu

            // Danh sách thao tác mô phỏng: truy cập trang mới, Back, Forward
            string[] thaoTac =
            {
                "VISIT:https://news.local",
                "VISIT:https://docs.local",
                "BACK",
                "BACK",
                "FORWARD",
                "VISIT:https://forum.local",
                "BACK"
            };

            Console.WriteLine($"Trang bắt đầu: {trangHienTai}");

            for (int i = 0; i < thaoTac.Length; i++)
            {
                string lenh = thaoTac[i];

                if (lenh.StartsWith("VISIT:")) // Truy cập trang mới
                {
                    string trangMoi = lenh.Substring("VISIT:".Length);
                    backStack.Push(trangHienTai); // Đẩy trang hiện tại vào Stack Back
                    trangHienTai = trangMoi;
                    forwardStack.Clear(); // Xóa sạch Stack Forward khi rẽ sang trang mới
                    Console.WriteLine($"[Truy cập] -> Đang xem: {trangHienTai} (Back: {backStack.Count}, Forward: {forwardStack.Count})");
                }
                else if (lenh == "BACK") // Nhấn Back
                {
                    if (backStack.Count > 0)
                    {
                        forwardStack.Push(trangHienTai); // Đẩy trang hiện tại vào Stack Forward
                        trangHienTai = backStack.Pop(); // Lấy trang từ Stack Back ra hiển thị
                        Console.WriteLine($"[Back]     -> Đang xem: {trangHienTai} (Back: {backStack.Count}, Forward: {forwardStack.Count})");
                    }
                    else
                    {
                        Console.WriteLine("[Back]     -> Không thể quay lại (Stack Back rỗng).");
                    }
                }
                else if (lenh == "FORWARD") // Nhấn Forward
                {
                    if (forwardStack.Count > 0)
                    {
                        backStack.Push(trangHienTai); // Đẩy trang hiện tại vào Stack Back
                        trangHienTai = forwardStack.Pop(); // Lấy trang từ Stack Forward ra hiển thị
                        Console.WriteLine($"[Forward]  -> Đang xem: {trangHienTai} (Back: {backStack.Count}, Forward: {forwardStack.Count})");
                    }
                    else
                    {
                        Console.WriteLine("[Forward]  -> Không thể chuyển tiếp (Stack Forward rỗng).");
                    }
                }
            }
        }
    }
}