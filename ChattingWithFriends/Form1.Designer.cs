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
            checkedList_UnblockedClients = new CheckedListBox();
            button1 = new Button();
            btn_UnBlock = new Button();
            checkedList_BlockedClients = new CheckedListBox();
            label1 = new Label();
            label2 = new Label();
            btn_StopService = new Button();
            SuspendLayout();
            // 
            // btn_start
            // 
            btn_start.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btn_start.AutoSize = true;
            btn_start.Font = new Font("Segoe UI", 12F);
            btn_start.ForeColor = Color.Green;
            btn_start.Location = new Point(-1, 2);
            btn_start.Name = "btn_start";
            btn_start.Size = new Size(800, 31);
            btn_start.TabIndex = 0;
            btn_start.Text = "Start Service";
            btn_start.UseVisualStyleBackColor = true;
            btn_start.Click += btnClick_StartService;
            // 
            // checkedList_UnblockedClients
            // 
            checkedList_UnblockedClients.CheckOnClick = true;
            checkedList_UnblockedClients.Font = new Font("Segoe UI", 12F);
            checkedList_UnblockedClients.FormattingEnabled = true;
            checkedList_UnblockedClients.Location = new Point(12, 67);
            checkedList_UnblockedClients.Name = "checkedList_UnblockedClients";
            checkedList_UnblockedClients.Size = new Size(378, 316);
            checkedList_UnblockedClients.TabIndex = 1;
            checkedList_UnblockedClients.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.Font = new Font("Segoe UI", 12F);
            button1.ForeColor = Color.Red;
            button1.Location = new Point(12, 401);
            button1.Name = "button1";
            button1.Size = new Size(103, 39);
            button1.TabIndex = 2;
            button1.Text = "Block >>";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // btn_UnBlock
            // 
            btn_UnBlock.AutoSize = true;
            btn_UnBlock.Font = new Font("Segoe UI", 12F);
            btn_UnBlock.ForeColor = Color.Green;
            btn_UnBlock.Location = new Point(679, 401);
            btn_UnBlock.Name = "btn_UnBlock";
            btn_UnBlock.Size = new Size(109, 39);
            btn_UnBlock.TabIndex = 3;
            btn_UnBlock.Text = "<< Un-Block";
            btn_UnBlock.UseVisualStyleBackColor = true;
            // 
            // checkedList_BlockedClients
            // 
            checkedList_BlockedClients.CheckOnClick = true;
            checkedList_BlockedClients.Font = new Font("Segoe UI", 12F);
            checkedList_BlockedClients.FormattingEnabled = true;
            checkedList_BlockedClients.Location = new Point(410, 67);
            checkedList_BlockedClients.Name = "checkedList_BlockedClients";
            checkedList_BlockedClients.Size = new Size(378, 316);
            checkedList_BlockedClients.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 36);
            label1.Name = "label1";
            label1.Size = new Size(109, 21);
            label1.TabIndex = 5;
            label1.Text = "Allowed Users";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(410, 36);
            label2.Name = "label2";
            label2.Size = new Size(107, 21);
            label2.TabIndex = 6;
            label2.Text = "Blocked Users";
            // 
            // btn_StopService
            // 
            btn_StopService.AutoSize = true;
            btn_StopService.Dock = DockStyle.Top;
            btn_StopService.Font = new Font("Segoe UI", 12F);
            btn_StopService.ForeColor = Color.Red;
            btn_StopService.Location = new Point(0, 0);
            btn_StopService.Name = "btn_StopService";
            btn_StopService.Size = new Size(800, 31);
            btn_StopService.TabIndex = 7;
            btn_StopService.Text = "Stop Service";
            btn_StopService.UseVisualStyleBackColor = true;
            btn_StopService.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_StopService);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(checkedList_BlockedClients);
            Controls.Add(btn_UnBlock);
            Controls.Add(button1);
            Controls.Add(checkedList_UnblockedClients);
            Controls.Add(btn_start);
            Name = "Form1";
            Text = "ChatWithFriends_Admin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_start;
        private CheckedListBox checkedList_UnblockedClients;
        private Button button1;
        private Button btn_UnBlock;
        private CheckedListBox checkedList_BlockedClients;
        private Label label1;
        private Label label2;
        private Button btn_StopService;
    }
}
