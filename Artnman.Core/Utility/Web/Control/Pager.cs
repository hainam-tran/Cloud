using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Artnman.Core.Utility.Web.Control
{
    [ToolboxData("<{0}:Pager runat=\"server\"></{0}:Pager>")]
    public class Pager : WebControl, IPostBackEventHandler, INamingContainer
    {
        #region Save/Load Control State
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Page.RegisterRequiresControlState(this);
        }

        protected override object SaveControlState()
        {
            object[] objState = new object[3];
            objState[0] = CurrentIndex;
            objState[1] = PageSize;
            objState[2] = ItemCount;

            return objState;
        }

        protected override void LoadControlState(object state)
        {
            object[] savedState = (object[])state;
            CurrentIndex = (int)savedState[0];
            PageSize = (int)savedState[1];
            ItemCount = (double)savedState[2];
        }
        #endregion

        #region PostBack Stuff
        private static readonly object EventCommand = new object();

        public event CommandEventHandler Command
        {
            add { Events.AddHandler(EventCommand, value); }
            remove { Events.RemoveHandler(EventCommand, value); }
        }

        protected virtual void OnCommand(CommandEventArgs e)
        {
            CommandEventHandler clickHandler = (CommandEventHandler)Events[EventCommand];
            if (clickHandler != null) clickHandler(this, e);
        }

        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
        {
            OnCommand(new CommandEventArgs(this.UniqueID, Convert.ToInt32(eventArgument)));
        }
        #endregion

        #region Accessors (Behavioural)

        /// <summary>
        /// Gets or sets total number of rows.
        /// </summary>
        private double _itemCount;
        [Browsable(false)]
        public double ItemCount
        {
            get { return _itemCount; }
            set
            {
                _itemCount = value;

                double divide = ItemCount / PageSize;
                double ceiled = System.Math.Ceiling(divide);
                PageCount = Convert.ToInt32(ceiled);
            }
        }

        /// <summary>
        /// Gets or sets current page index.
        /// </summary>
        private int _currentIndex = 1;
        [Browsable(false)]
        public int CurrentIndex
        {
            get { return _currentIndex; }
            set { _currentIndex = value; }
        }

        /// <summary>
        /// Gets or sets page size (results per page).
        /// </summary>
        private int _pageSize = 15;
        [Category("Behavioural")]
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        /// <summary>
        /// Gets or sets the total number of pages.
        /// </summary>
        private int _pageCount;
        [Browsable(false)]
        private int PageCount
        {
            get { return _pageCount; }
            set { _pageCount = value; }
        }

        /// <summary>
        /// Gets or sets the value that indicates whether the rendered pager is stateful (use querystring) or not.
        /// </summary>
        private bool _stateful = false;
        [Category("Behavioural")]
        public bool Stateful
        {
            get { return _stateful; }
            set { _stateful = value; }
        }

        /// <summary>
        /// Gets or sets the querystring key used in stateful mode.
        /// </summary>
        private string _querystringKey = "p";
        [Category("Behavioural")]
        public string QuerystringKey
        {
            get { return _querystringKey; }
            set { _querystringKey = value; }
        }

        /// <summary>
        /// Gets or sets the number of rendered page numbers in standard mode.
        /// </summary>
        private int _visiblePageCount = 5;
        [Category("Behavioural")]
        public int VisiblePageBeforeAfterCurrentPage
        {
            get { return _visiblePageCount; }
            set { _visiblePageCount = value; }
        }
        #endregion

        #region Accessors (Display)

        /// <summary>
        /// Gets or sets a value that indicates whether pager control should render align 'left', 'center' or 'right'.
        /// </summary>
        private string _align = "left";
        [Category("Display")]
        public string Align
        {
            get { return _align; }
            set { _align = value; }
        }

        #endregion

        #region Render methods

        private string RenderQueryString(int index)
        {
            System.Text.RegularExpressions.Regex regEx;
            Uri theURL = System.Web.HttpContext.Current.Request.Url;
            bool hasQueryStringParam = !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.ServerVariables["QUERY_STRING"]) ? true : false;


            if (hasQueryStringParam && System.Web.HttpContext.Current.Request.QueryString[QuerystringKey] != null)
            {
                regEx = new Regex(QuerystringKey + @"\=\d*", RegexOptions.Compiled | RegexOptions.Singleline);
                return "href=\"" + regEx.Replace(theURL.ToString(), QuerystringKey + "=" + index) + "\"";
            }
            else
            {
                return "href=\"" + theURL.ToString() + (hasQueryStringParam ? "&" : "?") + QuerystringKey + "=" + index + "\"";
            }
        }

        private string RenderScriptHyperLink(int index)
        {
            return "href=\"#\" onclick=\"" + Page.ClientScript.GetPostBackClientHyperlink(this, index.ToString()) + "\"";
        }

        private string RenderFirst(int bIndex)
        {
            if (bIndex > 1)
            {
                string templateCell = "<li><a {0}>1</a></li>" + (bIndex > 2 ? "<li class=\"disabled\"><a>...</a></li>" : "");
                return String.Format(templateCell, Stateful ? RenderQueryString(1) : RenderScriptHyperLink(1));
            }

            return "";
        }

        private string RenderLast(int eIndex)
        {
            if (eIndex < PageCount)
            {
                string templateCell = (eIndex + 1 < PageCount ? "<li class=\"disabled\"><a>...</a></li>" : "") + "<li><a {0}>" + PageCount + "</a></li>";
                return String.Format(templateCell, Stateful ? RenderQueryString(PageCount) : RenderScriptHyperLink(PageCount));
            }

            return "";
        }

        private string RenderBack()
        {
            if (CurrentIndex > 1)
            {
                string templateCell = "<li><a {0}>&larr;</a></li>";
                return String.Format(templateCell, Stateful ? RenderQueryString(CurrentIndex - 1) : RenderScriptHyperLink(CurrentIndex - 1));
            }

            return "<li class=\"disabled\"><a>&larr;</a></li>";
        }

        private string RenderNext()
        {
            if (CurrentIndex < PageCount)
            {
                string templateCell = "<li><a {0}>&rarr;</a></li>";
                return String.Format(templateCell, Stateful ? RenderQueryString(CurrentIndex + 1) : RenderScriptHyperLink(CurrentIndex + 1));
            }

            return "<li class=\"disabled\"><a>&rarr;</a></li>";
        }

        private string RenderCurrent()
        {
            return "<li class=\"active\"> <a>" + CurrentIndex + "</a> </li>";
        }

        private string RenderOther(int pageNumber)
        {
            string templateCell = "<li><a {0}>" + pageNumber + "</a></li>";
            return String.Format(templateCell, Stateful ? RenderQueryString(pageNumber) : RenderScriptHyperLink(pageNumber));
        }

        #endregion

        #region Override Control's Render operation 
        protected override void Render(HtmlTextWriter output)
        {
            if (output == null || ItemCount == 0)
            {
                return;
            }

            if (Page != null)
            {
                Page.VerifyRenderingInServerForm(this);
            }

            output.WriteBeginTag("div");
            output.WriteAttribute("class", "pagination");
            output.Write(">");

            output.WriteBeginTag("ul");
            output.Write(">");

            int bIndex = CurrentIndex - VisiblePageBeforeAfterCurrentPage;
            int eIndex = CurrentIndex + VisiblePageBeforeAfterCurrentPage;

            if (eIndex > PageCount)
            {
                bIndex -= eIndex - PageCount;
                eIndex = PageCount;
            }

            if (bIndex <= 0) bIndex = 1;

            if (CurrentIndex - bIndex < VisiblePageBeforeAfterCurrentPage)
            {
                eIndex += VisiblePageBeforeAfterCurrentPage + bIndex - CurrentIndex;
                if (eIndex > PageCount) eIndex = PageCount;
            }

            output.Write(RenderBack());
            output.Write(RenderFirst(bIndex));

            for (int i = bIndex; i < CurrentIndex; i++)
            {
                output.Write(RenderOther(i));
            }

            output.Write(RenderCurrent());

            for (int i = CurrentIndex; i < eIndex; i++)
            {
                output.Write(RenderOther(i + 1));
            }

            output.Write(RenderLast(eIndex));
            output.Write(RenderNext());
            output.WriteEndTag("ul");

            output.WriteEndTag("div");
        }

        #endregion
    }
}
