
namespace Formularios
{
    partial class FormRegistrarMuñeco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistrarMuñeco));
            this.lbl_MaterialPpal = new System.Windows.Forms.Label();
            this.lbl_CantidadProd = new System.Windows.Forms.Label();
            this.lbl_Marca = new System.Windows.Forms.Label();
            this.lbl_CantPartes = new System.Windows.Forms.Label();
            this.lbl_Indumentaria = new System.Windows.Forms.Label();
            this.cmb_MateriaPrima = new System.Windows.Forms.ComboBox();
            this.num_CantProd = new System.Windows.Forms.NumericUpDown();
            this.txt_Marca = new System.Windows.Forms.TextBox();
            this.radio_IndumSi = new System.Windows.Forms.RadioButton();
            this.radio_IndumNo = new System.Windows.Forms.RadioButton();
            this.radio_ArticNo = new System.Windows.Forms.RadioButton();
            this.radio_ArticSi = new System.Windows.Forms.RadioButton();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.group_Indumentaria = new System.Windows.Forms.GroupBox();
            this.group_Ariculado = new System.Windows.Forms.GroupBox();
            this.num_PartesEnsamblar = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.num_CantProd)).BeginInit();
            this.group_Indumentaria.SuspendLayout();
            this.group_Ariculado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_PartesEnsamblar)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_MaterialPpal
            // 
            this.lbl_MaterialPpal.AutoSize = true;
            this.lbl_MaterialPpal.BackColor = System.Drawing.Color.Transparent;
            this.lbl_MaterialPpal.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MaterialPpal.Location = new System.Drawing.Point(23, 29);
            this.lbl_MaterialPpal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_MaterialPpal.Name = "lbl_MaterialPpal";
            this.lbl_MaterialPpal.Size = new System.Drawing.Size(149, 21);
            this.lbl_MaterialPpal.TabIndex = 0;
            this.lbl_MaterialPpal.Text = "Material Principal: ";
            // 
            // lbl_CantidadProd
            // 
            this.lbl_CantidadProd.AutoSize = true;
            this.lbl_CantidadProd.BackColor = System.Drawing.Color.Transparent;
            this.lbl_CantidadProd.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CantidadProd.Location = new System.Drawing.Point(23, 97);
            this.lbl_CantidadProd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_CantidadProd.Name = "lbl_CantidadProd";
            this.lbl_CantidadProd.Size = new System.Drawing.Size(160, 21);
            this.lbl_CantidadProd.TabIndex = 1;
            this.lbl_CantidadProd.Text = "Cantidad a Producir:";
            // 
            // lbl_Marca
            // 
            this.lbl_Marca.AutoSize = true;
            this.lbl_Marca.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Marca.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Marca.Location = new System.Drawing.Point(23, 156);
            this.lbl_Marca.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Marca.Name = "lbl_Marca";
            this.lbl_Marca.Size = new System.Drawing.Size(160, 21);
            this.lbl_Marca.TabIndex = 2;
            this.lbl_Marca.Text = "Marca del Juguete: ";
            // 
            // lbl_CantPartes
            // 
            this.lbl_CantPartes.AutoSize = true;
            this.lbl_CantPartes.BackColor = System.Drawing.Color.Transparent;
            this.lbl_CantPartes.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CantPartes.Location = new System.Drawing.Point(23, 217);
            this.lbl_CantPartes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_CantPartes.Name = "lbl_CantPartes";
            this.lbl_CantPartes.Size = new System.Drawing.Size(224, 21);
            this.lbl_CantPartes.TabIndex = 3;
            this.lbl_CantPartes.Text = "Cantidad Partes a ensamblar:";
            // 
            // lbl_Indumentaria
            // 
            this.lbl_Indumentaria.AutoSize = true;
            this.lbl_Indumentaria.Location = new System.Drawing.Point(23, 381);
            this.lbl_Indumentaria.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Indumentaria.Name = "lbl_Indumentaria";
            this.lbl_Indumentaria.Size = new System.Drawing.Size(0, 21);
            this.lbl_Indumentaria.TabIndex = 4;
            // 
            // cmb_MateriaPrima
            // 
            this.cmb_MateriaPrima.BackColor = System.Drawing.Color.Firebrick;
            this.cmb_MateriaPrima.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_MateriaPrima.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_MateriaPrima.FormattingEnabled = true;
            this.cmb_MateriaPrima.Location = new System.Drawing.Point(265, 26);
            this.cmb_MateriaPrima.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_MateriaPrima.Name = "cmb_MateriaPrima";
            this.cmb_MateriaPrima.Size = new System.Drawing.Size(148, 29);
            this.cmb_MateriaPrima.TabIndex = 1;
            // 
            // num_CantProd
            // 
            this.num_CantProd.BackColor = System.Drawing.Color.Firebrick;
            this.num_CantProd.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_CantProd.Location = new System.Drawing.Point(265, 90);
            this.num_CantProd.Margin = new System.Windows.Forms.Padding(4);
            this.num_CantProd.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.num_CantProd.Name = "num_CantProd";
            this.num_CantProd.Size = new System.Drawing.Size(150, 28);
            this.num_CantProd.TabIndex = 2;
            // 
            // txt_Marca
            // 
            this.txt_Marca.BackColor = System.Drawing.Color.Firebrick;
            this.txt_Marca.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Marca.Location = new System.Drawing.Point(267, 153);
            this.txt_Marca.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Marca.Name = "txt_Marca";
            this.txt_Marca.Size = new System.Drawing.Size(148, 28);
            this.txt_Marca.TabIndex = 3;
            // 
            // radio_IndumSi
            // 
            this.radio_IndumSi.AutoSize = true;
            this.radio_IndumSi.Checked = true;
            this.radio_IndumSi.Location = new System.Drawing.Point(215, 14);
            this.radio_IndumSi.Margin = new System.Windows.Forms.Padding(4);
            this.radio_IndumSi.Name = "radio_IndumSi";
            this.radio_IndumSi.Size = new System.Drawing.Size(42, 25);
            this.radio_IndumSi.TabIndex = 5;
            this.radio_IndumSi.TabStop = true;
            this.radio_IndumSi.Text = "Si";
            this.radio_IndumSi.UseVisualStyleBackColor = true;
            // 
            // radio_IndumNo
            // 
            this.radio_IndumNo.AutoSize = true;
            this.radio_IndumNo.Location = new System.Drawing.Point(323, 16);
            this.radio_IndumNo.Margin = new System.Windows.Forms.Padding(4);
            this.radio_IndumNo.Name = "radio_IndumNo";
            this.radio_IndumNo.Size = new System.Drawing.Size(48, 25);
            this.radio_IndumNo.TabIndex = 6;
            this.radio_IndumNo.Text = "No";
            this.radio_IndumNo.UseVisualStyleBackColor = true;
            // 
            // radio_ArticNo
            // 
            this.radio_ArticNo.AutoSize = true;
            this.radio_ArticNo.Location = new System.Drawing.Point(323, 18);
            this.radio_ArticNo.Margin = new System.Windows.Forms.Padding(4);
            this.radio_ArticNo.Name = "radio_ArticNo";
            this.radio_ArticNo.Size = new System.Drawing.Size(48, 25);
            this.radio_ArticNo.TabIndex = 8;
            this.radio_ArticNo.Text = "No";
            this.radio_ArticNo.UseVisualStyleBackColor = true;
            // 
            // radio_ArticSi
            // 
            this.radio_ArticSi.AutoSize = true;
            this.radio_ArticSi.Checked = true;
            this.radio_ArticSi.Location = new System.Drawing.Point(215, 18);
            this.radio_ArticSi.Margin = new System.Windows.Forms.Padding(4);
            this.radio_ArticSi.Name = "radio_ArticSi";
            this.radio_ArticSi.Size = new System.Drawing.Size(42, 25);
            this.radio_ArticSi.TabIndex = 7;
            this.radio_ArticSi.TabStop = true;
            this.radio_ArticSi.Text = "Si";
            this.radio_ArticSi.UseVisualStyleBackColor = true;
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.BackColor = System.Drawing.Color.Firebrick;
            this.btn_Guardar.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Guardar.Location = new System.Drawing.Point(179, 475);
            this.btn_Guardar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(112, 38);
            this.btn_Guardar.TabIndex = 9;
            this.btn_Guardar.Text = "Guardar";
            this.btn_Guardar.UseVisualStyleBackColor = false;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.BackColor = System.Drawing.Color.Firebrick;
            this.btn_Cancelar.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancelar.Location = new System.Drawing.Point(310, 475);
            this.btn_Cancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(112, 38);
            this.btn_Cancelar.TabIndex = 10;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = false;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // group_Indumentaria
            // 
            this.group_Indumentaria.BackColor = System.Drawing.Color.Transparent;
            this.group_Indumentaria.Controls.Add(this.radio_IndumSi);
            this.group_Indumentaria.Controls.Add(this.radio_IndumNo);
            this.group_Indumentaria.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.group_Indumentaria.Location = new System.Drawing.Point(16, 272);
            this.group_Indumentaria.Margin = new System.Windows.Forms.Padding(4);
            this.group_Indumentaria.Name = "group_Indumentaria";
            this.group_Indumentaria.Padding = new System.Windows.Forms.Padding(4);
            this.group_Indumentaria.Size = new System.Drawing.Size(408, 47);
            this.group_Indumentaria.TabIndex = 16;
            this.group_Indumentaria.TabStop = false;
            this.group_Indumentaria.Text = "Necesita Indumentaria: ";
            // 
            // group_Ariculado
            // 
            this.group_Ariculado.BackColor = System.Drawing.Color.Transparent;
            this.group_Ariculado.Controls.Add(this.radio_ArticSi);
            this.group_Ariculado.Controls.Add(this.radio_ArticNo);
            this.group_Ariculado.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.group_Ariculado.Location = new System.Drawing.Point(16, 340);
            this.group_Ariculado.Margin = new System.Windows.Forms.Padding(4);
            this.group_Ariculado.Name = "group_Ariculado";
            this.group_Ariculado.Padding = new System.Windows.Forms.Padding(4);
            this.group_Ariculado.Size = new System.Drawing.Size(408, 51);
            this.group_Ariculado.TabIndex = 17;
            this.group_Ariculado.TabStop = false;
            this.group_Ariculado.Text = "Es Articulado:";
            // 
            // num_PartesEnsamblar
            // 
            this.num_PartesEnsamblar.BackColor = System.Drawing.Color.Firebrick;
            this.num_PartesEnsamblar.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_PartesEnsamblar.Location = new System.Drawing.Point(310, 217);
            this.num_PartesEnsamblar.Margin = new System.Windows.Forms.Padding(4);
            this.num_PartesEnsamblar.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.num_PartesEnsamblar.Name = "num_PartesEnsamblar";
            this.num_PartesEnsamblar.Size = new System.Drawing.Size(105, 28);
            this.num_PartesEnsamblar.TabIndex = 4;
            // 
            // FormRegistrarMuñeco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(449, 537);
            this.Controls.Add(this.num_PartesEnsamblar);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Guardar);
            this.Controls.Add(this.txt_Marca);
            this.Controls.Add(this.num_CantProd);
            this.Controls.Add(this.cmb_MateriaPrima);
            this.Controls.Add(this.lbl_Indumentaria);
            this.Controls.Add(this.lbl_CantPartes);
            this.Controls.Add(this.lbl_Marca);
            this.Controls.Add(this.lbl_CantidadProd);
            this.Controls.Add(this.lbl_MaterialPpal);
            this.Controls.Add(this.group_Indumentaria);
            this.Controls.Add(this.group_Ariculado);
            this.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRegistrarMuñeco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registrar Muñeco";
            this.Load += new System.EventHandler(this.FormRegistrarMuñeco_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_CantProd)).EndInit();
            this.group_Indumentaria.ResumeLayout(false);
            this.group_Indumentaria.PerformLayout();
            this.group_Ariculado.ResumeLayout(false);
            this.group_Ariculado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_PartesEnsamblar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_MaterialPpal;
        private System.Windows.Forms.Label lbl_CantidadProd;
        private System.Windows.Forms.Label lbl_Marca;
        private System.Windows.Forms.Label lbl_CantPartes;
        private System.Windows.Forms.Label lbl_Indumentaria;
        private System.Windows.Forms.ComboBox cmb_MateriaPrima;
        private System.Windows.Forms.NumericUpDown num_CantProd;
        private System.Windows.Forms.TextBox txt_Marca;
        private System.Windows.Forms.RadioButton radio_IndumSi;
        private System.Windows.Forms.RadioButton radio_IndumNo;
        private System.Windows.Forms.RadioButton radio_ArticNo;
        private System.Windows.Forms.RadioButton radio_ArticSi;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.GroupBox group_Indumentaria;
        private System.Windows.Forms.GroupBox group_Ariculado;
        private System.Windows.Forms.NumericUpDown num_PartesEnsamblar;
    }
}