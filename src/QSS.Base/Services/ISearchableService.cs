using Qss.Base.Models;

namespace Qss.Base.Services
{
    public interface ISearchableService<TModel, TSearchModel>
    {
        GridResponseModel<TModel> Get(GridRequestModel gridModel, string username, TSearchModel searchModel);
    }
}