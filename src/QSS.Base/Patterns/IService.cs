using Qss.Base.Models;

namespace Qss.Base.Patterns
{
    public interface IService<TModel, TSearchModel, TKey>
        where TKey : struct
    {
        TModel Get(TKey id, string username);

        GridResponseModel<TModel> Get(GridRequestModel gridModel, TSearchModel searchModel, string username);

        TModel[] Get(TSearchModel searchModel, string username);

        int Create(TModel model, string username);

        void Edit(TModel model, string username);

        void Delete(TKey id, string username);
    }
}