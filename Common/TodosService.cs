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
        const int iterations = 50_000;

        long sum = 0;
        for (int i = 0; i < iterations; i++)
        {
            sum += i;
        }

        return Task.FromResult(sum);
    }

    public Task<Todo> GetById(int id)
    {
        var todo = _db.Todos.FirstOrDefault(t => t.Id == id);
        if (todo is null)
        {
            throw new KeyNotFoundException($"Todo {id} not found.");
        }

        return Task.FromResult(todo);
    }

    public Task Create(TodoCreateReq toCreate)
    {
        return Task.CompletedTask;
    }

    public Task<IReadOnlyCollection<Todo>> GetList()
    {
        return Task.FromResult(_db.Todos);
    }

    public Task<IReadOnlyCollection<Todo>> GetBigList()
    {
        return Task.FromResult(_db.TodosBig);
    }
}

    