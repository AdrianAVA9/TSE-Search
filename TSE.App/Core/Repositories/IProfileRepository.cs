using TSE.App.Core.Models;

namespace TSE.App.Core.Repositories
{
    public interface IProfileRepository
    {
        Profile GetProfile(string id);
        Profile GetProfile_Linq(string id);
    }
}
