namespace Qss.Base.Services
{
    public interface ICrudService<TModel>
    {
        int Create(TModel model, string username);

        void Edit(TModel model);

        void Delete<T>(T id)
            where T : struct;
    }
}