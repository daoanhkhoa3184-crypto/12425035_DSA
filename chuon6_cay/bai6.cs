using System;

namespace Buoi06_CayNhiPhan
{
    internal class Bai6
    {
        public static void Chay()
        {
            TNode root = CayNhiPhanMau.TaoCayMau();

            Console.Write("Nhập giá trị nút cần đếm số con trực tiếp (ví dụ 30, 50, 20): ");
            if (!int.TryParse(Console.ReadLine(), out int giaTriCanTim))
            {
                Console.WriteLine("Giá trị nhập không hợp lệ!");
                return;
            }

            TNode nutTimThay = TimNut(root, giaTriCanTim);
            if (nutTimThay == null)
            {
                Console.WriteLine($"Không tìm thấy nút có giá trị {giaTriCanTim} trên cây.");
                return;
            }

            int soConTrucTiep = DemConTrucTiep(nutTimThay);
            Console.WriteLine($"Nút {giaTriCanTim} có {soConTrucTiep} nút con trực tiếp (trái/phải).");
        }

        private static TNode TimNut(TNode node, int giaTri)
        {
            if (node == null) return null;
            if (node.Data == giaTri) return node;

            TNode trai = TimNut(node.Left, giaTri);
            if (trai != null) return trai;

            return TimNut(node.Right, giaTri);
        }

        private static int DemConTrucTiep(TNode node)
        {
            if (node == null) return 0;
            int dem = 0;
            if (node.Left != null) dem++;  // Có con trái
            if (node.Right != null) dem++; // Có con phải
            return dem;
        }
    }
}