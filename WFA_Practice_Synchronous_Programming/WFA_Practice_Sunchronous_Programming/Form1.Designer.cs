namespace WFA_Practice_Sunchronous_Programming
{
    partial class Form1
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
            this.txt_bx_adrss_1 = new System.Windows.Forms.TextBox();
            this.txt_bx_adrss_2 = new System.Windows.Forms.TextBox();
            this.txt_bx_adrss_3 = new System.Windows.Forms.TextBox();
            this.txt_bx_adrss_11 = new System.Windows.Forms.TextBox();
            this.txt_bx_adrss_12 = new System.Windows.Forms.TextBox();
            this.txt_bx_adrss_13 = new System.Windows.Forms.TextBox();
            this.btn_start = new System.Windows.Forms.Button();
            this.combo_selection_list = new System.Windows.Forms.ComboBox();
            this.btn_reset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_bx_adrss_1
            // 
            this.txt_bx_adrss_1.Location = new System.Drawing.Point(29, 42);
            this.txt_bx_adrss_1.Name = "txt_bx_adrss_1";
            this.txt_bx_adrss_1.Size = new System.Drawing.Size(219, 20);
            this.txt_bx_adrss_1.TabIndex = 0;
            this.txt_bx_adrss_1.Text = "http://www.microsoft.com";
            // 
            // txt_bx_adrss_2
            // 
            this.txt_bx_adrss_2.Location = new System.Drawing.Point(263, 42);
            this.txt_bx_adrss_2.Name = "txt_bx_adrss_2";
            this.txt_bx_adrss_2.Size = new System.Drawing.Size(219, 20);
            this.txt_bx_adrss_2.TabIndex = 1;
            this.txt_bx_adrss_2.Text = "http://msdn.microsoft.com";
            // 
            // txt_bx_adrss_3
            // 
            this.txt_bx_adrss_3.Location = new System.Drawing.Point(499, 41);
            this.txt_bx_adrss_3.Name = "txt_bx_adrss_3";
            this.txt_bx_adrss_3.Size = new System.Drawing.Size(219, 20);
            this.txt_bx_adrss_3.TabIndex = 2;
            this.txt_bx_adrss_3.Text = "http://blogs.msdn.com";
            // 
            // txt_bx_adrss_11
            // 
            this.txt_bx_adrss_11.Location = new System.Drawing.Point(29, 68);
            this.txt_bx_adrss_11.Multiline = true;
            this.txt_bx_adrss_11.Name = "txt_bx_adrss_11";
            this.txt_bx_adrss_11.Size = new System.Drawing.Size(219, 132);
            this.txt_bx_adrss_11.TabIndex = 3;
            this.txt_bx_adrss_11.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // txt_bx_adrss_12
            // 
            this.txt_bx_adrss_12.Location = new System.Drawing.Point(263, 68);
            this.txt_bx_adrss_12.Multiline = true;
            this.txt_bx_adrss_12.Name = "txt_bx_adrss_12";
            this.txt_bx_adrss_12.Size = new System.Drawing.Size(219, 132);
            this.txt_bx_adrss_12.TabIndex = 4;
            // 
            // txt_bx_adrss_13
            // 
            this.txt_bx_adrss_13.Location = new System.Drawing.Point(499, 68);
            this.txt_bx_adrss_13.Multiline = true;
            this.txt_bx_adrss_13.Name = "txt_bx_adrss_13";
            this.txt_bx_adrss_13.Size = new System.Drawing.Size(219, 132);
            this.txt_bx_adrss_13.TabIndex = 5;
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(263, 224);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 6;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // combo_selection_list
            // 
            this.combo_selection_list.AccessibleName = "";
            this.combo_selection_list.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_selection_list.FormattingEnabled = true;
            this.combo_selection_list.Items.AddRange(new object[] {
            "1_Run UI & WebRequest in separate thread (Display Response Simultaneously)",
            "2_Run UI & WebRequest in separate thread (Display Response One After Another)",
            "3_Run UI & WebRequest in same thread (Display Response Simultaneously) (UI Halt)",
            "4_Run UI & WebRequest in same thread (Display Response One After Another) (UI Hal" +
                "t)",
            "5_Parallel#1"});
            this.combo_selection_list.Location = new System.Drawing.Point(29, 12);
            this.combo_selection_list.Name = "combo_selection_list";
            this.combo_selection_list.Size = new System.Drawing.Size(689, 21);
            this.combo_selection_list.TabIndex = 7;
            // 
            // btn_reset
            // 
            this.btn_reset.Location = new System.Drawing.Point(407, 224);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(75, 23);
            this.btn_reset.TabIndex = 8;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 274);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.combo_selection_list);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.txt_bx_adrss_13);
            this.Controls.Add(this.txt_bx_adrss_12);
            this.Controls.Add(this.txt_bx_adrss_11);
            this.Controls.Add(this.txt_bx_adrss_3);
            this.Controls.Add(this.txt_bx_adrss_2);
            this.Controls.Add(this.txt_bx_adrss_1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_bx_adrss_1;
        private System.Windows.Forms.TextBox txt_bx_adrss_2;
        private System.Windows.Forms.TextBox txt_bx_adrss_3;
        private System.Windows.Forms.TextBox txt_bx_adrss_11;
        private System.Windows.Forms.TextBox txt_bx_adrss_12;
        private System.Windows.Forms.TextBox txt_bx_adrss_13;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.ComboBox combo_selection_list;
        private System.Windows.Forms.Button btn_reset;
    }
}

