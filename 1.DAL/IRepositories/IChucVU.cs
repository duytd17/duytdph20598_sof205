using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface IChucVU
    {
        bool addChucVu(ChucVu chucVu);
        bool updateChucVu(ChucVu chucVu);
        bool deleteChucVu(ChucVu chucVu);
        ChucVu GetById(Guid id);
        List<ChucVu> getChucVuFromDB();

    }
}
