using Microsoft.EntityFrameworkCore;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Project.Data
{
    public class StaffRepo : IStaffRepo
    {
        private readonly StaffDbContext _dbContext;
        public StaffRepo(StaffDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Staff AddStaff(Staff staff)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Staff> GetAllStaff()
        {
            IEnumerable<Staff> staff = _dbContext.Staff.ToList<Staff>(); 
            return staff;
        }

        public Staff GetStaffByID(int id)
        {
            Staff staff = _dbContext.Staff.FirstOrDefault(e => e.ID == id);
            return staff;
        }

    }
}
