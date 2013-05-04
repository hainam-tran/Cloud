using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Artnman.Core.Global;
using Artnman.Core.Service;
using Artnman.Core.Utility.Web;

namespace Artnman.Core.Base
{
    public class BasePageBackEnd : System.Web.UI.Page
    {
        public static OperationResult operationResult;

        public void ShowAlert(AlertType type, string header, string message)
        {
            ShowAlert(type, message);

            HtmlGenericControl h4AlertHeading = (HtmlGenericControl)(this.Master).FindControl("h4AlertHeading");
            h4AlertHeading.InnerText = header;
            h4AlertHeading.Visible = true;
        }

        public void ShowAlert(AlertType type, string message)
        {
            HtmlGenericControl h4AlertHeading = (HtmlGenericControl)(this.Master).FindControl("h4AlertHeading");
            Label lblErrorMessage = (Label)(this.Master).FindControl("lblErrorMessage");
            Panel pnlAlert = (Panel)(this.Master).FindControl("pnlAlert");

            h4AlertHeading.Visible = false;
            lblErrorMessage.Text = message;
            switch (type)
            {
                case AlertType.Error:
                    pnlAlert.CssClass = BootstrapStyleConstant.AlertError;
                    break;
                case AlertType.Information:
                    pnlAlert.CssClass = BootstrapStyleConstant.AlertInfo;
                    break;
                case AlertType.Success:
                    pnlAlert.CssClass = BootstrapStyleConstant.AlertSuccess;
                    break;
                default:
                    pnlAlert.CssClass = BootstrapStyleConstant.AlertWarning;
                    break;
            }

            pnlAlert.Visible = true;
        }

        /// <summary>
        /// For the simplicity of the development process, just use a simple function and 
        /// error display method.
        /// Config a special message type for Success case in the Page. (ADD/EDIT/DELETE ...)
        /// </summary>
        /// <param name="opResult"></param>
        /// <returns></returns>
        /// TODO: For method with special error return, use the switch case structure instead
        public bool ValidateOperation(OperationResult opResult)
        {
            switch (opResult.Type)
            {
                case OperationResult.ResultType.Success:
                    return true;
                case OperationResult.ResultType.Failure:
                    ShowAlert(AlertType.Error, MessageConstant.Error, MessageConstant.InternalError + "<br />" + opResult.Message);
                    return false;
                default:
                    ShowAlert(AlertType.Error, MessageConstant.Error, MessageConstant.InvalidCredential + "<br />" + opResult.Message);
                    return false;
            }
        }
    }
}
