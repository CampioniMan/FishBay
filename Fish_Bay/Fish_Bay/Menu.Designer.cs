namespace Fish_Bay
{
    partial class Menu
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
            this.btnInicio = new System.Windows.Forms.Button();
            this.btnRecordes = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pbDesenho = new System.Windows.Forms.PictureBox();
            this.txtNomeJog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnComoJogar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbDesenho)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInicio
            // 
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicio.Location = new System.Drawing.Point(754, 103);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(186, 58);
            this.btnInicio.TabIndex = 1;
            this.btnInicio.Text = "INICIAR JOGO";
            this.btnInicio.UseVisualStyleBackColor = true;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // btnRecordes
            // 
            this.btnRecordes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecordes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecordes.Location = new System.Drawing.Point(754, 178);
            this.btnRecordes.Name = "btnRecordes";
            this.btnRecordes.Size = new System.Drawing.Size(186, 58);
            this.btnRecordes.TabIndex = 2;
            this.btnRecordes.Text = "RECORDES";
            this.btnRecordes.UseVisualStyleBackColor = true;
            this.btnRecordes.Click += new System.EventHandler(this.btnRecordes_Click);
            // 
            // timer
            // 
            this.timer.Interval = 300;
            this.timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pbDesenho
            // 
            this.pbDesenho.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbDesenho.Image = global::Fish_Bay.Properties.Resources.capa_inicio;
            this.pbDesenho.Location = new System.Drawing.Point(0, 0);
            this.pbDesenho.Name = "pbDesenho";
            this.pbDesenho.Size = new System.Drawing.Size(1004, 633);
            this.pbDesenho.TabIndex = 0;
            this.pbDesenho.TabStop = false;
            this.pbDesenho.Paint += new System.Windows.Forms.PaintEventHandler(this.pbDesenho_Paint);
            // 
            // txtNomeJog
            // 
            this.txtNomeJog.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtNomeJog.Location = new System.Drawing.Point(755, 55);
            this.txtNomeJog.MaxLength = 15;
            this.txtNomeJog.Name = "txtNomeJog";
            this.txtNomeJog.Size = new System.Drawing.Size(185, 30);
            this.txtNomeJog.TabIndex = 3;
            this.txtNomeJog.Text = "Guest";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(755, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nome do Pescador:";
            // 
            // btnComoJogar
            // 
            this.btnComoJogar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComoJogar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComoJogar.Location = new System.Drawing.Point(754, 252);
            this.btnComoJogar.Name = "btnComoJogar";
            this.btnComoJogar.Size = new System.Drawing.Size(186, 58);
            this.btnComoJogar.TabIndex = 5;
            this.btnComoJogar.Text = "COMO JOGAR";
            this.btnComoJogar.UseVisualStyleBackColor = true;
            this.btnComoJogar.Click += new System.EventHandler(this.btnComoJogar_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 633);
            this.Controls.Add(this.btnComoJogar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNomeJog);
            this.Controls.Add(this.btnRecordes);
            this.Controls.Add(this.btnInicio);
            this.Controls.Add(this.pbDesenho);
            this.MaximumSize = new System.Drawing.Size(1020, 671);
            this.MinimumSize = new System.Drawing.Size(1020, 671);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fish Bay - Menu";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbDesenho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbDesenho;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnRecordes;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox txtNomeJog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnComoJogar;
    }
}

