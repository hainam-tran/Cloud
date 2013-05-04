using System;
using System.Collections.Generic;
using System.Linq;
using Artnman.Bulletin.Model;
using Artnman.Core.Service;

namespace Artnman.Bulletin.Service
{
    public class RssSourceService
    {
        private static readonly object Lock = new Object();
        private static volatile RssSourceService _instance;

        /// <summary>
        /// RssSourceCategoryFactory singleton object
        /// </summary>
        public static RssSourceService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new RssSourceService();

                        }
                    }
                }

                return _instance;
            }
        }

        public void Insert(RssSource obj, out OperationResult operationResult)
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

        public void Update(RssSource obj, out OperationResult operationResult)
        {
            lock (Lock)
            {
                if (obj == null)
                {
                    operationResult = new OperationResult { Type = OperationResult.ResultType.Warning };
                    return;
                }
                Common.Instance.Update
                    (obj, objs => objs.RssSourceId == obj.RssSourceId && objs.LanguageId == obj.LanguageId, out operationResult);
            }
        }

        public void Delete(string languageId, Guid id, out OperationResult operationResult)
        {
            lock (Lock)
            {
                Common.Instance.Delete<RssSource>
                    (obj => obj.RssSourceId == id && obj.LanguageId == languageId, out operationResult);
            }
        }

        public RssSource GetById(string languageId, Guid id, out OperationResult operationResult)
        {
            return Common.Instance.SelectFirstOrDefault<RssSource>
                (obj => obj.RssSourceId == id && obj.LanguageId == languageId, out operationResult);
        }

        public RssSource GetByNewsCategoryIdAndRssProviderId(string languageId, Guid newsCategoryId, Guid rssProviderId, out OperationResult operationResult)
        {
            return Common.Instance.SelectFirstOrDefault<RssSource>
                (obj => obj.RssProviderId == rssProviderId && 
                    obj.NewsCategoryId == newsCategoryId && 
                    obj.LanguageId == languageId, out operationResult);
        }

        public List<object> GetAll(string languageId, out OperationResult operationResult)
        {
            return Common.Instance.SelectList<RssSource>
                (obj => obj.LanguageId == languageId, out operationResult)
                .OrderBy(obj => obj.CreateDate)
                .ToList<object>();
        }

        public List<object> GetAllOrderByName(string languageId, out OperationResult operationResult)
        {
            return Common.Instance.SelectList<RssSource>
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
                return (from obj in entities.RssSource
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
                return (from obj in entities.RssSource
                        where obj.LanguageId == languageId
                        select obj).OrderBy(obj => obj.Name).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList<object>();
            }
            catch (Exception)
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Warning };
                return null;
            }
        }

        public List<object> GetByProviderPagingOrderByName(string languageId, Guid rssProviderId, int pageNumber, int pageSize, out OperationResult operationResult)
        {
            try
            {
                var entities = DBMapManager.CreateInstance();
                operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
                return (from obj in entities.RssSource
                        where obj.LanguageId == languageId && obj.RssProviderId == rssProviderId
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
                return (from obj in entities.RssSource
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
