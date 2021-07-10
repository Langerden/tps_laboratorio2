
namespace Formularios
{
    partial class FormMateriales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMateriales));
            this.group_CantidadActual = new System.Windows.Forms.GroupBox();
            this.txt_Hilo = new System.Windows.Forms.TextBox();
            this.lbl_HiloActual = new System.Windows.Forms.Label();
            this.txt_Tela = new System.Windows.Forms.TextBox();
            this.lbl_TelaActual = new System.Windows.Forms.Label();
            this.txt_Plastico = new System.Windows.Forms.TextBox();
            this.lbl_PlasticoActual = new System.Windows.Forms.Label();
            this.group_Comprar = new System.Windows.Forms.GroupBox();
            this.num_Hilo = new System.Windows.Forms.NumericUpDown();
            this.num_Tela = new System.Windows.Forms.NumericUpDown();
            this.num_Plastico = new System.Windows.Forms.NumericUpDown();
            this.lbl_HiloComprar = new System.Windows.Forms.Label();
            this.lbl_TelaComprar = new System.Windows.Forms.Label();
            this.lbl_PlasticoComprar = new System.Windows.Forms.Label();
            this.btn_Comprar = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.group_CantidadActual.SuspendLayout();
            this.group_Comprar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Hilo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Tela)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Plastico)).BeginInit();
            this.SuspendLayout();
            // 
            // group_CantidadActual
            // 
            this.group_CantidadActual.BackColor = System.Drawing.Color.LightBlue;
            this.group_CantidadActual.Controls.Add(this.txt_Hilo);
            this.group_CantidadActual.Controls.Add(this.lbl_HiloActual);
            this.group_CantidadActual.Controls.Add(this.txt_Tela);
            this.group_CantidadActual.Controls.Add(this.lbl_TelaActual);
            this.group_CantidadActual.Controls.Add(this.txt_Plastico);
            this.group_CantidadActual.Controls.Add(this.lbl_PlasticoActual);
            this.group_CantidadActual.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.group_CantidadActual.Location = new System.Drawing.Point(49, 44);
            this.group_CantidadActual.Name = "group_CantidadActual";
            this.group_CantidadActual.Size = new System.Drawing.Size(583, 102);
            this.group_CantidadActual.TabIndex = 0;
            this.group_CantidadActual.TabStop = false;
            this.group_CantidadActual.Text = "Cantidad Actual";
            // 
            // txt_Hilo
            // 
            this.txt_Hilo.Enabled = false;
            this.txt_Hilo.Location = new System.Drawing.Point(452, 46);
            this.txt_Hilo.Name = "txt_Hilo";
            this.txt_Hilo.Size = new System.Drawing.Size(100, 28);
            this.txt_Hilo.TabIndex = 5;
            // 
            // lbl_HiloActual
            // 
            this.lbl_HiloActual.AutoSize = true;
            this.lbl_HiloActual.Location = new System.Drawing.Point(401, 49);
            this.lbl_HiloActual.Name = "lbl_HiloActual";
            this.lbl_HiloActual.Size = new System.Drawing.Size(45, 21);
            this.lbl_HiloActual.TabIndex = 4;
            this.lbl_HiloActual.Text = "Hilo:";
            // 
            // txt_Tela
            // 
            this.txt_Tela.Enabled = false;
            this.txt_Tela.Location = new System.Drawing.Point(269, 46);
            this.txt_Tela.Name = "txt_Tela";
            this.txt_Tela.Size = new System.Drawing.Size(100, 28);
            this.txt_Tela.TabIndex = 3;
            // 
            // lbl_TelaActual
            // 
            this.lbl_TelaActual.AutoSize = true;
            this.lbl_TelaActual.Location = new System.Drawing.Point(216, 49);
            this.lbl_TelaActual.Name = "lbl_TelaActual";
            this.lbl_TelaActual.Size = new System.Drawing.Size(47, 21);
            this.lbl_TelaActual.TabIndex = 2;
            this.lbl_TelaActual.Text = "Tela:";
            // 
            // txt_Plastico
            // 
            this.txt_Plastico.Enabled = false;
            this.txt_Plastico.Location = new System.Drawing.Point(94, 46);
            this.txt_Plastico.Name = "txt_Plastico";
            this.txt_Plastico.Size = new System.Drawing.Size(100, 28);
            this.txt_Plastico.TabIndex = 1;
            // 
            // lbl_PlasticoActual
            // 
            this.lbl_PlasticoActual.AutoSize = true;
            this.lbl_PlasticoActual.Location = new System.Drawing.Point(17, 49);
            this.lbl_PlasticoActual.Name = "lbl_PlasticoActual";
            this.lbl_PlasticoActual.Size = new System.Drawing.Size(71, 21);
            this.lbl_PlasticoActual.TabIndex = 0;
            this.lbl_PlasticoActual.Text = "Plastico:";
            // 
            // group_Comprar
            // 
            this.group_Comprar.BackColor = System.Drawing.Color.LightBlue;
            this.group_Comprar.Controls.Add(this.num_Hilo);
            this.group_Comprar.Controls.Add(this.num_Tela);
            this.group_Comprar.Controls.Add(this.num_Plastico);
            this.group_Comprar.Controls.Add(this.lbl_HiloComprar);
            this.group_Comprar.Controls.Add(this.lbl_TelaComprar);
            this.group_Comprar.Controls.Add(this.lbl_PlasticoComprar);
            this.group_Comprar.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.group_Comprar.Location = new System.Drawing.Point(49, 181);
            this.group_Comprar.Name = "group_Comprar";
            this.group_Comprar.Size = new System.Drawing.Size(583, 100);
            this.group_Comprar.TabIndex = 1;
            this.group_Comprar.TabStop = false;
            this.group_Comprar.Text = "Cantidad a Comprar";
            // 
            // num_Hilo
            // 
            this.num_Hilo.Location = new System.Drawing.Point(452, 46);
            this.num_Hilo.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.num_Hilo.Name = "num_Hilo";
            this.num_Hilo.Size = new System.Drawing.Size(100, 28);
            this.num_Hilo.TabIndex = 9;
            // 
            // num_Tela
            // 
            this.num_Tela.Location = new System.Drawing.Point(269, 51);
            this.num_Tela.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.num_Tela.Name = "num_Tela";
            this.num_Tela.Size = new System.Drawing.Size(100, 28);
            this.num_Tela.TabIndex = 8;
            // 
            // num_Plastico
            // 
            this.num_Plastico.Location = new System.Drawing.Point(94, 49);
            this.num_Plastico.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.num_Plastico.Name = "num_Plastico";
            this.num_Plastico.Size = new System.Drawing.Size(100, 28);
            this.num_Plastico.TabIndex = 7;
            // 
            // lbl_HiloComprar
            // 
            this.lbl_HiloComprar.AutoSize = true;
            this.lbl_HiloComprar.Location = new System.Drawing.Point(401, 51);
            this.lbl_HiloComprar.Name = "lbl_HiloComprar";
            this.lbl_HiloComprar.Size = new System.Drawing.Size(45, 21);
            this.lbl_HiloComprar.TabIndex = 6;
            this.lbl_HiloComprar.Text = "Hilo:";
            // 
            // lbl_TelaComprar
            // 
            this.lbl_TelaComprar.AutoSize = true;
            this.lbl_TelaComprar.Location = new System.Drawing.Point(216, 53);
            this.lbl_TelaComprar.Name = "lbl_TelaComprar";
            this.lbl_TelaComprar.Size = new System.Drawing.Size(47, 21);
            this.lbl_TelaComprar.TabIndex = 6;
            this.lbl_TelaComprar.Text = "Tela:";
            // 
            // lbl_PlasticoComprar
            // 
            this.lbl_PlasticoComprar.AutoSize = true;
            this.lbl_PlasticoComprar.Location = new System.Drawing.Point(17, 53);
            this.lbl_PlasticoComprar.Name = "lbl_PlasticoComprar";
            this.lbl_PlasticoComprar.Size = new System.Drawing.Size(71, 21);
            this.lbl_PlasticoComprar.TabIndex = 6;
            this.lbl_PlasticoComprar.Text = "Plastico:";
            // 
            // btn_Comprar
            // 
            this.btn_Comprar.BackColor = System.Drawing.Color.White;
            this.btn_Comprar.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Comprar.Location = new System.Drawing.Point(409, 298);
            this.btn_Comprar.Name = "btn_Comprar";
            this.btn_Comprar.Size = new System.Drawing.Size(86, 32);
            this.btn_Comprar.TabIndex = 2;
            this.btn_Comprar.Text = "Comprar";
            this.btn_Comprar.UseVisualStyleBackColor = false;
            this.btn_Comprar.Click += new System.EventHandler(this.btn_Comprar_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.BackColor = System.Drawing.Color.White;
            this.btn_Cancelar.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancelar.Location = new System.Drawing.Point(523, 298);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(89, 32);
            this.btn_Cancelar.TabIndex = 3;
            this.btn_Cancelar.Text = "Volver";
            this.btn_Cancelar.UseVisualStyleBackColor = false;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // FormMateriales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FormPpal.Properties.Resources._112_1124168_fondos_de_pantalla_de_toy_story;
            this.ClientSize = new System.Drawing.Size(651, 349);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Comprar);
            this.Controls.Add(this.group_Comprar);
            this.Controls.Add(this.group_CantidadActual);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMateriales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Comprar Materiales";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMateriales_FormClosing);
            this.Load += new System.EventHandler(this.FormMateriales_Load);
            this.group_CantidadActual.ResumeLayout(false);
            this.group_CantidadActual.PerformLayout();
            this.group_Comprar.ResumeLayout(false);
            this.group_Comprar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Hilo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Tela)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Plastico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox group_CantidadActual;
        private System.Windows.Forms.TextBox txt_Plastico;
        private System.Windows.Forms.TextBox txt_Tela;
        private System.Windows.Forms.TextBox txt_Hilo;
        private System.Windows.Forms.Label lbl_TelaActual;
        private System.Windows.Forms.Label lbl_PlasticoActual;
        private System.Windows.Forms.Label lbl_HiloActual;
        private System.Windows.Forms.GroupBox group_Comprar;
        private System.Windows.Forms.NumericUpDown num_Hilo;
        private System.Windows.Forms.NumericUpDown num_Tela;
        private System.Windows.Forms.NumericUpDown num_Plastico;
        private System.Windows.Forms.Label lbl_HiloComprar;
        private System.Windows.Forms.Label lbl_TelaComprar;
        private System.Windows.Forms.Label lbl_PlasticoComprar;
        private System.Windows.Forms.Button btn_Comprar;
        private System.Windows.Forms.Button btn_Cancelar;
    }
}