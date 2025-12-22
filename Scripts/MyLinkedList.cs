using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SingleLinkList.Scripts
{
    // Node cho danh sách liên kết
    public class Node
    {
        public Post Data;
        public Node Next;

        public Node(Post data)
        {
            Data = data;
            Next = null;
        }
    }

    public class MyLinkedList
    {
        private Node head;
        public Node Head => head;

        public MyLinkedList()
        {
            head = null;
        }
        // Thêm vào trong class MyLinkedList
        public static MyLinkedList FromList(List<Post> data)
        {
            MyLinkedList list = new MyLinkedList();
            foreach (var p in data) list.AddLast(p);
            return list;
        }
        public void SetHead(Node newHead)
        {
            head = newHead;
        }

        // 1. Thêm vào cuối danh sách
        public void AddLast(Post post)
        {
            Node newNode = new Node(post);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        // 2. Lấy tất cả bài đăng (để hiển thị lên GridView)
        public IEnumerable<Post> GetAllPosts()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        // 3. Sửa bài đăng theo PostID (sử dụng thuật toán Linear Search)
        public bool EditPost(string id, string noiDung, string tacGia, DateTime ngay, int luotThich )
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data.PostID == id) 
                {
                    current.Data.noiDungBaiDang = noiDung;
                    current.Data.tacGia = tacGia;
                    current.Data.ngayDang = ngay;
                    current.Data.luotThich = luotThich;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        // 4. Xóa bài đăng theo PostID (sử dụng thuật toán Linear Search)
        public bool DeletePost(string id)
        {
            if (head == null) return false;

            // Trường hợp xóa đầu
            if (head.Data.PostID == id)
            {
                head = head.Next;
                return true;
            }

            // Trường hợp xóa giữa hoặc cuối
            Node current = head;
            while (current.Next != null)
            {
                if (current.Next.Data.PostID == id)
                {
                    current.Next = current.Next.Next;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }
        //Hàm tìm kiếm bài đăng theo từ khóa (Linear Search)
        public IEnumerable<Post> SearchPosts(string keyword)
        {
            Node current = head;
            while (current != null)
            {
                // Kiểm tra xem Nội dung hoặc Tác giả có chứa từ khóa không (so sánh không phân biệt hoa thường)
                if (current.Data.noiDungBaiDang.ToLower().Contains(keyword.ToLower()) ||
                    current.Data.tacGia.ToLower().Contains(keyword.ToLower()))
                {
                    yield return current.Data;
                }
                current = current.Next;
            }
        }
        //5. Sắp xếp danh sách bài đăng theo lượt thích (giảm dần)
        public void MergeSortByLikesDesc()
        {
            head = MergeSortDesc(head);
        }

        private Node MergeSortDesc(Node h)
        {
            if (h == null || h.Next == null)
                return h;

            Node middle = GetMiddle(h);
            Node nextMiddle = middle.Next;
            middle.Next = null;

            Node left = MergeSortDesc(h);
            Node right = MergeSortDesc(nextMiddle);

            return SortedMergeDesc(left, right);
        }

        // Gộp 2 danh sách đã sắp xếp (giảm dần)
        private Node SortedMergeDesc(Node a, Node b)
        {
            if (a == null) return b;
            if (b == null) return a;

            if (a.Data.luotThich >= b.Data.luotThich)
            {
                a.Next = SortedMergeDesc(a.Next, b);
                return a;
            }
            else
            {
                b.Next = SortedMergeDesc(a, b.Next);
                return b;
            }
        }

        // Tìm node giữa
        private Node GetMiddle(Node h)
        {
            if (h == null) return h;

            Node slow = h;
            Node fast = h.Next;

            while (fast != null)
            {
                fast = fast.Next;
                if (fast != null)
                {
                    slow = slow.Next;
                    fast = fast.Next;
                }
            }
            return slow;
        }
        // Lấy tổng lượt thích theo từng tác giả
        public Dictionary<string, int> GetLikesByAuthor()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            Node current = head;

            while (current != null)
            {
                string author = current.Data.tacGia;
                int likes = current.Data.luotThich;

                if (result.ContainsKey(author))
                    result[author] += likes;
                else
                    result[author] = likes;

                current = current.Next;
            }

            return result;
        }

    }
}
