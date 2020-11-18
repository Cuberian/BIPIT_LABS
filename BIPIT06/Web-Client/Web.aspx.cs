using System;
using System.ServiceModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Client
{
    public partial class Web : System.Web.UI.Page
    {
        ServiceReference.ServiceClient service = new ServiceReference.ServiceClient("BasicHttpBinding_IService");
        
        static Uri address = new Uri("http://localhost:8733/");
        BasicHttpBinding binding = new BasicHttpBinding();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    service.GetStatus(binding.Name, address.Port.ToString(), address.LocalPath, address.ToString(), address.Scheme);

                    GridView1.DataSource = service.GetData();
                    GridView1.DataBind();

                    DropDownList1.DataSource = service.GetClients();
                    DropDownList1.DataTextField = "Value";
                    DropDownList1.DataValueField = "Key";
                    DropDownList1.DataBind();

                    DropDownList2.DataSource = service.GetServices();
                    DropDownList2.DataTextField = "Value";
                    DropDownList2.DataValueField = "Key";
                    DropDownList2.DataBind();
                }
            }
            catch 
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Host closed!')", true);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                service.NewRec(Convert.ToInt32(DropDownList1.SelectedValue), Convert.ToInt32(DropDownList2.SelectedValue), Convert.ToDateTime(Calendar1.SelectedDate));
                GridView1.DataSource = service.GetData();
                GridView1.DataBind();
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Host closed!')", true);
            }
        }
    }
}