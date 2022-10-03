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
    public class SanPhamRepos :ISanPham
    {
        private FpolyDBContext _DBContext;
        private List<SanPham> _lstSanPham;

        public SanPhamRepos()
        {
            _DBContext = new FpolyDBContext();
            _lstSanPham = new List<SanPham>();
            getSanPhamFromDB();
        }

        public bool addSanPham(SanPham sanPham)
        {
            _DBContext.SanPhams.Add(sanPham);
            _DBContext.SaveChanges();
            return true;
        }

        public bool updateSanPham(SanPham sanPham)
        {
            if (sanPham == null) return false;
            var obj = _DBContext.SanPhams.FirstOrDefault(c => c.Id == sanPham.Id);
            obj.Ma = sanPham.Ma;
            obj.Ten = sanPham.Ten;
            _DBContext.SanPhams.Update(obj);
            _DBContext.SaveChanges();
            return true;
        }

        public bool deleteSanPham(SanPham sanPham)
        {
            if (sanPham == null) return false;
            var obj = _DBContext.SanPhams.FirstOrDefault(c => c.Id == sanPham.Id);
            _DBContext.SanPhams.Remove(obj);
            _DBContext.SaveChanges();
            return true;
        }

        public SanPham getById(Guid id)
        {
            if (id == Guid.Empty) return null;
            return _DBContext.SanPhams.FirstOrDefault(c => c.Id == id);
        }

        public List<SanPham> getSanPhamFromDB()
        {
            _lstSanPham = _DBContext.SanPhams.ToList();
            return _lstSanPham;
        }

        
    }
}
