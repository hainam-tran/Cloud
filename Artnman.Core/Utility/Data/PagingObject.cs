using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artnman.Core.Utility.Data
{
    public class PagingObject
    {
        private int _pageNumber = 1;
        private int _pageSize = 1;

        public int PageNumber
        {
            get { return _pageNumber; }
            set { _pageNumber = value; }
        }

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public PagingObject()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        public PagingObject(int pageNumber, int pageSize)
        {
            _pageNumber = pageNumber;
            _pageSize = pageSize;
        }
    }
}
