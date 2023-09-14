using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Data
{
    public interface IStaffRepo
    {
        IEnumerable<Staff> GetAllStaff(); 
        Staff GetStaffByID(int id); 
        Staff AddStaff(Staff staff);
    }
}
