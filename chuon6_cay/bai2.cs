using System;

namespace Buoi06_CayNhiPhan
{
    internal class Bai2
    {
        public static void Chay()
        {
            TNode root = CayNhiPhanMau.TaoCayMau();
            long tong = TinhTongGiaTri(root); // Gọi thuật toán tính tổng giá trị các nút
            Console.WriteLine($"Tổng giá trị các nút trên cây nhị phân là: {tong}");
        }

        private static long TinhTongGiaTri(TNode node)
        {
            if (node == null) return 0; // Trường hợp cơ sở: nút null trả về 0
            // Tổng = giá trị nút hiện tại + tổng cây con trái + tổng cây con phải
            return node.Data + TinhTongGiaTri(node.Left) + TinhTongGiaTri(node.Right);
        }
    }
}