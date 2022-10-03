using _1.DAL.DomainClass;
using _2.BUS.IServices;
using _2.BUS.Services;
using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3.PL.View
{
    public partial class FrmQLNsx : Form
    {
        private INsxService _iNsxService;
        private Guid _IdWhenClick;

        public FrmQLNsx()
        {
            InitializeComponent();
            _iNsxService = new QLNsxService();
            LoadData();
        }

        private void LoadData()
        {
            int stt = 1;
            dgrid_Nsx.ColumnCount = 4;
            dgrid_Nsx.Columns[0].Name = "STT";
            dgrid_Nsx.Columns[1].Name = "Id";
            dgrid_Nsx.Columns[1].Visible = false;
            dgrid_Nsx.Columns[2].Name = "Mã";
            dgrid_Nsx.Columns[3].Name = "Tên";
            dgrid_Nsx.Rows.Clear();

            foreach (var x in _iNsxService.GetAll())
            {
                dgrid_Nsx.Rows.Add(stt++, x.Nsx.Id, x.Nsx.Ma, x.Nsx.Ten);
            }
        }

        private NsxView GetDataFromGuild()
        {
            NsxView view = new NsxView();
            view.Nsx = new Nsx()
            {
                Id = Guid.Empty,
                Ma = txt_Ma.Text,
                Ten = txt_Ten.Text
            };
            return view;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            _iNsxService.addNsx(GetDataFromGuild());
            LoadData();

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn thêm nhà sản xuất này không ?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var temp = GetDataFromGuild();
                MessageBox.Show(_iNsxService.addNsx(temp));
                LoadData();
            }
            if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            _iNsxService.updateNsx(GetDataFromGuild());
            LoadData();

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn sửa nhà sản xuất này không ?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var temp = GetDataFromGuild();
                temp.Nsx.Id = _IdWhenClick;
                MessageBox.Show(_iNsxService.updateNsx(temp));
                LoadData();
            }
            if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            _iNsxService.deleteNsx(GetDataFromGuild());
            LoadData();

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa nhà sản xuất này không ?", "Thông Báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var temp = GetDataFromGuild();
                temp.Nsx.Id = _IdWhenClick;
                MessageBox.Show(_iNsxService.deleteNsx(temp));
                LoadData();
            }
            if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void dgrid_Nsx_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            txt_Ma.Text = dgrid_Nsx.Rows[index].Cells[2].Value.ToString();
            txt_Ten.Text = dgrid_Nsx.Rows[index].Cells[3].Value.ToString();
        }
    }
}

