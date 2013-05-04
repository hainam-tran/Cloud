using System;
using System.Collections.Generic;
using Artnman.Core.Model;

namespace Artnman.Core.Service
{
    public class LanguageService
    {
        private static readonly object Lock = new Object();
        private static volatile LanguageService _instance;

        public static LanguageService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new LanguageService();

                        }
                    }
                }

                return _instance;
            }
        }

        private LanguageService() { }

        public List<object> GetAll(out OperationResult operationResult)
        {
            var list = new List<object>
                           {
                               new LanguageEntity {LanguageId = "vi-VN", Name = "Tiếng Việt"},
                               new LanguageEntity {LanguageId = "en-US", Name = "English"}
                           };
            operationResult = new OperationResult { Type = OperationResult.ResultType.Success };
            return list;

        }
    }
}
