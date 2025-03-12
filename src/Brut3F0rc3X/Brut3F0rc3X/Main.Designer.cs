namespace Brut3F0rc3X
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label1 = new System.Windows.Forms.Label();
            this.txtBruteForceStart = new System.Windows.Forms.TextBox();
            this.rbBruteForce = new System.Windows.Forms.RadioButton();
            this.rbDictionary = new System.Windows.Forms.RadioButton();
            this.btnSelectDictionary = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBruteForceEnd = new System.Windows.Forms.TextBox();
            this.txtDictionaryPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.Color.LimeGreen;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select method:";
            // 
            // txtBruteForceStart
            // 
            this.txtBruteForceStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtBruteForceStart.ForeColor = System.Drawing.Color.LimeGreen;
            this.txtBruteForceStart.Location = new System.Drawing.Point(17, 99);
            this.txtBruteForceStart.Multiline = true;
            this.txtBruteForceStart.Name = "txtBruteForceStart";
            this.txtBruteForceStart.Size = new System.Drawing.Size(100, 35);
            this.txtBruteForceStart.TabIndex = 0;
            this.txtBruteForceStart.Text = "1000000";
            this.txtBruteForceStart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBruteForceStart_KeyPress);
            // 
            // rbBruteForce
            // 
            this.rbBruteForce.AutoSize = true;
            this.rbBruteForce.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rbBruteForce.ForeColor = System.Drawing.Color.LimeGreen;
            this.rbBruteForce.Location = new System.Drawing.Point(17, 47);
            this.rbBruteForce.Name = "rbBruteForce";
            this.rbBruteForce.Size = new System.Drawing.Size(115, 24);
            this.rbBruteForce.TabIndex = 0;
            this.rbBruteForce.TabStop = true;
            this.rbBruteForce.Text = "Brute-force";
            this.rbBruteForce.UseVisualStyleBackColor = true;
            this.rbBruteForce.CheckedChanged += new System.EventHandler(this.rbBruteForce_CheckedChanged);
            // 
            // rbDictionary
            // 
            this.rbDictionary.AutoSize = true;
            this.rbDictionary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rbDictionary.ForeColor = System.Drawing.Color.LimeGreen;
            this.rbDictionary.Location = new System.Drawing.Point(248, 47);
            this.rbDictionary.Name = "rbDictionary";
            this.rbDictionary.Size = new System.Drawing.Size(106, 24);
            this.rbDictionary.TabIndex = 1;
            this.rbDictionary.TabStop = true;
            this.rbDictionary.Text = "Dictionary";
            this.rbDictionary.UseVisualStyleBackColor = true;
            this.rbDictionary.CheckedChanged += new System.EventHandler(this.rbDictionary_CheckedChanged);
            // 
            // btnSelectDictionary
            // 
            this.btnSelectDictionary.ForeColor = System.Drawing.Color.LimeGreen;
            this.btnSelectDictionary.Location = new System.Drawing.Point(437, 101);
            this.btnSelectDictionary.Name = "btnSelectDictionary";
            this.btnSelectDictionary.Size = new System.Drawing.Size(133, 33);
            this.btnSelectDictionary.TabIndex = 0;
            this.btnSelectDictionary.Text = "Select dictionary";
            this.btnSelectDictionary.UseVisualStyleBackColor = true;
            this.btnSelectDictionary.Click += new System.EventHandler(this.btnSelectDictionary_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.LimeGreen;
            this.label2.Location = new System.Drawing.Point(14, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Start";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.LimeGreen;
            this.label3.Location = new System.Drawing.Point(124, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "End";
            // 
            // txtBruteForceEnd
            // 
            this.txtBruteForceEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtBruteForceEnd.ForeColor = System.Drawing.Color.LimeGreen;
            this.txtBruteForceEnd.Location = new System.Drawing.Point(125, 99);
            this.txtBruteForceEnd.Multiline = true;
            this.txtBruteForceEnd.Name = "txtBruteForceEnd";
            this.txtBruteForceEnd.Size = new System.Drawing.Size(100, 35);
            this.txtBruteForceEnd.TabIndex = 0;
            this.txtBruteForceEnd.Text = "9999999";
            this.txtBruteForceEnd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBruteForceEnd_KeyPress);
            // 
            // txtDictionaryPath
            // 
            this.txtDictionaryPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.txtDictionaryPath.ForeColor = System.Drawing.Color.LimeGreen;
            this.txtDictionaryPath.Location = new System.Drawing.Point(248, 99);
            this.txtDictionaryPath.Multiline = true;
            this.txtDictionaryPath.Name = "txtDictionaryPath";
            this.txtDictionaryPath.Size = new System.Drawing.Size(183, 34);
            this.txtDictionaryPath.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.LimeGreen;
            this.label4.Location = new System.Drawing.Point(245, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Path";
            // 
            // btnSearch
            // 
            this.btnSearch.ForeColor = System.Drawing.Color.LimeGreen;
            this.btnSearch.Location = new System.Drawing.Point(437, 158);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(133, 33);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(582, 203);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDictionaryPath);
            this.Controls.Add(this.txtBruteForceEnd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSelectDictionary);
            this.Controls.Add(this.rbDictionary);
            this.Controls.Add(this.rbBruteForce);
            this.Controls.Add(this.txtBruteForceStart);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Opacity = 0.85D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Brut3F0rc3X";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBruteForceStart;
        private System.Windows.Forms.RadioButton rbBruteForce;
        private System.Windows.Forms.RadioButton rbDictionary;
        private System.Windows.Forms.Button btnSelectDictionary;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBruteForceEnd;
        private System.Windows.Forms.TextBox txtDictionaryPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSearch;
    }
}

