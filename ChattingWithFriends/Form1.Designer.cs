namespace ChattingWithFriends
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_start = new Button();
            checkedListBox1 = new CheckedListBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // btn_start
            // 
            btn_start.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btn_start.AutoSize = true;
            btn_start.Font = new Font("Segoe UI", 12F);
            btn_start.Location = new Point(-1, 2);
            btn_start.Name = "btn_start";
            btn_start.Size = new Size(800, 31);
            btn_start.TabIndex = 0;
            btn_start.Text = "Start Service";
            btn_start.UseVisualStyleBackColor = true;
            btn_start.Click += btnClick_StartService;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(588, 39);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(200, 328);
            checkedListBox1.TabIndex = 1;
            checkedListBox1.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(420, 356);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(checkedListBox1);
            Controls.Add(btn_start);
            Name = "Form1";
            Text = "ChatWithFriends_Admin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_start;
        private CheckedListBox checkedListBox1;
        private Button button1;
    }
}
