﻿namespace ChattingWithFriends_Client
{
    partial class ChattingWithFriend
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
            txtBox_DisplayChat = new TextBox();
            txtBox_MessageInput = new TextBox();
            btn_Send = new Button();
            btn_reload = new Button();
            lbl_reload = new Label();
            SuspendLayout();
            // 
            // txtBox_DisplayChat
            // 
            txtBox_DisplayChat.Enabled = false;
            txtBox_DisplayChat.Location = new Point(12, 27);
            txtBox_DisplayChat.Multiline = true;
            txtBox_DisplayChat.Name = "txtBox_DisplayChat";
            txtBox_DisplayChat.Size = new Size(776, 389);
            txtBox_DisplayChat.TabIndex = 0;
            // 
            // txtBox_MessageInput
            // 
            txtBox_MessageInput.Font = new Font("Segoe UI", 12F);
            txtBox_MessageInput.Location = new Point(12, 424);
            txtBox_MessageInput.Name = "txtBox_MessageInput";
            txtBox_MessageInput.Size = new Size(536, 29);
            txtBox_MessageInput.TabIndex = 1;
            // 
            // btn_Send
            // 
            btn_Send.AutoSize = true;
            btn_Send.Font = new Font("Segoe UI", 12F);
            btn_Send.Location = new Point(554, 422);
            btn_Send.Name = "btn_Send";
            btn_Send.Size = new Size(119, 31);
            btn_Send.TabIndex = 2;
            btn_Send.Text = "Send";
            btn_Send.UseVisualStyleBackColor = true;
            btn_Send.Click += btn_Send_Click;
            // 
            // btn_reload
            // 
            btn_reload.AutoSize = true;
            btn_reload.Font = new Font("Segoe UI", 12F);
            btn_reload.Location = new Point(679, 422);
            btn_reload.Name = "btn_reload";
            btn_reload.Size = new Size(109, 31);
            btn_reload.TabIndex = 3;
            btn_reload.Text = "Reload";
            btn_reload.UseVisualStyleBackColor = true;
            btn_reload.Click += btn_reload_Click;
            // 
            // lbl_reload
            // 
            lbl_reload.AutoSize = true;
            lbl_reload.ForeColor = Color.Red;
            lbl_reload.Location = new Point(12, 9);
            lbl_reload.Name = "lbl_reload";
            lbl_reload.Size = new Size(132, 15);
            lbl_reload.TabIndex = 4;
            lbl_reload.Text = "Reload to view updates.";
            lbl_reload.Visible = false;
            // 
            // ChattingWithFriend
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 459);
            Controls.Add(lbl_reload);
            Controls.Add(btn_reload);
            Controls.Add(btn_Send);
            Controls.Add(txtBox_MessageInput);
            Controls.Add(txtBox_DisplayChat);
            Name = "ChattingWithFriend";
            Text = "ChattingWithFriend";
            FormClosing += ChattingWithFriend_FormClosing;
            Load += ChattingWithFriend_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBox_DisplayChat;
        private TextBox txtBox_MessageInput;
        private Button btn_Send;
        private Button btn_reload;
        private Label lbl_reload;
    }
}