﻿namespace Fish_Bay
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
            this.timerSpawn = new System.Windows.Forms.Timer(this.components);
            this.lblQtosClien = new System.Windows.Forms.Label();
            this.lblQtosPont = new System.Windows.Forms.Label();
            this.lblQtosPeixes = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbIcon_Pont = new System.Windows.Forms.PictureBox();
            this.pbIcon_Clien = new System.Windows.Forms.PictureBox();
            this.pbDesenho = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon_Pont)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon_Clien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDesenho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // timerSpawn
            // 
            this.timerSpawn.Enabled = true;
            this.timerSpawn.Tick += new System.EventHandler(this.timerSpawn_Tick);
            // 
            // lblQtosClien
            // 
            this.lblQtosClien.AutoSize = true;
            this.lblQtosClien.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblQtosClien.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtosClien.Location = new System.Drawing.Point(96, 16);
            this.lblQtosClien.Name = "lblQtosClien";
            this.lblQtosClien.Size = new System.Drawing.Size(22, 24);
            this.lblQtosClien.TabIndex = 2;
            this.lblQtosClien.Text = "9";
            // 
            // lblQtosPont
            // 
            this.lblQtosPont.AutoSize = true;
            this.lblQtosPont.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblQtosPont.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtosPont.Location = new System.Drawing.Point(97, 87);
            this.lblQtosPont.Name = "lblQtosPont";
            this.lblQtosPont.Size = new System.Drawing.Size(22, 24);
            this.lblQtosPont.TabIndex = 4;
            this.lblQtosPont.Text = "0";
            // 
            // lblQtosPeixes
            // 
            this.lblQtosPeixes.AutoSize = true;
            this.lblQtosPeixes.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblQtosPeixes.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQtosPeixes.Location = new System.Drawing.Point(97, 46);
            this.lblQtosPeixes.Name = "lblQtosPeixes";
            this.lblQtosPeixes.Size = new System.Drawing.Size(22, 24);
            this.lblQtosPeixes.TabIndex = 6;
            this.lblQtosPeixes.Text = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Image = global::Fish_Bay.Properties.Resources.moedas5;
            this.pictureBox1.Location = new System.Drawing.Point(12, 73);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(142, 52);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pbIcon_Pont
            // 
            this.pbIcon_Pont.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pbIcon_Pont.Image = global::Fish_Bay.Properties.Resources.Icon_Pont;
            this.pbIcon_Pont.Location = new System.Drawing.Point(12, 45);
            this.pbIcon_Pont.Name = "pbIcon_Pont";
            this.pbIcon_Pont.Size = new System.Drawing.Size(142, 27);
            this.pbIcon_Pont.TabIndex = 3;
            this.pbIcon_Pont.TabStop = false;
            // 
            // pbIcon_Clien
            // 
            this.pbIcon_Clien.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pbIcon_Clien.Image = global::Fish_Bay.Properties.Resources.Icon_Clien1;
            this.pbIcon_Clien.Location = new System.Drawing.Point(12, 12);
            this.pbIcon_Clien.Name = "pbIcon_Clien";
            this.pbIcon_Clien.Size = new System.Drawing.Size(142, 32);
            this.pbIcon_Clien.TabIndex = 1;
            this.pbIcon_Clien.TabStop = false;
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
            this.pbDesenho.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbDesenho_MouseClick);
            this.pbDesenho.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbDesenho_MouseMove);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox2.Image = global::Fish_Bay.Properties.Resources.PeixeEsp;
            this.pictureBox2.Location = new System.Drawing.Point(12, 126);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(142, 22);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(96, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "0";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Location = new System.Drawing.Point(11, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(143, 137);
            this.panel1.TabIndex = 9;
            // 
            // Jogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 567);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblQtosPont);
            this.Controls.Add(this.lblQtosPeixes);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pbIcon_Pont);
            this.Controls.Add(this.lblQtosClien);
            this.Controls.Add(this.pbIcon_Clien);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbDesenho);
            this.MaximumSize = new System.Drawing.Size(1284, 605);
            this.MinimumSize = new System.Drawing.Size(1284, 605);
            this.Name = "Jogo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fish Bay - Jogo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Jogo_FormClosed);
            this.Load += new System.EventHandler(this.Jogo_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Jogo_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon_Pont)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon_Clien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDesenho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timerSpawn;
        private System.Windows.Forms.PictureBox pbDesenho;
        private System.Windows.Forms.PictureBox pbIcon_Clien;
        private System.Windows.Forms.Label lblQtosClien;
        private System.Windows.Forms.Label lblQtosPont;
        private System.Windows.Forms.PictureBox pbIcon_Pont;
        private System.Windows.Forms.Label lblQtosPeixes;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
    }
}