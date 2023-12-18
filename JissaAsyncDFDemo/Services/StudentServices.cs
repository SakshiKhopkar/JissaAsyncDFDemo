using JissaAsyncDFDemo.Models;
using JissaAsyncDFDemo.Repositories;

namespace JissaAsyncDFDemo.Services
{
    public class StudentServices:IStudentServices
    {
        private readonly IStudentRepository repo;
        public StudentServices(IStudentRepository repo)
        {
            this.repo = repo;
        }

        public async Task<int> AddStudent(Student stud)
        {
           return await repo.AddStudent(stud);
        }

        public async Task<int> DeleteStudent(int id)
        {
            return await repo.DeleteStudent(id);
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await repo.GetStudentById(id);
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await repo.GetStudents();
        }

        public async Task<int> UpdateStudent(Student stud)
        {
             return await repo.UpdateStudent(stud);
        }
    }
}
