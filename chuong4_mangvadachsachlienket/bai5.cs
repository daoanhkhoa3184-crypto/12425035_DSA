using System;

namespace Buoi04_DanhSach
{
    internal class IntNode
    {
        public int Data;
        public IntNode Next;
        public IntNode(int data)
        {
            Data = data;
            Next = null;
        }
    }

    internal class Bai5
    {
        private static IntNode l = null;

        public static void Chay()
        {
            l = null;
            Console.Write("Nhập số lượng phần tử nguyên của danh sách l: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Số lượng phần tử phải > 0!");
                return;
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Nhập phần tử thứ {i + 1}: ");
                if (!int.TryParse(Console.ReadLine(), out int val))
                {
                    Console.WriteLine("Giá trị không hợp lệ, nhập lại!");
                    i--;
                    continue;
                }
                ThemVaoL(val);
            }

            int maxVal = int.MinValue;
            long tong = 0;
            int demNT = 0;
            int demAm = 0, demKhong = 0, demDuong = 0;
            int minDuong = int.MaxValue;

            IntNode cur = l;
            while (cur != null)
            {
                int val = cur.Data;
                if (val > maxVal) maxVal = val;
                tong += val;
                if (KTNT(val)) demNT++;

                if (val < 0) demAm++;
                else if (val == 0) demKhong++;
                else
                {
                    demDuong++;
                    if (val < minDuong) minDuong = val;
                }

                cur = cur.Next;
            }

            Console.WriteLine($"a. Phần tử lớn nhất trong l: {maxVal}");
            Console.WriteLine($"b. Tổng các phần tử trong l: {tong}");
            Console.WriteLine($"c. Số lượng số nguyên tố trong l: {demNT}");
            Console.WriteLine($"d. Số âm: {demAm} | Số bằng 0: {demKhong} | Số dương: {demDuong}");

            Console.Write("Nhập x cần đếm trong l (e): ");
            if (int.TryParse(Console.ReadLine(), out int x))
            {
                int demX = 0;
                IntNode p = l;
                while (p != null)
                {
                    if (p.Data == x) demX++;
                    p = p.Next;
                }
                Console.WriteLine($"e. Số phần tử bằng {x} trong l: {demX}");
            }

            Console.WriteLine("f. Phần tử dương nhỏ nhất trong l: " + (minDuong == int.MaxValue ? "Không có số dương" : minDuong.ToString()));
        }

        private static void ThemVaoL(int val)
        {
            IntNode moi = new IntNode(val);
            if (l == null)
            {
                l = moi;
                return;
            }
            IntNode cur = l;
            while (cur.Next != null) cur = cur.Next;
            cur.Next = moi;
        }

        private static bool KTNT(int x)
        {
            if (x < 2) return false;
            if (x == 2) return true;
            if (x % 2 == 0) return false;
            int can = (int)Math.Sqrt(x);
            for (int i = 3; i <= can; i += 2)
            {
                if (x % i == 0) return false;
            }
            return true;
        }
    }
}