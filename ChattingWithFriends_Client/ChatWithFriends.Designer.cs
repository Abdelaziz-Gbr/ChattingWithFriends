namespace ChattingWithFriends_Client
{
    partial class ChatWithFriends
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
            checkedListBox1 = new CheckedListBox();
            label1 = new Label();
            btn_OpenConvo = new Button();
            checkedListBox2 = new CheckedListBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // checkedListBox1
            // 
            checkedListBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            checkedListBox1.CheckOnClick = true;
            checkedListBox1.Font = new Font("Segoe UI", 12F);
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(12, 33);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(218, 316);
            checkedListBox1.TabIndex = 0;
            checkedListBox1.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(108, 21);
            label1.TabIndex = 1;
            label1.Text = "Who Is Online";
            // 
            // btn_OpenConvo
            // 
            btn_OpenConvo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btn_OpenConvo.AutoSize = true;
            btn_OpenConvo.Font = new Font("Segoe UI", 12F);
            btn_OpenConvo.Location = new Point(12, 395);
            btn_OpenConvo.Name = "btn_OpenConvo";
            btn_OpenConvo.Size = new Size(512, 31);
            btn_OpenConvo.TabIndex = 2;
            btn_OpenConvo.Text = "Open Conversation";
            btn_OpenConvo.UseVisualStyleBackColor = true;
            // 
            // checkedListBox2
            // 
            checkedListBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            checkedListBox2.Font = new Font("Segoe UI", 12F);
            checkedListBox2.FormattingEnabled = true;
            checkedListBox2.Location = new Point(306, 33);
            checkedListBox2.Name = "checkedListBox2";
            checkedListBox2.Size = new Size(218, 316);
            checkedListBox2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(306, 9);
            label2.Name = "label2";
            label2.Size = new Size(113, 21);
            label2.TabIndex = 4;
            label2.Text = "Previous Chats";
            // 
            // ChatWithFriends
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(536, 460);
            Controls.Add(label2);
            Controls.Add(checkedListBox2);
            Controls.Add(btn_OpenConvo);
            Controls.Add(label1);
            Controls.Add(checkedListBox1);
            Name = "ChatWithFriends";
            Text = "ChatWithFriends";
            Load += ChatWithFriends_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox checkedListBox1;
        private Label label1;
        private Button btn_OpenConvo;
        private CheckedListBox checkedListBox2;
        private Label label2;
    }
}