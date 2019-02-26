using TSE.App.Core.Repositories;

namespace TSE.App.Core
{
    public interface IUnitOfWork
    {
        IProfileRepository Profiles { get; set; }
    }
}
