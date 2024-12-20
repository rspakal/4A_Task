using LibraryDAL.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace LibraryDAL.Services
{
    public class BookRepository : IBookRepository
    {
        private readonly string _connectionString;
        public BookRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task Add(Book book)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("AddBook", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Title", book.Title);
                command.Parameters.AddWithValue("@Author", book.Author);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("DeleteBook", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<Book> Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("GetBookById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.Read())
                    {
                        return new Book
                        {
                            Id = (int)reader["Id"],
                            Title = (string)reader["Title"],
                            Author = (string)reader["Author"]
                        };
                    }
                }

                throw new NullReferenceException($"No book wuth Id {id}");
            }
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            var books = new List<Book>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("[dbo].[GetAllBooks]", connection);
                command.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var book = new Book
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            Author = reader.GetString(reader.GetOrdinal("Author"))
                        };
                        books.Add(book);
                    }
                }
            }
            return books;
        }

        public async Task Update(Book book)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("UpdateBook", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", book.Id);
                command.Parameters.AddWithValue("@Title", book.Title);
                command.Parameters.AddWithValue("@Author", book.Author);
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
