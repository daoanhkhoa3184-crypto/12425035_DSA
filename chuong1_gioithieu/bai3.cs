using System;

namespace Buoi01_DeQuy
{
    internal class Bai3
    {
        public static void Chay()
        {
            Console.Write("Nhập chuỗi cần đảo ngược: "); // Nhắc người dùng nhập chuỗi
            string s = Console.ReadLine() ?? ""; // Đọc chuỗi từ bàn phím

            char[] arr = s.ToCharArray(); // Chuyển chuỗi thành mảng ký tự
            Array.Reverse(arr); // Đảo ngược thứ tự các ký tự trong mảng
            string daoNguoc = new string(arr); // Ghép mảng ký tự lại thành chuỗi mới

            Console.WriteLine($"Chuỗi đảo ngược: {daoNguoc}"); // In kết quả
        }
    }
}