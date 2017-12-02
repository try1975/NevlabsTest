namespace Try1975.Nevlabs.Entities
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}