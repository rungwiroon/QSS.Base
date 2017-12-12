using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qss.Base.Patterns
{
    public abstract class IteratorBase<T>
    {
        protected IEnumerable<T> _list;
        protected T _previousLevel1, _previousLevel2;

        public IteratorBase(IEnumerable<T> list)
        {
            _list = list;
        }

        protected abstract void Setup();

        protected abstract void Iterate(T currentItem, T previousItemLevel1, T previousItempLevel2);

        protected abstract void TearDown();

        public virtual void Run()
        {
            Setup();

            foreach(var item in _list)
            {
                Iterate(item, _previousLevel1, _previousLevel2);

                _previousLevel1 = item;
                _previousLevel2 = _previousLevel1;
            }

            TearDown();
        }
    }
}
