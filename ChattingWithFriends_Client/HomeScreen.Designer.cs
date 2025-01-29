namespace ChattingWithFriends_Client
{
    partial class HomeScreen
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
            lbl_username = new Label();
            btn_signOut = new Button();
            checkedList_pastChats = new CheckedListBox();
            btn_OpenSelectedChat = new Button();
            label2 = new Label();
            label1 = new Label();
            checkedList_onlineFriends = new CheckedListBox();
            SuspendLayout();
            // 
            // lbl_username
            // 
            lbl_username.AutoSize = true;
            lbl_username.Font = new Font("Segoe UI", 12F);
            lbl_username.Location = new Point(12, 22);
            lbl_username.Name = "lbl_username";
            lbl_username.Size = new Size(188, 21);
            lbl_username.TabIndex = 0;
            lbl_username.Text = "You are now logged in as ";
            // 
            // btn_signOut
            // 
            btn_signOut.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_signOut.AutoSize = true;
            btn_signOut.Font = new Font("Segoe UI", 12F);
            btn_signOut.ForeColor = Color.Red;
            btn_signOut.Location = new Point(368, 17);
            btn_signOut.Name = "btn_signOut";
            btn_signOut.Size = new Size(78, 31);
            btn_signOut.TabIndex = 1;
            btn_signOut.Text = "Sign out";
            btn_signOut.UseVisualStyleBackColor = true;
            // 
            // checkedList_pastChats
            // 
            checkedList_pastChats.FormattingEnabled = true;
            checkedList_pastChats.Location = new Point(12, 87);
            checkedList_pastChats.Name = "checkedList_pastChats";
            checkedList_pastChats.Size = new Size(184, 328);
            checkedList_pastChats.TabIndex = 2;
            // 
            // btn_OpenSelectedChat
            // 
            btn_OpenSelectedChat.AutoSize = true;
            btn_OpenSelectedChat.Dock = DockStyle.Bottom;
            btn_OpenSelectedChat.Font = new Font("Segoe UI", 12F);
            btn_OpenSelectedChat.Location = new Point(0, 425);
            btn_OpenSelectedChat.Name = "btn_OpenSelectedChat";
            btn_OpenSelectedChat.Size = new Size(458, 31);
            btn_OpenSelectedChat.TabIndex = 3;
            btn_OpenSelectedChat.Text = "Open Selected Chat";
            btn_OpenSelectedChat.UseVisualStyleBackColor = true;
            btn_OpenSelectedChat.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(12, 63);
            label2.Name = "label2";
            label2.Size = new Size(81, 21);
            label2.TabIndex = 4;
            label2.Text = "Past Chats";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(262, 63);
            label1.Name = "label1";
            label1.Size = new Size(111, 21);
            label1.TabIndex = 6;
            label1.Text = "Online Friends";
            // 
            // checkedList_onlineFriends
            // 
            checkedList_onlineFriends.FormattingEnabled = true;
            checkedList_onlineFriends.Location = new Point(262, 87);
            checkedList_onlineFriends.Name = "checkedList_onlineFriends";
            checkedList_onlineFriends.Size = new Size(184, 328);
            checkedList_onlineFriends.TabIndex = 5;
            // 
            // HomeScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(458, 456);
            Controls.Add(label1);
            Controls.Add(checkedList_onlineFriends);
            Controls.Add(label2);
            Controls.Add(btn_OpenSelectedChat);
            Controls.Add(checkedList_pastChats);
            Controls.Add(btn_signOut);
            Controls.Add(lbl_username);
            Name = "HomeScreen";
            Text = "HomeScreen";
            Load += HomeScreen_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_username;
        private Button btn_signOut;
        private CheckedListBox checkedList_pastChats;
        private Button btn_OpenSelectedChat;
        private Label label2;
        private Label label1;
        private CheckedListBox checkedList_onlineFriends;
    }
}