using _1.DAL.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DAL.IRepositories
{
    public interface INsx
    {
        Nsx getById(Guid id);
        List<Nsx> getNsxFromDB();
        bool addNsx(Nsx nsx);
        bool updateNsx(Nsx nsx);
        bool deleteNsx(Nsx nsx);
    }
}
