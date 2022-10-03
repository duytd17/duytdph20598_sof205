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
    public class MauSacRepos : IMauSac
    {
        private FpolyDBContext _DBContext;
        private List<MauSac> _lstMauSac;

        public MauSacRepos()
        {
            _DBContext = new FpolyDBContext(); ;
            _lstMauSac = new List<MauSac>();
            getMauSacFromDB();

        }

        public bool addMauSac(MauSac mauSac)
        {
            if (mauSac == null) return false;
            mauSac.Id = new Guid();
            _DBContext.MauSacs.Add(mauSac);
            _DBContext.SaveChanges();
            return true;
        }

        public bool updateMauSac(MauSac mauSac)
        {
            if (mauSac == null) return false;
            var obj = _DBContext.MauSacs.FirstOrDefault(c => c.Id == mauSac.Id);
            obj.Ma = mauSac.Ma;
            obj.Ten = mauSac.Ten;
            _DBContext.MauSacs.Update(obj);
            _DBContext.SaveChanges();
            return true;
        }

        public bool deleteMauSac(MauSac mauSac)
        {
            if (mauSac == null) return false;
            var obj = _DBContext.MauSacs.FirstOrDefault(c => c.Id == mauSac.Id);
            _DBContext.MauSacs.Remove(obj);
            _DBContext.SaveChanges();
            return true;
        }

        public MauSac getById(Guid id)
        {
            if (id == Guid.Empty) return null;
            return _DBContext.MauSacs.FirstOrDefault(c => c.Id == id);
        }

        public List<MauSac> getMauSacFromDB()
        {
            _lstMauSac = _DBContext.MauSacs.ToList();
            return _lstMauSac;
        }

        
    }
}
