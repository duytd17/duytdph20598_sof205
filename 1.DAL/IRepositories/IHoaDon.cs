using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface IHoaDon
    {
        HoaDon getById(Guid id);
        List<HoaDon> getHoaDonFromDB();
        bool addHoaDon(HoaDon hoaDon); 
        bool updateHoaDon(HoaDon hoaDon);
        bool deleteHoaDon(HoaDon hoaDon);
    }
}
