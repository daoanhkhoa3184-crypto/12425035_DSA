using System;

namespace Buoi06_CayNhiPhan
{
    internal class Bai7
    {
        public static void Chay()
        {
            TNode root = CayNhiPhanMau.TaoCayMau();
            Console.Write("Giá trị các nút trên cây con trái của gốc: ");
            if (root == null || root.Left == null)
            {
                Console.WriteLine("(Cây con trái rỗng)");
                return;
            }
            InCay(root.Left); // Bắt đầu duyệt từ gốc cây con trái (root.Left)
            Console.WriteLine();
        }

        private static void InCay(TNode node)
        {
            if (node == null) return;
            Console.Write(node.Data + " ");
            InCay(node.Left);
            InCay(node.Right);
        }
    }
}