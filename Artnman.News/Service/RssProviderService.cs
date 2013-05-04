using System;
using System.Collections.Generic;
using System.Linq;
using Artnman.Bulletin.Model;
using Artnman.Core.Service;


namespace Artnman.Bulletin.Service
{
    public class RssProviderService
    {
        private static readonly object Lock = new Object();
        private static volatile RssProviderService _instance;

        /// <summary>
        /// RssProviderCategoryFactory singleton object
        /// </summary>
        public static RssProviderService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new RssProviderService();

                        }
                    }
                }

                return _instance;
            }
        }

        public void Insert(RssProvider obj, out OperationResult operationResult)
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

        public void Update(RssProvider obj, out OperationResult operationResult)
        {
            lock (Lock)
            {
                if (obj == null)
                {
                    operationResult = new OperationResult { Type = OperationResult.ResultType.Warning };
                    return;
                }
                Common.Instance.Update
                    (obj, objs => objs.RssProviderId == obj.RssProviderId && objs.LanguageId == obj.LanguageId, out operationResult);
            }
        }

        public void Delete(string languageId, Guid id, out OperationResult operationResult)
        {
            lock (Lock)
            {
                Common.Instance.Delete<RssProvider>
                    (obj => obj.RssProviderId == id && obj.LanguageId == languageId, out operationResult);
            }
        }

        public RssProvider GetById(string languageId, Guid id, out OperationResult operationResult)
        {
            return Common.Instance.SelectFirstOrDefault<RssProvider>
                (obj => obj.RssProviderId == id && obj.LanguageId == languageId, out operationResult);
        }

        public List<object> GetAll(string languageId, out OperationResult operationResult)
        {
            return Common.Instance.SelectList<RssProvider>
                (obj => obj.LanguageId == languageId, out operationResult)
                .OrderBy(obj => obj.CreateDate)
                .ToList<object>();
        }

        public List<object> GetAllOrderByName(string languageId, out OperationResult operationResult)
        {
            return Common.Instance.SelectList<RssProvider>
                (obj => obj.LanguageId == languageId, out operationResult)
                .OrderBy(obj => obj.Name)
                .ToList<object>();
        }

        public List<object> GetPaging(string languageId, int pageNumber, int pageSize, out OperationResult operationResult)
        {
            try
            {
                var entities = DBMapManager.CreateInstance();
                operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
                return (from obj in entities.RssProvider
                        where obj.LanguageId == languageId
                        select obj).OrderBy(obj => obj.CreateDate).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList<object>();
            }
            catch (Exception)
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Warning };
                return null;
            }
        }

        public List<object> GetPagingOrderByName(string languageId, int pageNumber, int pageSize, out OperationResult operationResult)
        {
            try
            {
                var entities = DBMapManager.CreateInstance();
                operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
                return (from obj in entities.RssProvider
                        where obj.LanguageId == languageId
                        select obj).OrderBy(obj => obj.Name).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList<object>();
            }
            catch (Exception)
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Warning };
                return null;
            }
        }

        public int CountAll(string languageId, out OperationResult operationResult)
        {
            try
            {
                var entities = DBMapManager.CreateInstance();
                operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
                return (from obj in entities.RssProvider
                        where obj.LanguageId == languageId
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
