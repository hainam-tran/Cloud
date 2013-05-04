using System;
using System.Collections.Generic;
using System.Linq;
using Artnman.Commerce.Model;
using Artnman.Core.Service;


namespace Artnman.Commerce.Service
{
    public class ProductInfoService
    {
        private static readonly object Lock = new Object();
        private static volatile ProductInfoService _instance;

        /// <summary>
        /// ProductInfoCategoryFactory singleton object
        /// </summary>
        public static ProductInfoService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ProductInfoService();

                        }
                    }
                }

                return _instance;
            }
        }

        public void Insert(ProductInfo obj, out OperationResult operationResult)
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

        public void Update(ProductInfo obj, out OperationResult operationResult)
        {
            lock (Lock)
            {
                if (obj == null)
                {
                    operationResult = new OperationResult { Type = OperationResult.ResultType.Warning };
                    return;
                }
                Common.Instance.Update
                    (obj, objs => objs.ProductInfoId == obj.ProductInfoId && objs.LanguageId == obj.LanguageId, out operationResult);
            }
        }

        public void Delete(string languageId, Guid id, out OperationResult operationResult)
        {
            lock (Lock)
            {
                Common.Instance.Delete<ProductInfo>
                    (obj => obj.ProductInfoId == id && obj.LanguageId == languageId, out operationResult);
            }
        }

        public ProductInfo GetById(string languageId, Guid id, out OperationResult operationResult)
        {
            try
            {
                return Common.Instance.SelectFirstOrDefault<ProductInfo>
                    (obj => obj.ProductInfoId == id && obj.LanguageId == languageId, out operationResult);
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
                return Common.Instance.SelectList<ProductInfo>
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
                return Common.Instance.SelectList<ProductInfo>
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
                return Common.Instance.SelectList<ProductInfo>
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
                return (from obj in entities.ProductInfo
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
                return (from obj in entities.ProductInfo
                        where obj.LanguageId == languageId
                        select obj).OrderBy(obj => obj.Name).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList<object>();
            }
            catch (Exception)
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Warning };
                return null;
            }
        }

        public List<object> GetPagingOrderByNameVisible(string languageId, int pageNumber, int pageSize, out OperationResult operationResult)
        {
            try
            {
                var entities = DBMapManager.CreateInstance();
                operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
                return (from obj in entities.ProductInfo
                        where obj.LanguageId == languageId && obj.Visible == true
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
                return (from obj in entities.ProductInfo
                        where obj.LanguageId == languageId
                        select obj).OrderBy(obj => obj.Order).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList<object>();
            }
            catch (Exception)
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Warning };
                return null;
            }
        }

        public List<object> GetPagingOrderByOrderVisible(string languageId, int pageNumber, int pageSize, out OperationResult operationResult)
        {
            try
            {
                var entities = DBMapManager.CreateInstance();
                operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
                return (from obj in entities.ProductInfo
                        where obj.LanguageId == languageId && obj.Visible == true
                        select obj).OrderBy(obj => obj.Order).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList<object>();
            }
            catch (Exception)
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Warning };
                return null;
            }
        }

        public List<object> GetByProductCategoryId(string languageId, Guid productCategoryId, out OperationResult operationResult)
        {
            return Common.Instance.SelectList<ProductInfo>
                (obj => obj.LanguageId == languageId && obj.ProductCategoryId == productCategoryId, out operationResult)
                .OrderBy(obj => obj.CreateDate)
                .ToList<object>();
        }

        public List<object> GetByProductCategoryIdVisible(string languageId, Guid productCategoryId, out OperationResult operationResult)
        {
            return Common.Instance.SelectList<ProductInfo>
                (obj => obj.LanguageId == languageId && obj.ProductCategoryId == productCategoryId && obj.Visible == true, out operationResult)
                .OrderBy(obj => obj.CreateDate)
                .ToList<object>();
        }

        public List<object> GetByProductCategoryOrderByName(string languageId, Guid productCategoryId, out OperationResult operationResult)
        {
            return Common.Instance.SelectList<ProductInfo>
                (obj => obj.LanguageId == languageId && obj.ProductCategoryId == productCategoryId, out operationResult)
                .OrderBy(obj => obj.Name)
                .ToList<object>();
        }

        public List<object> GetByProductCategoryOrderByNameVisible(string languageId, Guid productCategoryId, out OperationResult operationResult)
        {
            return Common.Instance.SelectList<ProductInfo>
                (obj => obj.LanguageId == languageId && obj.ProductCategoryId == productCategoryId && obj.Visible == true, out operationResult)
                .OrderBy(obj => obj.Name)
                .ToList<object>();
        }

        public List<object> GetByProductCategoryOrderByOrder(string languageId, Guid productCategoryId, out OperationResult operationResult)
        {
            return Common.Instance.SelectList<ProductInfo>
                (obj => obj.LanguageId == languageId && obj.ProductCategoryId == productCategoryId, out operationResult)
                .OrderBy(obj => obj.Order)
                .ToList<object>();
        }

        public List<object> GetByProductCategoryOrderByOrderVisible(string languageId, Guid productCategoryId, out OperationResult operationResult)
        {
            return Common.Instance.SelectList<ProductInfo>
                (obj => obj.LanguageId == languageId && obj.ProductCategoryId == productCategoryId && obj.Visible == true, out operationResult)
                .OrderBy(obj => obj.Order)
                .ToList<object>();
        }

        public List<object> GetByProductCategoryIdPaging(string languageId, int pageNumber, int pageSize, Guid productCategoryId, out OperationResult operationResult)
        {
            return Common.Instance.SelectList<ProductInfo>
                (obj => obj.LanguageId == languageId && obj.ProductCategoryId == productCategoryId, out operationResult)
                .OrderBy(obj => obj.CreateDate)
                .Skip(pageSize * (pageNumber - 1)).Take(pageSize)
                .ToList<object>();
        }

        public List<object> GetByProductCategoryIdPagingVisible(string languageId, int pageNumber, int pageSize, Guid productCategoryId, out OperationResult operationResult)
        {
            return Common.Instance.SelectList<ProductInfo>
                (obj => obj.LanguageId == languageId && obj.ProductCategoryId == productCategoryId && obj.Visible == true, out operationResult)
                .OrderBy(obj => obj.CreateDate)
                .Skip(pageSize * (pageNumber - 1)).Take(pageSize)
                .ToList<object>();
        }

        public List<object> GetByProductCategoryIdPagingOrderByName(string languageId, int pageNumber, int pageSize, Guid productCategoryId, out OperationResult operationResult)
        {
            return Common.Instance.SelectList<ProductInfo>
                (obj => obj.LanguageId == languageId && obj.ProductCategoryId == productCategoryId, out operationResult)
                .OrderBy(obj => obj.Name)
                .Skip(pageSize * (pageNumber - 1)).Take(pageSize)
                .ToList<object>();
        }

        public List<object> GetByProductCategoryIdPagingOrderByNameVisible(string languageId, int pageNumber, int pageSize, Guid productCategoryId, out OperationResult operationResult)
        {
            return Common.Instance.SelectList<ProductInfo>
                (obj => obj.LanguageId == languageId && obj.ProductCategoryId == productCategoryId && obj.Visible == true, out operationResult)
                .OrderBy(obj => obj.Name)
                .Skip(pageSize * (pageNumber - 1)).Take(pageSize)
                .ToList<object>();
        }

        public List<object> GetByProductCategoryIdPagingOrderByOrder(string languageId, int pageNumber, int pageSize, Guid productCategoryId, out OperationResult operationResult)
        {
            return Common.Instance.SelectList<ProductInfo>
                (obj => obj.LanguageId == languageId && obj.ProductCategoryId == productCategoryId, out operationResult)
                .OrderBy(obj => obj.Order)
                .Skip(pageSize * (pageNumber - 1)).Take(pageSize)
                .ToList<object>();
        }

        public List<object> GetByProductCategoryIdPagingOrderByOrderVisible(string languageId, int pageNumber, int pageSize, Guid productCategoryId, out OperationResult operationResult)
        {
            return Common.Instance.SelectList<ProductInfo>
                (obj => obj.LanguageId == languageId && obj.ProductCategoryId == productCategoryId && obj.Visible == true, out operationResult)
                .OrderBy(obj => obj.Order)
                .Skip(pageSize * (pageNumber - 1)).Take(pageSize)
                .ToList<object>();
        }

        public List<object> GetByChildProductCategoryIdPaging(string languageId, int pageNumber, int pageSize, Guid productCategoryId, out OperationResult operationResult)
        {
            var ce = DBMapManager.CreateInstance();
            operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
            return ce.ProductInfo_GetByProductCategoryId_Child_Paging(languageId, pageSize, pageNumber,
                                                                      productCategoryId).ToList<object>();
        }

        public List<object> GetByChildProductCategoryIdPagingVisible(string languageId, int pageNumber, int pageSize, Guid productCategoryId, out OperationResult operationResult)
        {
            var ce = DBMapManager.CreateInstance();
            operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
            return ce.ProductInfo_GetByProductCategoryId_Child_Paging_Visible(languageId, pageSize, pageNumber,
                                                                      productCategoryId).ToList<object>();
        }

        public List<object> SearchByCodePaging(string languageId, int pageNumber, int pageSize, string code, out OperationResult operationResult)
        {
            return Common.Instance.SelectList<ProductInfo>
                (obj => obj.LanguageId == languageId && obj.Code.Contains("/" + code + "/"), out operationResult)
                .Skip(pageSize * (pageNumber - 1)).Take(pageSize)
                .ToList<object>();
        }

        public List<object> SearchByCodePagingVisible(string languageId, int pageNumber, int pageSize, string code, out OperationResult operationResult)
        {
            return Common.Instance.SelectList<ProductInfo>
                (obj => obj.LanguageId == languageId && obj.Visible == true && obj.Code.Contains("/" + code + "/"), out operationResult)
                .Skip(pageSize * (pageNumber - 1)).Take(pageSize)
                .ToList<object>();
        }

        public List<object> SearchByCode(string languageId, string code, out OperationResult operationResult)
        {
            return Common.Instance.SelectList<ProductInfo>
                (obj => obj.LanguageId == languageId && obj.Code.Contains(code), out operationResult)
                .ToList<object>();
        }

        public List<object> SearchByCodeVisible(string languageId, string code, out OperationResult operationResult)
        {
            return Common.Instance.SelectList<ProductInfo>
                (obj => obj.LanguageId == languageId && obj.Code.Contains(code) && obj.Visible == true, out operationResult)
                .ToList<object>();
        }

        public int CountAll(string languageId, out OperationResult operationResult)
        {
            try
            {
                var entities = DBMapManager.CreateInstance();
                operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
                return (from obj in entities.ProductInfo
                        where obj.LanguageId == languageId
                        select obj).Count();
            }
            catch (Exception ex)
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Failure, Message = ex.StackTrace };
                return 0;
            }
        }

        public int CountAllVisible(string languageId, out OperationResult operationResult)
        {
            try
            {
                var entities = DBMapManager.CreateInstance();
                operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
                return (from obj in entities.ProductInfo
                        where obj.LanguageId == languageId && obj.Visible == true
                        select obj).Count();
            }
            catch (Exception ex)
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Failure, Message = ex.StackTrace };
                return 0;
            }
        }

        public int CountAllByProductCategoryId(string languageId, Guid productCategoryId, out OperationResult operationResult)
        {
            try
            {
                var entities = DBMapManager.CreateInstance();
                operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
                return (from obj in entities.ProductInfo
                        where obj.LanguageId == languageId && obj.ProductCategoryId == productCategoryId
                        select obj).Count();
            }
            catch (Exception ex)
            {
                operationResult = new OperationResult { Type = OperationResult.ResultType.Failure, Message = ex.StackTrace };
                return 0;
            }
        }

        public int CountAllByProductCategoryIdVisible(string languageId, Guid productCategoryId, out OperationResult operationResult)
        {
            try
            {
                var entities = DBMapManager.CreateInstance();
                operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
                return (from obj in entities.ProductInfo
                        where obj.LanguageId == languageId && obj.ProductCategoryId == productCategoryId && obj.Visible == true
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
