using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface ICuaHang
    {
        CuaHang getById(Guid id);
        List<CuaHang> getCuaHangFromDB();
        bool addCuaHang(CuaHang cuaHang);
        bool updateCuaHang(CuaHang cuaHang);
        bool deleteCuaHang(CuaHang cuaHang);
    }
}
