using System;
using System.Collections.Generic;

namespace Buoi04_DanhSach
{
    internal struct NhanVien
    {
        public string MaNV;
        public string Hoten;
        public int Namsinh;
        public string Phongban;
        public int LuongCB;
        public int Thuong;
    }

    internal class Bai2
    {
        private static NhanVien[] DS = new NhanVien[0]; // Tương thích C# 7.3

        public static void Chay()
        {
            Console.Write("Nhập số lượng nhân viên: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Số lượng nhân viên phải > 0!");
                return;
            }

            DS = new NhanVien[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"--- Nhập nhân viên thứ {i + 1} ---");
                Console.Write("Mã NV: ");
                DS[i].MaNV = Console.ReadLine(); // Bỏ ?? "" cho C# 7.3
                Console.Write("Họ và tên: ");
                DS[i].Hoten = Console.ReadLine();
                Console.Write("Năm sinh: ");
                int.TryParse(Console.ReadLine(), out DS[i].Namsinh);
                Console.Write("Phòng ban: ");
                DS[i].Phongban = Console.ReadLine();
                Console.Write("Lương cơ bản: ");
                int.TryParse(Console.ReadLine(), out DS[i].LuongCB);
                Console.Write("Thưởng: ");
                int.TryParse(Console.ReadLine(), out DS[i].Thuong);
            }

            long tongThucLinh = 0;
            for (int i = 0; i < DS.Length; i++)
            {
                tongThucLinh += Thuclinh(i);
            }
            Console.WriteLine($"a. Tổng thực lĩnh tháng của toàn công ty: {tongThucLinh}");

            int minLuongCB = int.MaxValue;
            for (int i = 0; i < DS.Length; i++)
            {
                if (DS[i].LuongCB < minLuongCB)
                {
                    minLuongCB = DS[i].LuongCB;
                }
            }
            Console.WriteLine($"b. Nhân viên có lương cơ bản thấp nhất ({minLuongCB}):");
            for (int i = 0; i < DS.Length; i++)
            {
                if (DS[i].LuongCB == minLuongCB)
                {
                    Console.WriteLine($"   - {DS[i].MaNV} | {DS[i].Hoten} | {DS[i].Phongban} | LCB: {DS[i].LuongCB}");
                }
            }

            int demThuongCao = 0;
            for (int i = 0; i < DS.Length; i++)
            {
                if (DS[i].Thuong >= 1200000) demThuongCao++;
            }
            Console.WriteLine($"c. Số nhân viên có mức thưởng >= 1200000: {demThuongCao}");

            List<NhanVien> dsSapXep = new List<NhanVien>(DS);
            dsSapXep.Sort((x, y) =>
            {
                int cmpPb = string.Compare(x.Phongban, y.Phongban, StringComparison.OrdinalIgnoreCase);
                if (cmpPb != 0) return cmpPb;
                return string.Compare(y.MaNV, x.MaNV, StringComparison.OrdinalIgnoreCase);
            });
            Console.WriteLine("d. Danh sách sắp xếp (Phòng ban tăng dần, Mã NV giảm dần):");
            foreach (var nv in dsSapXep)
            {
                Console.WriteLine($"   - Phòng: {nv.Phongban} | Mã NV: {nv.MaNV} | Tên: {nv.Hoten} | Thực lĩnh: {nv.LuongCB + nv.Thuong}");
            }

            Console.WriteLine("e. Cập nhật tăng lương cơ bản cho tất cả nhân viên thêm 5%:");
            for (int i = 0; i < DS.Length; i++)
            {
                DS[i].LuongCB = (int)Math.Round(DS[i].LuongCB * 1.05);
                Console.WriteLine($"   - {DS[i].MaNV} ({DS[i].Hoten}): LCB mới = {DS[i].LuongCB}, Thực lĩnh mới = {Thuclinh(i)}");
            }
        }

        private static long Thuclinh(int index)
        {
            return (long)DS[index].LuongCB + DS[index].Thuong;
        }
    }
}