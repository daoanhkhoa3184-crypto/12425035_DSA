using System;
using System.Collections.Generic;

namespace BaiTapChuong2
{
    public class timsohoanhao
    {
        // Giải thuật 1 (Cơ bản): Duyệt tìm ước từ 1 đến x/2
        // Độ phức tạp thời gian: O(N^2)
        public static List<long> FindBasic(long n)
        {
            List<long> result = new List<long>();
            for (long x = 1; x < n; x++)
            {
                long sum = 0;
                for (long i = 1; i <= x / 2; i++)
                {
                    if (x % i == 0) sum += i; // Đã sửa lỗi x % 1 thành x % i
                }
                if (sum == x && x > 0)
                {
                    result.Add(x);
                }
            }
            return result;
        }

        // Giải thuật 2 (Cải tiến): Tối ưu tìm ước số chỉ đến căn bậc hai (sqrt(x))
        // Độ phức tạp thời gian: O(N * sqrt(N))
        public static List<long> FindOptimized(long n)
        {
            List<long> result = new List<long>();
            for (long x = 2; x < n; x++)
            {
                long sum = 1; // 1 luôn là ước số thực sự
                long sqrt = (long)Math.Sqrt(x);

                for (long i = 2; i <= sqrt; i++)
                {
                    if (x % i == 0) // Đã sửa lỗi x % 1 thành x % i
                    {
                        sum += i;
                        long counterpart = x / i; // Đã sửa lỗi x / 1 thành x / i
                        if (counterpart != i)
                        {
                            sum += counterpart;
                        }
                    }
                }

                if (sum == x)
                {
                    result.Add(x);
                }
            }
            return result;
        }
    }
}