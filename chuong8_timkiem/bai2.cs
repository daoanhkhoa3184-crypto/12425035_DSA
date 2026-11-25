using System;

namespace Buoi08_TimKiem_BST
{
    internal class SinhVienBST
    {
        public string MaSV;
        public string TenSV;
        public double DiemTB;

        public SinhVienBST(string maSV, string tenSV, double diemTB)
        {
            MaSV = maSV;
            TenSV = tenSV;
            DiemTB = diemTB;
        }

        public override string ToString()
        {
            return $"Mã SV: {MaSV} | Tên SV: {TenSV} | ĐTB: {DiemTB:0.00}";
        }
    }

    internal class NutBST
    {
        public SinhVienBST Data;
        public NutBST Left;
        public NutBST Right;

        public NutBST(SinhVienBST data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }

    internal class Bai2
    {
        public static void Chay()
        {
            NutBST root = null;

            Console.Write("Nhập số lượng sinh viên ban đầu cần thêm vào BST: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n < 0)
            {
                Console.WriteLine("Số lượng không hợp lệ!");
                return;
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"--- Nhập sinh viên thứ {i + 1} ---");
                Console.Write("Mã sinh viên (khóa BST): ");
                string ma = Console.ReadLine();
                Console.Write("Tên sinh viên: ");
                string ten = Console.ReadLine();
                Console.Write("Điểm trung bình: ");
                double.TryParse(Console.ReadLine(), out double dtb);

                root = ChenSinhVien(root, new SinhVienBST(ma, ten, dtb));
            }

            // Hiển thị danh sách theo thứ tự mã sinh viên tăng dần (Duyệt trung thứ tự In-order: L - N - R)
            Console.WriteLine("\n--- Danh sách sinh viên theo thứ tự Mã SV tăng dần (In-order) ---");
            InDanhSachTangDan(root);

            // Tìm kiếm sinh viên theo mã sinh viên
            Console.Write("\nNhập mã sinh viên cần tìm kiếm: ");
            string maTim = Console.ReadLine();
            NutBST nutTim = TimSinhVien(root, maTim);
            if (nutTim != null)
                Console.WriteLine("Tìm thấy sinh viên: " + nutTim.Data);
            else
                Console.WriteLine($"Không tìm thấy sinh viên có mã \"{maTim}\".");

            // Xóa sinh viên theo mã sinh viên (vẫn duy trì tính chất BST)
            Console.Write("\nNhập mã sinh viên cần xóa khỏi BST: ");
            string maXoa = Console.ReadLine();
            root = XoaSinhVien(root, maXoa);

            Console.WriteLine("\n--- Danh sách sinh viên sau khi xóa (duy trì tính chất BST) ---");
            InDanhSachTangDan(root);
        }

        // Chèn sinh viên mới vào BST dựa trên khóa MaSV
        private static NutBST ChenSinhVien(NutBST node, SinhVienBST sv)
        {
            if (node == null) return new NutBST(sv);

            string maMoi = sv.MaSV != null ? sv.MaSV.Trim() : "";
            string maHienTai = node.Data.MaSV != null ? node.Data.MaSV.Trim() : "";
            int cmp = string.Compare(maMoi, maHienTai, StringComparison.OrdinalIgnoreCase);

            if (cmp < 0)
                node.Left = ChenSinhVien(node.Left, sv);
            else if (cmp > 0)
                node.Right = ChenSinhVien(node.Right, sv);
            else
                node.Data = sv; // Trùng mã SV thì cập nhật lại thông tin

            return node;
        }

        // Tìm kiếm nút theo mã sinh viên trên BST
        private static NutBST TimSinhVien(NutBST node, string maSV)
        {
            if (node == null || string.IsNullOrEmpty(maSV)) return null;

            string key = maSV.Trim();
            string maHienTai = node.Data.MaSV != null ? node.Data.MaSV.Trim() : "";
            int cmp = string.Compare(key, maHienTai, StringComparison.OrdinalIgnoreCase);

            if (cmp == 0) return node;
            if (cmp < 0) return TimSinhVien(node.Left, key);
            return TimSinhVien(node.Right, key);
        }

        // Xóa nút theo mã sinh viên và bảo toàn tính chất cây nhị phân tìm kiếm
        private static NutBST XoaSinhVien(NutBST node, string maSV)
        {
            if (node == null || string.IsNullOrEmpty(maSV)) return node;

            string key = maSV.Trim();
            string maHienTai = node.Data.MaSV != null ? node.Data.MaSV.Trim() : "";
            int cmp = string.Compare(key, maHienTai, StringComparison.OrdinalIgnoreCase);

            if (cmp < 0)
            {
                node.Left = XoaSinhVien(node.Left, key);
            }
            else if (cmp > 0)
            {
                node.Right = XoaSinhVien(node.Right, key);
            }
            else
            {
                // Trường hợp 1: Nút lá hoặc chỉ có 1 con
                if (node.Left == null) return node.Right;
                if (node.Right == null) return node.Left;

                // Trường hợp 2: Có đủ 2 con -> lấy nút nhỏ nhất bên cây con phải (inorder successor)
                NutBST nhoNhatBenPhai = TimNutNhoNhat(node.Right);
                node.Data = nhoNhatBenPhai.Data;
                node.Right = XoaSinhVien(node.Right, nhoNhatBenPhai.Data.MaSV);
            }

            return node;
        }

        private static NutBST TimNutNhoNhat(NutBST node)
        {
            NutBST cur = node;
            while (cur != null && cur.Left != null)
            {
                cur = cur.Left;
            }
            return cur;
        }

        // Duyệt trung thứ tự (Trái -> Nút -> Phải) cho kết quả tăng dần theo khóa MaSV
        private static void InDanhSachTangDan(NutBST node)
        {
            if (node == null) return;
            InDanhSachTangDan(node.Left);
            Console.WriteLine("  " + node.Data);
            InDanhSachTangDan(node.Right);
        }
    }
}