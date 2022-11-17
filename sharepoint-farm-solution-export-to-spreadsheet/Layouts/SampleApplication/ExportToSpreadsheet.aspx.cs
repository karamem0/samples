//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using ClosedXML.Excel;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Karamem0.SampleApplication
{

    public partial class ExportToSpreadsheet : LayoutsPageBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            var web = SPContext.Current.Web;
            var listId = this.Request.QueryString["ListId"];
            var list = web.Lists[new Guid(listId)];
            using (var workbook = new XLWorkbook())
            using (var stream = new MemoryStream())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");
                for (var index = 0; index < list.Items.Count; index++)
                {
                    var item = list.Items[index];
                    worksheet.Cell(index + 1, 1).SetValue((int)item["ID"]);
                    worksheet.Cell(index + 1, 2).SetValue((string)item["Title"]);
                    worksheet.Cell(index + 1, 3).SetHtmlValue((string)item["Body"]);
                }
                workbook.SaveAs(stream);
                this.Response.Clear();
                this.Response.AppendHeader("Content-Type", "application/vnd.ms-excel");
                this.Response.AppendHeader("Content-Disposition", "attachment; filename=text.xlsx");
                this.Response.BinaryWrite(stream.ToArray());
                this.Response.End();
            }
        }

    }

}
