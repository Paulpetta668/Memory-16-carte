
namespace Memory_16_carte
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Mosse_labels = new System.Windows.Forms.Label();
            this.Punti_label = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Mosse_labels
            // 
            this.Mosse_labels.AutoSize = true;
            this.Mosse_labels.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mosse_labels.Location = new System.Drawing.Point(418, 54);
            this.Mosse_labels.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Mosse_labels.Name = "Mosse_labels";
            this.Mosse_labels.Size = new System.Drawing.Size(97, 24);
            this.Mosse_labels.TabIndex = 0;
            this.Mosse_labels.Text = "Mosse = 0";
            // 
            // Punti_label
            // 
            this.Punti_label.AutoSize = true;
            this.Punti_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Punti_label.Location = new System.Drawing.Point(418, 87);
            this.Punti_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Punti_label.Name = "Punti_label";
            this.Punti_label.Size = new System.Drawing.Size(83, 24);
            this.Punti_label.TabIndex = 1;
            this.Punti_label.Text = "Punti = 0";
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.Punti_label);
            this.Controls.Add(this.Mosse_labels);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Mosse_labels;
        private System.Windows.Forms.Label Punti_label;
        private System.Windows.Forms.Timer timer1;
    }
}

