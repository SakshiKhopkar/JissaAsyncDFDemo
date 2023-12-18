using JissaAsyncDFDemo.Models;
using JissaAsyncDFDemo.Repositories;

namespace JissaAsyncDFDemo.Services
{
    public class EmployeService : IEmployeService
    {
        private readonly IEmployeRepository repo;
        public EmployeService(IEmployeRepository repo)
        {
            this.repo = repo;
        }

        public async Task<int> AddEmploye(Employe emp)
        {
            return await repo.AddEmploye(emp);
        }

        public async Task<int> DeleteEmploye(int id)
        {
            return await repo.DeleteEmploye(id);
        }

        public async Task<Employe> GetEmployeById(int id)
        {
            return await repo.GetEmployeById(id);
        }

        public async Task<IEnumerable<Employe>> GetEmployes()
        {
           return await repo.GetEmployes();
        }

        public async Task<int> UpdateEmploye(Employe emp)
        {
            return await repo.UpdateEmploye(emp);
        }
    }
}
