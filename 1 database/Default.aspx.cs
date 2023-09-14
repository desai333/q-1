using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Drawing;


public partial class _Default : System.Web.UI.Page 
{
    SqlConnection con;
    SqlCommand cmd;
    SqlDataReader dr;

    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=D:\\ASP\\Unit 3\\1 database\\App_Data\\Database.mdf;Integrated Security=True;User Instance=True");
        cmd = new SqlCommand();
    }
protected void  Button2_Click(object sender, EventArgs e)
{
   

    cmd.CommandText="insert into std values("+TextBox1.Text+",'"+ TextBox2.Text +"','"+TextBox3.Text+"',"+TextBox4.Text+")";
    cmd.CommandType=CommandType.Text;
    cmd.Connection=con;
    con.Open();
    cmd.ExecuteNonQuery();
    con.Close();
    Label5.ForeColor = Color.Green; 
    Label5.Text="Insert Sucessfully";
}
protected void Button3_Click(object sender, EventArgs e)
{
    

    cmd.CommandText = "update std set name='" + TextBox2.Text + "',city='" + TextBox3.Text + "',pin=" + TextBox4.Text + " where id="+TextBox1.Text;
    cmd.CommandType = CommandType.Text;
    cmd.Connection = con;
    con.Open();
    cmd.ExecuteNonQuery();
    con.Close();
    Label5.ForeColor = Color.Blue; 
    Label5.Text = "Update Sucessfully";
}
protected void Button4_Click(object sender, EventArgs e)
{
   

    cmd.CommandText = "delete from std where id=" + TextBox1.Text ;
    cmd.CommandType = CommandType.Text;
    cmd.Connection = con;
    con.Open();
    cmd.ExecuteNonQuery();
    con.Close();
    Label5.ForeColor = Color.Red; 
    Label5.Text = "Record Deleted Sucessfully";
}
protected void Button6_Click(object sender, EventArgs e)
{
    TextBox1.Text = " ";
    TextBox2.Text = " ";
    TextBox3.Text = " ";
    TextBox4.Text = " ";
}
protected void Button5_Click(object sender, EventArgs e)
{
    cmd.CommandText="select * from std where id="+TextBox1.Text;
    cmd.CommandType = CommandType.Text;
    cmd.Connection = con;
    con.Open();
    dr=cmd.ExecuteReader();

    if (dr.HasRows)
    {
        dr.Read();
        TextBox1.Text = dr["id"].ToString();
        TextBox2.Text = dr["name"].ToString();
        TextBox3.Text = dr["city"].ToString();
        TextBox4.Text = dr["pin"].ToString();

        Label5.ForeColor = Color.Green;
        Label5.Text = "Record Found";
    }
    else
    {
        TextBox1.Text = " ";
        TextBox2.Text = " ";
        TextBox3.Text = " ";
        TextBox4.Text = " ";
        Label5.ForeColor = Color.Red;
        Label5.Text = "Record Not Found";
    }
    con.Close();
}
}
