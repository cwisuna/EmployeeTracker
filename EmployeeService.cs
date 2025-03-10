using Microsoft.EntityFrameworkCore;
using CrudAppData;

namespace EmployeeTracker
{
    public class EmployeeService
    {
        private readonly AppDbContext dbContext;

        public EmployeeService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await dbContext.Employees.Include(d => d.Department).ToListAsync();
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            dbContext.Employees.Add(employee);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            dbContext.Employees.Update(employee);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await dbContext.Employees.FindAsync(id);
            if (employee != null)
            {
                dbContext.Employees.Remove(employee);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
