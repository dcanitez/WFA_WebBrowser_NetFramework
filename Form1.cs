using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_WebBrowser_NetFramework
{
    public partial class Form1 : Form
    {
        List<string> urlList = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            NavigateToBrowser();
        }

        private void NavigateToBrowser()
        {
            string url = txtURL.Text.Trim();

            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Please Write a proper URL to Go!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (url.StartsWith("https://") == false)
            {
                url = "https://" + url;
                txtURL.Text = url;
            }

            wbBrowser.Navigate(url);

            if (!urlList.Contains(url))
            {
                urlList.Add(url);
            }

            FillComboBox();
            
        }

        private void FillComboBox()
        {
            cmbUrlList.DataSource = null;
            cmbUrlList.DataSource = urlList;
            cmbUrlList.SelectedIndex = -1;
            cmbUrlList.Text = "Search History..";
        }

        private void txtURL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                NavigateToBrowser();
            }
        }
    }
}
