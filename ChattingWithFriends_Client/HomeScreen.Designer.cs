﻿namespace ChattingWithFriends_Client
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
            btn_OpenSelectedChat = new Button();
            label1 = new Label();
            checkedList_chats = new CheckedListBox();
            btn_refresh = new Button();
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
            // btn_OpenSelectedChat
            // 
            btn_OpenSelectedChat.AutoSize = true;
            btn_OpenSelectedChat.Dock = DockStyle.Bottom;
            btn_OpenSelectedChat.Font = new Font("Segoe UI", 12F);
            btn_OpenSelectedChat.Location = new Point(0, 472);
            btn_OpenSelectedChat.Name = "btn_OpenSelectedChat";
            btn_OpenSelectedChat.Size = new Size(458, 31);
            btn_OpenSelectedChat.TabIndex = 3;
            btn_OpenSelectedChat.Text = "Open Selected Chat";
            btn_OpenSelectedChat.UseVisualStyleBackColor = true;
            btn_OpenSelectedChat.Click += btn_OpenChat_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 63);
            label1.Name = "label1";
            label1.Size = new Size(108, 21);
            label1.TabIndex = 6;
            label1.Text = "Avilable Chats";
            // 
            // checkedList_chats
            // 
            checkedList_chats.CheckOnClick = true;
            checkedList_chats.FormattingEnabled = true;
            checkedList_chats.Location = new Point(12, 87);
            checkedList_chats.Name = "checkedList_chats";
            checkedList_chats.Size = new Size(434, 328);
            checkedList_chats.TabIndex = 5;
            checkedList_chats.ItemCheck += checkedList_chats_ItemCheck;
            // 
            // btn_refresh
            // 
            btn_refresh.AutoSize = true;
            btn_refresh.Font = new Font("Segoe UI", 12F);
            btn_refresh.Location = new Point(263, 421);
            btn_refresh.Name = "btn_refresh";
            btn_refresh.Size = new Size(183, 31);
            btn_refresh.TabIndex = 7;
            btn_refresh.Text = "Refresh Available Chats";
            btn_refresh.UseVisualStyleBackColor = true;
            btn_refresh.Click += btn_refresh_Click;
            // 
            // HomeScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(458, 503);
            Controls.Add(btn_refresh);
            Controls.Add(label1);
            Controls.Add(checkedList_chats);
            Controls.Add(btn_OpenSelectedChat);
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
        private Button btn_OpenSelectedChat;
        private Label label1;
        private CheckedListBox checkedList_chats;
        private Button btn_refresh;
    }
}