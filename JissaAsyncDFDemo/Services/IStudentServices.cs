using JissaAsyncDFDemo.Models;

namespace JissaAsyncDFDemo.Services
{
    public interface IStudentServices
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudentById(int id);
        Task<int> AddStudent(Student stud);
        Task<int> UpdateStudent(Student stud);
        Task<int> DeleteStudent(int id);
    }
}
