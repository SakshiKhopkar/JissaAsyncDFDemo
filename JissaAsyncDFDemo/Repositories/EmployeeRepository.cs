using Dapper;
using JissaAsyncDFDemo.Data;
using JissaAsyncDFDemo.Models;

namespace JissaAsyncDFDemo.Repositories
{
    public class EmployeeRepository : IEmployeRepository
    {
        private readonly ApplicationDbContext context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<int> AddEmploye(Employe emp)
        {
            int result = 0;
            var query = "insert into Employe values(@ename,@email,@age,@salary)";
            var parameters = new DynamicParameters();
            parameters.Add("@ename", emp.Ename);
            parameters.Add("@email", emp.Email);
            parameters.Add("@age", emp.Age);
            parameters.Add("@salary", emp.Salary);
            using (var connection = context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, parameters);
            }
            return result;
        }

        public async Task<int> DeleteEmploye(int id)
        {
            int result = 0;
            var query = "delete from Employe where id=@id";

            using (var connection = context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, new { id });
            }
            return result;
        }

        public async Task<Employe> GetEmployeById(int id)
        {
            var qry = "select * from Employe where id=@id";
            using (var connection = context.CreateConnection())
            {
                var result = await connection.QueryFirstOrDefaultAsync<Employe>(qry, new { id });
                return result;
            }
        }

        public async Task<IEnumerable<Employe>> GetEmployes()
        {
            var qry = "select * from Employe";
            using (var connection = context.CreateConnection())
            {
                var result = await connection.QueryAsync<Employe>(qry);
                return result.ToList();
            }
        }

        public async Task<int> UpdateEmploye(Employe emp)
        {
            int result = 0;
            var query = "update Employe set ename=@ename,email=@email,age=@age,salary=@salary";
            var parameters = new DynamicParameters();
            parameters.Add("@ename", emp.Ename);
            parameters.Add("@email", emp.Email);
            parameters.Add("@age", emp.Age);
            parameters.Add("@salary", emp.Salary);
            using (var connection = context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, parameters);
            }
            return result;
        }
    }
}
