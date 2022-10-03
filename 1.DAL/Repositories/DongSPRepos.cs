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
    public class DongSPRepos : IDongSP
    {
        private FpolyDBContext _DBContext;
        private List<DongSp> _lstDongSP;

        public DongSPRepos()
        {
            _DBContext = new FpolyDBContext();
            _lstDongSP = new List<DongSp>();
            getDongSPFromDB();
        }

        public bool addDongSP(DongSp dongSp)
        {
            if (dongSp == null) return false;
            dongSp.Id = Guid.NewGuid();
            _DBContext.DongSps.Add(dongSp);
            _DBContext.SaveChanges();
            return true;
        }

        public bool updateDongSP(DongSp dongSp)
        {
            if (dongSp == null) return false;
            var obj = _DBContext.DongSps.FirstOrDefault(c => c.Id == dongSp.Id);
            obj.Ma = dongSp.Ma;
            obj.Ten = dongSp.Ten;
            _DBContext.DongSps.Update(obj);
            _DBContext.SaveChanges();
            return true;
        }

        public bool deleteDongSP(DongSp dongSp)
        {
            if (dongSp == null) return false;
            var obj = _DBContext.DongSps.FirstOrDefault(c => c.Id == dongSp.Id);
            _DBContext.DongSps.Remove(obj);
            _DBContext.SaveChanges();
            return true;
        }

        public DongSp getById(Guid id)
        {
            if (id == Guid.Empty) return null;
            return _DBContext.DongSps.FirstOrDefault(c => c.Id == id);

        }
        public List<DongSp> getDongSPFromDB()
        {
            _lstDongSP = _DBContext.DongSps.ToList();
            return _lstDongSP;
        }
    }
}
