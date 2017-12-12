using Qss.Base.Models;

namespace Qss.Base.Services
{
    public interface IGridService<TModel, TSearchModel>
    {
        GridResponseModel<TModel> Get(GridRequestModel gridModel, TSearchModel searchModel, string username);
    }
}