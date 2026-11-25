using System;

namespace Buoi06_CayNhiPhan
{
    internal class Bai5
    {
        public static void Chay()
        {
            TNode root = CayNhiPhanMau.TaoCayMau();
            int demChan = DemNutChan(root); // Gọi hàm đếm nút có giá trị chẵn
            Console.WriteLine($"Số lượng nút có giá trị chẵn trên cây nhị phân là: {demChan}");
        }

        private static int DemNutChan(TNode node)
        {
            if (node == null) return 0;
            int laChan = (node.Data % 2 == 0) ? 1 : 0; // 1 nếu nút hiện tại chẵn, ngược lại 0
            return laChan + DemNutChan(node.Left) + DemNutChan(node.Right);
        }
    }
}