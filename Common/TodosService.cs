using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common;

public record Todo(int Id, string Title, string? Notes, bool Done);
public record TodoCreateReq(string Title, string? Notes, bool Done);

public interface ITodosService
{
    Task<Todo> GetById(int id);
    Task Create(TodoCreateReq toCreate);
    Task<IReadOnlyCollection<Todo>> GetList();
    Task<IReadOnlyCollection<Todo>> GetBigList();
    Task<long> Compute();
}

internal class TodosService : ITodosService
{
    private readonly IToDoDbContext _db;

    public TodosService(IToDoDbContext db)
    {
        _db = db;
    }

    public Task<long> Compute()
    {
        return Task.Run(() =>
        {
            var targetMs = 10_000;
            var sw = Stopwatch.StartNew();

            var buffer = new byte[8192];
            Random.Shared.NextBytes(buffer);

            using var sha = SHA256.Create();

            long hashes = 0;

            while (true)
            {
                for (int i = 0; i < 4096; i++)
                {
                    var hash = sha.ComputeHash(buffer);           
                                                                
                    Buffer.BlockCopy(hash, 0, buffer,
                        (int) ((hashes * 13) % (buffer.Length - hash.Length)),
                        hash.Length);
                    hashes++;
                }

                if (sw.ElapsedMilliseconds >= targetMs)
                {
                    break;
                }
            }

            return hashes;
        });
    }

    public Task<Todo> GetById(int id)
    {
        var todo = _db.Todos.FirstOrDefault(t => t.Id == id);
        if (todo is null)
            return Task.FromException<Todo>(new KeyNotFoundException($"Todo {id} not found."));
        return Task.FromResult(todo);
    }

    public Task Create(TodoCreateReq toCreate)
    {
        // naive ID generation for testing; for EF you'd usually let the DB assign it
        var nextId = -1;
        var entity = new Todo(nextId, toCreate.Title, toCreate.Notes, toCreate.Done);

        _db.Add(entity);
        _db.SaveChanges();
        return Task.CompletedTask;
    }

    public Task<IReadOnlyCollection<Todo>> GetList()
    {
        IReadOnlyCollection<Todo> list = _db.Todos.ToArray();
        return Task.FromResult(list);
    }

    public Task<IReadOnlyCollection<Todo>> GetBigList()
    {
        IReadOnlyCollection<Todo> list = _db.TodosBig.ToArray();
        return Task.FromResult(list);
    }
}

    