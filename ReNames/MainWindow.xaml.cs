using System;
using System.IO;
using System.Windows;
using Ookii.Dialogs.WinForms;

namespace ReNames
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] _files = null!;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void Directory_Click(object sender, EventArgs e)
        {
            lstOriginal.Items.Clear();
            var dlg = new VistaFolderBrowserDialog();
            dlg.ShowNewFolderButton = true;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ObtenerFicheros(dlg.SelectedPath);
            }
        }

        private void ObtenerFicheros(string path)
        {
            if (string.IsNullOrEmpty(path)) return;

            lstOriginal.Items.Clear();
            TxPath.Text = path;
            _files = Directory.GetFiles(path, "*.*");

            for (int i = 0; i < _files.Length; i++)
            {
                var fileName =Path.GetFileName(_files[i]);
                fileName=CleanFileName(fileName);
                lstOriginal.Items.Add(fileName);
            }
            lstModifieds.Items.Clear();
        }


        private string GetTextoRemplazable(string Original)
        {
            string textoRemplazable = "";
            if (string.IsNullOrEmpty(TxFinal.Text))
            {
                textoRemplazable = TxInicial.Text;
            }
            else
            {
                var start = Original.IndexOf(TxInicial.Text, StringComparison.Ordinal);
                if (start > 0)
                {
                    var end = Original.IndexOf(TxFinal.Text, start, StringComparison.Ordinal);
                    if (end > 0)
                    {
                        end = end + TxFinal.Text.Length;
                        textoRemplazable = Original.Substring(start, end - start);
                    }
                }
            }

            return textoRemplazable;
        }




        private void lstOriginal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstOriginal.SelectedIndex == -1) return;
            var item = lstOriginal.SelectedIndex;
            if (RbFin.IsChecked == true)
            {
                TxFinal.Text = lstOriginal.Items[item].ToString();
            }
            else
            {  
                TxInicial.Text = lstOriginal.Items[item].ToString();
            }
        }


        private void Previsualizar_Click(object sender, EventArgs e)
        {
            lstModifieds.Items.Clear();
            if (_files==null) return;
            foreach (var file in _files)
            {
                var fileNameOrigen = CleanFileName(file);
                string cambio = fileNameOrigen;
                string textoRemplazable = GetTextoRemplazable(fileNameOrigen);
                if (textoRemplazable != "")
                {
                    cambio = fileNameOrigen.Replace(textoRemplazable, TxCambio.Text);
                }
                var add = true;
                if (ckOnlyChanges.IsChecked==true)
                {
                    if (cambio == fileNameOrigen) add=false;
                }
                if (add)  lstModifieds.Items.Add(cambio);
            }
        }

        private string CleanFileName(string path)
        {
            if (ckHideExtensions.IsChecked == true)
            {
                path = Path.GetFileName(path);
                string extension = Path.GetExtension(path);
                path = path.Substring(0, path.Length - extension.Length);
            }

            return path;
        }

        private void Refrescar_Click(object sender, RoutedEventArgs e)
        {
            ObtenerFicheros(TxPath.Text);
        }

        private void Aplicar_Click(object sender, EventArgs e)
        {
            lstModifieds.Items.Clear();
            foreach (var file in _files)
            {
                var cambio = Path.GetFileName(file);
                var textoRemplazable = GetTextoRemplazable(file);
                if (textoRemplazable != "")
                {
                    cambio = cambio.Replace(textoRemplazable, TxCambio.Text);
                }

                cambio = cambio.Replace(":", "-");
                lstModifieds.Items.Add(cambio);

                var origen = file;
                var destino = TxPath.Text + "\\" + cambio;
                File.Move(origen, destino);
            }

            ObtenerFicheros(TxPath.Text);
        }
    }
}
