using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIPIT08
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        WebService1 obj = new WebService1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList1.DataSource = obj.getClients();
                DropDownList1.DataTextField = "ClientFullname";
                DropDownList1.DataValueField = "ClientId";
                DropDownList1.DataBind();

                DropDownList2.DataSource = obj.getServices();
                DropDownList2.DataTextField = "ServiceTitle";
                DropDownList2.DataValueField = "ServiceId";
                DropDownList2.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            obj.AddShipping(int.Parse(DropDownList1.SelectedValue), int.Parse(DropDownList2.SelectedValue), DateTime.Parse(TextBox1.Text));
            Page.Response.Redirect("WebForm3.aspx", true);
        }
    }
}