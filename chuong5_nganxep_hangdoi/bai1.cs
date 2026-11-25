using System;
using System.Collections.Generic;

namespace Buoi05_Stack_Queue
{
    internal class Bai1
    {
        public static void Chay()
        {
            Console.Write("Nhập biểu thức toán học cần kiểm tra: ");
            string bieuThuc = Console.ReadLine(); // Đọc chuỗi biểu thức từ bàn phím

            bool hopLe = KiemTraNgoacHopLe(bieuThuc); // Gọi hàm kiểm tra bằng Stack
            Console.WriteLine(hopLe
                ? "Kết quả: Biểu thức HỢP LỆ (các dấu ngoặc đóng mở đúng cách)."
                : "Kết quả: Biểu thức KHÔNG HỢP LỆ.");
        }

        private static bool KiemTraNgoacHopLe(string expr)
        {
            if (expr == null) return true;

            Stack<char> stack = new Stack<char>(); // Ngăn xếp lưu các dấu ngoặc mở

            for (int i = 0; i < expr.Length; i++) // Duyệt từng ký tự của biểu thức
            {
                char c = expr[i];

                // Gặp dấu ngoặc mở thì đẩy vào Stack
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                // Gặp dấu ngoặc đóng thì kiểm tra Stack rỗng và đỉnh Stack có khớp không
                else if (c == ')' || c == ']' || c == '}')
                {
                    if (stack.Count == 0) return false; // Không có ngoặc mở tương ứng -> sai

                    char mo = stack.Pop(); // Lấy dấu ngoặc mở trên cùng ra đối chiếu
                    if (!LaCapTuongUng(mo, c)) return false; // Không khớp cặp -> sai
                }
            }

            // Duyệt hết biểu thức: nếu Stack rỗng thì mọi dấu ngoặc đều đã đóng đủ
            return stack.Count == 0;
        }

        private static bool LaCapTuongUng(char mo, char dong)
        {
            return (mo == '(' && dong == ')') ||
                   (mo == '[' && dong == ']') ||
                   (mo == '{' && dong == '}');
        }
    }
}