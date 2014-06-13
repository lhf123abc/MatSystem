using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.BLL
{
    public class _XJbll
    {
        Maticsoft.DAL._XJdal dal = new DAL._XJdal();
        public bool Add_xjmodel(Model._XJmodel model)
        {
            if (dal.Add(model) > 0)
            {
                return true;
            }
            else
                return false;
        }
    }
}
