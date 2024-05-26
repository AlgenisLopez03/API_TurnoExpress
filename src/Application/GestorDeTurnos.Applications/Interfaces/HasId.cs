namespace GestorDeTurnos.Application.Interfaces
{
    public interface IHasId<TKey>
    {
        TKey Id { get; set; }
    }
}