namespace Qss.Base.Patterns
{
    public interface IPipelineFilter<T>
    {
        void Execute(T message);
    }
}