using Artnman.Core.Utility.Config;

namespace Artnman.Commerce.Model
{
    class DBMapManager
    {
        /// <summary>
        /// Create an instance of DBMapDataContext
        /// using default connection string defined
        /// </summary>
        /// <returns></returns>
        public static CommerceEntities CreateInstance()
        {
            return new CommerceEntities(ConfigurationAccess.GetConnectionString("CommerceEntities"));
        }
    }
}
