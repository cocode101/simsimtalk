namespace Client
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnChatting = new System.Windows.Forms.Button();
            this.btnFriend = new System.Windows.Forms.Button();
            this.btnOption = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlOpt = new System.Windows.Forms.Panel();
            this.pnlChat = new System.Windows.Forms.Panel();
            this.pnlFriend = new System.Windows.Forms.Panel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnChatting
            // 
            this.btnChatting.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnChatting.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnChatting, "btnChatting");
            this.btnChatting.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.btnChatting.Name = "btnChatting";
            this.btnChatting.UseVisualStyleBackColor = false;
            this.btnChatting.Click += new System.EventHandler(this.btnChatting_Click);
            // 
            // btnFriend
            // 
            this.btnFriend.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFriend.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnFriend, "btnFriend");
            this.btnFriend.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.btnFriend.Name = "btnFriend";
            this.btnFriend.UseVisualStyleBackColor = false;
            this.btnFriend.Click += new System.EventHandler(this.btnFriend_Click);
            // 
            // btnOption
            // 
            this.btnOption.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnOption.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnOption, "btnOption");
            this.btnOption.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.btnOption.Name = "btnOption";
            this.btnOption.UseVisualStyleBackColor = false;
            this.btnOption.Click += new System.EventHandler(this.btnOption_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnFriend);
            this.flowLayoutPanel1.Controls.Add(this.btnChatting);
            this.flowLayoutPanel1.Controls.Add(this.btnOption);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.pnlOpt);
            this.panel3.Controls.Add(this.pnlChat);
            this.panel3.Controls.Add(this.pnlFriend);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // pnlOpt
            // 
            this.pnlOpt.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.pnlOpt, "pnlOpt");
            this.pnlOpt.Name = "pnlOpt";
            // 
            // pnlChat
            // 
            this.pnlChat.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.pnlChat, "pnlChat");
            this.pnlChat.Name = "pnlChat";
            // 
            // pnlFriend
            // 
            this.pnlFriend.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.pnlFriend, "pnlFriend");
            this.pnlFriend.Name = "pnlFriend";
            // 
            // notifyIcon1
            // 
            resources.ApplyResources(this.notifyIcon1, "notifyIcon1");
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            resources.ApplyResources(this.ExitToolStripMenuItem, "ExitToolStripMenuItem");
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnChatting;
        private System.Windows.Forms.Button btnFriend;
        private System.Windows.Forms.Button btnOption;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnlOpt;
        private System.Windows.Forms.Panel pnlChat;
        private System.Windows.Forms.Panel pnlFriend;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
    }
}

