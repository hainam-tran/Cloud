using System;
using System.Collections.Generic;
using System.Linq;
using Artnman.Content.Model;
using Artnman.Core.Service;

namespace Artnman.Content.Service
{
    public class StaticContentService
    {
        private static readonly object Lock = new Object();
        private static volatile StaticContentService _instance;

        /// <summary>
        /// NewsCategoryFactory singleton object
        /// </summary>
        public static StaticContentService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new StaticContentService();

                        }
                    }
                }

                return _instance;
            }
        }

        public void Insert(StaticContent obj, out OperationResult operationResult)
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

        public void Update(StaticContent obj, out OperationResult operationResult)
        {
            lock (Lock)
            {
                if (obj == null)
                {
                    operationResult = new OperationResult { Type = OperationResult.ResultType.Warning };
                    return;
                }
                Common.Instance.Update
                    (obj, objs => objs.StaticContentId == obj.StaticContentId && objs.LanguageId == obj.LanguageId, out operationResult);
            }
        }

        public void Delete(string languageId, Guid id, out OperationResult operationResult)
        {
            lock (Lock)
            {
                Common.Instance.Delete<StaticContent>
                    (obj => obj.StaticContentId == id && obj.LanguageId == languageId, out operationResult);
            }
        }

        public StaticContent GetById(string languageId, Guid id, out OperationResult operationResult)
        {
            try
            {
                return Common.Instance.SelectFirstOrDefault<StaticContent>
                    (obj => obj.StaticContentId == id && obj.LanguageId == languageId, out operationResult);
            }
            catch (Exception ex)
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Warning, Message = ex.Message + ex.StackTrace };
                return null;
            }
        }

        public List<object> GetAll(string languageId, out OperationResult operationResult)
        {
            try
            {
                return Common.Instance.SelectList<StaticContent>
                    (obj => obj.LanguageId == languageId, out operationResult)
                    .ToList<object>();
            }
            catch (Exception ex)
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Warning, Message = ex.Message + ex.StackTrace };
                return null;
            }
        }

        public List<object> GetAllOrderByName(string languageId, out OperationResult operationResult)
        {
            try
            {
                return Common.Instance.SelectList<StaticContent>
                    (obj => obj.LanguageId == languageId, out operationResult)
                    .OrderBy(obj => obj.Name)
                    .ToList<object>();
            }
            catch (Exception ex)
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Warning, Message = ex.Message + ex.StackTrace };
                return null;
            }
        }

        public List<object> GetAllOrderByOrder(string languageId, out OperationResult operationResult)
        {
            try
            {
                return Common.Instance.SelectList<StaticContent>
                    (obj => obj.LanguageId == languageId, out operationResult)
                    .OrderBy(obj => obj.Order)
                    .ToList<object>();
            }
            catch (Exception ex)
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Warning, Message = ex.Message + ex.StackTrace };
                return null;
            }
        }

        public List<object> GetPaging(string languageId, int pageNumber, int pageSize, out OperationResult operationResult)
        {
            try
            {
                var entities = DBMapManager.CreateInstance();
                operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
                return (from obj in entities.StaticContent
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
                return (from obj in entities.StaticContent
                        where obj.LanguageId == languageId
                        select obj).OrderBy(obj => obj.Name).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList<object>();
            }
            catch (Exception)
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Warning };
                return null;
            }
        }

        public List<object> GetPagingOrderByOrder(string languageId, int pageNumber, int pageSize, out OperationResult operationResult)
        {
            try
            {
                var entities = DBMapManager.CreateInstance();
                operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
                return (from obj in entities.StaticContent
                        where obj.LanguageId == languageId
                        select obj).OrderBy(obj => obj.Order).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList<object>();
            }
            catch (Exception)
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Warning };
                return null;
            }
        }

        public List<object> GetByStaticContentTypeId(string languageId, Guid staticContentTypeId, out OperationResult operationResult)
        {
            try
            {
                return Common.Instance.SelectList<StaticContent>
                    (obj => obj.LanguageId == languageId && obj.StaticContentTypeId == staticContentTypeId, out operationResult)
                    .OrderBy(obj => obj.CreateDate)
                    .ToList<object>();
            }
            catch (Exception)
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Warning };
                return null;
            }
        }

        public List<object> GetByStaticContentTypeIdVisible(string languageId, Guid staticContentTypeId, out OperationResult operationResult)
        {
            try
            {
                return Common.Instance.SelectList<StaticContent>
                    (obj => obj.LanguageId == languageId && obj.StaticContentTypeId == staticContentTypeId && obj.Visible == true, out operationResult)
                    .OrderBy(obj => obj.CreateDate)
                    .ToList<object>();
            }
            catch (Exception)
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Warning };
                return null;
            }
        }

        public List<object> GetByStaticContentTypeIdOrderByOrder(string languageId, Guid staticContentTypeId, out OperationResult operationResult)
        {
            try
            {
                return Common.Instance.SelectList<StaticContent>
                    (obj => obj.LanguageId == languageId && obj.StaticContentTypeId == staticContentTypeId, out operationResult)
                    .OrderBy(obj => obj.Order)
                    .ToList<object>();
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
                return (from sc in entities.StaticContent
                        where sc.LanguageId == languageId
                        select sc).Count();
            }
            catch (Exception ex)
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Failure, Message = ex.StackTrace };
                return 0;
            }
        }
    }
}
