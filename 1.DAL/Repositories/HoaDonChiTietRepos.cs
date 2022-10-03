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
    public class HoaDonChiTietRepos : IHoaDonChiTiet
    {
        private FpolyDBContext _DBContext;
        private List<HoaDonChiTiet> _lstHoaDonChiTiet;

        public HoaDonChiTietRepos()
        {
            _DBContext = new FpolyDBContext();
            _lstHoaDonChiTiet = new List<HoaDonChiTiet>();
            getHoaDonChiTietFromDB();
        }

        public bool addHoaDonChiTiet(HoaDonChiTiet hoaDonChiTiet)
        {
            
            _DBContext.HoaDonChiTiets.Add(hoaDonChiTiet);
            _DBContext.SaveChanges();
            return true;
        }

        public bool updateHoaDonChiTiet(HoaDonChiTiet hoaDonChiTiet)
        {
            _DBContext.HoaDonChiTiets.Update(hoaDonChiTiet);
            _DBContext.SaveChanges();
            return true;
        }

        public bool deleteHoaDonChiTiet(HoaDonChiTiet hoaDonChiTiet)
        {
            _DBContext.HoaDonChiTiets.Remove(hoaDonChiTiet);
            _DBContext.SaveChanges();
            return true;
        }
        public List<HoaDonChiTiet> getHoaDonChiTietFromDB()
        {
            _lstHoaDonChiTiet = _DBContext.HoaDonChiTiets.ToList();
            return _lstHoaDonChiTiet;
        }
    }
}
