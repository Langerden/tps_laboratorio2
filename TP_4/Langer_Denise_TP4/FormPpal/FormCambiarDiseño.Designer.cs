
namespace Formularios
{
    partial class FormCambiarDiseño
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCambiarDiseño));
            this.btn_Seleccionar = new System.Windows.Forms.Button();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.cmb_Clases = new System.Windows.Forms.ComboBox();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btnSQLHistorial = new System.Windows.Forms.Button();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Seleccionar
            // 
            this.btn_Seleccionar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Seleccionar.Enabled = false;
            this.btn_Seleccionar.Location = new System.Drawing.Point(533, 393);
            this.btn_Seleccionar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_Seleccionar.Name = "btn_Seleccionar";
            this.btn_Seleccionar.Size = new System.Drawing.Size(109, 50);
            this.btn_Seleccionar.TabIndex = 1;
            this.btn_Seleccionar.Text = "Editar";
            this.btn_Seleccionar.UseVisualStyleBackColor = false;
            this.btn_Seleccionar.Click += new System.EventHandler(this.btn_Seleccionar_Click);
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToResizeColumns = false;
            this.dataGrid.AllowUserToResizeRows = false;
            this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid.BackgroundColor = System.Drawing.Color.White;
            this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.GridColor = System.Drawing.Color.DarkBlue;
            this.dataGrid.Location = new System.Drawing.Point(53, 115);
            this.dataGrid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGrid.MultiSelect = false;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.RowHeadersWidth = 50;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dataGrid.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(717, 242);
            this.dataGrid.StandardTab = true;
            this.dataGrid.TabIndex = 4;
            // 
            // cmb_Clases
            // 
            this.cmb_Clases.BackColor = System.Drawing.Color.SkyBlue;
            this.cmb_Clases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Clases.ForeColor = System.Drawing.Color.DarkBlue;
            this.cmb_Clases.FormattingEnabled = true;
            this.cmb_Clases.Location = new System.Drawing.Point(53, 54);
            this.cmb_Clases.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmb_Clases.Name = "cmb_Clases";
            this.cmb_Clases.Size = new System.Drawing.Size(180, 29);
            this.cmb_Clases.TabIndex = 5;
            this.cmb_Clases.SelectedValueChanged += new System.EventHandler(this.cmb_Clases_SelectedValueChanged);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Cancelar.Location = new System.Drawing.Point(53, 393);
            this.btn_Cancelar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(120, 50);
            this.btn_Cancelar.TabIndex = 8;
            this.btn_Cancelar.Text = "Volver Atras";
            this.btn_Cancelar.UseVisualStyleBackColor = false;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // btnSQLHistorial
            // 
            this.btnSQLHistorial.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSQLHistorial.Location = new System.Drawing.Point(533, 54);
            this.btnSQLHistorial.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSQLHistorial.Name = "btnSQLHistorial";
            this.btnSQLHistorial.Size = new System.Drawing.Size(185, 29);
            this.btnSQLHistorial.TabIndex = 9;
            this.btnSQLHistorial.Text = "Historial Completo";
            this.btnSQLHistorial.UseVisualStyleBackColor = false;
            this.btnSQLHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Eliminar.Enabled = false;
            this.btn_Eliminar.Location = new System.Drawing.Point(661, 393);
            this.btn_Eliminar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(109, 50);
            this.btn_Eliminar.TabIndex = 10;
            this.btn_Eliminar.Text = "Eliminar";
            this.btn_Eliminar.UseVisualStyleBackColor = false;
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click);
            // 
            // FormCambiarDiseño
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(806, 464);
            this.Controls.Add(this.btn_Eliminar);
            this.Controls.Add(this.btnSQLHistorial);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.cmb_Clases);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.btn_Seleccionar);
            this.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCambiarDiseño";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cambiar Diseño";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCambiarDiseño_FormClosing);
            this.Load += new System.EventHandler(this.FormCambiarDiseño_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Seleccionar;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.ComboBox cmb_Clases;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button btnSQLHistorial;
        private System.Windows.Forms.Button btn_Eliminar;
    }
}