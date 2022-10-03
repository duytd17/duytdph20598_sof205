using _2.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.IServices
{
    public interface INsxService
    {
        string addNsx(NsxView obj);
        string updateNsx(NsxView obj);
        string deleteNsx(NsxView obj);
        List<NsxView> GetAll();
    }
}
