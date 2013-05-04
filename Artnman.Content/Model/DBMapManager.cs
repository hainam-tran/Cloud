using Artnman.Core.Utility.Config;

namespace Artnman.Content.Model
{
    class DBMapManager
    {
        /// <summary>
        /// Create an instance of DBMapDataContext
        /// using default connection string defined
        /// </summary>
        /// <returns></returns>
        public static ContentEntities CreateInstance()
        {
            return new ContentEntities(ConfigurationAccess.GetConnectionString("ContentEntities"));
        }
    }
}
