using System;

namespace Buoi06_CayNhiPhan
{
    internal class Bai4
    {
        public static void Chay()
        {
            TNode root = CayNhiPhanMau.TaoCayMau();
            Console.Write("Các nút có giá trị chẵn trên cây nhị phân: ");
            HienThiNutChan(root);
            Console.WriteLine();
        }

        private static void HienThiNutChan(TNode node)
        {
            if (node == null) return;
            if (node.Data % 2 == 0) // Kiểm tra giá trị chẵn
            {
                Console.Write(node.Data + " ");
            }
            HienThiNutChan(node.Left);
            HienThiNutChan(node.Right);
        }
    }
}