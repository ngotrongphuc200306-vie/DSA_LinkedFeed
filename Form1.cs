using SingleLinkList.Scripts;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms.DataVisualization.Charting;


namespace SingleLinkList
{
    public partial class Form1 : Form
    {
        // Khởi tạo danh sách liên kết
        MyLinkedList linkedList = new MyLinkedList();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AlgorithmComparison algo = new AlgorithmComparison();
            algo.RunFullComparison();
        }



        // Hàm hỗ trợ: Refresh lại DataGridView từ LinkedList
        private void HienThi()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PostID");
            dt.Columns.Add("noiDungBaiDang");
            dt.Columns.Add("tacGia");
            dt.Columns.Add("ngayDang");
            dt.Columns.Add("luotThich");


            // Lấy dữ liệu từ Linked List đổ vào DataTable
            foreach (Post p in linkedList.GetAllPosts())
            {
                dt.Rows.Add(
                    p.PostID,
                    p.noiDungBaiDang,
                    p.tacGia,
                    p.ngayDang.ToShortDateString(),
                    p.luotThich
                );
            }

            dgvbaiDang.DataSource = dt;
        }



        private void btnSuaBaiDang_Click(object sender, EventArgs e)
        {
            int luotThich = 0;
            int.TryParse(txtLuotThich.Text, out luotThich);

            // Gọi hàm EditPost với tham số mới
            bool result = linkedList.EditPost(
                txtPostID.Text,
                txtNoiDungBaiDang.Text,
                txtTacGia.Text,
                dtpngayDang.Value,
                luotThich // <--- Thêm tham số này
            );

            if (!result)
                MessageBox.Show("Không tìm thấy bài đăng có ID: " + txtPostID.Text);
            else
                MessageBox.Show("Sửa thành công!");

            HienThi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Validate dữ liệu
            if (string.IsNullOrEmpty(txtPostID.Text) ||
                string.IsNullOrEmpty(txtNoiDungBaiDang.Text) ||
                string.IsNullOrEmpty(txtTacGia.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }

            // Xử lý lượt thích: Nếu người dùng không nhập hoặc nhập sai thì mặc định là 0
            int luotThich = 0;
            int.TryParse(txtLuotThich.Text, out luotThich);

            // Tạo đối tượng Post mới
            Post post = new Post
            {
                PostID = txtPostID.Text,
                noiDungBaiDang = txtNoiDungBaiDang.Text,
                tacGia = txtTacGia.Text,
                ngayDang = dtpngayDang.Value,
                luotThich = luotThich
            };

            // Gọi hàm AddLast của LinkedList
            linkedList.AddLast(post);

            // Xóa trắng các ô nhập liệu sau khi thêm (Optional)
            ClearInput();

            HienThi();
        }

        private void btnXoaBaiDang_Click(object sender, EventArgs e)
        {
            // Nên hỏi xác nhận trước khi xóa
            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool result = linkedList.DeletePost(txtPostID.Text);

                if (!result)
                    MessageBox.Show("Không tìm thấy bài đăng để xóa");
                else
                    ClearInput();

                HienThi();
            }
        }

        private void dgvbaiDang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Tránh lỗi click vào header

            // Lấy dòng hiện tại
            DataGridViewRow row = dgvbaiDang.Rows[e.RowIndex];

            txtPostID.Text = row.Cells["PostID"].Value.ToString();
            txtNoiDungBaiDang.Text = row.Cells["noiDungBaiDang"].Value.ToString();
            txtTacGia.Text = row.Cells["tacGia"].Value.ToString();

            // Xử lý DateTime an toàn
            if (DateTime.TryParse(row.Cells["ngayDang"].Value.ToString(), out DateTime date))
            {
                dtpngayDang.Value = date;
            }

            // Cần kiểm tra null để tránh lỗi nếu cột chưa có dữ liệu
            if (row.Cells["luotThich"].Value != null)
            {
                txtLuotThich.Text = row.Cells["luotThich"].Value.ToString();
            }
            else
            {
                txtLuotThich.Text = "0";
            }
        }

        // Hàm phụ: Xóa trắng ô nhập
        private void ClearInput()
        {
            txtPostID.Text = "";
            txtNoiDungBaiDang.Text = "";
            txtTacGia.Text = "";
            dtpngayDang.Value = DateTime.Now;
            txtLuotThich.Text = "0";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa để tìm!");
                return;
            }

            // Tạo DataTable mới để chứa kết quả tìm kiếm
            DataTable dt = new DataTable();
            dt.Columns.Add("PostID");
            dt.Columns.Add("noiDungBaiDang");
            dt.Columns.Add("tacGia");
            dt.Columns.Add("ngayDang");
            dt.Columns.Add("luotThich");

            // Gọi hàm SearchPosts thay vì GetAllPosts
            // Biến found dùng để kiểm tra có tìm thấy kết quả nào không
            bool found = false;
            foreach (Post p in linkedList.SearchPosts(keyword))
            {
                dt.Rows.Add(
                    p.PostID,
                    p.noiDungBaiDang,
                    p.tacGia,
                    p.ngayDang.ToShortDateString(),
                    p.luotThich
                );
                found = true;
            }

            if (!found)
            {
                MessageBox.Show("Không tìm thấy bài đăng nào khớp với từ khóa: " + keyword);
                // Có thể chọn giữ nguyên bảng cũ hoặc xóa trắng bảng tùy bạn
            }
            else
            {
                // Cập nhật DataGridView với kết quả tìm được
                dgvbaiDang.DataSource = dt;
            }
        }

        private void btnHienThiTatCa_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = ""; // Xóa ô tìm kiếm
            HienThi(); // Gọi lại hàm HienThi gốc để nạp lại toàn bộ danh sách
        }
        private void btnSapXepLuotThich_Click(object sender, EventArgs e)
        {
            linkedList.MergeSortByLikesDesc();
            HienThi();
        }
        private void VeBieuDoLuotThich()
        {
            // 1. Xóa TabControl cũ để tránh chồng lấp dữ liệu khi nhấn nút nhiều lần
            var oldTab = Controls.OfType<TabControl>().FirstOrDefault(t => t.Name == "tabBieuDo");
            if (oldTab != null)
            {
                Controls.Remove(oldTab);
                oldTab.Dispose();
            }

            // 2. THIẾT LẬP VỊ TRÍ: Tránh chèn vào các nút
            int tabHeight = 400;
            // Dịch xuống dưới DataGridView thêm 100px thay vì 40px để không đè lên các nút phụ
            int x = dgvbaiDang.Location.X;
            int y = dgvbaiDang.Location.Y + dgvbaiDang.Height + 100;
            int width = dgvbaiDang.Width;

            TabControl tabBieuDo = new TabControl
            {
                Name = "tabBieuDo",
                Size = new Size(width, tabHeight),
                Location = new Point(x, y),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            // -----------------------------------------------------------
            // 3. TAB 1: BIỂU ĐỒ CỘT (Chi tiết lượt thích từng bài)
            // -----------------------------------------------------------
            TabPage tabCot = new TabPage("Thống kê bài đăng");
            Chart chartCot = new Chart { Dock = DockStyle.Fill };
            chartCot.ChartAreas.Add(new ChartArea("AreaCot"));

            Series seriesCot = new Series("Lượt Thích")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };

            foreach (Post p in linkedList.GetAllPosts())
                seriesCot.Points.AddXY(p.PostID, p.luotThich);

            chartCot.Series.Add(seriesCot);
            chartCot.Titles.Add("SỐ LƯỢT THÍCH THEO MÃ BÀI ĐĂNG");
            tabCot.Controls.Add(chartCot);
            tabBieuDo.TabPages.Add(tabCot);

            // -----------------------------------------------------------
            // 4. TAB 2: BIỂU ĐỒ TRÒN (Tỉ lệ % thực tế theo tác giả)
            // -----------------------------------------------------------
            TabPage tabTron = new TabPage("Tỉ lệ theo Tác giả");
            Chart chartTron = new Chart { Dock = DockStyle.Fill };
            chartTron.ChartAreas.Add(new ChartArea("AreaTron"));
            chartTron.Legends.Add(new Legend("LegendAuthors") { Docking = Docking.Right });

            Series seriesTron = new Series("Authors")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                // SỬA LỖI HIỂN THỊ: Dùng #PERCENT để tự động tính % thay vì lấy số thô
                Label = "#PERCENT{P1}"
            };

            var authorStats = linkedList.GetLikesByAuthor();
            foreach (var item in authorStats)
            {
                int pIndex = seriesTron.Points.AddXY(item.Key, item.Value);
                seriesTron.Points[pIndex].LegendText = item.Key;
            }

            chartTron.Series.Add(seriesTron);
            chartTron.Titles.Add("TỔNG HỢP TỈ LỆ TƯƠNG TÁC THEO TÁC GIẢ");
            tabTron.Controls.Add(chartTron);
            tabBieuDo.TabPages.Add(tabTron);

            // 5. Thêm vào Form
            this.Controls.Add(tabBieuDo);
            tabBieuDo.BringToFront();
        }

        private void BtnVeBieuDo_Click(object sender, EventArgs e)
        {
            VeBieuDoLuotThich();
        }
    }
}
