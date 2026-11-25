using System;

namespace Buoi01_DeQuy
{
    internal class Bai1
    {
        public static void Chay()
        {
            const int n = 1000; // Số lượng phần tử tự nhiên cần sinh ngẫu nhiên
            int[] a = new int[n]; // Khởi tạo mảng 1000 phần tử
            Random rd = new Random(); // Đối tượng sinh số ngẫu nhiên

            int max = int.MinValue; // Khởi tạo max nhỏ nhất có thể để dễ so sánh
            int min = int.MaxValue; // Khởi tạo min lớn nhất có thể để dễ so sánh

            for (int i = 0; i < n; i++) // Duyệt qua từng vị trí của mảng
            {
                a[i] = rd.Next(0, 10000); // Sinh số tự nhiên ngẫu nhiên từ 0 đến 9999
                if (a[i] > max) max = a[i]; // Cập nhật số lớn nhất
                if (a[i] < min) min = a[i]; // Cập nhật số nhỏ nhất
            }

            Console.WriteLine($"a. Số lớn nhất: {max}"); // In kết quả câu a
            Console.WriteLine($"b. Số nhỏ nhất: {min}"); // In kết quả câu b
        }
    }
}