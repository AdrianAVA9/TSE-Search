using System;
using System.Globalization;
using TSE.App.Core.Models;

namespace TSE.App.Persistance.EntityFactory
{
    public class ProfileFactory
    {
        public static Profile GetProfile(ADRIAN_VEGA_ACEVEDO_Result entity)
        {
            Profile profile = new Profile();

            return new Profile
            {
                Name = entity.NAME,
                Lastname = entity.LASTNAME,
                Birthdate = (DateTime)entity.BIRTHDATE
            };
        }
    }
}