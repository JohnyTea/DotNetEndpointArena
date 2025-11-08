using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common;

public record Todo(int Id, string Title, string? Notes, bool Done);
public record TodoCreateReq(string Title, string? Notes, bool Done);

public interface ITodosService
{
    Todo GetById(int id);
    void Create(TodoCreateReq toCreate);
    IReadOnlyCollection<Todo> GetList();
    IReadOnlyCollection<Todo> GetBigList();
    long Compute();
}

internal class TodosService : ITodosService
{
    private readonly IToDoDbContext _db;

    public TodosService(IToDoDbContext db)
    {
        _db = db;
    }

    public long Compute()
    {
        const long N = 5_000_000_000;
        long sum = 0;
        for (long i = 1; i <= N; i++)
        {
            sum += i;
        }
        return sum;
    }
    public Todo GetById(int id)
    {
        return _db.Todos.FirstOrDefault(t => t.Id == id)
           ?? throw new KeyNotFoundException($"Todo {id} not found.");
    }

    public void Create(TodoCreateReq toCreate)
    {
        // naive ID generation for testing; for EF you'd usually let the DB assign it
        var nextId = -1;
        var entity = new Todo(nextId, toCreate.Title, toCreate.Notes, toCreate.Done);

        _db.Add(entity);
        _db.SaveChanges();
    }

    public IReadOnlyCollection<Todo> GetList()
    {
        return [.. _db.Todos];
    }

    public IReadOnlyCollection<Todo> GetBigList()
    {
        return _db.TodosBig.ToArray();
    }
}
