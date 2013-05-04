using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artnman.Core.Base
{
    public interface IListTable
    {
        void BuildData();
        void DeleteSelectedRecords();
        void SetButtonState(bool hasData);
    }

    public class BasePageListTable : BasePage, IListTable
    {
        #region Implementation of IListTable

        public virtual void BuildData()
        {
            throw new NotImplementedException();
        }

        public virtual void DeleteSelectedRecords()
        {
            throw new NotImplementedException();
        }

        public virtual void SetButtonState(bool hasData)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
