using TSE.App.Core;
using TSE.App.Core.Repositories;
using TSE.App.Persistance.Repository;

namespace TSE.App.Persistance
{
    public class UnitOfWork:IUnitOfWork
    {
        public IProfileRepository Profiles { get; set; }

        public UnitOfWork()
        {
            Profiles = new ProfileRepository();
        }
    }
}