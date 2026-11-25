using System;

namespace Buoi04_DanhSach
{
    internal class Node
    {
        public int Data;
        public Node Next;
        public Node(int data)
        {
            Data = data;
            Next = null;
        }
    }

    internal class Bai4
    {
        private static Node pHead = null;

        public static void Chay()
        {
            pHead = null;
            Console.Write("Nhập số lượng nút nguyên dương ban đầu: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Số lượng nút phải > 0!");
                return;
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Nhập giá trị nguyên dương nút {i + 1}: ");
                if (!int.TryParse(Console.ReadLine(), out int val) || val <= 0)
                {
                    Console.WriteLine("Chỉ nhận số nguyên dương, nhập lại!");
                    i--;
                    continue;
                }
                ThemCuoi(val);
            }

            Console.Write("Danh sách ban đầu: ");
            InDanhSach();

            Console.Write("Nhập x cần đếm số lần xuất hiện (a): ");
            if (int.TryParse(Console.ReadLine(), out int xDem))
            {
                int d = DemBangX(xDem);
                Console.WriteLine($"a. Số lượng phần tử bằng {xDem}: {d}");
            }

            int minDuong = TimDuongNhoNhat();
            Console.WriteLine("b. Phần tử dương nhỏ nhất: " + (minDuong == int.MaxValue ? "Không có" : minDuong.ToString()));

            Console.Write("Nhập giá trị x cần xóa lần đầu tiên (c): ");
            if (int.TryParse(Console.ReadLine(), out int xXoa))
            {
                bool daXoa = XoaDauTien(xXoa);
                Console.WriteLine(daXoa ? $"c. Đã xóa nút đầu tiên có giá trị {xXoa}." : $"c. Không tìm thấy giá trị {xXoa} để xóa.");
                Console.Write("Danh sách sau khi xóa: ");
                InDanhSach();
            }
        }

        private static void ThemCuoi(int val)
        {
            Node moi = new Node(val);
            if (pHead == null)
            {
                pHead = moi;
                return;
            }
            Node cur = pHead;
            while (cur.Next != null) cur = cur.Next;
            cur.Next = moi;
        }

        private static int DemBangX(int x)
        {
            int d = 0;
            Node cur = pHead;
            while (cur != null)
            {
                if (cur.Data == x) d++;
                cur = cur.Next;
            }
            return d;
        }

        private static int TimDuongNhoNhat()
        {
            int minduong = int.MaxValue;
            Node cur = pHead;
            while (cur != null)
            {
                if (cur.Data > 0 && cur.Data < minduong)
                {
                    minduong = cur.Data;
                }
                cur = cur.Next;
            }
            return minduong;
        }

        private static bool XoaDauTien(int x)
        {
            if (pHead == null) return false;

            if (pHead.Data == x)
            {
                pHead = pHead.Next;
                return true;
            }

            Node t = pHead;
            Node p = pHead.Next;
            while (p != null && p.Data != x)
            {
                t = p;
                p = p.Next;
            }

            if (p == null) return false;

            t.Next = p.Next;
            return true;
        }

        private static void InDanhSach()
        {
            if (pHead == null)
            {
                Console.WriteLine("(Rỗng)");
                return;
            }
            Node cur = pHead;
            while (cur != null)
            {
                Console.Write(cur.Data + (cur.Next != null ? " -> " : ""));
                cur = cur.Next;
            }
            Console.WriteLine();
        }
    }
}