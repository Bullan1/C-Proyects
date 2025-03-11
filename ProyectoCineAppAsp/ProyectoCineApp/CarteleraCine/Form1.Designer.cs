namespace CarteleraCine
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCRUD = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCRUD
            // 
            this.btnCRUD.Location = new System.Drawing.Point(32, 37);
            this.btnCRUD.Name = "btnCRUD";
            this.btnCRUD.Size = new System.Drawing.Size(153, 64);
            this.btnCRUD.TabIndex = 0;
            this.btnCRUD.Text = "CRUD Pelicula";
            this.btnCRUD.UseVisualStyleBackColor = true;
            this.btnCRUD.Click += new System.EventHandler(this.btnCRUD_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCRUD);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCRUD;
    }
}

