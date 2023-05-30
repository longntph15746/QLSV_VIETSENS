using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV_VIETSENS
{
    public partial class Form1 : Form
    {
        private List<SinhVien> lstSinhVien = new List<SinhVien>();
        private DXErrorProvider errorProvider = new DXErrorProvider();
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDuLieuSinhVien(@"D:\Vietsens\Học việc\TEST\QLSV_VIETSENS\QLSV_VIETSENS\TextFile1.txt");
            ShowMain();
        }

        private void ShowMain()
        {
            GenerateMaSV();

        }
        private int countSV = 0;

        private string GenerateMaSV()
        {

            countSV++; // Tăng số lượng sinh viên lên 1
            return "SV" + countSV.ToString("0000"); // Sinh mã sinh viên tự động
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            SinhVien sv = new SinhVien();
            sv.MaSinhVien = GenerateMaSV();
            // Kiểm tra trường tên sinh viên
            if (string.IsNullOrEmpty(txtTen.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sinh viên.");
                return;
            }

            // Kiểm tra trường ngày sinh
            if (dateNS.EditValue == null)
            {
                MessageBox.Show("Vui lòng chọn ngày sinh.");
                return;
            }

            // Kiểm tra trường giới tính
            if (cboGioiTinh.EditValue == null)
            {
                MessageBox.Show("Vui lòng chọn giới tính.");
                return;
            }

            sv.HoTen = txtTen.Text;
            sv.GioiTinh = cboGioiTinh.SelectedItem.ToString();
            sv.NgaySinh = dateNS.DateTime;
            sv.DoiTuong = cboDoiTuong.Text.ToString();
            sv.DiemToan = txtToan.Text.ToString();
            sv.DiemVan = txtVan.Text.ToString();
            sv.DiemAnh = txtAnh.Text.ToString();
            sv.GhiChu = mmGhiChu.Text;
            lstSinhVien.Add(sv);
            gridControl1.DataSource = lstSinhVien;
            gridControl1.RefreshDataSource();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            // Lấy dòng hiện tại và thông tin sinh viên tương ứng
            GridView view = sender as GridView;
            int rowHandle = e.RowHandle;
            SinhVien sv = view.GetRow(rowHandle) as SinhVien;

            // Cập nhật thông tin sinh viên từ giá trị mới trong ô
            if (e.Column.FieldName == "MaSinhVien")
                sv.MaSinhVien = e.Value.ToString();
            else if (e.Column.FieldName == "HoTen")
                sv.HoTen = e.Value.ToString();
            else if (e.Column.FieldName == "NgaySinh")
                sv.NgaySinh = Convert.ToDateTime(e.Value);
            else if (e.Column.FieldName == "GioiTinh")
                sv.GioiTinh = e.Value.ToString();
            else if (e.Column.FieldName == "DoiTuong")
                sv.DoiTuong = e.Value.ToString();
            else if (e.Column.FieldName == "DiemToan")
                sv.DiemToan = e.Value.ToString();
            else if (e.Column.FieldName == "DiemVan")
                sv.DiemVan = e.Value.ToString();
            else if (e.Column.FieldName == "DiemAnh")
                sv.DiemAnh = e.Value.ToString();
            else if (e.Column.FieldName == "GhiChu")
                sv.GhiChu = e.Value.ToString();

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            //lay sinh vien duoc chon tu controls
            SinhVien sv = gridView1.GetRow(e.FocusedRowHandle) as SinhVien;
            //neu khong co sinh vien duoc chon thi thoat khoi phuong thuc
            if (sv == null) return;
            //fill du lieu vao cac control
            txtMa.Text = sv.MaSinhVien;
            txtTen.Text = sv.HoTen;
            cboGioiTinh.SelectedItem = sv.GioiTinh;
            dateNS.DateTime = sv.NgaySinh;
            cboDoiTuong.SelectedItem = sv.DoiTuong;
            txtToan.Text = sv.DiemToan.ToString();
            txtVan.Text = sv.DiemVan.ToString();
            txtAnh.Text = sv.DiemAnh.ToString();
            mmGhiChu.Text = sv.GhiChu;
        }

        private void bbtnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SinhVien sv = new SinhVien();
            sv.MaSinhVien = GenerateMaSV();
            // Kiểm tra trường tên sinh viên
            if (string.IsNullOrEmpty(txtTen.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sinh viên.");
                return;
            }

            // Kiểm tra trường ngày sinh
            if (dateNS.EditValue == null)
            {
                MessageBox.Show("Vui lòng chọn ngày sinh.");
                return;
            }

            // Kiểm tra trường giới tính
            if (cboGioiTinh.EditValue == null)
            {
                MessageBox.Show("Vui lòng chọn giới tính.");
                return;
            }

            sv.HoTen = txtTen.Text;
            sv.NgaySinh = dateNS.DateTime;
            sv.GioiTinh = cboGioiTinh.SelectedItem.ToString();
            sv.DoiTuong = cboDoiTuong.Text.ToString();
            sv.DiemToan = txtToan.Text;
            sv.DiemVan = (txtVan.Text);
            sv.DiemAnh = (txtAnh.Text);
            sv.GhiChu = mmGhiChu.Text;
            lstSinhVien.Add(sv);
            gridControl1.DataSource = lstSinhVien;
            gridControl1.RefreshDataSource();
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //tim kiem sinh vien theo MaSinhVien
            string searchValue = txtSearch.Text;
            var result = lstSinhVien.Where(sv => sv.MaSinhVien.Contains(searchValue)).ToList();
            gridControl1.DataSource = result;
        }


        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            // Xoá sinh viên
            // Lấy chỉ số dòng đang được chọn
            int rowIndex = gridView1.FocusedRowHandle;

            // Kiểm tra nếu không có dòng được chọn
            if (rowIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để xoá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Lấy thông tin sinh viên đang được chọn
            SinhVien sv = (SinhVien)gridView1.GetRow(rowIndex);

            // Hiển thị hộp thoại xác nhận xoá sinh viên
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xoá sinh viên '" + sv.MaSinhVien + "'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Xóa sinh viên khỏi danh sách
                lstSinhVien.RemoveAt(rowIndex);

                // Refresh dữ liệu trên GridView
                gridView1.RefreshData();
            }

        }

        private void btnTongSV_Click(object sender, EventArgs e)
        {
            //tim tong so sinh vien trong gridcontrol
            int totalCount = gridView1.RowCount;
            int tongSoSV = lstSinhVien.Count;
            MessageBox.Show("Tổng số sinh viên : " + totalCount);
        }

        private void btnSVDT_Click(object sender, EventArgs e)
        {
            //Tim sinh vien theo {DoiTuong}
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (SinhVien sv in lstSinhVien)
            {
                if (dict.ContainsKey(sv.DoiTuong))
                {
                    dict[sv.DoiTuong]++;
                }
                else
                {
                    dict.Add(sv.DoiTuong, 1);
                }
            }

            string result = "";
            foreach (var pair in dict)
            {
                result += pair.Key + ": " + pair.Value + "\n";
            }
            MessageBox.Show(result, "Tổng số sinh viên theo từng đối tượng là : ");
        }

        private void txtToan_Validating(object sender, CancelEventArgs e)
        {
            double diem;
            if (double.TryParse(txtToan.Text, out diem))
            {
                if (diem > 10)
                {
                    e.Cancel = true;
                    txtToan.ErrorText = "Điểm không được lớn hơn 10";
                }
            }
        }

        private void btnSV8_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                float diemToan = Convert.ToSingle(gridView1.GetRowCellValue(i, "DiemToan"));
                float diemVan = Convert.ToSingle(gridView1.GetRowCellValue(i, "DiemVan"));
                float diemAnh = Convert.ToSingle(gridView1.GetRowCellValue(i, "DiemAnh"));

                if ((diemToan + diemVan + diemAnh) / 3 > 8)
                    count++;
            }
            MessageBox.Show("Tong so sinh vien co diem trung binh 3 mon toan van anh tren 8: " + count.ToString());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            LuuDuLieuSinhVien(@"D:\Vietsens\Học việc\TEST\QLSV_VIETSENS\QLSV_VIETSENS\TextFile1.txt");
        }

        private void LuuDuLieuSinhVien(string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (SinhVien sv in lstSinhVien)
                    {
                        // Ghi thông tin sinh viên vào file theo định dạng mong muốn
                        writer.WriteLine($"Mã sinh viên: {sv.MaSinhVien}");
                        writer.WriteLine($"Tên sinh viên: {sv.HoTen}");
                        writer.WriteLine($"Ngày sinh: {sv.NgaySinh.ToShortDateString()}");
                        writer.WriteLine($"Giới tính: {sv.GioiTinh}");
                        writer.WriteLine($"Đối tượng: {sv.DoiTuong}");
                        writer.WriteLine($"Điểm toán: {sv.DiemToan}");
                        writer.WriteLine($"Điểm văn: {sv.DiemVan}");
                        writer.WriteLine($"Điểm anh: {sv.DiemAnh}");
                        writer.WriteLine($"Ghi chú: {sv.GhiChu}");
                        writer.WriteLine("--------------------------------------------------");
                    }
                }

                MessageBox.Show("Lưu dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void gridControl1_Load(object sender, EventArgs e)
        {
            LoadDuLieuSinhVien(@"D:\Vietsens\Học việc\TEST\QLSV_VIETSENS\QLSV_VIETSENS\TextFile1.txt");
        }

        private void LoadDuLieuSinhVien(string filePath)
        {

            try
            {
                List<SinhVien> lstSinhVien = new List<SinhVien>();
                SinhVien sv = null;

                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.StartsWith("Mã sinh viên:"))
                        {
                            // Nếu tìm thấy dòng bắt đầu bằng "Mã sinh viên", tạo đối tượng sinh viên mới
                            sv = new SinhVien();
                            lstSinhVien.Add(sv);

                            string MaSinhVien = line.Substring(line.IndexOf(":") + 1).Trim();
                            sv.MaSinhVien = MaSinhVien;
                        }
                        else if (sv != null)
                        {
                            // Xử lý các dòng thông tin khác và gán giá trị vào đối tượng sinh viên
                            if (line.StartsWith("Tên sinh viên:"))
                            {
                                sv.HoTen = line.Substring(line.IndexOf(":") + 1).Trim();
                            }
                            else if (line.StartsWith("Ngày sinh:"))
                            {
                                sv.NgaySinh = DateTime.Parse(line.Substring(line.IndexOf(":") + 1).Trim());
                            }
                            else if (line.StartsWith("Giới tính:"))
                            {
                                sv.GioiTinh = line.Substring(line.IndexOf(":") + 1).Trim();
                            }
                            else if (line.StartsWith("Đối tượng:"))
                            {
                                sv.DoiTuong = line.Substring(line.IndexOf(":") + 1).Trim();
                            }
                            else if (line.StartsWith("Điểm toán:"))
                            {
                                sv.DiemToan = (line.Substring(line.IndexOf(":") + 1).Trim());
                            }
                            else if (line.StartsWith("Điểm văn:"))
                            {
                                sv.DiemVan = (line.Substring(line.IndexOf(":") + 1).Trim());
                            }
                            else if (line.StartsWith("Điểm anh:"))
                            {
                                sv.DiemAnh = (line.Substring(line.IndexOf(":") + 1).Trim());
                            }
                            else if (line.StartsWith("Ghi chú:"))
                            {
                                sv.GhiChu = line.Substring(line.IndexOf(":") + 1).Trim();
                            }
                        }
                    }
                }

                // Hiển thị dữ liệu trên GridControl
                gridControl1.DataSource = lstSinhVien;
                gridView1.RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải dữ liệu sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            GridView view = sender as GridView;
            // Tạo một đối tượng SinhVien mới và gán vào dòng mới
            SinhVien sv = new SinhVien();
            view.SetRowCellValue(e.RowHandle, view.Columns["MaSinhVien"], sv.MaSinhVien);
            view.SetRowCellValue(e.RowHandle, view.Columns["HoTen"], sv.HoTen);
            view.SetRowCellValue(e.RowHandle, view.Columns["NgaySinh"], sv.NgaySinh);
            view.SetRowCellValue(e.RowHandle, view.Columns["GioiTinh"], sv.GioiTinh);
            view.SetRowCellValue(e.RowHandle, view.Columns["DoiTuong"], sv.DoiTuong);
            view.SetRowCellValue(e.RowHandle, view.Columns["DiemToan"], sv.DiemToan);
            view.SetRowCellValue(e.RowHandle, view.Columns["DiemVan"], sv.DiemVan);
            view.SetRowCellValue(e.RowHandle, view.Columns["DiemAnh"], sv.DiemAnh);
            view.SetRowCellValue(e.RowHandle, view.Columns["GhiChu"], sv.GhiChu);
            lstSinhVien.Add(sv);  // Thêm sinh viên vào danh sách
        }

        private void gridView1_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            GridView view = sender as GridView;
            int rowHandle = e.RowHandle;
            // Lấy thông tin sinh viên tương ứng với dòng bị xóa và xóa khỏi danh sách
            SinhVien sv = view.GetRow(rowHandle) as SinhVien;
            lstSinhVien.Remove(sv);
        }

        private void bbtnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //tim kiem sinh vien theo MaSinhVien
            string searchValue = txtSearch.Text;
            var result = lstSinhVien.Where(sv => sv.MaSinhVien.Contains(searchValue)).ToList();
            gridControl1.DataSource = result;
        }

        private void gridView1_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {
            // Hiển thị hộp thoại xác nhận xoá sinh viên
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xoá sinh viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Lấy chỉ số dòng đang xoá
                int rowIndex = e.RowHandle;

                // Xoá sinh viên khỏi danh sách
                lstSinhVien.RemoveAt(rowIndex);

                // Cập nhật dữ liệu trong GridView
                gridView1.RefreshData();
            }
            else
            {
                e.Cancel = true; // Hủy thao tác xoá
            }
        }
    }
}
