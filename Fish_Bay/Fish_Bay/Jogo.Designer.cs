namespace Fish_Bay
{
    partial class Jogo
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
            this.components = new System.ComponentModel.Container();
            this.pbDesenho = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbDesenho)).BeginInit();
            this.SuspendLayout();
            // 
            // pbDesenho
            // 
            this.pbDesenho.Image = global::Fish_Bay.Properties.Resources.imagem_fundo_jogo;
            this.pbDesenho.Location = new System.Drawing.Point(0, -2);
            this.pbDesenho.Name = "pbDesenho";
            this.pbDesenho.Size = new System.Drawing.Size(1270, 576);
            this.pbDesenho.TabIndex = 0;
            this.pbDesenho.TabStop = false;
            this.pbDesenho.Paint += new System.Windows.Forms.PaintEventHandler(this.pbDesenho_Paint);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Jogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 567);
            this.Controls.Add(this.pbDesenho);
            this.MaximumSize = new System.Drawing.Size(1284, 605);
            this.MinimumSize = new System.Drawing.Size(1284, 605);
            this.Name = "Jogo";
            this.Text = "Fish Bay - Jogo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Jogo_FormClosed);
            this.Load += new System.EventHandler(this.Jogo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbDesenho)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbDesenho;
        private System.Windows.Forms.Timer timer;
    }
}