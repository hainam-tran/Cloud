using System;
using System.Collections.Generic;
using System.Linq;
using Artnman.Bulletin.Model;
using Artnman.Core.Service;

namespace Artnman.Bulletin.Service
{
    public class NewsCategoryService
    {
        private static readonly object Lock = new Object();
        private static volatile NewsCategoryService _instance;

        /// <summary>
        /// NewsCategoryCategoryFactory singleton object
        /// </summary>
        public static NewsCategoryService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new NewsCategoryService();

                        }
                    }
                }

                return _instance;
            }
        }

        public void Insert(NewsCategory obj, out OperationResult operationResult)
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

        public void Update(NewsCategory obj, out OperationResult operationResult)
        {
            lock (Lock)
            {
                if (obj == null)
                {
                    operationResult = new OperationResult { Type = OperationResult.ResultType.Warning };
                    return;
                }
                Common.Instance.Update
                    (obj, objs => objs.NewsCategoryId == obj.NewsCategoryId && objs.LanguageId == obj.LanguageId, out operationResult);
            }
        }

        public void Delete(string languageId, Guid id, out OperationResult operationResult)
        {
            lock (Lock)
            {
                Common.Instance.Delete<NewsCategory>
                    (obj => obj.NewsCategoryId == id && obj.LanguageId == languageId, out operationResult);
            }
        }

        public NewsCategory GetById(string languageId, Guid id, out OperationResult operationResult)
        {
            return Common.Instance.SelectFirstOrDefault<NewsCategory>
                (obj => obj.NewsCategoryId == id && obj.LanguageId == languageId, out operationResult);
        }

        public List<object> GetAll(string languageId, out OperationResult operationResult)
        {
            return Common.Instance.SelectList<NewsCategory>
                (obj => obj.LanguageId == languageId, out operationResult)
                .OrderBy(obj => obj.CreateDate)
                .ToList<object>();
        }

        public List<object> GetAllOrderByName(string languageId, out OperationResult operationResult)
        {
            return Common.Instance.SelectList<NewsCategory>
                (obj => obj.LanguageId == languageId, out operationResult)
                .OrderBy(obj => obj.Name)
                .ToList<object>();
        }

        public List<object> GetAllOrderByOrder(string languageId, out OperationResult operationResult)
        {
            return Common.Instance.SelectList<NewsCategory>
                (obj => obj.LanguageId == languageId, out operationResult)
                .OrderBy(obj => obj.Order)
                .ToList<object>();
        }

        public List<object> GetAllRootOrderByName(string languageId, out OperationResult operationResult)
        {
            return Common.Instance.SelectList<NewsCategory>
                (obj => obj.LanguageId == languageId && (obj.ParrentId == Guid.Empty || !obj.ParrentId.HasValue)
                    , out operationResult)
                .OrderBy(obj => obj.Name)
                .ToList<object>();
        }

        public List<object> GetAllRootOrderByOrder(string languageId, out OperationResult operationResult)
        {
            return Common.Instance.SelectList<NewsCategory>
                (obj => obj.LanguageId == languageId && (obj.ParrentId == Guid.Empty || !obj.ParrentId.HasValue)
                    , out operationResult)
                .OrderBy(obj => obj.Order)
                .ToList<object>();
        }

        public List<object> GetAllRootOrderByOrderVisible(string languageId, out OperationResult operationResult)
        {
            return Common.Instance.SelectList<NewsCategory>
                (obj => obj.LanguageId == languageId && (obj.ParrentId == Guid.Empty || !obj.ParrentId.HasValue) && obj.Visible == true
                    , out operationResult)
                .OrderBy(obj => obj.Order)
                .ToList<object>();
        }

        public List<object> GetPaging(string languageId, int pageNumber, int pageSize, out OperationResult operationResult)
        {
            try
            {
                var entities = DBMapManager.CreateInstance();
                operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
                return (from obj in entities.NewsCategory
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
                return (from obj in entities.NewsCategory
                        where obj.LanguageId == languageId
                        select obj).OrderBy(obj => obj.Name).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList<object>();
            }
            catch (Exception)
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Warning };
                return null;
            }
        }

        public List<object> GetByParrentId(string languageId, Guid parentId, out OperationResult operationResult)
        {
            return Common.Instance.SelectList<NewsCategory>
                (obj => obj.LanguageId == languageId && obj.ParrentId == parentId, out operationResult)
                .OrderBy(obj => obj.CreateDate)
                .ToList<object>();
        }

        public List<object> GetByParrentIdOrderByOrder(string languageId, Guid parentId, out OperationResult operationResult)
        {
            return Common.Instance.SelectList<NewsCategory>
                (obj => obj.LanguageId == languageId && obj.ParrentId == parentId, out operationResult)
                .OrderBy(obj => obj.Order)
                .ToList<object>();
        }

        public List<object> GetByParentIdPagingOrderByName(string languageId, int pageNumber, int pageSize, Guid parentId, out OperationResult operationResult)
        {
            try
            {
                var entities = DBMapManager.CreateInstance();
                operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
                return (from obj in entities.NewsCategory
                        where obj.LanguageId == languageId && obj.ParrentId == parentId
                        select obj).OrderBy(obj => obj.Name).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList<object>();
            }
            catch (Exception)
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Warning };
                return null;
            }
        }

        public List<object> GetByParentIdPagingOrderByOrder(string languageId, int pageNumber, int pageSize, Guid parentId, out OperationResult operationResult)
        {
            try
            {
                var entities = DBMapManager.CreateInstance();
                operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
                return (from obj in entities.NewsCategory
                        where obj.LanguageId == languageId && obj.ParrentId == parentId
                        select obj).OrderBy(obj => obj.Order).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList<object>();
            }
            catch (Exception)
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Warning };
                return null;
            }
        }

        public List<object> GetRootPaging(string languageId, int pageNumber, int pageSize, out OperationResult operationResult)
        {
            try
            {
                var entities = DBMapManager.CreateInstance();
                operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
                return (from obj in entities.NewsCategory
                        where obj.LanguageId == languageId && (obj.ParrentId == Guid.Empty || !obj.ParrentId.HasValue)
                        select obj).OrderBy(obj => obj.CreateDate).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList<object>();
            }
            catch (Exception)
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Warning };
                return null;
            }
        }

        public List<object> GetRootPagingOrderByName(string languageId, int pageNumber, int pageSize, out OperationResult operationResult)
        {
            try
            {
                var entities = DBMapManager.CreateInstance();
                operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
                return (from obj in entities.NewsCategory
                        where obj.LanguageId == languageId && (obj.ParrentId == Guid.Empty || !obj.ParrentId.HasValue)
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
                return (from obj in entities.NewsCategory
                        where obj.LanguageId == languageId
                        select obj).Count();
            }
            catch (Exception ex)
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Failure, Message = ex.StackTrace };
                return 0;
            }
        }

        public int CountByRoot(string languageId, out OperationResult operationResult)
        {
            try
            {
                var entities = DBMapManager.CreateInstance();
                operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
                return (from obj in entities.NewsCategory
                        where obj.LanguageId == languageId && (obj.ParrentId == Guid.Empty || !obj.ParrentId.HasValue)
                        select obj).Count();
            }
            catch (Exception ex)
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Failure, Message = ex.StackTrace };
                return 0;
            }
        }

        public int CountByParentId(string languageId, Guid parentId, out OperationResult operationResult)
        {
            try
            {
                var entities = DBMapManager.CreateInstance();
                operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
                return (from obj in entities.NewsCategory
                        where obj.LanguageId == languageId && obj.ParrentId == parentId
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
