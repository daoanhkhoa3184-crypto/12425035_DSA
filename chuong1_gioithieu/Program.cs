using System;
using System.Text;  

namespace Buoi01_DeQuy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; // Hỗ trợ hiển thị tiếng Việt có dấu trên Console

            Console.WriteLine("BÀI 1 "); // Chạy Bài 1
            Bai1.Chay();

            Console.WriteLine("\n BÀI 2 "); // Chạy Bài 2
            Bai2.Chay();

            Console.WriteLine("\n BÀI 3 "); // Chạy Bài 3
            Bai3.Chay();

            Console.WriteLine("\n BÀI 4 "); // Chạy Bài 4
            Bai4.Chay();

            Console.WriteLine("\n BÀI 5 "); // Chạy Bài 5
            Bai5.Chay();
        }
    }
}