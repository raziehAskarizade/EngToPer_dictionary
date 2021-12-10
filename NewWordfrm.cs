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
    public partial class NewWordfrm : Form
    {
        Dictionary dictionary = new Dictionary(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + @"\DictionaryDataBase.mdf;Integrated Security=True");
        public NewWordfrm()
        {
            InitializeComponent();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            dictionary.newItem(txtEnglish.Text, txtPersian.Text);
            txtEnglish.Focus();
            this.Close();
        }
    }
}
