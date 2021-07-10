
namespace FormPpal
{
    partial class FormSQL
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSQL));
            this.dataPeluche = new System.Windows.Forms.DataGridView();
            this.btnContar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.dataInflable = new System.Windows.Forms.DataGridView();
            this.dataMuñeco = new System.Windows.Forms.DataGridView();
            this.lblPeluche = new System.Windows.Forms.Label();
            this.lblInflable = new System.Windows.Forms.Label();
            this.lblMuñeco = new System.Windows.Forms.Label();
            this.lblContar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataPeluche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataInflable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataMuñeco)).BeginInit();
            this.SuspendLayout();
            // 
            // dataPeluche
            // 
            this.dataPeluche.AllowUserToAddRows = false;
            this.dataPeluche.AllowUserToDeleteRows = false;
            this.dataPeluche.AllowUserToResizeColumns = false;
            this.dataPeluche.AllowUserToResizeRows = false;
            this.dataPeluche.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataPeluche.BackgroundColor = System.Drawing.Color.White;
            this.dataPeluche.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataPeluche.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataPeluche.GridColor = System.Drawing.Color.DarkBlue;
            this.dataPeluche.Location = new System.Drawing.Point(74, 22);
            this.dataPeluche.Margin = new System.Windows.Forms.Padding(5);
            this.dataPeluche.MultiSelect = false;
            this.dataPeluche.Name = "dataPeluche";
            this.dataPeluche.ReadOnly = true;
            this.dataPeluche.RowHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataPeluche.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataPeluche.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataPeluche.Size = new System.Drawing.Size(763, 161);
            this.dataPeluche.TabIndex = 0;
            this.dataPeluche.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataPeluche_CellDoubleClick);
            // 
            // btnContar
            // 
            this.btnContar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnContar.Location = new System.Drawing.Point(209, 584);
            this.btnContar.Margin = new System.Windows.Forms.Padding(5);
            this.btnContar.Name = "btnContar";
            this.btnContar.Size = new System.Drawing.Size(158, 30);
            this.btnContar.TabIndex = 10;
            this.btnContar.Text = "Total Registros:";
            this.btnContar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnContar.UseVisualStyleBackColor = false;
            this.btnContar.Click += new System.EventHandler(this.btnContar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnVolver.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(32, 584);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(5);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(123, 29);
            this.btnVolver.TabIndex = 12;
            this.btnVolver.Text = "Volver atras";
            this.btnVolver.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // dataInflable
            // 
            this.dataInflable.AllowUserToAddRows = false;
            this.dataInflable.AllowUserToDeleteRows = false;
            this.dataInflable.AllowUserToResizeColumns = false;
            this.dataInflable.AllowUserToResizeRows = false;
            this.dataInflable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataInflable.BackgroundColor = System.Drawing.Color.White;
            this.dataInflable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataInflable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataInflable.GridColor = System.Drawing.Color.DarkBlue;
            this.dataInflable.Location = new System.Drawing.Point(74, 205);
            this.dataInflable.Margin = new System.Windows.Forms.Padding(5);
            this.dataInflable.MultiSelect = false;
            this.dataInflable.Name = "dataInflable";
            this.dataInflable.ReadOnly = true;
            this.dataInflable.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataInflable.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataInflable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataInflable.Size = new System.Drawing.Size(763, 184);
            this.dataInflable.TabIndex = 14;
            this.dataInflable.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataInflable_CellContentDoubleClick);
            // 
            // dataMuñeco
            // 
            this.dataMuñeco.AllowUserToAddRows = false;
            this.dataMuñeco.AllowUserToDeleteRows = false;
            this.dataMuñeco.AllowUserToResizeColumns = false;
            this.dataMuñeco.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dataMuñeco.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataMuñeco.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataMuñeco.BackgroundColor = System.Drawing.Color.White;
            this.dataMuñeco.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataMuñeco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataMuñeco.GridColor = System.Drawing.Color.DarkBlue;
            this.dataMuñeco.Location = new System.Drawing.Point(74, 415);
            this.dataMuñeco.Margin = new System.Windows.Forms.Padding(5);
            this.dataMuñeco.MultiSelect = false;
            this.dataMuñeco.Name = "dataMuñeco";
            this.dataMuñeco.ReadOnly = true;
            this.dataMuñeco.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataMuñeco.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataMuñeco.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataMuñeco.Size = new System.Drawing.Size(763, 138);
            this.dataMuñeco.TabIndex = 15;
            this.dataMuñeco.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataMuñeco_CellDoubleClick);
            // 
            // lblPeluche
            // 
            this.lblPeluche.AutoSize = true;
            this.lblPeluche.Location = new System.Drawing.Point(36, 22);
            this.lblPeluche.Name = "lblPeluche";
            this.lblPeluche.Size = new System.Drawing.Size(22, 161);
            this.lblPeluche.TabIndex = 16;
            this.lblPeluche.Text = "P\r\nE\r\nL\r\nU\r\nC\r\nH\r\nE";
            this.lblPeluche.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblInflable
            // 
            this.lblInflable.AutoSize = true;
            this.lblInflable.Location = new System.Drawing.Point(35, 205);
            this.lblInflable.Name = "lblInflable";
            this.lblInflable.Size = new System.Drawing.Size(23, 184);
            this.lblInflable.TabIndex = 17;
            this.lblInflable.Text = "I\r\nN\r\nF\r\nL\r\nA\r\nB\r\nL\r\nE";
            this.lblInflable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMuñeco
            // 
            this.lblMuñeco.AutoSize = true;
            this.lblMuñeco.Location = new System.Drawing.Point(35, 415);
            this.lblMuñeco.Name = "lblMuñeco";
            this.lblMuñeco.Size = new System.Drawing.Size(24, 138);
            this.lblMuñeco.TabIndex = 18;
            this.lblMuñeco.Text = "M\r\nU\r\nÑ\r\nE\r\nC\r\nO";
            this.lblMuñeco.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblContar
            // 
            this.lblContar.AutoSize = true;
            this.lblContar.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblContar.Location = new System.Drawing.Point(398, 587);
            this.lblContar.Name = "lblContar";
            this.lblContar.Size = new System.Drawing.Size(0, 23);
            this.lblContar.TabIndex = 20;
            // 
            // FormSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FormPpal.Properties.Resources._112_1124168_fondos_de_pantalla_de_toy_story;
            this.ClientSize = new System.Drawing.Size(859, 626);
            this.Controls.Add(this.lblContar);
            this.Controls.Add(this.lblMuñeco);
            this.Controls.Add(this.lblInflable);
            this.Controls.Add(this.lblPeluche);
            this.Controls.Add(this.dataMuñeco);
            this.Controls.Add(this.dataInflable);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnContar);
            this.Controls.Add(this.dataPeluche);
            this.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSQL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormSQL";
            this.Load += new System.EventHandler(this.FormSQL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataPeluche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataInflable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataMuñeco)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnContar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DataGridView dataInflable;
        private System.Windows.Forms.DataGridView dataMuñeco;
        private System.Windows.Forms.DataGridView dataPeluche;
        private System.Windows.Forms.Label lblPeluche;
        private System.Windows.Forms.Label lblInflable;
        private System.Windows.Forms.Label lblMuñeco;
        private System.Windows.Forms.Label lblContar;
    }
}