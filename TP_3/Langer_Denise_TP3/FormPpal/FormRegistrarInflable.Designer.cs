
namespace Formularios
{
    partial class FormRegistrarInflable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistrarInflable));
            this.txt_Marca = new System.Windows.Forms.TextBox();
            this.num_CantProd = new System.Windows.Forms.NumericUpDown();
            this.cmb_Material = new System.Windows.Forms.ComboBox();
            this.lbl_Marca = new System.Windows.Forms.Label();
            this.lbl_CantProd = new System.Windows.Forms.Label();
            this.lbl_Material = new System.Windows.Forms.Label();
            this.cmb_Diseño = new System.Windows.Forms.ComboBox();
            this.lbl_Diseño = new System.Windows.Forms.Label();
            this.cmb_Color = new System.Windows.Forms.ComboBox();
            this.lbl_Color = new System.Windows.Forms.Label();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.num_CantProd)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_Marca
            // 
            this.txt_Marca.BackColor = System.Drawing.Color.YellowGreen;
            this.txt_Marca.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Marca.Location = new System.Drawing.Point(284, 209);
            this.txt_Marca.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_Marca.Name = "txt_Marca";
            this.txt_Marca.Size = new System.Drawing.Size(134, 28);
            this.txt_Marca.TabIndex = 3;
            // 
            // num_CantProd
            // 
            this.num_CantProd.BackColor = System.Drawing.Color.YellowGreen;
            this.num_CantProd.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_CantProd.Location = new System.Drawing.Point(284, 128);
            this.num_CantProd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.num_CantProd.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.num_CantProd.Name = "num_CantProd";
            this.num_CantProd.Size = new System.Drawing.Size(138, 28);
            this.num_CantProd.TabIndex = 2;
            // 
            // cmb_Material
            // 
            this.cmb_Material.BackColor = System.Drawing.Color.YellowGreen;
            this.cmb_Material.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Material.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Material.FormattingEnabled = true;
            this.cmb_Material.Location = new System.Drawing.Point(284, 49);
            this.cmb_Material.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmb_Material.Name = "cmb_Material";
            this.cmb_Material.Size = new System.Drawing.Size(138, 29);
            this.cmb_Material.TabIndex = 1;
            // 
            // lbl_Marca
            // 
            this.lbl_Marca.AutoSize = true;
            this.lbl_Marca.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Marca.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Marca.Location = new System.Drawing.Point(40, 209);
            this.lbl_Marca.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Marca.Name = "lbl_Marca";
            this.lbl_Marca.Size = new System.Drawing.Size(203, 27);
            this.lbl_Marca.TabIndex = 17;
            this.lbl_Marca.Text = "Marca del Juguete: ";
            // 
            // lbl_CantProd
            // 
            this.lbl_CantProd.AutoSize = true;
            this.lbl_CantProd.BackColor = System.Drawing.Color.Transparent;
            this.lbl_CantProd.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CantProd.Location = new System.Drawing.Point(42, 129);
            this.lbl_CantProd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_CantProd.Name = "lbl_CantProd";
            this.lbl_CantProd.Size = new System.Drawing.Size(201, 27);
            this.lbl_CantProd.TabIndex = 16;
            this.lbl_CantProd.Text = "Cantidad a Producir:";
            // 
            // lbl_Material
            // 
            this.lbl_Material.AutoSize = true;
            this.lbl_Material.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Material.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Material.Location = new System.Drawing.Point(42, 51);
            this.lbl_Material.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Material.Name = "lbl_Material";
            this.lbl_Material.Size = new System.Drawing.Size(189, 27);
            this.lbl_Material.TabIndex = 15;
            this.lbl_Material.Text = "Material Principal: ";
            // 
            // cmb_Diseño
            // 
            this.cmb_Diseño.BackColor = System.Drawing.Color.YellowGreen;
            this.cmb_Diseño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Diseño.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Diseño.FormattingEnabled = true;
            this.cmb_Diseño.Location = new System.Drawing.Point(284, 293);
            this.cmb_Diseño.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmb_Diseño.Name = "cmb_Diseño";
            this.cmb_Diseño.Size = new System.Drawing.Size(136, 29);
            this.cmb_Diseño.TabIndex = 4;
            // 
            // lbl_Diseño
            // 
            this.lbl_Diseño.AutoSize = true;
            this.lbl_Diseño.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Diseño.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Diseño.Location = new System.Drawing.Point(42, 292);
            this.lbl_Diseño.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Diseño.Name = "lbl_Diseño";
            this.lbl_Diseño.Size = new System.Drawing.Size(87, 27);
            this.lbl_Diseño.TabIndex = 21;
            this.lbl_Diseño.Text = "Diseño: ";
            // 
            // cmb_Color
            // 
            this.cmb_Color.BackColor = System.Drawing.Color.YellowGreen;
            this.cmb_Color.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Color.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Color.FormattingEnabled = true;
            this.cmb_Color.Location = new System.Drawing.Point(282, 379);
            this.cmb_Color.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmb_Color.Name = "cmb_Color";
            this.cmb_Color.Size = new System.Drawing.Size(136, 29);
            this.cmb_Color.TabIndex = 5;
            // 
            // lbl_Color
            // 
            this.lbl_Color.AutoSize = true;
            this.lbl_Color.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Color.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Color.Location = new System.Drawing.Point(40, 378);
            this.lbl_Color.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Color.Name = "lbl_Color";
            this.lbl_Color.Size = new System.Drawing.Size(157, 27);
            this.lbl_Color.TabIndex = 23;
            this.lbl_Color.Text = "Color Principal: ";
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.BackColor = System.Drawing.Color.White;
            this.btn_Guardar.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Guardar.Location = new System.Drawing.Point(168, 454);
            this.btn_Guardar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(112, 37);
            this.btn_Guardar.TabIndex = 6;
            this.btn_Guardar.Text = "Guardar";
            this.btn_Guardar.UseVisualStyleBackColor = false;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.BackColor = System.Drawing.Color.White;
            this.btn_Cancelar.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancelar.Location = new System.Drawing.Point(310, 454);
            this.btn_Cancelar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(112, 37);
            this.btn_Cancelar.TabIndex = 7;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = false;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // FormRegistrarInflable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FormPpal.Properties.Resources._224dfeef77923e3d0ebc9845d5c4744d;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(452, 517);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Guardar);
            this.Controls.Add(this.cmb_Color);
            this.Controls.Add(this.lbl_Color);
            this.Controls.Add(this.cmb_Diseño);
            this.Controls.Add(this.lbl_Diseño);
            this.Controls.Add(this.txt_Marca);
            this.Controls.Add(this.num_CantProd);
            this.Controls.Add(this.cmb_Material);
            this.Controls.Add(this.lbl_Marca);
            this.Controls.Add(this.lbl_CantProd);
            this.Controls.Add(this.lbl_Material);
            this.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRegistrarInflable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Registrar Inflable";
            this.Load += new System.EventHandler(this.FormRegistrarInflable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_CantProd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Marca;
        private System.Windows.Forms.NumericUpDown num_CantProd;
        private System.Windows.Forms.ComboBox cmb_Material;
        private System.Windows.Forms.Label lbl_Marca;
        private System.Windows.Forms.Label lbl_CantProd;
        private System.Windows.Forms.Label lbl_Material;
        private System.Windows.Forms.ComboBox cmb_Diseño;
        private System.Windows.Forms.Label lbl_Diseño;
        private System.Windows.Forms.ComboBox cmb_Color;
        private System.Windows.Forms.Label lbl_Color;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button btn_Cancelar;
    }
}