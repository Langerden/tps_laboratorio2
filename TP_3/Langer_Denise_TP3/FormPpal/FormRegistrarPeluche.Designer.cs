
namespace Formularios
{
    partial class FormRegistrarPeluche
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistrarPeluche));
            this.txt_Marca = new System.Windows.Forms.TextBox();
            this.num_CantProd = new System.Windows.Forms.NumericUpDown();
            this.cmb_Material = new System.Windows.Forms.ComboBox();
            this.lbl_Marca = new System.Windows.Forms.Label();
            this.lbl_CantProd = new System.Windows.Forms.Label();
            this.lbl_Material = new System.Windows.Forms.Label();
            this.txt_Modelo = new System.Windows.Forms.TextBox();
            this.lbl_Modelo = new System.Windows.Forms.Label();
            this.cmb_Color = new System.Windows.Forms.ComboBox();
            this.lbl_Color = new System.Windows.Forms.Label();
            this.lbl_Tamaño = new System.Windows.Forms.Label();
            this.num_Tamaño = new System.Windows.Forms.NumericUpDown();
            this.group_Medida = new System.Windows.Forms.GroupBox();
            this.radio_Milim = new System.Windows.Forms.RadioButton();
            this.radio_Centimetro = new System.Windows.Forms.RadioButton();
            this.radio_Metro = new System.Windows.Forms.RadioButton();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.num_CantProd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Tamaño)).BeginInit();
            this.group_Medida.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_Marca
            // 
            this.txt_Marca.BackColor = System.Drawing.Color.MediumOrchid;
            resources.ApplyResources(this.txt_Marca, "txt_Marca");
            this.txt_Marca.Name = "txt_Marca";
            // 
            // num_CantProd
            // 
            this.num_CantProd.BackColor = System.Drawing.Color.MediumOrchid;
            resources.ApplyResources(this.num_CantProd, "num_CantProd");
            this.num_CantProd.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.num_CantProd.Name = "num_CantProd";
            // 
            // cmb_Material
            // 
            this.cmb_Material.BackColor = System.Drawing.Color.MediumOrchid;
            this.cmb_Material.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmb_Material, "cmb_Material");
            this.cmb_Material.FormattingEnabled = true;
            this.cmb_Material.Name = "cmb_Material";
            // 
            // lbl_Marca
            // 
            resources.ApplyResources(this.lbl_Marca, "lbl_Marca");
            this.lbl_Marca.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Marca.Name = "lbl_Marca";
            // 
            // lbl_CantProd
            // 
            resources.ApplyResources(this.lbl_CantProd, "lbl_CantProd");
            this.lbl_CantProd.BackColor = System.Drawing.Color.Transparent;
            this.lbl_CantProd.Name = "lbl_CantProd";
            // 
            // lbl_Material
            // 
            resources.ApplyResources(this.lbl_Material, "lbl_Material");
            this.lbl_Material.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Material.Name = "lbl_Material";
            // 
            // txt_Modelo
            // 
            this.txt_Modelo.BackColor = System.Drawing.Color.MediumOrchid;
            resources.ApplyResources(this.txt_Modelo, "txt_Modelo");
            this.txt_Modelo.Name = "txt_Modelo";
            // 
            // lbl_Modelo
            // 
            resources.ApplyResources(this.lbl_Modelo, "lbl_Modelo");
            this.lbl_Modelo.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Modelo.Name = "lbl_Modelo";
            // 
            // cmb_Color
            // 
            this.cmb_Color.BackColor = System.Drawing.Color.MediumOrchid;
            this.cmb_Color.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cmb_Color, "cmb_Color");
            this.cmb_Color.FormattingEnabled = true;
            this.cmb_Color.Name = "cmb_Color";
            // 
            // lbl_Color
            // 
            resources.ApplyResources(this.lbl_Color, "lbl_Color");
            this.lbl_Color.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Color.Name = "lbl_Color";
            // 
            // lbl_Tamaño
            // 
            resources.ApplyResources(this.lbl_Tamaño, "lbl_Tamaño");
            this.lbl_Tamaño.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Tamaño.Name = "lbl_Tamaño";
            // 
            // num_Tamaño
            // 
            this.num_Tamaño.BackColor = System.Drawing.Color.MediumOrchid;
            resources.ApplyResources(this.num_Tamaño, "num_Tamaño");
            this.num_Tamaño.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_Tamaño.Name = "num_Tamaño";
            // 
            // group_Medida
            // 
            this.group_Medida.BackColor = System.Drawing.Color.Transparent;
            this.group_Medida.Controls.Add(this.radio_Milim);
            this.group_Medida.Controls.Add(this.radio_Centimetro);
            this.group_Medida.Controls.Add(this.radio_Metro);
            resources.ApplyResources(this.group_Medida, "group_Medida");
            this.group_Medida.Name = "group_Medida";
            this.group_Medida.TabStop = false;
            // 
            // radio_Milim
            // 
            resources.ApplyResources(this.radio_Milim, "radio_Milim");
            this.radio_Milim.Name = "radio_Milim";
            this.radio_Milim.TabStop = true;
            this.radio_Milim.UseVisualStyleBackColor = true;
            this.radio_Milim.CheckedChanged += new System.EventHandler(this.radio_Milim_CheckedChanged);
            // 
            // radio_Centimetro
            // 
            resources.ApplyResources(this.radio_Centimetro, "radio_Centimetro");
            this.radio_Centimetro.Checked = true;
            this.radio_Centimetro.Name = "radio_Centimetro";
            this.radio_Centimetro.TabStop = true;
            this.radio_Centimetro.UseVisualStyleBackColor = true;
            // 
            // radio_Metro
            // 
            resources.ApplyResources(this.radio_Metro, "radio_Metro");
            this.radio_Metro.Name = "radio_Metro";
            this.radio_Metro.TabStop = true;
            this.radio_Metro.UseVisualStyleBackColor = true;
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.BackColor = System.Drawing.Color.MediumOrchid;
            resources.ApplyResources(this.btn_Guardar, "btn_Guardar");
            this.btn_Guardar.ForeColor = System.Drawing.Color.Black;
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.UseVisualStyleBackColor = false;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.BackColor = System.Drawing.Color.MediumOrchid;
            resources.ApplyResources(this.btn_Cancelar, "btn_Cancelar");
            this.btn_Cancelar.ForeColor = System.Drawing.Color.Black;
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = false;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // FormRegistrarPeluche
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FormPpal.Properties.Resources._1a7fafcd964eba2fb5026f96188c8e3c;
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Guardar);
            this.Controls.Add(this.group_Medida);
            this.Controls.Add(this.num_Tamaño);
            this.Controls.Add(this.lbl_Tamaño);
            this.Controls.Add(this.cmb_Color);
            this.Controls.Add(this.lbl_Color);
            this.Controls.Add(this.txt_Modelo);
            this.Controls.Add(this.lbl_Modelo);
            this.Controls.Add(this.txt_Marca);
            this.Controls.Add(this.num_CantProd);
            this.Controls.Add(this.cmb_Material);
            this.Controls.Add(this.lbl_Marca);
            this.Controls.Add(this.lbl_CantProd);
            this.Controls.Add(this.lbl_Material);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRegistrarPeluche";
            this.Load += new System.EventHandler(this.FormRegistrarPeluche_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_CantProd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Tamaño)).EndInit();
            this.group_Medida.ResumeLayout(false);
            this.group_Medida.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Marca;
        private System.Windows.Forms.TextBox txt_Modelo;
        private System.Windows.Forms.NumericUpDown num_CantProd;
        private System.Windows.Forms.NumericUpDown num_Tamaño;
        private System.Windows.Forms.ComboBox cmb_Material;
        private System.Windows.Forms.ComboBox cmb_Color;
        private System.Windows.Forms.Label lbl_Marca;
        private System.Windows.Forms.Label lbl_CantProd;
        private System.Windows.Forms.Label lbl_Material;
        private System.Windows.Forms.Label lbl_Color;
        private System.Windows.Forms.Label lbl_Modelo;
        private System.Windows.Forms.Label lbl_Tamaño;
        private System.Windows.Forms.GroupBox group_Medida;
        private System.Windows.Forms.RadioButton radio_Milim;
        private System.Windows.Forms.RadioButton radio_Centimetro;
        private System.Windows.Forms.RadioButton radio_Metro;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button btn_Cancelar;
    }
}