using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace F74121246_practice_8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'f74121246_dbDataSet.Items' 資料表。您可以視需要進行移動或移除。
            this.itemsTableAdapter.Fill(this.f74121246_dbDataSet.Items);
            // TODO: 這行程式碼會將資料載入 'f74121246_dbDataSet.Customers' 資料表。您可以視需要進行移動或移除。
            this.customersTableAdapter.Fill(this.f74121246_dbDataSet.Customers);
            // TODO: 這行程式碼會將資料載入 'f74121246_dbDataSet.TransactionHistory' 資料表。您可以視需要進行移動或移除。
            this.transactionHistoryTableAdapter.Fill(this.f74121246_dbDataSet.TransactionHistory);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
