namespace Common;

public interface IToDoDbContext
{
    IReadOnlyCollection<Todo> Todos { get; }
    IReadOnlyCollection<Todo> TodosBig { get; }
}

public sealed class InMemoryToDoDbContext : IToDoDbContext
{
    private readonly IList<Todo> _store;
    private readonly IList<Todo> _storeBig;

    public InMemoryToDoDbContext(int seedCount = 100)
    {

        _store = [];
        _storeBig = [];

        for (int i = 1; i <= seedCount; i++)
        {
            _store.Add(new Todo(i, $"todo-{i}", i % 7 == 0 ? "note" : null, Done: i % 3 == 0));
        }

        for (int i = 1; i <= seedCount * 100; i++)
        {
            _storeBig.Add(new Todo(i, $"todo-{i}", i % 7 == 0 ? "note" : null, Done: i % 3 == 0));
        }
    }

    public IReadOnlyCollection<Todo> Todos => (IReadOnlyList<Todo>) _store;
    public IReadOnlyCollection<Todo> TodosBig => (IReadOnlyList<Todo>) _storeBig;
}
