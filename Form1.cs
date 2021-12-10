using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DictionaryProject
{
    public partial class Form1 : Form
    {
        Dictionary dictionary = new Dictionary(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + @"\DictionaryDataBase.mdf;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }
        private void showData(string data = null)
        {
            dataGridView1.DataSource = dictionary.search(data);
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[0].Width = dataGridView1.Width;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            showData();
        }

        private void txtEnglishWord_TextChanged(object sender, EventArgs e)
        {
            showData(txtEnglishWord.Text);
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index < dataGridView1.Rows.Count )
            {
                txtPersianWord.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewWordfrm newWord = new NewWordfrm();
            newWord.Show(this);
            showData();
        }
    }
}
