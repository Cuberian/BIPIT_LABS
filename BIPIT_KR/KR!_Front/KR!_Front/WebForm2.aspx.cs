using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KR__Front.ServiceReference1;
using System.ServiceModel;

namespace KR__Front
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        Service1Client client = new Service1Client("BasicHttpBinding_IService1");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSource = client.GetWaybilles();
                GridView1.DataBind();

                DropDownList1.DataSource = client.GetSuppliers();
                DropDownList1.DataTextField = "SupplierName";
                DropDownList1.DataValueField = "SupplierCode";
                DropDownList1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            client.InsertWaybill(Convert.ToDateTime(TextBox2.Text), Convert.ToInt32(TextBox1.Text), Convert.ToInt32(DropDownList1.SelectedValue));
            GridView1.DataSource = client.GetWaybilles();
            GridView1.DataBind();
        }
    }
}