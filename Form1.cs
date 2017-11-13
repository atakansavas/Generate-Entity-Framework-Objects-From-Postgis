using Npgsql;
using System;
using System.Windows.Forms;

namespace CreateRows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            var table = textBox1.Text;

            richTextBox1.AppendText(Environment.NewLine + " [Table(\"" + table + "\")]");
            richTextBox1.AppendText(Environment.NewLine + "  public class TabloAdi : BaseModel  {");

            var cString = "#";
            using (var conn = new NpgsqlConnection(cString))
            using (var cmd = new NpgsqlCommand())
            {
                conn.Open();
                cmd.Connection = conn;

                cmd.CommandText = "SELECT * FROM information_schema.columns where table_name = '" + table + "'";
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        var tx = "public ";
                        var clName = reader["column_name"].ToString();
                        if (clName.Contains("geom"))
                            continue;

                        if (clName.Contains("created") || clName.Contains("modified") || clName.Contains("created_by")
                            || clName.Contains("modified_by") || clName.Contains("gid"))
                            continue;

                        var udtName = reader["udt_name"].ToString();

                        if (udtName.Contains("int"))
                        {
                            tx += "int ";
                        }
                        else if (udtName.Contains("numeric"))
                        {
                            tx += "decimal ";
                        }
                        else if (udtName.Contains("varchar") || udtName.Contains("text"))
                        {
                            tx += "string ";
                        }
                        else if (udtName.Contains("timestamp"))
                        {
                            tx += "DateTime ";
                        }
                        else if (udtName.Contains("bool") || udtName.Contains("bit"))
                        {
                            tx += "bool ";
                        }

                        tx += clName + " { get; set; }";
                        richTextBox1.AppendText(Environment.NewLine + tx);
                    }
            }
            richTextBox1.AppendText(Environment.NewLine + " } ");
        }
    }
}