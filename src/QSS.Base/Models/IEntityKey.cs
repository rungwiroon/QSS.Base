namespace Qss.Base.Models
{
    public interface IEntityKey<T>
        where T : struct
    {
        T Id { get; set; }
    }

    public interface IIntegerEntityKey : IEntityKey<int>
    {
    }
}