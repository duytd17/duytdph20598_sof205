using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface IHoaDonChiTiet
    {
        List<HoaDonChiTiet> getHoaDonChiTietFromDB();
        bool addHoaDonChiTiet(HoaDonChiTiet hoaDonChiTiet);
        bool updateHoaDonChiTiet(HoaDonChiTiet hoaDonChiTiet);
        bool deleteHoaDonChiTiet(HoaDonChiTiet hoaDonChiTiet);
    }
}
