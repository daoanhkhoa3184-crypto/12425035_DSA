using System;

namespace Buoi06_CayNhiPhan
{
    internal class TNode
    {
        public int Data;
        public TNode Left;
        public TNode Right;

        public TNode(int data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }

    internal class CayNhiPhanMau
    {
        public static TNode TaoCayMau()
        {
            // Cây nhị phân mẫu:
            //         50
            //        /  \
            //      30    70
            //     /  \  /  \
            //   20  40 60  80
            TNode root = new TNode(50);
            root.Left = new TNode(30);
            root.Right = new TNode(70);
            root.Left.Left = new TNode(20);
            root.Left.Right = new TNode(40);
            root.Right.Left = new TNode(60);
            root.Right.Right = new TNode(80);
            return root;
        }
    }

    internal class Bai1
    {
        public static void Chay()
        {
            TNode root = CayNhiPhanMau.TaoCayMau();
            int soNut = DemSoNut(root); // Gọi thuật toán đếm số nút trên cây
            Console.WriteLine($"Tổng số nút trên cây nhị phân là: {soNut}");
        }

        private static int DemSoNut(TNode node)
        {
            if (node == null) return 0; // Cây rỗng không có nút nào
            // Số nút = 1 (nút hiện tại) + số nút cây con trái + số nút cây con phải
            return 1 + DemSoNut(node.Left) + DemSoNut(node.Right);
        }
    }
}