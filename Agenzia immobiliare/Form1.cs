using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Agenzia_immobiliare
{
    public partial class Form1 : Form
    {   
        //string path = @"C:\Users\langu\source\repos\Agenzia immobiliare\Agenzia immobiliare\bin\Dati";
        //public void Letturra()
        //{
        //    StreamReader a = new StreamReader(path);

            
        //}
        public Form1()
        {
            InitializeComponent();
            
        }
     
        public int i = 1;
        public int l = 0;
        public int posizione = 0;
        ClasseAgenzia[] alloggio = new ClasseAgenzia[50];
        public int Aumenta = 0;
        private void button1_Click(object sender, EventArgs e)//crea 50 allogi come massimo
        {

            dataGridView1.RowCount = 51;
            dataGridView1.ColumnCount = 5;
            //per vedere bello
            dataGridView1.Rows[0].Cells[0].Value = "Numero"; dataGridView1.Rows[0].Cells[1].Value = "Provincia";
            dataGridView1.Rows[0].Cells[2].Value = "Prezzo"; dataGridView1.Rows[0].Cells[3].Value = "N.Locali";
            dataGridView1.Rows[0].Cells[4].Value = "Agente";
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==""|| textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" )
            {
                MessageBox.Show("error");
            }
            else if (i > 50)
            {
                MessageBox.Show("Massimo numero è 50");
            }
            else
            {
                alloggio[l] = new ClasseAgenzia(textBox1.Text, Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), textBox4.Text);
                dataGridView1.Rows[i].Cells[0].Value = i;
                dataGridView1.Rows[i].Cells[1].Value = alloggio[l].GetProvincia();
                dataGridView1.Rows[i].Cells[2].Value = alloggio[l].GetPrezzo();
                dataGridView1.Rows[i].Cells[3].Value = alloggio[l].GetLocali();
                dataGridView1.Rows[i].Cells[4].Value = alloggio[l].GetAgente();
                i++;
                l++;
                posizione++;
            }
            
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            ClasseAgenzia save = new ClasseAgenzia();
            if (i > 2)
            {
                for (int j = 0; j < i-1; j++)
                {
                    for (int k = j+1; k < i-1; k++)
                    {
                        if (alloggio[j].GetProvincia().CompareTo(alloggio[k].GetProvincia()) == 1)
                        {
                            save = alloggio[j];
                            alloggio[j] = alloggio[k];
                            alloggio[k] = save;
                        }
                        else if (alloggio[j].GetProvincia().CompareTo(alloggio[k].GetProvincia()) == 0)
                        {
                            if (alloggio[j].GetPrezzo().CompareTo(alloggio[k].GetPrezzo()) == 1)
                            {
                                save = alloggio[j];
                                alloggio[j] = alloggio[k];
                                alloggio[k] = save;
                            }
                            else if (alloggio[j].GetPrezzo().CompareTo(alloggio[k].GetPrezzo()) == 0)
                            {
                                if (alloggio[j].GetLocali().CompareTo(alloggio[k].GetLocali()) == 1)
                                {
                                    save = alloggio[j];
                                    alloggio[j] = alloggio[k];
                                    alloggio[k] = save;
                                }
                            }
                        }
                    }
                }
            }
            // ordina
            for (int j = 0; j < i-1; j++)
            {
                dataGridView1.Rows[j+1].Cells[1].Value = alloggio[j].GetProvincia();
                dataGridView1.Rows[j+1].Cells[2].Value = alloggio[j].GetPrezzo();
                dataGridView1.Rows[j+1].Cells[3].Value = alloggio[j].GetLocali();
                dataGridView1.Rows[j+1].Cells[4].Value = alloggio[j].GetAgente();
            }
        }
        //set
        private void button4_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < i-1; j++)
            {
                alloggio[j].SetProvincia(Convert.ToString(dataGridView1.Rows[j + 1].Cells[1].Value));
                alloggio[j].SetPrezzo(Convert.ToInt32(dataGridView1.Rows[j + 1].Cells[2].Value));
                alloggio[j].SetLocali(Convert.ToInt32(dataGridView1.Rows[j + 1].Cells[3].Value));
                alloggio[j].SetAgente(Convert.ToString(dataGridView1.Rows[j + 1].Cells[4].Value));
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StreamWriter save = new StreamWriter(@"Dati.text",true);
            for (int j = 0; j < posizione; j++)
            {
                save.WriteLine(alloggio[j].GetProvincia() + "," + alloggio[j].GetPrezzo() + "," + alloggio[j].GetLocali() + "," + alloggio[j].GetAgente() + ",");
            }
            save.Close();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            posizione = 0;
            StreamReader Carica = new StreamReader(@"Dati.text");
            string riga;
            while ((riga = Carica.ReadLine()) != null)
            {
                string[] dunno = System.Text.RegularExpressions.Regex.Split(riga, @",");
                alloggio[posizione] = new ClasseAgenzia (dunno[0], Convert.ToInt32(dunno[1]), Convert.ToInt32(dunno[2]), dunno[3]);
                posizione++;
            }
            dataGridView1.Rows[0].Cells[0].Value = "Numero"; dataGridView1.Rows[0].Cells[1].Value = "Provincia";
            dataGridView1.Rows[0].Cells[2].Value = "Prezzo"; dataGridView1.Rows[0].Cells[3].Value = "N.Locali";
            dataGridView1.Rows[0].Cells[4].Value = "Agente";
            for (int i = 0; i < posizione; i++)
            {
                dataGridView1.Rows[i+1].Cells[0].Value = i+1;
                dataGridView1.Rows[i+1].Cells[1].Value = alloggio[i].GetProvincia();
                dataGridView1.Rows[i+1].Cells[2].Value = alloggio[i].GetPrezzo();
                dataGridView1.Rows[i+1].Cells[3].Value = alloggio[i].GetLocali();
                dataGridView1.Rows[i+1].Cells[4].Value = alloggio[i].GetAgente();

            }
            Carica.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)//solo alfabeti
        {
            if (!char.IsControl(e.KeyChar) && char.IsPunctuation(e.KeyChar) || char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))//cosi utente puo inserire solo numeri
            {
                e.Handled = true;
            }
        }

    } 
}