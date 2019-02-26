using System.Linq;
using TSE.App.Core.Models;
using TSE.App.Core.Repositories;
using TSE.App.Persistance.AccessData;
using TSE.App.Persistance.EntityFactory;

namespace TSE.App.Persistance.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        private ConnectDatabase _instance { get; set; }

        public ProfileRepository()
        {
            _instance = ConnectDatabase.GetInstance();
        }

        public Profile GetProfile(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;

            Profile profile = null;

            var operation = new SqlOperation("ADRIAN_VEGA_ACEVEDO");
            operation.addParameter("IDENTIFICATION", id);

            var result = _instance.ExecuteQueryProcedure(operation);

            if(result?.Count > 0)
            {
                profile = new BuilderObjects<Profile>().Build(result[0],new Profile());
            }

            return profile;
        }

        public Profile GetProfile_Linq(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;

            var context = new TSEContext();

            var existingProfile = context.ADRIAN_VEGA_ACEVEDO(id).ToList();

            if(existingProfile?.Count > 0)
            {
                return ProfileFactory.GetProfile(existingProfile[0]);
            }
            else
            {
                return null;
            }
        }
    }
}