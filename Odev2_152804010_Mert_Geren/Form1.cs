using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odev2_152804010_Mert_Geren
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int oyunAlanBoyutu = 0;
        public int count = 0;
        DateTime baslangicZamani = new DateTime();

        private void btnBasla_Click(object sender, EventArgs e)
        {

            count = 0;

            if (radioButon5.Checked)
            {
                oyunAlanBoyutu = 5;
            }
            else if (radioButon6.Checked)
            {
                oyunAlanBoyutu = 6;
            }  
            else if (radioButon7.Checked)
            {
                oyunAlanBoyutu = 7;
            }   
            else if (radioButon8.Checked)
            {
                oyunAlanBoyutu = 8;
            }     
            else if (radioButon9.Checked)
            {
                oyunAlanBoyutu = 9;
            }    
            else
            {
                MessageBox.Show("Oyun Alanının Boyutunu Belirlemediniz !");
            } 

            dataGridViewOyunAlani.Enabled = true;
            dataGridViewOyunAlani.Rows.Clear();
            dataGridViewOyunAlani.Columns.Clear();
            dataGridViewOyunAlani.Size = new Size(oyunAlanBoyutu * 50, oyunAlanBoyutu * 50);

            for (int i = 0; i < oyunAlanBoyutu; i++)
            {
                dataGridViewOyunAlani.Columns.Add(null, null);
                DataGridViewColumn Column = dataGridViewOyunAlani.Columns[i];
                Column.Width = 40;
            }
            for (int j = 0; j < oyunAlanBoyutu - 1; j++)
            {
                dataGridViewOyunAlani.Rows.Add(null, null);
                DataGridViewRow Row = dataGridViewOyunAlani.Rows[j];
                Row.Height = 40;
            }
        }

        private void dataGridViewOyunAlani_Click(object sender, EventArgs e)
        {

            int SelectedRow = dataGridViewOyunAlani.CurrentCell.RowIndex;
            int SelectedColumn = dataGridViewOyunAlani.CurrentCell.ColumnIndex;

            if (dataGridViewOyunAlani.Rows[SelectedRow].Cells[SelectedColumn].Style.BackColor == Color.LightBlue || count == 0)
            {
                if (count == 0)
                {
                    baslangicZamani = DateTime.Now;
                }
                    
                lblZaman.Text = (DateTime.Now - baslangicZamani).ToString();

                for (int i = 0; i < oyunAlanBoyutu; i++)
                {
                    for (int j = 0; j < oyunAlanBoyutu; j++)
                    {
                        if (dataGridViewOyunAlani.Rows[i].Cells[j].Style.BackColor != Color.Pink)
                        {
                            dataGridViewOyunAlani.Rows[i].Cells[j].Style.BackColor = Color.White;
                        }
                    }
                }

                count++;

                dataGridViewOyunAlani.Rows[dataGridViewOyunAlani.CurrentCell.RowIndex].Cells[dataGridViewOyunAlani.CurrentCell.ColumnIndex].Value = count;
                dataGridViewOyunAlani.Rows[dataGridViewOyunAlani.CurrentCell.RowIndex].Cells[dataGridViewOyunAlani.CurrentCell.ColumnIndex].Style.BackColor = Color.Pink;

                if (SelectedRow + 2 < oyunAlanBoyutu && SelectedColumn + 1 < oyunAlanBoyutu && dataGridViewOyunAlani.Rows[SelectedRow + 2].Cells[SelectedColumn + 1].Style.BackColor != Color.Pink)
                {
                    dataGridViewOyunAlani.Rows[SelectedRow + 2].Cells[SelectedColumn + 1].Style.BackColor = Color.LightBlue;
                }
                if (SelectedRow + 2 < oyunAlanBoyutu && 0 <= SelectedColumn - 1 && dataGridViewOyunAlani.Rows[SelectedRow + 2].Cells[SelectedColumn - 1].Style.BackColor != Color.Pink)
                {
                    dataGridViewOyunAlani.Rows[SelectedRow + 2].Cells[SelectedColumn - 1].Style.BackColor = Color.LightBlue;
                }    
                if (SelectedRow - 2 >= 0 && SelectedColumn + 1 < oyunAlanBoyutu && dataGridViewOyunAlani.Rows[SelectedRow - 2].Cells[SelectedColumn + 1].Style.BackColor != Color.Pink)
                {
                    dataGridViewOyunAlani.Rows[SelectedRow - 2].Cells[SelectedColumn + 1].Style.BackColor = Color.LightBlue;
                }   
                if (SelectedRow - 2 >= 0 && SelectedColumn - 1 >= 0 && dataGridViewOyunAlani.Rows[SelectedRow - 2].Cells[SelectedColumn - 1].Style.BackColor != Color.Pink)
                {
                    dataGridViewOyunAlani.Rows[SelectedRow - 2].Cells[SelectedColumn - 1].Style.BackColor = Color.LightBlue;
                }   
                if (SelectedRow + 1 < oyunAlanBoyutu && SelectedColumn + 2 < oyunAlanBoyutu && dataGridViewOyunAlani.Rows[SelectedRow + 1].Cells[SelectedColumn + 2].Style.BackColor != Color.Pink)
                {
                    dataGridViewOyunAlani.Rows[SelectedRow + 1].Cells[SelectedColumn + 2].Style.BackColor = Color.LightBlue;
                }   
                if (SelectedRow + 1 < oyunAlanBoyutu && SelectedColumn - 2 >= 0 && dataGridViewOyunAlani.Rows[SelectedRow + 1].Cells[SelectedColumn - 2].Style.BackColor != Color.Pink)
                {
                    dataGridViewOyunAlani.Rows[SelectedRow + 1].Cells[SelectedColumn - 2].Style.BackColor = Color.LightBlue;
                }   
                if (SelectedRow - 1 >= 0 && SelectedColumn + 2 < oyunAlanBoyutu && dataGridViewOyunAlani.Rows[SelectedRow - 1].Cells[SelectedColumn + 2].Style.BackColor != Color.Pink)
                {
                    dataGridViewOyunAlani.Rows[SelectedRow - 1].Cells[SelectedColumn + 2].Style.BackColor = Color.LightBlue;
                } 
                if (SelectedRow - 1 >= 0 && SelectedColumn - 2 >= 0 && dataGridViewOyunAlani.Rows[SelectedRow - 1].Cells[SelectedColumn - 2].Style.BackColor != Color.Pink)
                {
                    dataGridViewOyunAlani.Rows[SelectedRow - 1].Cells[SelectedColumn - 2].Style.BackColor = Color.LightBlue;
                }    
            }

            if (dataGridViewOyunAlani.Rows[SelectedRow].Cells[SelectedColumn].Style.BackColor == Color.LightBlue)
            {
                dataGridViewOyunAlani.Rows[SelectedRow].Cells[SelectedColumn].Value = count;
                dataGridViewOyunAlani.Rows[SelectedRow].Cells[SelectedColumn].Style.BackColor = Color.Pink;
            }

            lblSkor.Text = count.ToString();

            if (count == oyunAlanBoyutu * oyunAlanBoyutu)
            {
                MessageBox.Show("TEBRİKLER KAZANDINIZ !");
            }
        }
    }
}
