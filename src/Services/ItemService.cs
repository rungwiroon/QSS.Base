using Examples.Entities;
using Qss.Base.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Services
{
    public class ItemService
    {
        private IRepository<ItemEntity> _repo;

        public ItemService(IRepository<ItemEntity> repo)
        {
            _repo = repo;
        }

        public IList<ItemEntity> Get()
        {
            return _repo.Query.ToList();
        }

        public ItemEntity Get(int id)
        {
            return _repo.Get(id);
        }

        public int Create(ItemEntity model)
        {
            return (int)_repo.Create(model);
        }

        public void Update(ItemEntity model)
        {
            _repo.Update(model);
        }
        
        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public void Delete(ItemEntity model)
        {
            _repo.Delete(model);
        }
    }
}
