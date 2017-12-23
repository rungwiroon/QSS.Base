namespace Qss.Base.Models
{
    public interface IEntity
    {

    }

    public interface IEntityKey<T> : IEntity
        where T : struct
    {
        T Id { get; set; }
    }

    public interface IIntegerEntityKey : IEntityKey<int>
    {
    }
}