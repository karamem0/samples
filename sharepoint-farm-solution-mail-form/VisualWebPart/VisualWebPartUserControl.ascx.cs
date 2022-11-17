using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Karamem0.SampleApplication
{

    public partial class VisualWebPartUserControl : UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            this.ToPeopleEditor.Validate();
            if (this.Page.IsValid == false)
            {
                return;
            }
            var entity = this.ToPeopleEditor.ResolvedEntities.Cast<PickerEntity>().Single();
            var to = (string)entity.EntityData["Email"];
            if (to == null)
            {
                return;
            }
            var from = SPContext.Current.Web.CurrentUser.Email;
            var msg = new MailMessage(
                from,
                to,
                this.SubjectTextBox.Text,
                this.BodyTextBox.Text);
            var client = new SmtpClient();
            client.Host = "localhost";
            client.Send(msg);
        }

    }

}
