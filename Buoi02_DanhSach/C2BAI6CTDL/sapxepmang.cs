using System;

namespace BaiTapChuong2
{
    public class sapxepmang
    {
        // -------------------------------------------------------------------------
        // GIẢI THUẬT 1: Sắp xếp nổi bọt (Bubble Sort)
        // Độ phức tạp thời gian: O(n^2)
        // -------------------------------------------------------------------------
        public static void SapXepNoiBot(double[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // Hoán đổi 2 phần tử
                        double temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        // -------------------------------------------------------------------------
        // GIẢI THUẬT 2: Sắp xếp nhanh (Quick Sort)
        // Độ phức tạp thời gian: O(n log n) trung bình
        // -------------------------------------------------------------------------
        public static void SapXepNhanh(double[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = PhanHoach(arr, left, right);
                SapXepNhanh(arr, left, pivotIndex - 1);
                SapXepNhanh(arr, pivotIndex + 1, right);
            }
        }

        private static int PhanHoach(double[] arr, int left, int right)
        {
            double pivot = arr[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    double temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            double temp2 = arr[i + 1];
            arr[i + 1] = arr[right];
            arr[right] = temp2;

            return i + 1;
        }

        // -------------------------------------------------------------------------
        // GIẢI THUẬT 3: Sắp xếp trộn (Merge Sort)
        // Độ phức tạp thời gian: O(n log n) trong mọi trường hợp, ổn định
        // -------------------------------------------------------------------------
        public static void SapXepTron(double[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;

                SapXepTron(arr, left, mid);
                SapXepTron(arr, mid + 1, right);

                TronMangan(arr, left, mid, right);
            }
        }

        private static void TronMangan(double[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            double[] L = new double[n1];
            double[] R = new double[n2];

            for (int i = 0; i < n1; ++i) L[i] = arr[left + i];
            for (int j = 0; j < n2; ++j) R[j] = arr[mid + 1 + j];

            int i_idx = 0, j_idx = 0;
            int k = left;

            while (i_idx < n1 && j_idx < n2)
            {
                if (L[i_idx] <= R[j_idx])
                {
                    arr[k] = L[i_idx];
                    i_idx++;
                }
                else
                {
                    arr[k] = R[j_idx];
                    j_idx++;
                }
                k++;
            }

            while (i_idx < n1)
            {
                arr[k] = L[i_idx];
                i_idx++;
                k++;
            }

            while (j_idx < n2)
            {
                arr[k] = R[j_idx];
                j_idx++;
                k++;
            }
        }
    }
}