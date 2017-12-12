namespace Qss.Base.Models
{
    public interface IPagingModel
    {
        int Page { get; }
        int Rows { get; }

        bool IsSortAsending { get; }
    }
}