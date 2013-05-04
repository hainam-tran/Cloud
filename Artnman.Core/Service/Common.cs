using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Artnman.Core.Utility.Data;

namespace Artnman.Core.Service
{
    public class Common
    {
        private static object _lock = new Object();
        private static Common _instance;

        private Common()
        {
        }

        /// <summary>
        ///   StaticContentsFactory singleton object
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

        public void Insert<T>(ObjectContext context, T entity, out OperationResult operationResult) where T : class, new()
        {
            try
            {
                using (context)
                {
                    //context.GetTable<T>().InsertOnSubmit(entity);
                    context.AddObject(typeof(T).Name, entity);
                    context.SaveChanges();
                    operationResult = new OperationResult() { Type = OperationResult.ResultType.Success };
                }
            }
            catch (Exception ex)
            {
                operationResult = new OperationResult() { Type = OperationResult.ResultType.Failure, Message = ex.StackTrace };
            }
        }

        /// <summary>
        /// Check existance
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        public bool IsExist<T>(ObjectContext context, Expression<Func<T, bool>> filter, out OperationResult operationResult) where T : class, new()
        {
            try
            {
                using (context)
                {
                    operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
                    if (filter == null)
                        return false;
                    else
                    {
                        return context.CreateObjectSet<T>().Any<T>(filter);
                    }
                }
            }
            catch (Exception ex)
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Failure, Message = ex.StackTrace };
                return false;
            }
        }

        /// <summary>
        /// Select a list of data with filter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<T> SelectList<T>(ObjectContext context, Expression<Func<T, bool>> filter, out OperationResult operationResult) where T : class, new()
        {
            try
            {
                using (context)
                {
                    operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
                    if (filter == null)
                    {
                        return context.CreateObjectSet<T>().ToList();
                    }
                    return context.CreateObjectSet<T>().Where(filter).ToList();
                }
            }
            catch (Exception ex)
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Failure, Message = ex.StackTrace };
                return null;
            }
        }

        /// <summary>
        /// Count number of data with filter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        public int Count<T>(ObjectContext context, Expression<Func<T, bool>> filter, out OperationResult operationResult) where T : class, new()
        {
            try
            {
                using (context)
                {
                    operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
                    if (filter == null)
                    {
                        return context.CreateObjectSet<T>().Count();
                    }
                    return context.CreateObjectSet<T>().Where(filter).Count();
                }
            }
            catch (Exception ex)
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Failure, Message = ex.StackTrace };
                return 0;
            }
        }

        /// <summary>
        /// Select first or default data with filter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        public T SelectFirstOrDefault<T>(ObjectContext context, Expression<Func<T, bool>> filter, out OperationResult operationResult) where T : class, new()
        {
            try
            {
                using (context)
                {
                    operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
                    if (filter == null)
                    {
                        return context.CreateObjectSet<T>().FirstOrDefault();
                    }
                    return context.CreateObjectSet<T>().Where(filter).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Failure, Message = ex.StackTrace };
                return null;
            }
        }

        /// <summary>
        /// Delete data with filter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Boolean Delete<T>(ObjectContext context, Expression<Func<T, bool>> filter, out OperationResult operationResult) where T : class, new()
        {
            try
            {
                if (filter == null)
                {
                    operationResult = new OperationResult { Type = OperationResult.ResultType.Warning };
                    return false;
                }
                using (context)
                {
                    operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
                    T entityFromDb = context.CreateObjectSet<T>().Where(filter).Single();
                    context.CreateObjectSet<T>().DeleteObject(entityFromDb);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Failure, Message = ex.StackTrace };
                return false;
            }
        }

        /// <summary>
        /// Update database with entity and filter
        /// Ex: Update(obj, ob=>ob.objId == id)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Boolean Update<T>(ObjectContext context, T entity, Expression<Func<T, bool>> filter, out OperationResult operationResult) where T : class, new()
        {
            try
            {
                if (filter == null)
                {
                    operationResult = new OperationResult { Type = OperationResult.ResultType.Warning };
                    return false;
                }
                using (context)
                {
                    operationResult = new OperationResult { Type = OperationResult.ResultType.Success };

                    T entityFromDb = context.CreateObjectSet<T>().Where(filter).Single();
                    if (entityFromDb == null)
                    {
                        throw new NullReferenceException();
                    }

                    DataUtility.CloneObject<T>(entity, ref entityFromDb);

                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Failure, Message = ex.StackTrace };
                return false;
            }
        }
    }
}
