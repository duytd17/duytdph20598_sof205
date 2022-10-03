using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface IDongSP
    {
        DongSp getById(Guid id);
        List<DongSp> getDongSPFromDB();
        bool addDongSP(DongSp dongSp);
        bool updateDongSP(DongSp dongSp);
        bool deleteDongSP(DongSp dongSp);
    }
}
