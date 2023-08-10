namespace ReNames.Formularios
{
    partial class ReNames
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReNames));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btAbrir = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btPrevisualizar = new System.Windows.Forms.Button();
            this.btAplicar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txFinal = new System.Windows.Forms.TextBox();
            this.txInicial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btReferescar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txCambio = new System.Windows.Forms.TextBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ruta";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(356, 20);
            this.textBox1.TabIndex = 2;
            // 
            // btAbrir
            // 
            this.btAbrir.Location = new System.Drawing.Point(375, 21);
            this.btAbrir.Name = "btAbrir";
            this.btAbrir.Size = new System.Drawing.Size(26, 24);
            this.btAbrir.TabIndex = 3;
            this.btAbrir.Text = "...";
            this.btAbrir.UseVisualStyleBackColor = true;
            this.btAbrir.Click += new System.EventHandler(this.button2_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 51);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(211, 263);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 206;
            // 
            // btPrevisualizar
            // 
            this.btPrevisualizar.Location = new System.Drawing.Point(230, 454);
            this.btPrevisualizar.Name = "btPrevisualizar";
            this.btPrevisualizar.Size = new System.Drawing.Size(99, 29);
            this.btPrevisualizar.TabIndex = 5;
            this.btPrevisualizar.Text = "Previsualizar";
            this.btPrevisualizar.UseVisualStyleBackColor = true;
            this.btPrevisualizar.Click += new System.EventHandler(this.button3_Click);
            // 
            // btAplicar
            // 
            this.btAplicar.Location = new System.Drawing.Point(335, 454);
            this.btAplicar.Name = "btAplicar";
            this.btAplicar.Size = new System.Drawing.Size(99, 29);
            this.btAplicar.TabIndex = 10;
            this.btAplicar.Text = "Aplicar";
            this.btAplicar.UseVisualStyleBackColor = true;
            this.btAplicar.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txFinal);
            this.groupBox1.Controls.Add(this.txInicial);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 320);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(422, 67);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Texto a buscar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(222, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Hasta";
            // 
            // txFinal
            // 
            this.txFinal.Location = new System.Drawing.Point(225, 32);
            this.txFinal.Name = "txFinal";
            this.txFinal.Size = new System.Drawing.Size(186, 20);
            this.txFinal.TabIndex = 17;
            // 
            // txInicial
            // 
            this.txInicial.Location = new System.Drawing.Point(9, 32);
            this.txInicial.Name = "txInicial";
            this.txInicial.Size = new System.Drawing.Size(186, 20);
            this.txInicial.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Desde";
            // 
            // btReferescar
            // 
            this.btReferescar.Image = global::ReNames.Properties.Resources.actualizar;
            this.btReferescar.Location = new System.Drawing.Point(407, 22);
            this.btReferescar.Name = "btReferescar";
            this.btReferescar.Size = new System.Drawing.Size(24, 24);
            this.btReferescar.TabIndex = 11;
            this.btReferescar.UseVisualStyleBackColor = true;
            this.btReferescar.Click += new System.EventHandler(this.btReferescar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txCambio);
            this.groupBox2.Location = new System.Drawing.Point(12, 393);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(422, 53);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Texto a remplazar";
            // 
            // txCambio
            // 
            this.txCambio.Location = new System.Drawing.Point(7, 22);
            this.txCambio.Name = "txCambio";
            this.txCambio.Size = new System.Drawing.Size(399, 20);
            this.txCambio.TabIndex = 20;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(229, 52);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(202, 263);
            this.listView2.TabIndex = 20;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 190;
            // 
            // ReNames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 490);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btReferescar);
            this.Controls.Add(this.btAplicar);
            this.Controls.Add(this.btPrevisualizar);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btAbrir);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReNames";
            this.Text = "ReNames";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btAbrir;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btPrevisualizar;
        private System.Windows.Forms.Button btAplicar;
        private System.Windows.Forms.Button btReferescar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txFinal;
        private System.Windows.Forms.TextBox txInicial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txCambio;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}

