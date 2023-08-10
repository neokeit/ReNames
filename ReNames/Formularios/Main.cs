using System;
using System.IO;
using System.Windows.Forms;

namespace ReNames.Formularios
{
    public partial class ReNames : Form
    {
        string[] _files;
        public ReNames()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                ObtenerFicheros(fbd.SelectedPath);
            }

        }

        private void ObtenerFicheros(string path)
        {
            listView1.Items.Clear();
            textBox1.Text = path;
            _files = Directory.GetFiles(path, "*.*");

            for (int i = 0; i < _files.Length; i++)
            {
                _files[i] = Path.GetFileName(_files[i]);
                ListViewItem lvi = new ListViewItem(_files[i]);
                listView1.Items.Add(lvi);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            foreach (var file in _files)
            {                
                string cambio = file;
                string textoRemplazable = GetTextoRemplazable(file);
                if (textoRemplazable != "")
                { cambio = file.Replace(textoRemplazable, txCambio.Text); }
                ListViewItem lvi = new ListViewItem(cambio);
                listView2.Items.Add(lvi);
            }
        }

        private string GetTextoRemplazable(string Original)
        {
            string textoRemplazable="";
            if (string.IsNullOrEmpty(txFinal.Text))
            {
                textoRemplazable = txInicial.Text;
            }
            else
            {
                int start = Original.IndexOf(txInicial.Text);
                if (start > 0)
                {
                    int end = Original.IndexOf(txFinal.Text, start);
                    if (end > 0)
                    {
                        end = end + txFinal.Text.Length;
                        textoRemplazable = Original.Substring(start, end - start); }
                }
            }

            return textoRemplazable;
        }
    

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            foreach (var file in _files)
            {
                string Original=file;
                string cambio = file;
                string textoRemplazable = GetTextoRemplazable(Original);
                if (textoRemplazable != "")
                { cambio = file.Replace(textoRemplazable,txCambio.Text); }
                ListViewItem lvi = new ListViewItem(Original);
                lvi.SubItems.Add(cambio);
                listView1.Items.Add(lvi);
                File.Move(textBox1.Text + "\\" + Original, textBox1.Text + "\\" + cambio);               
            }
            ObtenerFicheros(textBox1.Text);
        }

        private void btReferescar_Click(object sender, EventArgs e)
        {
            ObtenerFicheros(textBox1.Text);
        }
    }
}
