using _1.DAL.Context;
using _1.DAL.DomainClass;
using _1.DAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.Repositories
{
    public class KhachHangRepos : IKhachHang
    {
        private FpolyDBContext _DBContext;
        private List<KhachHang> _lstKhachHang;

        public KhachHangRepos()
        {
            _DBContext = new FpolyDBContext();
            _lstKhachHang = new List<KhachHang>();
            getKhachHangFromDB();
        }

        public bool addKhachHang(KhachHang khachHang)
        {
            if(khachHang == null) return false;
            khachHang.Id = new Guid();
            _DBContext.KhachHangs.Add(khachHang);
            _DBContext.SaveChanges();
            return true;
        }

        public bool updateKhachHang(KhachHang khachHang)
        {
            if(khachHang == null) return false;
            var obj = _DBContext.KhachHangs.FirstOrDefault(c => c.Id == khachHang.Id);
            obj.Ma = khachHang.Ma;
            obj.Ten = khachHang.Ten;
            obj.TenDem = khachHang.TenDem;
            obj.Ho = khachHang.Ho;
            obj.NgaySinh = khachHang.NgaySinh;
            obj.Sdt = khachHang.Sdt;
            obj.DiaChi = khachHang.DiaChi;
            obj.ThanhPho = khachHang.ThanhPho;
            obj.QuocGia = khachHang.QuocGia;
            obj.MatKhau = khachHang.MatKhau;
            _DBContext.KhachHangs.Update(obj);
            _DBContext.SaveChanges();
            return true;
        }

        public bool deleteKhachHang(KhachHang khachHang)
        {
            if (khachHang == null) return false;
            var obj = _DBContext.KhachHangs.FirstOrDefault(c => c.Id == khachHang.Id);
            _DBContext.KhachHangs.Remove(obj);
            _DBContext.SaveChanges();
            return true;
        }

        public KhachHang getById(Guid id)
        {
            if (id == Guid.Empty) return null;
            return _DBContext.KhachHangs.FirstOrDefault(c => c.Id == id);
        }

        public List<KhachHang> getKhachHangFromDB()
        {
            _lstKhachHang = _DBContext.KhachHangs.ToList();
            return _lstKhachHang;
        }
    }
}
