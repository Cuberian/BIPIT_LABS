using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BIPIT08
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        WebService1 obj = new WebService1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSource = obj.GetShippings();
                GridView1.DataBind();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            foreach(GridViewRow row in GridView1.Rows)
            {
                CheckBox checkbox = (CheckBox)row.FindControl("CheckBox1");

                if (checkbox != null && checkbox.Checked)
                {
                    int shippingsId = Convert.ToInt32(row.Cells[1].Text);
                    obj.DeleteShipping(shippingsId);
                }
            }
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "" && TextBox2.Text != "")
            {
                GridView1.DataSource = obj.GetShippings(DateTime.Parse(TextBox1.Text), DateTime.Parse(TextBox2.Text));
                GridView1.DataBind();
            }
        }
    }
}