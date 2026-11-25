using System;

namespace Buoi01_DeQuy
{
    internal class Bai2
    {
        public static void Chay()
        {
            for (int i = 1; i <= 100; i++) // Duyệt các số từ 1 đến 100
            {
                if (i % 3 == 0 && i % 5 == 0) // Chia hết cho cả 3 và 5 (ưu tiên kiểm tra trước)
                    Console.Write("FizzBuzz ");
                else if (i % 3 == 0) // Chỉ chia hết cho 3
                    Console.Write("Fizz ");
                else if (i % 5 == 0) // Chỉ chia hết cho 5
                    Console.Write("Buzz ");
                else // Các trường hợp còn lại
                    Console.Write($"{i} ");
            }
            Console.WriteLine(); // Xuống dòng sau khi in xong dãy
        }
    }
}