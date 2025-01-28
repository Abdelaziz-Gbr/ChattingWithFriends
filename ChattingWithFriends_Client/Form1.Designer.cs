namespace ChattingWithFriends_Client
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
            btn_signIn = new Button();
            txtBox_username = new TextBox();
            txtBox_password = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // btn_signIn
            // 
            btn_signIn.AutoSize = true;
            btn_signIn.Font = new Font("Segoe UI", 12F);
            btn_signIn.Location = new Point(245, 139);
            btn_signIn.Name = "btn_signIn";
            btn_signIn.Size = new Size(135, 31);
            btn_signIn.TabIndex = 0;
            btn_signIn.Text = "Sign in / Sign up";
            btn_signIn.UseVisualStyleBackColor = true;
            btn_signIn.Click += btn_signIn_Click;
            // 
            // txtBox_username
            // 
            txtBox_username.Font = new Font("Segoe UI", 12F);
            txtBox_username.Location = new Point(106, 12);
            txtBox_username.Name = "txtBox_username";
            txtBox_username.Size = new Size(159, 29);
            txtBox_username.TabIndex = 1;
            // 
            // txtBox_password
            // 
            txtBox_password.Font = new Font("Segoe UI", 12F);
            txtBox_password.Location = new Point(106, 66);
            txtBox_password.Name = "txtBox_password";
            txtBox_password.Size = new Size(159, 29);
            txtBox_password.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(88, 21);
            label1.TabIndex = 3;
            label1.Text = "User name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(12, 74);
            label2.Name = "label2";
            label2.Size = new Size(79, 21);
            label2.TabIndex = 4;
            label2.Text = "Password:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(392, 182);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtBox_password);
            Controls.Add(txtBox_username);
            Controls.Add(btn_signIn);
            Name = "Form1";
            Text = "Chat With Firends ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_signIn;
        private TextBox txtBox_username;
        private TextBox txtBox_password;
        private Label label1;
        private Label label2;
    }
}
