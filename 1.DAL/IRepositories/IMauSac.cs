using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface IMauSac
    {
        List<MauSac> getMauSacFromDB();
        MauSac getById(Guid id);
        bool addMauSac(MauSac mauSac);
        bool updateMauSac(MauSac mauSac);
        bool deleteMauSac(MauSac mauSac);
    }
}
