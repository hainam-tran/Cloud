using System;
using System.Collections.Generic;
using System.Linq;
using Artnman.Bulletin.Model;
using Artnman.Core.Service;

namespace Artnman.Bulletin.Service
{
    public class NewsService
    {
        private static readonly object Lock = new Object();
        private static volatile NewsService _instance;

        /// <summary>
        /// NewsCategoryFactory singleton object
        /// </summary>
        public static NewsService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new NewsService();

                        }
                    }
                }

                return _instance;
            }
        }

        public void Insert(News obj, out OperationResult operationResult)
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

        public void Update(News obj, out OperationResult operationResult)
        {
            lock (Lock)
            {
                if (obj == null)
                {
                    operationResult = new OperationResult { Type = OperationResult.ResultType.Warning };
                    return;
                }
                Common.Instance.Update
                    (obj, objs => objs.NewsId == obj.NewsId && objs.LanguageId == obj.LanguageId, out operationResult);
            }
        }

        public void Delete(string languageId, Guid id, out OperationResult operationResult)
        {
            lock (Lock)
            {
                Common.Instance.Delete<News>
                    (obj => obj.NewsId == id && obj.LanguageId == languageId, out operationResult);
            }
        }

        public News GetById(string languageId, Guid id, out OperationResult operationResult)
        {
            try
            {
                return Common.Instance.SelectFirstOrDefault<News>
                    (obj => obj.NewsId == id && obj.LanguageId == languageId, out operationResult);
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
                return Common.Instance.SelectList<News>
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
                return Common.Instance.SelectList<News>
                    (obj => obj.LanguageId == languageId, out operationResult)
                    .OrderBy(obj => obj.Title)
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
                return Common.Instance.SelectList<News>
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
                return (from obj in entities.News
                        where obj.LanguageId == languageId
                        select obj).OrderByDescending(obj => obj.CreateDate).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList<object>();
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
                return (from obj in entities.News
                        where obj.LanguageId == languageId
                        select obj).OrderBy(obj => obj.Title).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList<object>();
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
                return (from obj in entities.News
                        where obj.LanguageId == languageId
                        select obj).OrderBy(obj => obj.Order).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList<object>();
            }
            catch (Exception)
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Warning };
                return null;
            }
        }

        public List<object> GetByNewsCategoryId(string languageId, Guid NewsCategoryId, out OperationResult operationResult)
        {
            return Common.Instance.SelectList<News>
                (obj => obj.LanguageId == languageId && obj.NewsCategoryId == NewsCategoryId, out operationResult)
                .OrderBy(obj => obj.CreateDate)
                .ToList<object>();
        }

        public List<object> GetByProductCategoryOrderByName(string languageId, Guid NewsCategoryId, out OperationResult operationResult)
        {
            return Common.Instance.SelectList<News>
                (obj => obj.LanguageId == languageId && obj.NewsCategoryId == NewsCategoryId, out operationResult)
                .OrderBy(obj => obj.Title)
                .ToList<object>();
        }

        public List<object> GetByProductCategoryOrderByOrder(string languageId, Guid NewsCategoryId, out OperationResult operationResult)
        {
            return Common.Instance.SelectList<News>
                (obj => obj.LanguageId == languageId && obj.NewsCategoryId == NewsCategoryId, out operationResult)
                .OrderBy(obj => obj.Order)
                .ToList<object>();
        }

        public List<object> GetByNewsCategoryIdPaging(string languageId, int pageNumber, int pageSize, Guid NewsCategoryId, out OperationResult operationResult)
        {
            return Common.Instance.SelectList<News>
                (obj => obj.LanguageId == languageId && obj.NewsCategoryId == NewsCategoryId, out operationResult)
                .OrderByDescending(obj => obj.CreateDate)
                .Skip(pageSize * (pageNumber - 1)).Take(pageSize)
                .ToList<object>();
        }

        public List<object> GetByNewsCategoryIdPagingVisible(string languageId, int pageNumber, int pageSize, Guid NewsCategoryId, out OperationResult operationResult)
        {
            return Common.Instance.SelectList<News>
                (obj => obj.LanguageId == languageId && obj.NewsCategoryId == NewsCategoryId && obj.Visible == true, out operationResult)
                .OrderByDescending(obj => obj.CreateDate)
                .Skip(pageSize * (pageNumber - 1)).Take(pageSize)
                .ToList<object>();
        }

        public List<object> GetByNewsCategoryIdPagingOrderByName(string languageId, int pageNumber, int pageSize, Guid NewsCategoryId, out OperationResult operationResult)
        {
            return Common.Instance.SelectList<News>
                (obj => obj.LanguageId == languageId && obj.NewsCategoryId == NewsCategoryId, out operationResult)
                .OrderBy(obj => obj.Title)
                .Skip(pageSize * (pageNumber - 1)).Take(pageSize)
                .ToList<object>();
        }

        public List<object> GetByNewsCategoryIdPagingOrderByOrder(string languageId, int pageNumber, int pageSize, Guid NewsCategoryId, out OperationResult operationResult)
        {
            return Common.Instance.SelectList<News>
                (obj => obj.LanguageId == languageId && obj.NewsCategoryId == NewsCategoryId, out operationResult)
                .OrderBy(obj => obj.Order)
                .Skip(pageSize * (pageNumber - 1)).Take(pageSize)
                .ToList<object>();
        }

        public int CountAll(string languageId, out OperationResult operationResult)
        {
            try
            {
                var entities = DBMapManager.CreateInstance();
                operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
                return (from obj in entities.News
                        where obj.LanguageId == languageId
                        select obj).Count();
            }
            catch (Exception ex)
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Failure, Message = ex.StackTrace };
                return 0;
            }
        }

        public int CountAllByNewsCategoryId(string languageId, Guid NewsCategoryId, out OperationResult operationResult)
        {
            try
            {
                var entities = DBMapManager.CreateInstance();
                operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
                return (from obj in entities.News
                        where obj.LanguageId == languageId && obj.NewsCategoryId == NewsCategoryId
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
