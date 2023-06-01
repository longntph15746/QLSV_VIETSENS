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
            ShowMain();
        }

        private void ShowMain()
        {
            GenerateMaSV();

        }
        private int countSV = 0;

        private string GenerateMaSV()
        {
            string maSV = "";
            bool isDuplicate = true;

            while (isDuplicate)
            {
                countSV++; // Tăng số lượng sinh viên lên 1
                maSV = "SV" + countSV.ToString("0000"); // Sinh mã sinh viên tự động

                // Kiểm tra xem mã sinh viên đã tồn tại trong danh sách hay chưa
                isDuplicate = lstSinhVien.Any(s => s.MaSinhVien == maSV);
            }
            return maSV;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
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
                sv.DiemToan = string.IsNullOrEmpty(txtToan.Text) ? 0 : Convert.ToDouble(txtToan.Text);
                sv.DiemVan = string.IsNullOrEmpty(txtVan.Text) ? 0 : Convert.ToDouble(txtVan.Text);
                sv.DiemAnh = string.IsNullOrEmpty(txtAnh.Text) ? 0 : Convert.ToDouble(txtAnh.Text);
                sv.GhiChu = mmGhiChu.Text;
                lstSinhVien.Add(sv);
                gridControl1.DataSource = lstSinhVien;
                gridControl1.RefreshDataSource();
                MessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LuuDuLieuSinhVien("TextFile1.txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi tải dữ liệu sinh viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            {
                sv.DoiTuong = e.Value.ToString();
                UpdateTongSoSVByDoiTuong();
            }

            else if (e.Column.FieldName == "DiemToan")
                sv.DiemToan = Convert.ToDouble(e.Value.ToString());
            else if (e.Column.FieldName == "DiemVan")
                sv.DiemVan = Convert.ToDouble(e.Value.ToString());
            else if (e.Column.FieldName == "DiemAnh")
                sv.DiemAnh = Convert.ToDouble(e.Value.ToString());
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
            cboDoiTuong.Text = sv.DoiTuong;
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
            sv.DiemToan = string.IsNullOrEmpty(txtToan.Text) ? 0 : Convert.ToDouble(txtToan.Text);
            sv.DiemVan = string.IsNullOrEmpty(txtVan.Text) ? 0 : Convert.ToDouble(txtVan.Text);
            sv.DiemAnh = string.IsNullOrEmpty(txtAnh.Text) ? 0 : Convert.ToDouble(txtAnh.Text);
            sv.GhiChu = mmGhiChu.Text;
            lstSinhVien.Add(sv);
            gridControl1.DataSource = lstSinhVien;
            gridControl1.RefreshDataSource();
            MessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LuuDuLieuSinhVien("TextFile1.txt");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var sv = lstSinhVien.FirstOrDefault(x => x.MaSinhVien == txtMa.Text);
                lstSinhVien.Remove(sv);
                sv.HoTen = txtTen.Text;
                sv.NgaySinh = dateNS.DateTime;
                sv.GioiTinh = cboGioiTinh.SelectedItem.ToString();
                sv.DoiTuong = cboDoiTuong.Text.ToString();
                sv.DiemToan = string.IsNullOrEmpty(txtToan.Text) ? 0 : Convert.ToDouble(txtToan.Text);
                sv.DiemVan = string.IsNullOrEmpty(txtVan.Text) ? 0 : Convert.ToDouble(txtVan.Text);
                sv.DiemAnh = string.IsNullOrEmpty(txtAnh.Text) ? 0 : Convert.ToDouble(txtAnh.Text);
                sv.GhiChu = mmGhiChu.Text;
                lstSinhVien.Add(sv);
                gridControl1.DataSource = lstSinhVien;
                gridControl1.RefreshDataSource();
                MessageBox.Show("Đã sửa thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LuuDuLieuSinhVien("TextFile1.txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //tim kiem sinh vien theo MaSinhVien
                string searchValue = txtSearch.Text;
                var result = lstSinhVien.Where(sv => sv.MaSinhVien.Contains(searchValue)).ToList();
                gridControl1.DataSource = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            int rowIndex = gridView1.FocusedRowHandle;

            if (rowIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để xoá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string maSinhVien = gridView1.GetRowCellValue(rowIndex, "MaSinhVien").ToString();

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xoá sinh viên '" + maSinhVien + "'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SinhVien sinhVien = lstSinhVien.FirstOrDefault(sv => sv.MaSinhVien == maSinhVien);
                if (sinhVien != null)
                {
                    lstSinhVien.Remove(sinhVien);
                    gridControl1.DataSource = lstSinhVien;
                    gridView1.RefreshData();
                }
            }
            LuuDuLieuSinhVien("TextFile1.txt");
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
                        writer.WriteLine(" ");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void LoadDuLieuSinhVien(string filePath)
        {

            try
            {
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

                            string maSinhVien = line.Substring(line.IndexOf(":") + 1).Trim();
                            sv.MaSinhVien = maSinhVien;
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
                                sv.DiemToan = Convert.ToDouble(line.Substring(line.IndexOf(":") + 1).Trim());
                            }
                            else if (line.StartsWith("Điểm văn:"))
                            {
                                sv.DiemVan = Convert.ToDouble(line.Substring(line.IndexOf(":") + 1).Trim());
                            }
                            else if (line.StartsWith("Điểm anh:"))
                            {
                                sv.DiemAnh = Convert.ToDouble(line.Substring(line.IndexOf(":") + 1).Trim());
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
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtVan_Validating(object sender, CancelEventArgs e)
        {
            double diem;
            if (double.TryParse(txtVan.Text, out diem))
            {
                if (diem > 10)
                {
                    e.Cancel = true;
                    txtVan.ErrorText = "Điểm không được lớn hơn 10";
                }
            }
        }

        private void txtAnh_Validating(object sender, CancelEventArgs e)
        {
            double diem;
            if (double.TryParse(txtAnh.Text, out diem))
            {
                if (diem > 10)
                {
                    e.Cancel = true;
                    txtAnh.ErrorText = "Điểm không được lớn hơn 10";
                }
            }
        }
        private void gridControl1_Load_1(object sender, EventArgs e)
        {
            string fileName = "TextFile1.txt";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            try
            {
                LoadDuLieuSinhVien("TextFile1.txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bbtnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var sv = lstSinhVien.FirstOrDefault(x => x.MaSinhVien == txtMa.Text);
            lstSinhVien.Remove(sv);
            sv.HoTen = txtTen.Text;
            sv.NgaySinh = dateNS.DateTime;
            sv.GioiTinh = cboGioiTinh.SelectedItem.ToString();
            sv.DoiTuong = cboDoiTuong.Text.ToString();
            sv.DiemToan = string.IsNullOrEmpty(txtToan.Text) ? 0 : Convert.ToDouble(txtToan.Text);
            sv.DiemVan = string.IsNullOrEmpty(txtVan.Text) ? 0 : Convert.ToDouble(txtVan.Text);
            sv.DiemAnh = string.IsNullOrEmpty(txtAnh.Text) ? 0 : Convert.ToDouble(txtAnh.Text);
            sv.GhiChu = mmGhiChu.Text;
            lstSinhVien.Add(sv);
            gridControl1.DataSource = lstSinhVien;
            gridControl1.RefreshDataSource();
            MessageBox.Show("Đã sửa thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LuuDuLieuSinhVien("TextFile1.txt");
        }

        private void bbtnSearch_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //tim kiem sinh vien theo MaSinhVien
            string searchValue = txtSearch.Text;
            var result = lstSinhVien.Where(sv => sv.MaSinhVien.Contains(searchValue)).ToList();
            gridControl1.DataSource = result;
        }

        private void txtToan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Hủy ký tự không hợp lệ
            }
        }

        private void txtVan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Hủy ký tự không hợp lệ
            }
        }

        private void txtAnh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Hủy ký tự không hợp lệ
            }
        }

        private void dateNS_Validating(object sender, CancelEventArgs e)
        {
            DateTime ngaySinh;
            if (DateTime.TryParse(dateNS.Text, out ngaySinh))
            {
                if (ngaySinh > DateTime.Now)
                {
                    e.Cancel = true;
                    dateNS.ErrorText = "Ngày sinh không được lớn hơn ngày hiện tại.";
                }
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Xóa thông tin trong các điều khiển
            txtMa.Text = string.Empty;
            txtTen.Text = string.Empty;
            dateNS.Text = string.Empty;
            cboGioiTinh.Text = string.Empty;
            cboDoiTuong.Text = string.Empty;
            txtToan.Text = string.Empty;
            txtVan.Text = string.Empty;
            txtAnh.Text = string.Empty;
            mmGhiChu.Text = string.Empty;
            // Đặt focus vào điều khiển đầu tiên
            txtTen.Focus();
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            UpdateTongSoSinhVien();
            UpdateTongSoSVByDoiTuong();
            TongSoSinhVien8Plus();
            SinhVienNam();
            SinhVienNu();
            LuuDuLieuSinhVien("TextFile1.txt");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateTongSoSinhVien();
        }

        private void TongSoSinhVien8Plus()
        {
            int count = gridView1.DataController.ListSource.Cast<SinhVien>()
              .Count(sv => (sv.DiemToan + sv.DiemVan + sv.DiemAnh) / 3.0 > 8.0);
            labelControl4.Text = $"-Tổng số sinh viên có điểm TB Toán-Văn-Anh > 8: {count}";
        }

        private void UpdateTongSoSVByDoiTuong()
        {
            var groupedByDoiTuong = gridView1.DataController.ListSource.Cast<SinhVien>()
        .GroupBy(sv => sv.DoiTuong)
        .Select(g => new { DoiTuong = g.Key, TongSoSV = g.Count() });

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("- Sinh viên theo từng đối tượng:");

            foreach (var group in groupedByDoiTuong)
            {
                sb.AppendLine($"{group.DoiTuong}: {group.TongSoSV}");
            }

            labelControl3.Text = sb.ToString();
        }

        private void gridView1_DataSourceChanged(object sender, EventArgs e)
        {
        }

        private void UpdateTongSoSinhVien()
        {
            int tongSoSV = gridView1.DataRowCount;

            // Hiển thị tổng số sinh viên trong labelControl1
            labelControl1.Text = $"-Tổng số sinh viên :{tongSoSV} sinh viên";
        }

        private void gridView1_RowCountChanged(object sender, EventArgs e)
        {
            UpdateTongSoSinhVien();
            UpdateTongSoSVByDoiTuong();
            TongSoSinhVien8Plus();
            SinhVienNam();
            SinhVienNu();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            UpdateTongSoSinhVien();
            UpdateTongSoSVByDoiTuong();
            TongSoSinhVien8Plus();
            SinhVienNam();
            SinhVienNu();
        }

        private void SinhVienNu()
        {
            var sinhVienNu = gridView1.DataController.ListSource.Cast<SinhVien>()
        .Where(sv => sv.GioiTinh == "Nữ")
        .ToList();
            int tongSoSinhVienNu = sinhVienNu.Count;
            labelControl6.Text = $"Số sinh viên nữ: {tongSoSinhVienNu}";
        }

        private void SinhVienNam()
        {
            var sinhVienNam = gridView1.DataController.ListSource.Cast<SinhVien>()
        .Where(sv => sv.GioiTinh == "Nam")
        .ToList();
            int tongSoSinhVienNam = sinhVienNam.Count;
            labelControl5.Text = $"Số sinh viên nam: {tongSoSinhVienNam}";
        }

        private void cboGioiTinh_Click(object sender, EventArgs e)
        {
            ComboBoxEdit comboBox = sender as ComboBoxEdit;
            comboBox.ShowPopup();
        }

        private void cboDoiTuong_Click(object sender, EventArgs e)
        {
            ComboBoxEdit comboBox = sender as ComboBoxEdit;
            comboBox.ShowPopup();
        }

        private void cboGioiTinh_Validating(object sender, CancelEventArgs e)
        {
            ComboBoxEdit comboBox = sender as ComboBoxEdit;
            string gioiTinh = comboBox.EditValue as string;

            if (string.IsNullOrEmpty(gioiTinh))
            {
                e.Cancel = true; // Hủy sự kiện đang xảy ra

                MessageBox.Show("Vui lòng chọn giới tính từ danh sách", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                comboBox.Undo(); // Hoàn tác giá trị vừa nhập
            }
        }

        private void cboGioiTinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Xóa thông tin trong các điều khiển
            txtMa.Text = string.Empty;
            txtTen.Text = string.Empty;
            dateNS.Text = string.Empty;
            cboGioiTinh.Text = string.Empty;
            cboDoiTuong.Text = string.Empty;
            txtToan.Text = string.Empty;
            txtVan.Text = string.Empty;
            txtAnh.Text = string.Empty;
            mmGhiChu.Text = string.Empty;
            // Đặt focus vào điều khiển đầu tiên
            txtTen.Focus();
        }

        private void txtTen_Validating(object sender, CancelEventArgs e)
        {

        }

        private void dateNS_Click(object sender, EventArgs e)
        {
            DateEdit date = sender as DateEdit;
            date.ShowPopup();
        }
    }
}
