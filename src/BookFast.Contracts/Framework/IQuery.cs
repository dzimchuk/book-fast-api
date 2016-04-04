using System.Threading.Tasks;

namespace BookFast.Contracts.Framework
{
    public interface IQuery<in TModel, TResult>
    {
        Task<TResult> ExecuteAsync(TModel model);
    }
}