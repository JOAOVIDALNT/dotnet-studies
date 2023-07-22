using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MyTable_API.Data;
using MyTable_API.Models;

namespace MyTable_API.Repository;

public class BookRepository : IBookRepository
{
    private readonly Context _db;
    internal DbSet<Book> dbSet;

    public BookRepository(Context db)
    {
        _db = db;
        dbSet = db.Set<Book>();
    }

    public async Task<List<Book>> GetAllAsync(Expression<Func<Book, bool>>? filter = null)
    {
        IQueryable<Book> query = dbSet;
        if (filter != null)
        {
            query = query.Where(filter);
        }

        return await query.ToListAsync();
    }

    public async Task<Book> GetAsync(Expression<Func<Book, bool>>? filter = null, bool tracked = true)
    {
        IQueryable<Book> query = dbSet;

        if (!tracked)
        {
            query = query.AsNoTracking();
        }

        if (filter != null)
        {
            query = query.Where(filter);
        }

        return await query.FirstOrDefaultAsync();
    }

    public async Task CreateAsync(Book entity)
    {
        entity.CreatedAt = DateTime.Now;
        await dbSet.AddAsync(entity);
        await SaveAsync();
    }

    public async Task UpdateAsync(Book entity)
    {
        dbSet.Update(entity);
        await SaveAsync();
    }

    public async Task DeleteAsync(Book entity)
    {
        dbSet.Remove(entity);
        await SaveAsync();

    }

    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }

}