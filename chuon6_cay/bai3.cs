using System;

namespace Buoi06_CayNhiPhan
{
    internal class Bai3
    {
        public static void Chay()
        {
            TNode root = CayNhiPhanMau.TaoCayMau();
            Console.Write("Giá trị các nút trên cây nhị phân (duyệt NLR): ");
            HienThiCacNut(root);
            Console.WriteLine();
        }

        private static void HienThiCacNut(TNode node)
        {
            if (node == null) return;
            Console.Write(node.Data + " "); // In giá trị nút hiện tại
            HienThiCacNut(node.Left); // Duyệt cây con trái
            HienThiCacNut(node.Right); // Duyệt cây con phải
        }
    }
}