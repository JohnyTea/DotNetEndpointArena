using System.Collections.Concurrent;

namespace Common;

public interface IToDoDbContext
{
    IQueryable<Todo> Todos { get; }
    IQueryable<Todo> TodosBig { get; }

    void Add(Todo todo);
    int SaveChanges();
}

public sealed class InMemoryToDoDbContext : IToDoDbContext
{
    private readonly ConcurrentDictionary<int, Todo> _store = new();
    private readonly ConcurrentDictionary<int, Todo> _storeBig = new();

    public InMemoryToDoDbContext(int seedCount = 100)
    {
        for (int i = 1; i <= seedCount; i++)
        {
            _store[i] = new Todo(i, $"todo-{i}", i % 7 == 0 ? "note" : null, Done: i % 3 == 0);
        }

        for (int i = 1; i <= seedCount * 1_000; i++)
        {
            _storeBig[i] = new Todo(i, $"todo-{i}", i % 7 == 0 ? "note" : null, Done: i % 3 == 0);
        }
    }

    public IQueryable<Todo> Todos => _store.Values.AsQueryable();
    public IQueryable<Todo> TodosBig => _storeBig.Values.AsQueryable();

    public void Add(Todo todo) => _store[todo.Id] = todo;

    public int SaveChanges() => 1;
}
