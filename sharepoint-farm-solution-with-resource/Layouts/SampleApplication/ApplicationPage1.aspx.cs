using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karamem0.SampleApplication
{

    public partial class ApplicationPage1 : LayoutsPageBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DataBind();
        }

    }

}
