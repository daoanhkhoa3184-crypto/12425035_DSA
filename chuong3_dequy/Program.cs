using System;
using System.Text;

namespace Buoi03_Stack_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; // Hiển thị tiếng Việt có dấu trên Console

            Console.WriteLine("=== BÀI 1: TÍNH TỔNG S(n) = 1 + 2 + ... + n ===");
            Bai1.Chay();

            Console.WriteLine("\n=== BÀI 2: TÍNH TỔNG BÌNH PHƯƠNG S(n) ===");
            Bai2.Chay();

            Console.WriteLine("\n=== BÀI 3: TÍNH TỔNG NGHỊCH ĐẢO S(n) ===");
            Bai3.Chay();

            Console.WriteLine("\n=== BÀI 4: TÍNH LŨY THỪA S(x, n) = x^n ===");
            Bai4.Chay();

            Console.WriteLine("\n=== BÀI 5: TÌM ƯỚC SỐ LẺ LỚN NHẤT CỦA n ===");
            Bai5.Chay();

            Console.WriteLine("\n=== BÀI 6: TÌM ƯỚC CHUNG LỚN NHẤT (EUCLID) ===");
            Bai6.Chay();

            Console.WriteLine("\n=== BÀI 7: ĐẾM SỐ CHỮ SỐ CỦA n ===");
            Bai7.Chay();

            Console.WriteLine("\n=== BÀI 8: TÍNH TỔNG CĂN LỒNG NHAU S(n) ===");
            Bai8.Chay();
        }
    }
}