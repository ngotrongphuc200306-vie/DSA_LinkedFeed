using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace SingleLinkList.Scripts
{
    public class AlgorithmComparison
    {
        // =========================
        // HÀM CHẠY TỔNG THỂ
        // =========================
        public void RunFullComparison()
        {
            int n = 2000;
            int loopsSearch = 100000;

            List<Post> rawData = GenerateMockPosts(n);
            MyLinkedList listForSort = MyLinkedList.FromList(rawData);
            MyLinkedList listForSearch = MyLinkedList.FromList(rawData);

            StringBuilder report = new StringBuilder();
            Stopwatch sw = new Stopwatch();

            report.AppendLine("=== BÁO CÁO SO SÁNH SORT & SEARCH ===");
            report.AppendLine($"Số phần tử: {n}");
            report.AppendLine($"Số lần tìm kiếm: {loopsSearch}");
            report.AppendLine("-----------------------------------\n");

            // =========================
            // SORT
            // =========================
            report.AppendLine("I. SORT (SINGLE LINKED LIST)");

            sw.Restart();
            BubbleSort(MyLinkedList.FromList(rawData));
            sw.Stop();
            report.AppendLine($"Bubble Sort:    {sw.ElapsedMilliseconds} ms");

            sw.Restart();
            SelectionSort(MyLinkedList.FromList(rawData));
            sw.Stop();
            report.AppendLine($"Selection Sort: {sw.ElapsedMilliseconds} ms");

            sw.Restart();
            listForSort.SetHead(MergeSort(listForSort.Head));
            sw.Stop();
            report.AppendLine($"Merge Sort:     {sw.ElapsedMilliseconds} ms");

            // =========================
            // SEARCH
            // =========================
            report.AppendLine("\nII. SEARCH");
            string key = "NON_EXISTENT";

            sw.Restart();
            for (int i = 0; i < loopsSearch; i++)
                LinearSearch(listForSearch, key);
            sw.Stop();
            report.AppendLine($"Linear Search (LinkedList): {sw.ElapsedMilliseconds} ms");

            sw.Restart();
            for (int i = 0; i < loopsSearch; i++)
                rawData.Find(p => p.PostID == key);
            sw.Stop();
            report.AppendLine($"Sequential Search (List):  {sw.ElapsedMilliseconds} ms");

            rawData.Sort((a, b) => a.PostID.CompareTo(b.PostID));
            sw.Restart();
            for (int i = 0; i < loopsSearch; i++)
                BinarySearch(rawData, key);
            sw.Stop();
            report.AppendLine($"Binary Search (List):      {sw.ElapsedMilliseconds} ms");

            // =========================
            // GHI FILE
            // =========================
            string path = Path.Combine(AppContext.BaseDirectory, "KetQua_Sort_Search.txt");
            File.WriteAllText(path, report.ToString());
        }

        // =========================
        // TẠO DỮ LIỆU GIẢ
        // =========================
        private List<Post> GenerateMockPosts(int n)
        {
            List<Post> list = new List<Post>();
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                list.Add(new Post
                {
                    PostID = $"P{i:D5}",
                    noiDungBaiDang = "Noi dung " + i,
                    tacGia = "Tac gia " + rnd.Next(1, 100),
                    ngayDang = DateTime.Now.AddDays(-rnd.Next(0, 365)),
                    luotThich = rnd.Next(0, 1000)
                });
            }
            return list;
        }

        // =========================
        // LINEAR SEARCH (LINKED LIST)
        // =========================
        private bool LinearSearch(MyLinkedList list, string key)
        {
            foreach (var p in list.GetAllPosts())
                if (p.PostID == key)
                    return true;
            return false;
        }

        // =========================
        // BINARY SEARCH (LIST)
        // =========================
        private int BinarySearch(List<Post> list, string key)
        {
            int left = 0, right = list.Count - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                int cmp = list[mid].PostID.CompareTo(key);
                if (cmp == 0) return mid;
                if (cmp < 0) left = mid + 1;
                else right = mid - 1;
            }
            return -1;
        }

        // =========================
        // BUBBLE SORT
        // =========================
        private void BubbleSort(MyLinkedList list)
        {
            bool swapped;
            do
            {
                swapped = false;
                Node cur = list.Head;
                while (cur != null && cur.Next != null)
                {
                    if (cur.Data.PostID.CompareTo(cur.Next.Data.PostID) > 0)
                    {
                        var temp = cur.Data;
                        cur.Data = cur.Next.Data;
                        cur.Next.Data = temp;
                        swapped = true;
                    }
                    cur = cur.Next;
                }
            } while (swapped);
        }

        // =========================
        // SELECTION SORT
        // =========================
        private void SelectionSort(MyLinkedList list)
        {
            for (Node i = list.Head; i != null; i = i.Next)
            {
                Node min = i;
                for (Node j = i.Next; j != null; j = j.Next)
                    if (j.Data.PostID.CompareTo(min.Data.PostID) < 0)
                        min = j;

                if (min != i)
                {
                    var temp = i.Data;
                    i.Data = min.Data;
                    min.Data = temp;
                }
            }
        }

        // =========================
        // MERGE SORT (LINKED LIST)
        // =========================
        private Node MergeSort(Node head)
        {
            if (head == null || head.Next == null) return head;

            Node mid = GetMiddle(head);
            Node next = mid.Next;
            mid.Next = null;

            Node left = MergeSort(head);
            Node right = MergeSort(next);

            return Merge(left, right);
        }

        private Node Merge(Node a, Node b)
        {
            if (a == null) return b;
            if (b == null) return a;

            if (a.Data.PostID.CompareTo(b.Data.PostID) <= 0)
            {
                a.Next = Merge(a.Next, b);
                return a;
            }
            else
            {
                b.Next = Merge(a, b.Next);
                return b;
            }
        }

        private Node GetMiddle(Node head)
        {
            Node slow = head, fast = head.Next;
            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            return slow;
        }
    }
}
