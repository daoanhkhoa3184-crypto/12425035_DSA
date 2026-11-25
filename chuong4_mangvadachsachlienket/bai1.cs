using System;

namespace Buoi04_DanhSach
{
    internal class Bai1
    {
        public static void Chay()
        {
            Console.Write("Nhập số nguyên dương n: "); // a. Nhập n
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Vui lòng nhập số nguyên dương n > 0!");
                return;
            }

            int[] a = new int[n]; // Khai báo khởi tạo mảng a
            for (int i = 0; i < n; i++) // Duyệt for i = 0..n-1 để nhập từng phần tử
            {
                Console.Write($"Nhập a[{i}]: ");
                if (!int.TryParse(Console.ReadLine(), out int val) || val <= 0)
                {
                    Console.WriteLine("Giá trị phải là số nguyên dương, nhập lại!");
                    i--;
                    continue;
                }
                a[i] = val;
            }

            Console.Write("Danh sách các phần tử: "); // b. Hiển thị cách nhau 1 khoảng trống
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + (i < a.Length - 1 ? " " : ""));
            }
            Console.WriteLine();

            Console.Write("Nhập giá trị x cần chèn: "); // c. Nhập x và vị trí k
            if (!int.TryParse(Console.ReadLine(), out int x)) return;

            Console.Write($"Nhập vị trí k cần chèn (từ 0 đến {a.Length}): ");
            if (!int.TryParse(Console.ReadLine(), out int k) || k < 0 || k > a.Length)
            {
                Console.WriteLine("Vị trí k không hợp lệ!");
                return;
            }

            int[] tmp = new int[a.Length + 1]; // Khởi tạo mảng trung gian độ dài a.Length + 1
            for (int i = 0; i < k; i++) // Gán tmp[i] = a[i] với i từ 0 -> k-1
            {
                tmp[i] = a[i];
            }
            tmp[k] = x; // Gán giá trị cần chèn tại vị trí k
            for (int i = k; i < a.Length; i++) // Gán tmp[i+1] = a[i] với i từ k -> a.Length-1
            {
                tmp[i + 1] = a[i];
            }
            a = tmp; // Cuối cùng gán mảng a = tmp

            Console.Write("Danh sách sau khi chèn: ");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + (i < a.Length - 1 ? " " : ""));
            }
            Console.WriteLine();
        }
    }
}