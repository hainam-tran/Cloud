using Artnman.Core.Utility.Config;

namespace Artnman.Bulletin.Model
{
    class DBMapManager
    {
        /// <summary>
        /// Create an instance of DBMapDataContext
        /// using default connection string defined
        /// </summary>
        /// <returns></returns>
        public static NewsEntities CreateInstance()
        {
            return new NewsEntities(ConfigurationAccess.GetConnectionString("NewsEntities"));

        }
    }
}
