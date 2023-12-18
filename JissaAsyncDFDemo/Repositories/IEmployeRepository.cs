using JissaAsyncDFDemo.Models;

namespace JissaAsyncDFDemo.Repositories
{
    public interface IEmployeRepository
    {
        Task<IEnumerable<Employe>> GetEmployes();
        Task<Employe> GetEmployeById(int id);
        Task<int> AddEmploye(Employe emp);
        Task<int> UpdateEmploye(Employe emp);
        Task<int> DeleteEmploye(int id);
    }
}
