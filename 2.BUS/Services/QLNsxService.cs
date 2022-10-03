using _1.DAL.Context;
using _1.DAL.DomainClass;
using _1.DAL.IRepositories;
using _1.DAL.Repositories;
using _2.BUS.IServices;
using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.Services
{
    public class QLNsxService : INsxService
    {
        private INsx _iNsxRepository;
       

        public QLNsxService()
        {   
            _iNsxRepository = new NsxRepos();
            GetAll();

        }
        public string addNsx(NsxView obj)
        {
            if (obj == null) return "Không tồn tại";
            var Nsx = obj.Nsx;
            if (_iNsxRepository.addNsx(Nsx)) return "Thêm thành công";
            return "Thêm không thành công";
        }

        public string deleteNsx(NsxView obj)
        {
            if (obj == null) return "Không tồn tại";
            var Nsx = obj.Nsx;
            if (_iNsxRepository.deleteNsx(Nsx)) return "Xóa thành công";
            return "Xóa không thành công";
        }

        public List<NsxView> GetAll()
        {
            List<NsxView> list = new List<NsxView>();
             list = (from a in _iNsxRepository.getNsxFromDB()
                     select new NsxView()
                     {Nsx = a}).ToList();
             return list;
           
            
        }

        public string updateNsx(NsxView obj)
        {
            if (obj == null) return "Không tồn tại";
            var Nsx = obj.Nsx;
            if (_iNsxRepository.updateNsx(Nsx)) return "Sưa thành công";
            return "Sửa không thành công";
        }
    }
}
