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
    public class HoaDonRepos : IHoaDon
    {
        private FpolyDBContext _DBContext;
        private List<HoaDon> _lstHoaDon;

        public HoaDonRepos()
        {
            _DBContext = new FpolyDBContext();
            _lstHoaDon = new List<HoaDon>();
            getHoaDonFromDB();
        }

        public bool addHoaDon(HoaDon hoaDon)
        {
            if (hoaDon == null) return false;
            hoaDon.Id = Guid.NewGuid();
            _DBContext.HoaDons.Add(hoaDon);
            _DBContext.SaveChanges();
            return true;
        }

        public bool updateHoaDon(HoaDon hoaDon)
        {
            if (hoaDon == null) return false;
            var obj = _DBContext.HoaDons.FirstOrDefault(c => c.Id == hoaDon.Id);
            obj.Ma = hoaDon.Ma;
            obj.NgayTao = hoaDon.NgayTao;
            obj.NgayThanhToan = hoaDon.NgayThanhToan;
            obj.NgayShip = hoaDon.NgayShip;
            obj.NgayNhan = hoaDon.NgayNhan;
            obj.TinhTrang = hoaDon.TinhTrang;
            obj.TenNguoiNhan = hoaDon.TenNguoiNhan;
            obj.DiaChi = hoaDon.DiaChi;
            obj.Sdt = hoaDon.Sdt;
            _DBContext.HoaDons.Update(obj);
            _DBContext.SaveChanges();
            return true;
        }

        public bool deleteHoaDon(HoaDon hoaDon)
        {
            if(hoaDon == null) return false;
            var obj = _DBContext.HoaDons.FirstOrDefault(c => c.Id == hoaDon.Id);
            _DBContext.HoaDons.Remove(obj);
            _DBContext.SaveChanges();
            return true;
        }

        public HoaDon getById(Guid id)
        {
            if (id == Guid.Empty) return null;
            return _DBContext.HoaDons.FirstOrDefault(c => c.Id == id);
        }
        public List<HoaDon> getHoaDonFromDB()
        {
            _lstHoaDon = _DBContext.HoaDons.ToList();
            return _lstHoaDon;
        }
    }
}
