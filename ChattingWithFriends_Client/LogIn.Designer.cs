namespace ChattingWithFriends_Client
{
    partial class LogIn
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
            pnl_Instructions = new Panel();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            pnl_Instructions.SuspendLayout();
            SuspendLayout();
            // 
            // btn_signIn
            // 
            btn_signIn.AutoSize = true;
            btn_signIn.Font = new Font("Segoe UI", 12F);
            btn_signIn.Location = new Point(130, 169);
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
            // pnl_Instructions
            // 
            pnl_Instructions.Controls.Add(label6);
            pnl_Instructions.Controls.Add(label5);
            pnl_Instructions.Controls.Add(label4);
            pnl_Instructions.Controls.Add(label3);
            pnl_Instructions.Location = new Point(271, 12);
            pnl_Instructions.Name = "pnl_Instructions";
            pnl_Instructions.Size = new Size(307, 188);
            pnl_Instructions.TabIndex = 5;
            pnl_Instructions.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.ForeColor = Color.Red;
            label3.Location = new Point(3, 8);
            label3.Name = "label3";
            label3.Size = new Size(192, 21);
            label3.TabIndex = 6;
            label3.Text = ".user name can't be empty";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(3, 29);
            label4.Name = "label4";
            label4.Size = new Size(218, 21);
            label4.TabIndex = 7;
            label4.Text = ".user name can't contatin (#,$)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.ForeColor = Color.Red;
            label5.Location = new Point(3, 50);
            label5.Name = "label5";
            label5.Size = new Size(209, 21);
            label5.TabIndex = 8;
            label5.Text = "password can't be left empty";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.ForeColor = Color.Red;
            label6.Location = new Point(3, 71);
            label6.Name = "label6";
            label6.Size = new Size(204, 21);
            label6.TabIndex = 9;
            label6.Text = "password can't contain (#,$)";
            label6.Click += label6_Click;
            // 
            // LogIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(590, 212);
            Controls.Add(pnl_Instructions);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtBox_password);
            Controls.Add(txtBox_username);
            Controls.Add(btn_signIn);
            Name = "LogIn";
            Text = "Chat With Firends ";
            Load += LogIn_Load;
            pnl_Instructions.ResumeLayout(false);
            pnl_Instructions.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_signIn;
        private TextBox txtBox_username;
        private TextBox txtBox_password;
        private Label label1;
        private Label label2;
        private Panel pnl_Instructions;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
    }
}
