namespace Qss.Base.Patterns
{
    public interface IPipeline<T, U>
        where T : IPipelineFilter<U>
    {
        void Register(T filter);

        void Execute(U input);
    }
}