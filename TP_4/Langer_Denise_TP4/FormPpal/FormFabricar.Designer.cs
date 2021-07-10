
namespace FormPpal
{
    partial class FormFabricar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFabricar));
            this.bar_Fabricar = new System.Windows.Forms.ProgressBar();
            this.lbl_Fabricar = new System.Windows.Forms.Label();
            this.btn_Aceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bar_Fabricar
            // 
            this.bar_Fabricar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.bar_Fabricar.ForeColor = System.Drawing.Color.Black;
            this.bar_Fabricar.Location = new System.Drawing.Point(30, 59);
            this.bar_Fabricar.Name = "bar_Fabricar";
            this.bar_Fabricar.Size = new System.Drawing.Size(479, 36);
            this.bar_Fabricar.TabIndex = 0;
            // 
            // lbl_Fabricar
            // 
            this.lbl_Fabricar.AutoSize = true;
            this.lbl_Fabricar.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Fabricar.Location = new System.Drawing.Point(26, 20);
            this.lbl_Fabricar.Name = "lbl_Fabricar";
            this.lbl_Fabricar.Size = new System.Drawing.Size(136, 27);
            this.lbl_Fabricar.TabIndex = 1;
            this.lbl_Fabricar.Text = "Fabricando...";
            // 
            // btn_Aceptar
            // 
            this.btn_Aceptar.BackColor = System.Drawing.Color.White;
            this.btn_Aceptar.Enabled = false;
            this.btn_Aceptar.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Aceptar.Location = new System.Drawing.Point(408, 108);
            this.btn_Aceptar.Name = "btn_Aceptar";
            this.btn_Aceptar.Size = new System.Drawing.Size(101, 33);
            this.btn_Aceptar.TabIndex = 2;
            this.btn_Aceptar.Text = "Aceptar";
            this.btn_Aceptar.UseVisualStyleBackColor = false;
            this.btn_Aceptar.Click += new System.EventHandler(this.btn_Aceptar_Click);
            // 
            // FormFabricar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(529, 153);
            this.Controls.Add(this.btn_Aceptar);
            this.Controls.Add(this.lbl_Fabricar);
            this.Controls.Add(this.bar_Fabricar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFabricar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormFabricar";
            this.Load += new System.EventHandler(this.FormFabricar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar bar_Fabricar;
        private System.Windows.Forms.Label lbl_Fabricar;
        private System.Windows.Forms.Button btn_Aceptar;
    }
}