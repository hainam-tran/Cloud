using System;
using System.Collections.Generic;
using System.Linq;
using Artnman.Content.Model;
using Artnman.Core.Service;

namespace Artnman.Content.Service
{
    class RegistrationService
    {
        private static readonly object Lock = new Object();
        private static volatile RegistrationService _instance;

        /// <summary>
        /// NewsCategoryFactory singleton object
        /// </summary>
        public static RegistrationService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new RegistrationService();

                        }
                    }
                }

                return _instance;
            }
        }

        public void Insert(Registration obj, out OperationResult operationResult)
        {
            lock (Lock)
            {
                if (obj == null)
                {
                    operationResult = new OperationResult { Type = OperationResult.ResultType.Warning };
                }
                else
                {
                    Common.Instance.Insert(obj, out operationResult);
                }
            }
        }

        public void Update(Registration obj, out OperationResult operationResult)
        {
            lock (Lock)
            {
                if (obj == null)
                {
                    operationResult = new OperationResult { Type = OperationResult.ResultType.Warning };
                    return;
                }
                Common.Instance.Update
                    (obj, objs => objs.RegistrationId == obj.RegistrationId, out operationResult);
            }
        }

        public void Delete(Guid id, out OperationResult operationResult)
        {
            lock (Lock)
            {
                Common.Instance.Delete<Registration>
                    (obj => obj.RegistrationId == id, out operationResult);
            }
        }

        public Registration GetById(Guid id, out OperationResult operationResult)
        {
            return Common.Instance.SelectFirstOrDefault<Registration>
                (obj => obj.RegistrationId == id, out operationResult);
        }

        public List<object> GetAll(out OperationResult operationResult)
        {
            return Common.Instance.SelectList<Registration>
                (null, out operationResult)
                .ToList<object>();
        }

        public List<object> GetPaging(int pageNumber, int pageSize, out OperationResult operationResult)
        {
            try
            {
                var entities = DBMapManager.CreateInstance();
                operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
                return (from obj in entities.Registration
                        select obj).OrderBy(obj => obj.CreateDate).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList<object>();
            }
            catch (Exception)
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Warning };
                return null;
            }
        }

        public List<object> GetPagingOrderByName(int pageNumber, int pageSize, out OperationResult operationResult)
        {
            try
            {
                var entities = DBMapManager.CreateInstance();
                operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
                return (from obj in entities.Registration
                        select obj).OrderBy(obj => obj.CreateDate).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList<object>();
            }
            catch (Exception)
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Warning };
                return null;
            }
        }

        public int CountAll(out OperationResult operationResult)
        {
            try
            {
                var entities = DBMapManager.CreateInstance();
                operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
                return (from obj in entities.Registration
                        select obj).Count();
            }
            catch (Exception ex)
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Failure, Message = ex.StackTrace };
                return 0;
            }
        }
    }
}
