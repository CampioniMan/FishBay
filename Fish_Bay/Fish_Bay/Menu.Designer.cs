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
            this.pbDesenho = new System.Windows.Forms.PictureBox();
            this.btnInicio = new System.Windows.Forms.Button();
            this.btnRecordes = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbDesenho)).BeginInit();
            this.SuspendLayout();
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
            // btnInicio
            // 
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicio.Location = new System.Drawing.Point(802, 44);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(162, 58);
            this.btnInicio.TabIndex = 1;
            this.btnInicio.Text = "INICIAR JOGO";
            this.btnInicio.UseVisualStyleBackColor = true;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // btnRecordes
            // 
            this.btnRecordes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecordes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecordes.Location = new System.Drawing.Point(802, 142);
            this.btnRecordes.Name = "btnRecordes";
            this.btnRecordes.Size = new System.Drawing.Size(162, 58);
            this.btnRecordes.TabIndex = 2;
            this.btnRecordes.Text = "RECORDES";
            this.btnRecordes.UseVisualStyleBackColor = true;
            this.btnRecordes.Click += new System.EventHandler(this.btnRecordes_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 633);
            this.Controls.Add(this.btnRecordes);
            this.Controls.Add(this.btnInicio);
            this.Controls.Add(this.pbDesenho);
            this.MaximumSize = new System.Drawing.Size(1020, 671);
            this.MinimumSize = new System.Drawing.Size(1020, 671);
            this.Name = "Menu";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbDesenho)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbDesenho;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnRecordes;
        private System.Windows.Forms.Timer timer1;
    }
}

