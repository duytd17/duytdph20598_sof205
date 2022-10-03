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
    public class ChucVuRepos : IChucVU
    {
        private FpolyDBContext _DBContext;
        private List<ChucVu> _lstChucVu;
        public ChucVuRepos()
        {
            _DBContext = new FpolyDBContext();
            _lstChucVu = new List<ChucVu>();
            getChucVuFromDB();
        }
        public bool addChucVu(ChucVu chucVu)
        {
            if (chucVu == null) return false;
            chucVu.Id = Guid.NewGuid();
            _DBContext.ChucVus.Add(chucVu);
            _DBContext.SaveChanges();
            return true;
        }

        public bool updateChucVu(ChucVu chucVu)
        {
            if(chucVu == null) return false;
            var obj = _DBContext.ChucVus.FirstOrDefault(c => c.Id == chucVu.Id);
            obj.Ma = chucVu.Ma;
            obj.Ten = chucVu.Ten;
            _DBContext.ChucVus.Update(obj);
            _DBContext.SaveChanges();
            return true;
        }

        public bool deleteChucVu(ChucVu chucVu)
        {
            if (chucVu == null) return false;
            var obj = _DBContext.ChucVus.FirstOrDefault(c => c.Id == chucVu.Id);
            _DBContext.ChucVus.Remove(obj);
            _DBContext.SaveChanges();
            return true;
        }

        public ChucVu GetById(Guid id)
        {
            if (id == Guid.Empty) return null;
            return _DBContext.ChucVus.FirstOrDefault(c => c.Id == id);
        }
        
        public List<ChucVu> getChucVuFromDB()
        {
            _lstChucVu = _DBContext.ChucVus.ToList();
            return _lstChucVu;
        }
    }
}
