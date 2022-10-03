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
    public class CuaHangRepos : ICuaHang
    {
        private FpolyDBContext _DBContext;
        private List<CuaHang> _lstCuaHang;
        
        public CuaHangRepos()
        {
            _DBContext = new FpolyDBContext();
            _lstCuaHang = new List<CuaHang>();
            getCuaHangFromDB();
        }

        public bool addCuaHang(CuaHang cuaHang)
        {
            if (cuaHang == null) return false;
            cuaHang.Id = Guid.NewGuid();
            _DBContext.CuaHangs.Add(cuaHang);
            _DBContext.SaveChanges();
            return true;
        }

        public bool deleteCuaHang(CuaHang cuaHang)
        {
            if (cuaHang == null) return false;
            var obj = _DBContext.CuaHangs.FirstOrDefault(c => c.Id == cuaHang.Id);
            _DBContext.CuaHangs.Remove(obj);
            _DBContext.SaveChanges();
            return true;
        }

        public bool updateCuaHang(CuaHang cuaHang) 
        {
            if (cuaHang == null) return false;  
            var obj = _DBContext.CuaHangs.FirstOrDefault(c => c.Id == cuaHang.Id);
            obj.Ten = cuaHang.Ten;
            obj.Ma = cuaHang.Ma;
            obj.DiaChi = cuaHang.DiaChi;
            obj.ThanhPho = cuaHang.ThanhPho;
            obj.QuocGia = cuaHang.QuocGia;
            _DBContext.CuaHangs.Update(obj);
            _DBContext.SaveChanges();
            return true;
        }

        public CuaHang getById(Guid id)
        {
            if (id == Guid.Empty) return null;
            return _DBContext.CuaHangs.FirstOrDefault(c => c.Id == id);
        }

        public List<CuaHang> getCuaHangFromDB()
        {
            _lstCuaHang = _DBContext.CuaHangs.ToList();
            return _lstCuaHang;
        }
    }
}
