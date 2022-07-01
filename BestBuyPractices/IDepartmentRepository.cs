using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyPractices
{
    internal interface IDepartmentRepository
    {
        IEnumerable<Department> GetAllDepartments();
    }
}
