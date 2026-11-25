using System;

namespace Buoi01_DeQuy
{
    internal class Bai4
    {
        public static void Chay()
        {
            const int n = 1000; // Kích thước mảng 1000 phần tử
            int[] a = new int[n]; // Khởi tạo mảng
            Random rd = new Random(); // Đối tượng sinh số ngẫu nhiên

            for (int i = 0; i < n; i++) // Điền 1000 số tự nhiên ngẫu nhiên
            {
                a[i] = rd.Next(0, 10000);
            }

            Console.WriteLine("a. Mảng ban đầu:"); // Câu a: In mảng chưa sắp xếp
            InMang(a);

            Array.Sort(a); // Câu b: Sắp xếp mảng theo chiều tăng dần

            Console.WriteLine("b. Mảng sau khi sắp xếp tăng dần:"); // In mảng đã sắp xếp
            InMang(a);
        }

        private static void InMang(int[] a) // Hàm phụ in mảng gọn gàng
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write($"{a[i]} "); // In từng phần tử cách nhau bởi dấu cách
            }
            Console.WriteLine(); // Xuống dòng cuối mảng
        }
    }
}