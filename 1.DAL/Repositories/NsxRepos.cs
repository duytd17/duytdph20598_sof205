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
    public class NsxRepos : INsx
    {
        private FpolyDBContext _DBContext;
        private List<Nsx> _lstNxs;

        public NsxRepos()
        {
            _DBContext = new FpolyDBContext();
            _lstNxs = new List<Nsx>();
            getNsxFromDB();


        }

        public bool addNsx(Nsx nsx)
        {
            if (nsx == null) return false;
            nsx.Id = new Guid();
            _DBContext.Nsxes.Add(nsx);
            _DBContext.SaveChanges();
            return true;
        }

        public bool updateNsx(Nsx nsx)
        {
            if (nsx == null) return false;
            var obj = _DBContext.Nsxes.FirstOrDefault(c => c.Id == nsx.Id);
            obj.Ma = nsx.Ma;
            obj.Ten = nsx.Ten;
            _DBContext.Nsxes.Update(obj);
            _DBContext.SaveChanges();
            return true;
        }

        public bool deleteNsx(Nsx nsx)
        {
            if (nsx == null) return false;
            var obj = _DBContext.Nsxes.FirstOrDefault(c => c.Id == nsx.Id);
            _DBContext.Nsxes.Remove(obj);
            _DBContext.SaveChanges();
            return true;
        }

        public Nsx getById(Guid id)
        {
            if (id == Guid.Empty) return null;
            return _DBContext.Nsxes.FirstOrDefault(c => c.Id == id);
        }

        public List<Nsx> getNsxFromDB()
        {
            _lstNxs = _DBContext.Nsxes.ToList();
            return _lstNxs;
        }

       
    }
}
