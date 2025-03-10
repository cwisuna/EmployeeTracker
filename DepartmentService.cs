using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudAppData;

namespace EmployeeTracker
{
    public class DepartmentService
    {
        private readonly AppDbContext dbContext;

        public DepartmentService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Department>> GetDepartmentsAsync()
        {
            return await dbContext.Departments.ToListAsync();
        }

        public async Task AddDepartmentAsync(Department department)
        {
            dbContext.Departments.Add(department);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateDepartmentAsync(Department department)
        {
            dbContext.Departments.Update(department);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var department = await dbContext.Departments.FindAsync(id);
            if (department != null)
            {
                dbContext.Departments.Remove(department);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
