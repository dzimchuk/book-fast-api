using System.Threading.Tasks;

namespace BookFast.Contracts.Framework
{
    public interface ICommand<in TModel>
    {
        Task ApplyAsync(TModel model);
    }
}