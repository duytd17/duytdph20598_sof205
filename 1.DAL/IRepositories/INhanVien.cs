using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface INhanVien
    {
        NhanVien getById(Guid id);
        List<NhanVien> getNhanVienFromDB();
        bool addNhanVien(NhanVien nhanVien);
        bool updateNhanVien(NhanVien nhanVien);
        bool deleteNhanVien(NhanVien nhanVien);
    }
}
