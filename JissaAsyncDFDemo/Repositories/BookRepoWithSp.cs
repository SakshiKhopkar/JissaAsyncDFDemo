using Dapper;
using JissaAsyncDFDemo.Data;
using JissaAsyncDFDemo.Models;
using System.Data;//change1
namespace JissaAsyncDFDemo.Repositories
{
    public class BookRepoWithSp:IBookRepository
    {
        private readonly ApplicationDbContext context;

        public BookRepoWithSp(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> AddBook(Book book)
        {
            int result = 0;
            //change2--> remove query
            var parameters = new DynamicParameters();
            //change3 --> parameters match with stored procedure parameters
            parameters.Add("@name", book.Name);
            parameters.Add("@author", book.Author);
            parameters.Add("@price", book.Price);
            using (var connection = context.CreateConnection())
            {
                result = await connection.ExecuteAsync("SP_book_InsertBook", parameters,commandType:CommandType.StoredProcedure);
            }
            return result;
        }

        public async Task<int> DeleteBook(int id)
        {
            int result = 0;
            using (var connection = context.CreateConnection())
            {
                result = await connection.ExecuteAsync("SP_book_DeleteBook", new { id },commandType:CommandType.StoredProcedure);
            }
            return result;
        }

        public async Task<Book> GetBookById(int id)
        {
            using (var connection = context.CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<Book>("SP_book_GetBookById", new { id },commandType:CommandType.StoredProcedure);
                return result;
            }

        }
        public async Task<IEnumerable<Book>> GetBooks()
        {
           
            using (var connection = context.CreateConnection())
            {
                var result = await connection.QueryAsync<Book>("SP_book_GetBooks",commandType:CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<int> UpdateBook(Book book)
        {
            int result = 0;
            var parameters = new DynamicParameters();
            parameters.Add("@name", book.Name);
            parameters.Add("@author", book.Author);
            parameters.Add("@price", book.Price);
            parameters.Add("@id", book.Id);
            using (var connection = context.CreateConnection())
            {
                result = await connection.ExecuteAsync("SP_book_UpdateBook", parameters, commandType:CommandType.StoredProcedure);
            }
            return result;
        }
    }
}
