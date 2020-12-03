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
    public partial class WebForm1 : System.Web.UI.Page
    {
        Service1Client client = new Service1Client("BasicHttpBinding_IService1");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSource = client.GetSuppliers();
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            client.InsertSupplier(TextBox1.Text);
            GridView1.DataSource = client.GetSuppliers();
            GridView1.DataBind();
        }
    }
}