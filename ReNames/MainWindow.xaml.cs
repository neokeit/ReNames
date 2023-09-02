using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using Ookii.Dialogs.WinForms;
using ReNames.Models;

namespace ReNames
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] _files = null!;
        private SettingsModel _config;

        public MainWindow()
        {
            InitializeComponent();
            LoadConfig();
        }

        private void LoadConfig()
        {
            _config = ConfigHelpper.LoadConfig();
            ckOnlyChanges.IsChecked = _config.ShowOnlyChanges;
            ckHideExtensions.IsChecked = _config.HideExtensions;
            if (string.IsNullOrEmpty(_config.Language))
            {
                _config.Language =  CultureInfo.CurrentCulture.Parent.Name;
            }
            foreach (ComboBoxItem item in CbLanguage.Items)
            {
                if (item.Tag.ToString() == _config.Language)
                {
                    CbLanguage.SelectedValue = item;
                }
            }
        }

        private void SaveConfig()
        {
             ConfigHelpper.SaveConfig(_config);
        }

        private void Directory_Click(object sender, EventArgs e)
        {
            lstOriginal.Items.Clear();
            var dlg = new VistaFolderBrowserDialog();
            dlg.ShowNewFolderButton = true;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                GetFileList(dlg.SelectedPath);
            }
        }

        private void GetFileList(string path)
        {
            if (string.IsNullOrEmpty(path)) return;

            lstOriginal.Items.Clear();
            TxPath.Text = path;
            _files = Directory.GetFiles(path, "*.*");

            foreach (var file in _files)
            {
                var fileName =Path.GetFileName(file);
                fileName=CleanFileName(fileName);
                lstOriginal.Items.Add(fileName);
            }

            GetNumberFiles();
            lstModifieds.Items.Clear();
        }

        private void GetNumberFiles()
        {
            TbNumOriginal.Text = "";
            if (lstOriginal.Items.Count > 0)
                TbNumOriginal.Text = "(" + lstOriginal.Items.Count + ")";
        }
        
        private void GetNumberModifiedFiles(int number)
        {
            TbNumModified.Text = "";
            if (number > 0)
                TbNumModified.Text = "(" + number + ")";
        }

        private string GetTextoRemplazable(string original)
        {
            var textoRemplazable = "";
            var textoFinal = "";
            var item = CbReplaceType.SelectedIndex;
            switch (item)
            {
                case 1:
                    if (string.IsNullOrEmpty(TxFinal.Text))
                    {
                        textoRemplazable = TxInicial.Text;
                    }
                    else
                    {
                        var start = original.IndexOf(TxInicial.Text, StringComparison.InvariantCultureIgnoreCase);
                        if (start > -1)
                        {
                            var end = original.IndexOf(TxFinal.Text, start, StringComparison.InvariantCultureIgnoreCase);
                            if (end > -1)
                            {
                                end = end + TxFinal.Text.Length;
                                textoRemplazable = original.Substring(start, end - start);
                            }
                        }
                    }
                    if (textoRemplazable != "")
                    {
                        textoFinal = original.Replace(textoRemplazable, TxCambio.Text);
                    }

                    break;
                case 2:
                    var postition = GetPositions(original);
                    var textStart = original.Substring(0,postition.Start);
                    var textEnd = original.Substring(postition.Start+postition.Lenght,original.Length- (postition.Start+postition.Lenght));
                    textoFinal = textStart+TxCambio.Text+textEnd;
                    break;
                default:
                    textoRemplazable = TxReplacement.Text;
                    if (textoRemplazable != "")
                    {
                        textoFinal = original.Replace(textoRemplazable, TxCambio.Text);
                    }
                    break;
            }

            return textoFinal;
        }

        private void Previsualizar_Click(object sender, EventArgs e)
        {
            int filesModified = 0;
            lstModifieds.Items.Clear();
            if (_files == null) return;
            foreach (var file in _files)
            {
                var fileNameOrigen = CleanFileName(file);
                var cambio= GetTextoRemplazable(fileNameOrigen);
                var add = true;
                if (ckOnlyChanges.IsChecked==true)
                {
                    if (string.IsNullOrEmpty(cambio) || cambio == fileNameOrigen) add=false;
                }

                if (add)
                {
                    filesModified++;
                    lstModifieds.Items.Add(cambio);
                }
            }
            
            GetNumberModifiedFiles(filesModified);
        }

        private string CleanFileName(string path)
        {
            if (ckHideExtensions.IsChecked == true)
            {
                path = Path.GetFileName(path);
                var extension = Path.GetExtension(path);
                path = path.Substring(0, path.Length - extension.Length);
            }

            return path;
        }

        private void Refrescar_Click(object sender, RoutedEventArgs e)
        {
            GetFileList(TxPath.Text);
        }

        private void Aplicar_Click(object sender, EventArgs e)
        {
            int filesModified = 0;
            lstModifieds.Items.Clear();
            foreach (var file in _files)
            {
                var cambio = GetTextoRemplazable(file);
                if (string.IsNullOrEmpty(cambio) || cambio == file)
                {
                    filesModified++;
                }
                cambio = cambio.Replace(":", "-");
                lstModifieds.Items.Add(cambio);

                var origen = file;
                var destino = TxPath.Text + "\\" + cambio;
                File.Move(origen, destino);
            }

            GetNumberModifiedFiles(filesModified);
            GetFileList(TxPath.Text);
        }

        private void Config_Click(object sender, RoutedEventArgs e)
        {
            GrConfig.Visibility = Visibility.Visible;
        }
        private void CloseConfig_Click(object sender, RoutedEventArgs e)
        {
            GrConfig.Visibility = Visibility.Hidden;
        }
        private void lstOriginal_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstOriginal.SelectedIndex == -1) return;
            var item = lstOriginal.SelectedItem;
            SetTextValueOriginal(item.ToString());
        }
        private void lstModifieds_SelectedIndexChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstModifieds.SelectedIndex == -1) return;
            var item = lstModifieds.SelectedItem;
            SetTextValueOriginal(item.ToString());
        }
        private void SetTextValueOriginal(string? value)
        {
            var item = CbReplaceType.SelectedIndex;
            switch (item)
            {
                case 1:
                    if (RbFin.IsChecked == true)
                    {
                        TxFinal.Text = value;
                    }
                    else
                    {  
                        TxInicial.Text = value;
                    }
                    break;
                case 2:
                    TbExample.Document.Blocks.Clear();  
                    TbExample.AppendText(value);
                    SelectedTextByPosition();
                    break;
                default:
                    TxReplacement.Text = value;
                    break;
            }
           
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PnlByText==null || PnlByPosition==null) return;
            var item = CbReplaceType.SelectedIndex;
            PnlByText.Visibility= Visibility.Collapsed;
            PnlByTextStartEnd.Visibility= Visibility.Collapsed;
            PnlByPosition.Visibility= Visibility.Collapsed;
            switch (item)
            {
                case 1:
                    PnlByTextStartEnd.Visibility= Visibility.Visible;
                    break;
                case 2:
                    PnlByPosition.Visibility= Visibility.Visible;
                    InitByPosition();
                    break;
                default:
                    PnlByText.Visibility= Visibility.Visible;
                    break;
            }
        }

        private void InitByPosition()
        {
            var selectedItem = lstOriginal.Items[0];
            if (selectedItem != null)
                SetTextValueOriginal(selectedItem.ToString());
        }

        private TextPosition GetPositions(string text)
        {
            if (string.IsNullOrEmpty(text)) return null;

            var positions =new TextPosition();
            var charsLenght = UpCaracters.Value??0;
            var charStart = UpPosition.Value??0;
            
            var textlengh = text.Length-1;
            if (RbStartPosition.IsChecked == true)
            {
                positions.Start = textlengh>charStart ? charStart :textlengh;
                positions.Lenght = textlengh>=(charStart+charsLenght) ? charsLenght :(textlengh-charStart)+1;
            }
            else
            {
                positions.Lenght = textlengh>=(charStart+charsLenght) ? charsLenght :(textlengh-charStart)+1;
                positions.Start =(textlengh +1)-((textlengh>charStart ? charStart :textlengh) + positions.Lenght);
            }
            return positions;
        }
        private void UpCaracters_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            SelectedTextByPosition();
        }

        private void UpPosition_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            SelectedTextByPosition();
        }

        private void SelectedTextByPosition()
        {
            var text = new TextRange(TbExample.Document.ContentStart, TbExample.Document.ContentEnd).Text;
            text = Regex.Replace(text, @"(\r\n)|(\n\r)|(\n)", "");
            if (string.IsNullOrEmpty(text)) return;

            var postition = GetPositions(text);

            var textStart = text.Substring(0,postition.Start);
            var textSelected = text.Substring(postition.Start,postition.Lenght);
            var textEnd = text.Substring(postition.Start+postition.Lenght,text.Length- (postition.Start+postition.Lenght));

            TbExample.Document.Blocks.Clear();  

            AppendText(TbExample, textStart, Brushes.Black, Brushes.Transparent);
            AppendText(TbExample, textSelected, Brushes.Black, Brushes.Red);
            AppendText(TbExample, textEnd, Brushes.Black, Brushes.Transparent);
        }
        
        private void AppendText(RichTextBox textBox, string message, SolidColorBrush fontColor, SolidColorBrush backgroundColor)
        {
            message = Regex.Replace(message, @"(\r\n)|(\n\r)|(\n)", "\r");
            var textRange = new TextRange(textBox.Document.ContentEnd, textBox.Document.ContentEnd) { Text = message };
            textRange.ApplyPropertyValue(TextElement.ForegroundProperty, fontColor);
            textRange.ApplyPropertyValue(TextElement.BackgroundProperty, backgroundColor);
        }

 

        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            if (_config==null) return;
            SelectedTextByPosition();
        }

        private void CkHideExtensions_OnChecked(object sender, RoutedEventArgs e)
        {
            if (_config==null) return;
            if (_config.HideExtensions == (ckHideExtensions.IsChecked==true)) return;
            _config.HideExtensions = (ckHideExtensions.IsChecked==true);
            SaveConfig();
        }

        private void CkOnlyChanges_OnChecked(object sender, RoutedEventArgs e)
        {
            if (_config==null) return;
            if (_config.ShowOnlyChanges == (ckOnlyChanges.IsChecked==true)) return;
            _config.ShowOnlyChanges = (ckOnlyChanges.IsChecked==true);
            SaveConfig();
        }

        private void CbLanguage_OnDropDownClosed(object? sender, EventArgs e)
        {
            if (_config==null) return;
            if (_config.Language == ((ComboBoxItem)CbLanguage.SelectedItem).Tag.ToString()!) return;
            _config.Language =((ComboBoxItem)CbLanguage.SelectedItem).Tag.ToString()!;
            SaveConfig();
            App.SetLanguague(_config.Language);
        }
    }


}
