using System.Linq.Expressions;
using MyTable_API.Models;

namespace MyTable_API.Repository;

public interface IBookRepository
{
    Task<List<Book>> GetAllAsync(Expression<Func<Book, bool>>? filter = null);
    Task<Book> GetAsync(Expression<Func<Book, bool>>? filter = null, bool tracked = true);
    Task CreateAsync(Book entity);
    Task UpdateAsync(Book entity);
    Task DeleteAsync(Book entity);
    Task SaveAsync();
}