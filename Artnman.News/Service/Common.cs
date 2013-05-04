using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Artnman.Bulletin.Model;
using Artnman.Core.Service;

namespace Artnman.Bulletin.Service
{
    public class Common
    {
        private static object _lock = new Object();
        private static Common _instance;

        private Common()
        {
        }

        /// <summary>
        ///  StaticContentsFactory singleton object
        /// </summary>
        public static Common Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Common();
                        }
                    }
                }

                return _instance;
            }
        }

        public void Insert<T>(T entity, out OperationResult operationResult) where T : class, new()
        {
            Artnman.Core.Service.Common.Instance.Insert<T>(DBMapManager.CreateInstance(), entity, out operationResult);
        }

        /// <summary>
        /// Check existance
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        public bool IsExist<T>(Expression<Func<T, bool>> filter, out OperationResult operationResult)
            where T : class, new()
        {
            return Artnman.Core.Service.Common.Instance.IsExist<T>(DBMapManager.CreateInstance(), filter,
                                                                   out operationResult);
        }

        /// <summary>
        /// Select a list of data with filter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<T> SelectList<T>(Expression<Func<T, bool>> filter, out OperationResult operationResult)
            where T : class, new()
        {
            return Artnman.Core.Service.Common.Instance.SelectList<T>(DBMapManager.CreateInstance(), filter,
                                                                      out operationResult);
        }

        /// <summary>
        /// Count number of data with filter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        public int Count<T>(Expression<Func<T, bool>> filter, out OperationResult operationResult)
            where T : class, new()
        {
            return Artnman.Core.Service.Common.Instance.Count<T>(DBMapManager.CreateInstance(), filter,
                                                                 out operationResult);
        }

        /// <summary>
        /// Select first or default data with filter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        public T SelectFirstOrDefault<T>(Expression<Func<T, bool>> filter, out OperationResult operationResult)
            where T : class, new()
        {
            return Artnman.Core.Service.Common.Instance.SelectFirstOrDefault<T>(DBMapManager.CreateInstance(), filter,
                                                                                out operationResult);
        }

        /// <summary>
        /// Delete data with filter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Boolean Delete<T>(Expression<Func<T, bool>> filter, out OperationResult operationResult)
            where T : class, new()
        {
            return Artnman.Core.Service.Common.Instance.Delete<T>(DBMapManager.CreateInstance(), filter,
                                                                  out operationResult);
        }

        /// <summary>
        /// Update database with entity and filter
        /// Ex: Update(obj, ob=>ob.objId == id)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Boolean Update<T>(T entity, Expression<Func<T, bool>> filter, out OperationResult operationResult)
            where T : class, new()
        {
            return Artnman.Core.Service.Common.Instance.Update<T>(DBMapManager.CreateInstance(), entity, filter,
                                                                  out operationResult);
        }
    }
}
