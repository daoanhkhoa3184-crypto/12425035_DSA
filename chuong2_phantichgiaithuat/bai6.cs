using System;
using System.Diagnostics;

namespace Buoi02_DanhSach
{
    internal class Bai6
    {
        public static void Chay()
        {
            Console.Write("Nhập số lượng phần tử thực n (khuyên dùng 5..20 để in dãy, hoặc số lớn để đo thời gian): ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Vui lòng nhập số nguyên dương n > 0!");
                return;
            }

            double[] goc = new double[n];
            Random rd = new Random();
            for (int i = 0; i < n; i++) // Sinh dãy n số thực ngẫu nhiên
            {
                goc[i] = Math.Round(rd.NextDouble() * 100, 2);
            }

            if (n <= 20) // In dãy gốc nếu số lượng ít để dễ kiểm tra
            {
                Console.WriteLine("Dãy số thực ban đầu: " + string.Join("  ", goc));
            }

            double[] aBubble = (double[])goc.Clone();
            Stopwatch swBubble = Stopwatch.StartNew(); // Giải thuật 1: Bubble Sort O(n^2)
            BubbleSort(aBubble);
            swBubble.Stop();

            double[] aSelection = (double[])goc.Clone();
            Stopwatch swSelection = Stopwatch.StartNew(); // Giải thuật 2: Selection Sort O(n^2)
            SelectionSort(aSelection);
            swSelection.Stop();

            double[] aInsertion = (double[])goc.Clone();
            Stopwatch swInsertion = Stopwatch.StartNew(); // Giải thuật 3: Insertion Sort O(n^2), tốt nhất O(n)
            InsertionSort(aInsertion);
            swInsertion.Stop();

            double[] aQuick = (double[])goc.Clone();
            Stopwatch swQuick = Stopwatch.StartNew(); // Giải thuật 4: Quick Sort trung bình O(n log n), xấu nhất O(n^2)
            QuickSort(aQuick, 0, aQuick.Length - 1);
            swQuick.Stop();

            double[] aMerge = (double[])goc.Clone();
            Stopwatch swMerge = Stopwatch.StartNew(); // Giải thuật 5: Merge Sort ổn định O(n log n) mọi trường hợp
            MergeSort(aMerge, 0, aMerge.Length - 1);
            swMerge.Stop();

            if (n <= 20)
            {
                Console.WriteLine("Dãy tăng dần (Merge Sort): " + string.Join("  ", aMerge));
            }

            Console.WriteLine("So sánh thời gian chạy sắp xếp tăng dần:");
            Console.WriteLine($"  1. Bubble Sort [O(n^2)]: {swBubble.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine($"  2. Selection Sort [O(n^2)]: {swSelection.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine($"  3. Insertion Sort [O(n^2)]: {swInsertion.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine($"  4. Quick Sort [TB O(n log n)]: {swQuick.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine($"  5. Merge Sort [Ổn định O(n log n)]: {swMerge.Elapsed.TotalMilliseconds:F4} ms");
        }

        private static void BubbleSort(double[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
                for (int j = 0; j < a.Length - 1 - i; j++)
                    if (a[j] > a[j + 1]) (a[j], a[j + 1]) = (a[j + 1], a[j]);
        }

        private static void SelectionSort(double[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                int minIdx = i;
                for (int j = i + 1; j < a.Length; j++)
                    if (a[j] < a[minIdx]) minIdx = j;
                if (minIdx != i) (a[i], a[minIdx]) = (a[minIdx], a[i]);
            }
        }

        private static void InsertionSort(double[] a)
        {
            for (int i = 1; i < a.Length; i++)
            {
                double key = a[i];
                int j = i - 1;
                while (j >= 0 && a[j] > key)
                {
                    a[j + 1] = a[j];
                    j--;
                }
                a[j + 1] = key;
            }
        }

        private static void QuickSort(double[] a, int low, int high)
        {
            if (low >= high) return;
            double pivot = a[low + (high - low) / 2];
            int i = low, j = high;
            while (i <= j)
            {
                while (a[i] < pivot) i++;
                while (a[j] > pivot) j--;
                if (i <= j)
                {
                    (a[i], a[j]) = (a[j], a[i]);
                    i++;
                    j--;
                }
            }
            if (low < j) QuickSort(a, low, j);
            if (i < high) QuickSort(a, i, high);
        }

        private static void MergeSort(double[] a, int left, int right)
        {
            if (left >= right) return;
            int mid = left + (right - left) / 2;
            MergeSort(a, left, mid);
            MergeSort(a, mid + 1, right);
            Tron(a, left, mid, right);
        }

        private static void Tron(double[] a, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;
            double[] L = new double[n1];
            double[] R = new double[n2];
            Array.Copy(a, left, L, 0, n1);
            Array.Copy(a, mid + 1, R, 0, n2);

            int i = 0, j = 0, k = left;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j]) a[k++] = L[i++];
                else a[k++] = R[j++];
            }
            while (i < n1) a[k++] = L[i++];
            while (j < n2) a[k++] = R[j++];
        }
    }
}