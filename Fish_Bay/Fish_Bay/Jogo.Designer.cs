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
            this.timerCoord = new System.Windows.Forms.Timer(this.components);
            this.timerSpawn = new System.Windows.Forms.Timer(this.components);
            this.timerBota = new System.Windows.Forms.Timer(this.components);
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.pbDesenho = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbDesenho)).BeginInit();
            this.SuspendLayout();
            // 
            // timerCoord
            // 
            this.timerCoord.Enabled = true;
            this.timerCoord.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // timerSpawn
            // 
            this.timerSpawn.Enabled = true;
            this.timerSpawn.Tick += new System.EventHandler(this.timerSpawn_Tick);
            // 
            // timerBota
            // 
            this.timerBota.Interval = 1;
            this.timerBota.Tick += new System.EventHandler(this.timerBota_Tick);
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(727, 13);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(20, 13);
            this.lblX.TabIndex = 1;
            this.lblX.Text = "X: ";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(797, 13);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(17, 13);
            this.lblY.TabIndex = 2;
            this.lblY.Text = "Y:";
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
            this.pbDesenho.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbDesenho_MouseMove);
            // 
            // Jogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 567);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.pbDesenho);
            this.MaximumSize = new System.Drawing.Size(1284, 605);
            this.MinimumSize = new System.Drawing.Size(1284, 605);
            this.Name = "Jogo";
            this.Text = "Fish Bay - Jogo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Jogo_FormClosed);
            this.Load += new System.EventHandler(this.Jogo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbDesenho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timerCoord;
        private System.Windows.Forms.Timer timerSpawn;
        private System.Windows.Forms.Timer timerBota;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.PictureBox pbDesenho;
    }
}