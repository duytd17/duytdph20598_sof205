using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface IChiTietSP
    {
        bool addChiTietSP(ChiTietSp chiTietSp);
        bool updateChiTietSP(ChiTietSp chiTietSp);
        bool deleteChiTietSP(ChiTietSp chiTietSp);
        ChiTietSp TimKiem(Guid id);
        List<ChiTietSp> getChiTietSPfromDB();

    }
}
