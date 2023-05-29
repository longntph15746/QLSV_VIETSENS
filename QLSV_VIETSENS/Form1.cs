using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            ShowMain();
        }

        private void ShowMain()
        {
            //
            GenerateMaSV();

        }
        private int countSV = 0;

        private string GenerateMaSV()
        {

            countSV++; // Tăng số lượng sinh viên lên 1
            return "SV" + countSV.ToString("000000"); // Sinh mã sinh viên tự động
        }

        private void LoadDataToGrid()
        {
            throw new NotImplementedException();
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
            sv.DoiTuong = cboDoiTuong.Text;
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
            // Lấy thông tin sinh viên đã được chỉnh sửa
            SinhVien sinhVien = gridView1.GetRow(e.RowHandle) as SinhVien;
            if (sinhVien != null)
            {
                // Cập nhật thông tin sinh viên đã được chỉnh sửa
                if (e.Column.FieldName == "HoTen")
                {
                    sinhVien.HoTen = e.Value.ToString();
                }
                else if (e.Column.FieldName == "GioiTinh")
                {
                    sinhVien.GioiTinh = e.Value.ToString();
                }
                else if (e.Column.FieldName == "NgaySinh")
                {
                    sinhVien.NgaySinh = (DateTime)e.Value;
                }
                else if (e.Column.FieldName == "DoiTuong")
                {
                    sinhVien.DoiTuong = e.Value.ToString();
                }
                else if (e.Column.FieldName == "GhiChu")
                {
                    sinhVien.GhiChu = e.Value.ToString();
                }
            }

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
            cboGioiTinh.Text = sv.GioiTinh;
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
            sv.GioiTinh = cboGioiTinh.SelectedItem.ToString();
            sv.DoiTuong = cboDoiTuong.Text;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string maSV = txtMa.Text; // Lấy mã sinh viên từ TextBox

            // Tìm kiếm sinh viên theo mã sinh viên
            SinhVien sv = lstSinhVien.Find(s => s.MaSinhVien == maSV);

            if (sv != null)
            {
                // Tạo danh sách tạm thời chứa kết quả tìm kiếm
                List<SinhVien> result = new List<SinhVien>();
                result.Add(sv);

                // Cập nhật dữ liệu tìm kiếm trong GridControl hoặc GridView
                gridControl1.DataSource = result;
                gridView1.RefreshData();
            }
            else
            {
                // Thông báo không tìm thấy sinh viên
                MessageBox.Show("Không tìm thấy sinh viên có mã " + maSV);
            }
        }

        private void cboGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
