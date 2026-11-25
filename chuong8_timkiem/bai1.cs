using System;
using System.Collections.Generic;

namespace Buoi08_TimKiem_BST
{
    internal class LienHe
    {
        public string Ten;
        public string SoDienThoai;

        public LienHe(string ten, string sdt)
        {
            Ten = ten;
            SoDienThoai = sdt;
        }

        public override string ToString()
        {
            return $"Tên: {Ten} | SĐT: {SoDienThoai}";
        }
    }

    internal class Bai1
    {
        public static void Chay()
        {
            List<LienHe> danhBa = new List<LienHe>();

            // 1. Nhập danh sách người dùng
            Console.Write("Nhập số lượng liên hệ ban đầu: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Số lượng phải lớn hơn 0!");
                return;
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"--- Nhập liên hệ thứ {i + 1} ---");
                Console.Write("Tên người dùng: ");
                string ten = Console.ReadLine();
                Console.Write("Số điện thoại: ");
                string sdt = Console.ReadLine();
                danhBa.Add(new LienHe(ten, sdt));
            }

            // Hiển thị danh sách
            Console.WriteLine("\n--- Danh sách danh bạ ban đầu ---");
            HienThiDanhBa(danhBa);

            // 2. Tìm kiếm tuần tự theo SĐT hoặc tên
            Console.Write("\nNhập từ khóa (tên hoặc SĐT) để tìm kiếm tuần tự: ");
            string tuKhoaTuanTu = Console.ReadLine();
            int idxTuanTu = TimKiemTuanTu(danhBa, tuKhoaTuanTu);
            if (idxTuanTu >= 0)
                Console.WriteLine($"[Tìm kiếm tuần tự] Tìm thấy tại vị trí {idxTuanTu}: {danhBa[idxTuanTu]}");
            else
                Console.WriteLine("[Tìm kiếm tuần tự] Không tìm thấy liên hệ phù hợp.");

            // 3 & 4. Sắp xếp danh sách theo tên người dùng trước khi tìm kiếm nhị phân
            SapXepTheoTen(danhBa);
            Console.WriteLine("\n--- Danh sách danh bạ sau khi sắp xếp theo tên (A -> Z) ---");
            HienThiDanhBa(danhBa);

            Console.Write("\nNhập chính xác tên người dùng để tìm kiếm nhị phân: ");
            string tenCanTim = Console.ReadLine();
            int idxNhiPhan = TimKiemNhiPhanTheoTen(danhBa, tenCanTim);
            if (idxNhiPhan >= 0)
                Console.WriteLine($"[Tìm kiếm nhị phân] Tìm thấy tại vị trí {idxNhiPhan} (sau sắp xếp): {danhBa[idxNhiPhan]}");
            else
                Console.WriteLine("[Tìm kiếm nhị phân] Không tìm thấy tên người dùng này.");

            // 5. Thêm người dùng mới
            Console.WriteLine("\n--- Thêm người dùng mới ---");
            Console.Write("Nhập tên người dùng mới: ");
            string tenMoi = Console.ReadLine();
            Console.Write("Nhập SĐT người dùng mới: ");
            string sdtMoi = Console.ReadLine();
            ThemLienHe(danhBa, new LienHe(tenMoi, sdtMoi));
            Console.WriteLine("Danh bạ sau khi thêm:");
            HienThiDanhBa(danhBa);

            // 5. Xóa người dùng theo tên
            Console.Write("\nNhập tên người dùng cần xóa khỏi danh bạ: ");
            string tenXoa = Console.ReadLine();
            bool daXoa = XoaLienHeTheoTen(danhBa, tenXoa);
            Console.WriteLine(daXoa ? $"Đã xóa liên hệ có tên \"{tenXoa}\"." : $"Không tìm thấy liên hệ tên \"{tenXoa}\" để xóa.");
            Console.WriteLine("Danh bạ sau khi xóa:");
            HienThiDanhBa(danhBa);
        }

        // Duyệt tuần tự từ đầu đến cuối danh sách để khớp tên hoặc số điện thoại
        private static int TimKiemTuanTu(List<LienHe> ds, string tuKhoa)
        {
            if (string.IsNullOrEmpty(tuKhoa)) return -1;
            string key = tuKhoa.Trim();

            for (int i = 0; i < ds.Count; i++)
            {
                string ten = ds[i].Ten != null ? ds[i].Ten.Trim() : "";
                string sdt = ds[i].SoDienThoai != null ? ds[i].SoDienThoai.Trim() : "";

                if (string.Equals(ten, key, StringComparison.CurrentCultureIgnoreCase) ||
                    string.Equals(sdt, key, StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }
            return -1;
        }

        // Sắp xếp tăng dần theo tên bằng Bubble Sort (bắt buộc trước khi tìm kiếm nhị phân)
        private static void SapXepTheoTen(List<LienHe> ds)
        {
            for (int i = 0; i < ds.Count - 1; i++)
            {
                for (int j = 0; j < ds.Count - 1 - i; j++)
                {
                    string ten1 = ds[j].Ten != null ? ds[j].Ten.Trim() : "";
                    string ten2 = ds[j + 1].Ten != null ? ds[j + 1].Ten.Trim() : "";
                    if (string.Compare(ten1, ten2, StringComparison.CurrentCultureIgnoreCase) > 0)
                    {
                        LienHe tam = ds[j];
                        ds[j] = ds[j + 1];
                        ds[j + 1] = tam;
                    }
                }
            }
        }

        // Tìm kiếm nhị phân trên danh sách đã sắp xếp theo tên
        private static int TimKiemNhiPhanTheoTen(List<LienHe> ds, string tenCanTim)
        {
            if (string.IsNullOrEmpty(tenCanTim)) return -1;
            string key = tenCanTim.Trim();

            int left = 0;
            int right = ds.Count - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                string tenMid = ds[mid].Ten != null ? ds[mid].Ten.Trim() : "";
                int cmp = string.Compare(tenMid, key, StringComparison.CurrentCultureIgnoreCase);

                if (cmp == 0) return mid;
                else if (cmp < 0) left = mid + 1; // Tìm nửa phải
                else right = mid - 1;             // Tìm nửa trái
            }
            return -1;
        }

        private static void ThemLienHe(List<LienHe> ds, LienHe lienHeMoi)
        {
            ds.Add(lienHeMoi);
        }

        private static bool XoaLienHeTheoTen(List<LienHe> ds, string tenXoa)
        {
            if (string.IsNullOrEmpty(tenXoa)) return false;
            string key = tenXoa.Trim();

            for (int i = 0; i < ds.Count; i++)
            {
                string ten = ds[i].Ten != null ? ds[i].Ten.Trim() : "";
                if (string.Equals(ten, key, StringComparison.CurrentCultureIgnoreCase))
                {
                    ds.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        private static void HienThiDanhBa(List<LienHe> ds)
        {
            if (ds.Count == 0)
            {
                Console.WriteLine("(Danh bạ rỗng)");
                return;
            }
            for (int i = 0; i < ds.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. {ds[i]}");
            }
        }
    }
}