using Dapper;
using JissaAsyncDFDemo.Data;
using JissaAsyncDFDemo.Models;

namespace JissaAsyncDFDemo.Repositories
{
    public class StudentRepository:IStudentRepository
    {
        private readonly ApplicationDbContext context;
        public StudentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<int> AddStudent(Student stud)
        {
            int result = 0;
            var query = "insert into Student1 values(@name,@percentage,@city)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", stud.Name);
            parameters.Add("@percentage", stud.percentage);
            parameters.Add("@city", stud.City);
            using (var connection = context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, parameters);
            }
            return result;
        }

        public async Task<int> DeleteStudent(int id)
        {
            int result = 0;
            var query = "delete from Student1 where rollno=@id";

            using (var connection = context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, new { id });
            }
            return result;
        }

        public async Task<Student> GetStudentById(int id)
        {
            var qry = "select * from Student1 where rollno=@id";
            using (var connection = context.CreateConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<Student>(qry, new { id });
                return result;
            }
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            var qry = "select * from Student1";
            using (var connection = context.CreateConnection())
            {
                var result = await connection.QueryAsync<Student>(qry);
                return result.ToList();
            }
        }

        public async Task<int> UpdateStudent(Student stud)
        {
            int result = 0;
            var query = "update student1 set name=@name,percentage=@percentage,city=@city where rollno=@rollno";
            var parameters = new DynamicParameters();
            parameters.Add("@name", stud.Name);
            parameters.Add("@percentage", stud.percentage);
            parameters.Add("@city", stud.City);
            parameters.Add("@rollno", stud.rollNo);
            using (var connection = context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, parameters);
            }
            return result;
        }
    }
}
