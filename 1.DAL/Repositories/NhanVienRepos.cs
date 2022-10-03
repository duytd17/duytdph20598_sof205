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
    public class NhanVienRepos : INhanVien
    {
        private FpolyDBContext _DBContext;
        private List<NhanVien> _lstNhanVien;

        public NhanVienRepos()
        {
            _DBContext = new FpolyDBContext();
            _lstNhanVien = new List<NhanVien>();
            getNhanVienFromDB();
        }

        public bool addNhanVien(NhanVien nhanVien)
        {
            if (nhanVien == null) return false;
            nhanVien.Id = new Guid();
            _DBContext.NhanViens.Add(nhanVien);
            _DBContext.SaveChanges();
            return true;
        }

        public bool updateNhanVien(NhanVien nhanVien)
        {
            if (nhanVien == null) return false;
            var obj = _DBContext.NhanViens.FirstOrDefault(c => c.Id == nhanVien.Id);
            obj.Ma = nhanVien.Ma;
            obj.Ten = nhanVien.Ten;
            obj.TenDem = nhanVien.TenDem;
            obj.Ho = nhanVien.Ho;
            obj.GioiTinh = nhanVien.GioiTinh;
            obj.NgaySinh = nhanVien.NgaySinh;
            obj.DiaChi = nhanVien.DiaChi;
            obj.Sdt = nhanVien.Sdt;
            obj.MatKhau = nhanVien.MatKhau;
            obj.TrangThai = nhanVien.TrangThai;
            _DBContext.NhanViens.Update(obj);
            _DBContext.SaveChanges();
            return true;
        }

        public bool deleteNhanVien(NhanVien nhanVien)
        {
            if (nhanVien == null) return false;
            var obj = _DBContext.KhachHangs.FirstOrDefault(c => c.Id == nhanVien.Id);
            _DBContext.KhachHangs.Remove(obj);
            _DBContext.SaveChanges();
            return true;
        }

        public NhanVien getById(Guid id)
        {
            if (id == Guid.Empty) return null;
            return _DBContext.NhanViens.FirstOrDefault(c => c.Id == id);
        }

        public List<NhanVien> getNhanVienFromDB()
        {
            _lstNhanVien = _DBContext.NhanViens.ToList();
            return _lstNhanVien;
        }

        
    }
}
