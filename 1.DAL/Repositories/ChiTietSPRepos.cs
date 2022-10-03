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
    public class ChiTietSPRepos : IChiTietSP
    {
        private FpolyDBContext _DBcontext;
        private List<ChiTietSp> _lstChiTietSP;

        public ChiTietSPRepos()
        {
            _DBcontext = new FpolyDBContext();
            _lstChiTietSP = new List<ChiTietSp>();
            getChiTietSPfromDB();
        }

        public bool addChiTietSP(ChiTietSp chiTietSp)
        {
            if (chiTietSp == null) return false;
            chiTietSp.Id = Guid.NewGuid();
            _DBcontext.ChiTietSps.Add(chiTietSp);
            _DBcontext.SaveChanges();
            return true;
        }  

        public bool updateChiTietSP(ChiTietSp chiTietSp)
        {
            if (chiTietSp == null) return false;
            var obj = _DBcontext.ChiTietSps.FirstOrDefault(c => c.Id == chiTietSp.Id);
            obj.IdSp = chiTietSp.IdSp;
            obj.IdNsx = chiTietSp.IdNsx;
            obj.IdMauSac = chiTietSp.IdMauSac;
            obj.IdDongSp = chiTietSp.IdDongSp;
            obj.NamBh = chiTietSp.NamBh;
            obj.MoTa = chiTietSp.MoTa;
            obj.SoLuongTon = chiTietSp.SoLuongTon;
            obj.GiaBan = chiTietSp.GiaBan;
            obj.GiaNhap = chiTietSp.GiaNhap;
            _DBcontext.ChiTietSps.Update(obj);
            _DBcontext.SaveChanges();
            return true;
        }

        public bool deleteChiTietSP(ChiTietSp chiTietSp)
        {
            if (chiTietSp == null) return false;
            var obj = _DBcontext.ChiTietSps.FirstOrDefault(c => c.Id == chiTietSp.Id);
            _DBcontext.ChiTietSps.Remove(obj);
            _DBcontext.SaveChanges();
            return true;
        }

        public ChiTietSp TimKiem(Guid Id)
        {
            if (Id == Guid.Empty) return null;
            var obj = _DBcontext.ChiTietSps.FirstOrDefault(c => c.Id == Id);
            return obj;

        }
        public List<ChiTietSp> getChiTietSPfromDB()
        {
            _lstChiTietSP = _DBcontext.ChiTietSps.ToList();
            return _lstChiTietSP;
        }

    }
}
