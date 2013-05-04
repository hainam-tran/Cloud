using System;
using System.Collections.Generic;
using System.Linq;
using Artnman.Content.Model;
using Artnman.Core.Service;

namespace Artnman.Content.Service
{
    class EmailReceiverService
    {
        private static readonly object Lock = new Object();
        private static volatile EmailReceiverService _instance;

        /// <summary>
        /// NewsCategoryFactory singleton object
        /// </summary>
        public static EmailReceiverService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new EmailReceiverService();

                        }
                    }
                }

                return _instance;
            }
        }

        public void Insert(EmailReceiver obj, out OperationResult operationResult)
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

        public void Update(EmailReceiver obj, out OperationResult operationResult)
        {
            lock (Lock)
            {
                if (obj == null)
                {
                    operationResult = new OperationResult { Type = OperationResult.ResultType.Warning };
                    return;
                }
                Common.Instance.Update
                    (obj, objs => objs.EmailReceiverId == obj.EmailReceiverId, out operationResult);
            }
        }

        public void Delete(Guid id, out OperationResult operationResult)
        {
            lock (Lock)
            {
                Common.Instance.Delete<EmailReceiver>
                    (obj => obj.EmailReceiverId == id, out operationResult);
            }
        }

        public EmailReceiver GetById(Guid id, out OperationResult operationResult)
        {
            return Common.Instance.SelectFirstOrDefault<EmailReceiver>
                (obj => obj.EmailReceiverId == id, out operationResult);
        }

        public List<object> GetAll(out OperationResult operationResult)
        {
            return Common.Instance.SelectList<EmailReceiver>
                (null, out operationResult)
                .ToList<object>();
        }

        public List<object> GetPaging(int pageNumber, int pageSize, out OperationResult operationResult)
        {
            try
            {
                var entities = DBMapManager.CreateInstance();
                operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
                return (from obj in entities.EmailReceiver
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
                return (from obj in entities.EmailReceiver
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
                return (from obj in entities.EmailReceiver
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
