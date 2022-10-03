using _1.DAL.IRepositories;
using _1.DAL.Repositories;
using _2.BUS.IServices;
using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.Services
{
    public class QLSanPhamService : IQLSanPhamService
    {
        private IChiTietSP _iChiTietSPRepos;
        private ISanPham _iSanPhamRepos;
        private IMauSac _iMauSacRepos;
        private INsx _iNsxRepos;
        private IDongSP _iDongSpRepos;

        public QLSanPhamService()
        {
            _iChiTietSPRepos = new ChiTietSPRepos();
            _iSanPhamRepos = new SanPhamRepos();
            _iMauSacRepos = new MauSacRepos();
            _iNsxRepos = new NsxRepos();
            _iDongSpRepos = new DongSPRepos();
        }

        public string Add(SanPhamView obj)
        {
            if (obj == null) return "Không tồn tại";
            var chiTietSanPham = obj.ChiTietSp;
            if (_iChiTietSPRepos.addChiTietSP(chiTietSanPham)) return "Thêm thành công";
            return "Thêm không thành công";
        }

        public string Delete(SanPhamView obj)
        {
            if (obj == null) return "Không tồn tại";
            var chiTietSanPham = obj.ChiTietSp;
            if (_iChiTietSPRepos.deleteChiTietSP(chiTietSanPham)) return "Xóa thành công";
            return "Xóa không thành công";
        }

        public string Update(SanPhamView obj)
        {
            if (obj == null) return "Không tồn tại";
            var chiTietSanPham = obj.ChiTietSp;
            if (_iChiTietSPRepos.updateChiTietSP(chiTietSanPham)) return "Sửa thành công";
            return "Sửa không thành công";
        }

        public List<SanPhamView> GetAll()
        {
            List<SanPhamView> lstPhamViews = new List<SanPhamView>();
            //Viết 1 câu LINQ để gán giá trị cho từng prop của SPView
            lstPhamViews =
                (from a in _iChiTietSPRepos.getChiTietSPfromDB()
                 join b in _iSanPhamRepos.getSanPhamFromDB() on a.IdSp equals b.Id
                 join c in _iMauSacRepos.getMauSacFromDB() on a.IdMauSac equals c.Id
                 join d in _iNsxRepos.getNsxFromDB() on a.IdNsx equals d.Id
                 join e in _iDongSpRepos.getDongSPFromDB() on a.IdDongSp equals e.Id
                 select new SanPhamView()
                 {
                    ChiTietSp = a,
                     SanPham = b,
                     MauSac = c,
                     Nsx = d,
                     DongSp = e
                 }).ToList();
            //Để hiển thị sản phẩm thì có càng nhiều bảng tham gia thì join vào càng nhiều

            return lstPhamViews;
        }

        
    }
}
