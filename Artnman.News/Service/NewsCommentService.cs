using System;
using System.Collections.Generic;
using System.Linq;
using Artnman.Bulletin.Model;
using Artnman.Core.Service;

namespace Artnman.Bulletin.Service
{
    public class NewsCommentService
    {
        private static readonly object Lock = new Object();
        private static volatile NewsCommentService _instance;

        /// <summary>
        /// NewsCommentCategoryFactory singleton object
        /// </summary>
        public static NewsCommentService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new NewsCommentService();

                        }
                    }
                }

                return _instance;
            }
        }

        public void Insert(NewsComment obj, out OperationResult operationResult)
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

        public void Update(NewsComment obj, out OperationResult operationResult)
        {
            lock (Lock)
            {
                if (obj == null)
                {
                    operationResult = new OperationResult { Type = OperationResult.ResultType.Warning };
                    return;
                }
                Common.Instance.Update
                    (obj, objs => objs.NewsCommentId == obj.NewsCommentId && objs.LanguageId == obj.LanguageId, out operationResult);
            }
        }

        public void Delete(string languageId, Guid id, out OperationResult operationResult)
        {
            lock (Lock)
            {
                Common.Instance.Delete<NewsComment>
                    (obj => obj.NewsCommentId == id && obj.LanguageId == languageId, out operationResult);
            }
        }

        public NewsComment GetById(string languageId, Guid id, out OperationResult operationResult)
        {
            return Common.Instance.SelectFirstOrDefault<NewsComment>
                (obj => obj.NewsCommentId == id && obj.LanguageId == languageId, out operationResult);
        }

        public List<object> GetAll(string languageId, out OperationResult operationResult)
        {
            return Common.Instance.SelectList<NewsComment>
                (obj => obj.LanguageId == languageId, out operationResult)
                .ToList<object>();
        }

        public List<object> GetPaging(string languageId, int pageNumber, int pageSize, out OperationResult operationResult)
        {
            try
            {
                var entities = DBMapManager.CreateInstance();
                operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
                return (from obj in entities.NewsComment
                        where obj.LanguageId == languageId
                        select obj).OrderBy(obj => obj.CreateDate).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList<object>();
            }
            catch (Exception)
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Warning };
                return null;
            }
        }

        public List<object> GetPagingOrderByFullname(string languageId, int pageNumber, int pageSize, out OperationResult operationResult)
        {
            try
            {
                var entities = DBMapManager.CreateInstance();
                operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
                return (from obj in entities.NewsComment
                        where obj.LanguageId == languageId
                        select obj).OrderBy(obj => obj.Fullname).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList<object>();
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
                return (from obj in entities.NewsComment
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
