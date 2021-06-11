
namespace CS056Semafor
{
    partial class SemaforForm
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.semaforTimer = new System.Windows.Forms.Timer(this.components);
            this.zapnoutButton = new System.Windows.Forms.Button();
            this.vypnoutButton = new System.Windows.Forms.Button();
            this.rizeniZapnoutButton = new System.Windows.Forms.Button();
            this.rizeniVypnoutButton = new System.Windows.Forms.Button();
            this.cisloSemaforuTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // semaforTimer
            // 
            this.semaforTimer.Enabled = true;
            this.semaforTimer.Interval = 50;
            this.semaforTimer.Tick += new System.EventHandler(this.semaforTimer_Tick);
            // 
            // zapnoutButton
            // 
            this.zapnoutButton.Location = new System.Drawing.Point(12, 38);
            this.zapnoutButton.Name = "zapnoutButton";
            this.zapnoutButton.Size = new System.Drawing.Size(75, 23);
            this.zapnoutButton.TabIndex = 5;
            this.zapnoutButton.Text = "Zapnout";
            this.zapnoutButton.UseVisualStyleBackColor = true;
            this.zapnoutButton.Click += new System.EventHandler(this.zapnoutButton_Click);
            // 
            // vypnoutButton
            // 
            this.vypnoutButton.Location = new System.Drawing.Point(93, 38);
            this.vypnoutButton.Name = "vypnoutButton";
            this.vypnoutButton.Size = new System.Drawing.Size(75, 23);
            this.vypnoutButton.TabIndex = 6;
            this.vypnoutButton.Text = "Vypnout";
            this.vypnoutButton.UseVisualStyleBackColor = true;
            this.vypnoutButton.Click += new System.EventHandler(this.vypnoutButton_Click);
            // 
            // rizeniZapnoutButton
            // 
            this.rizeniZapnoutButton.Location = new System.Drawing.Point(12, 67);
            this.rizeniZapnoutButton.Name = "rizeniZapnoutButton";
            this.rizeniZapnoutButton.Size = new System.Drawing.Size(75, 38);
            this.rizeniZapnoutButton.TabIndex = 7;
            this.rizeniZapnoutButton.Text = "Řízení Zapnout";
            this.rizeniZapnoutButton.UseVisualStyleBackColor = true;
            this.rizeniZapnoutButton.Click += new System.EventHandler(this.rizeniZapnoutButton_Click);
            // 
            // rizeniVypnoutButton
            // 
            this.rizeniVypnoutButton.Location = new System.Drawing.Point(93, 67);
            this.rizeniVypnoutButton.Name = "rizeniVypnoutButton";
            this.rizeniVypnoutButton.Size = new System.Drawing.Size(75, 38);
            this.rizeniVypnoutButton.TabIndex = 9;
            this.rizeniVypnoutButton.Text = "Řízení Vypnout";
            this.rizeniVypnoutButton.UseVisualStyleBackColor = true;
            this.rizeniVypnoutButton.Click += new System.EventHandler(this.rizeniVypnoutButton_Click);
            // 
            // cisloSemaforuTextBox
            // 
            this.cisloSemaforuTextBox.Location = new System.Drawing.Point(43, 12);
            this.cisloSemaforuTextBox.Name = "cisloSemaforuTextBox";
            this.cisloSemaforuTextBox.Size = new System.Drawing.Size(100, 20);
            this.cisloSemaforuTextBox.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Yellow;
            this.panel1.Location = new System.Drawing.Point(313, 167);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 14;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "label1";
            // 
            // SemaforForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cisloSemaforuTextBox);
            this.Controls.Add(this.rizeniVypnoutButton);
            this.Controls.Add(this.rizeniZapnoutButton);
            this.Controls.Add(this.vypnoutButton);
            this.Controls.Add(this.zapnoutButton);
            this.Name = "SemaforForm";
            this.Text = "CS060 Semafor - Ondřej Fejtek";
            this.Load += new System.EventHandler(this.CS056Semafor_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SemaforForm_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SemaforForm_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer semaforTimer;
        private System.Windows.Forms.Button zapnoutButton;
        private System.Windows.Forms.Button vypnoutButton;
        private System.Windows.Forms.Button rizeniZapnoutButton;
        private System.Windows.Forms.Button rizeniVypnoutButton;
        private System.Windows.Forms.TextBox cisloSemaforuTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}

