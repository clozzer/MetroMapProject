namespace MetroMapProject
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.resetbutton = new System.Windows.Forms.Button();
            this.zoomout = new System.Windows.Forms.Button();
            this.zoomin = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rechtsuntenbutton = new System.Windows.Forms.Button();
            this.rechtsobenbutton = new System.Windows.Forms.Button();
            this.untenrechtsregelbutton = new System.Windows.Forms.Button();
            this.untenlinksregelbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(916, 629);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.resetbutton);
            this.panel1.Controls.Add(this.zoomout);
            this.panel1.Controls.Add(this.zoomin);
            this.panel1.Location = new System.Drawing.Point(12, 676);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 55);
            this.panel1.TabIndex = 1;
            // 
            // resetbutton
            // 
            this.resetbutton.Location = new System.Drawing.Point(162, 3);
            this.resetbutton.Name = "resetbutton";
            this.resetbutton.Size = new System.Drawing.Size(75, 23);
            this.resetbutton.TabIndex = 2;
            this.resetbutton.Text = "reset";
            this.resetbutton.UseVisualStyleBackColor = true;
            this.resetbutton.Click += new System.EventHandler(this.resetbutton_Click);
            // 
            // zoomout
            // 
            this.zoomout.Location = new System.Drawing.Point(81, 3);
            this.zoomout.Name = "zoomout";
            this.zoomout.Size = new System.Drawing.Size(75, 23);
            this.zoomout.TabIndex = 1;
            this.zoomout.Text = "-";
            this.zoomout.UseVisualStyleBackColor = true;
            this.zoomout.Click += new System.EventHandler(this.zoomout_Click);
            // 
            // zoomin
            // 
            this.zoomin.Location = new System.Drawing.Point(3, 3);
            this.zoomin.Name = "zoomin";
            this.zoomin.Size = new System.Drawing.Size(75, 23);
            this.zoomin.TabIndex = 0;
            this.zoomin.Text = "+";
            this.zoomin.UseVisualStyleBackColor = true;
            this.zoomin.Click += new System.EventHandler(this.zoomin_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rechtsuntenbutton);
            this.panel2.Controls.Add(this.rechtsobenbutton);
            this.panel2.Controls.Add(this.untenrechtsregelbutton);
            this.panel2.Controls.Add(this.untenlinksregelbutton);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(968, 743);
            this.panel2.TabIndex = 2;
            // 
            // rechtsuntenbutton
            // 
            this.rechtsuntenbutton.Location = new System.Drawing.Point(934, 185);
            this.rechtsuntenbutton.Name = "rechtsuntenbutton";
            this.rechtsuntenbutton.Size = new System.Drawing.Size(22, 62);
            this.rechtsuntenbutton.TabIndex = 7;
            this.rechtsuntenbutton.Text = "|";
            this.rechtsuntenbutton.UseVisualStyleBackColor = true;
            this.rechtsuntenbutton.Click += new System.EventHandler(this.rechtsuntenbutton_Click);
            // 
            // rechtsobenbutton
            // 
            this.rechtsobenbutton.Location = new System.Drawing.Point(934, 77);
            this.rechtsobenbutton.Name = "rechtsobenbutton";
            this.rechtsobenbutton.Size = new System.Drawing.Size(22, 62);
            this.rechtsobenbutton.TabIndex = 6;
            this.rechtsobenbutton.Text = "^|";
            this.rechtsobenbutton.UseVisualStyleBackColor = true;
            this.rechtsobenbutton.Click += new System.EventHandler(this.rechtsobenbutton_Click);
            // 
            // untenrechtsregelbutton
            // 
            this.untenrechtsregelbutton.Location = new System.Drawing.Point(93, 647);
            this.untenrechtsregelbutton.Name = "untenrechtsregelbutton";
            this.untenrechtsregelbutton.Size = new System.Drawing.Size(75, 23);
            this.untenrechtsregelbutton.TabIndex = 5;
            this.untenrechtsregelbutton.Text = "->";
            this.untenrechtsregelbutton.UseVisualStyleBackColor = true;
            this.untenrechtsregelbutton.Click += new System.EventHandler(this.untenrechtsregelbutton_Click);
            // 
            // untenlinksregelbutton
            // 
            this.untenlinksregelbutton.Location = new System.Drawing.Point(12, 647);
            this.untenlinksregelbutton.Name = "untenlinksregelbutton";
            this.untenlinksregelbutton.Size = new System.Drawing.Size(75, 23);
            this.untenlinksregelbutton.TabIndex = 4;
            this.untenlinksregelbutton.Text = "<-";
            this.untenlinksregelbutton.UseVisualStyleBackColor = true;
            this.untenlinksregelbutton.Click += new System.EventHandler(this.untenlinksregelbutton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 743);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button zoomout;
        private System.Windows.Forms.Button zoomin;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button resetbutton;
        private System.Windows.Forms.Button rechtsobenbutton;
        private System.Windows.Forms.Button untenrechtsregelbutton;
        private System.Windows.Forms.Button untenlinksregelbutton;
        private System.Windows.Forms.Button rechtsuntenbutton;
    }
}

