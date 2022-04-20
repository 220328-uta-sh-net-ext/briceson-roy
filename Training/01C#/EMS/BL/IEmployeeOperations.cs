using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;

namespace BL
{
    internal interface IEmployeeOperations
    {
        void Add(DL.Employee employee);

        void Delete(DL.Employee employee);  

    }
}
