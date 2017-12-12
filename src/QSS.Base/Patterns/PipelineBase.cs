using System.Collections.Generic;

namespace Qss.Base.Patterns
{
    public abstract class PipelineBase<T, U> : IPipeline<T, U>
        where T : IPipelineFilter<U>
    {
        private List<T> _filters = new List<T>();

        public virtual void Execute(U input)
        {
            foreach (var filter in _filters)
            {
                filter.Execute(input);
            }
        }

        public void Register(T filter)
        {
            _filters.Add(filter);
        }
    }
}