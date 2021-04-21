namespace Server
{
    partial class ServerMain
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
            this.serverGroupBox = new System.Windows.Forms.GroupBox();
            this.serverCutButton = new System.Windows.Forms.Button();
            this.serverPortTextBox = new System.Windows.Forms.TextBox();
            this.serverIPTextBox = new System.Windows.Forms.TextBox();
            this.serverButton = new System.Windows.Forms.Button();
            this.serverPortLabel = new System.Windows.Forms.Label();
            this.serverIPLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DBCutButton = new System.Windows.Forms.Button();
            this.DBButton = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.userIDTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DBNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DBPortTextBox = new System.Windows.Forms.TextBox();
            this.DBIPTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.serverGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serverGroupBox
            // 
            this.serverGroupBox.Controls.Add(this.serverCutButton);
            this.serverGroupBox.Controls.Add(this.serverPortTextBox);
            this.serverGroupBox.Controls.Add(this.serverIPTextBox);
            this.serverGroupBox.Controls.Add(this.serverButton);
            this.serverGroupBox.Controls.Add(this.serverPortLabel);
            this.serverGroupBox.Controls.Add(this.serverIPLabel);
            this.serverGroupBox.Location = new System.Drawing.Point(13, 13);
            this.serverGroupBox.Name = "serverGroupBox";
            this.serverGroupBox.Size = new System.Drawing.Size(303, 76);
            this.serverGroupBox.TabIndex = 0;
            this.serverGroupBox.TabStop = false;
            this.serverGroupBox.Text = "서버";
            // 
            // serverCutButton
            // 
            this.serverCutButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.serverCutButton.Enabled = false;
            this.serverCutButton.Location = new System.Drawing.Point(247, 17);
            this.serverCutButton.Name = "serverCutButton";
            this.serverCutButton.Size = new System.Drawing.Size(50, 50);
            this.serverCutButton.TabIndex = 5;
            this.serverCutButton.Text = "해제";
            this.serverCutButton.UseVisualStyleBackColor = true;
            this.serverCutButton.Click += new System.EventHandler(this.serverCutButton_Click);
            // 
            // serverPortTextBox
            // 
            this.serverPortTextBox.Location = new System.Drawing.Point(84, 46);
            this.serverPortTextBox.Name = "serverPortTextBox";
            this.serverPortTextBox.Size = new System.Drawing.Size(102, 21);
            this.serverPortTextBox.TabIndex = 4;
            this.serverPortTextBox.Text = "5000";
            // 
            // serverIPTextBox
            // 
            this.serverIPTextBox.Location = new System.Drawing.Point(84, 21);
            this.serverIPTextBox.Name = "serverIPTextBox";
            this.serverIPTextBox.Size = new System.Drawing.Size(102, 21);
            this.serverIPTextBox.TabIndex = 3;
            this.serverIPTextBox.Text = "127.0.0.1";
            this.serverIPTextBox.TextChanged += new System.EventHandler(this.serverIPTextBox_TextChanged);
            // 
            // serverButton
            // 
            this.serverButton.Location = new System.Drawing.Point(191, 17);
            this.serverButton.Name = "serverButton";
            this.serverButton.Size = new System.Drawing.Size(50, 50);
            this.serverButton.TabIndex = 2;
            this.serverButton.Text = "연결";
            this.serverButton.UseVisualStyleBackColor = true;
            this.serverButton.Click += new System.EventHandler(this.serverButton_Click);
            // 
            // serverPortLabel
            // 
            this.serverPortLabel.AutoSize = true;
            this.serverPortLabel.Location = new System.Drawing.Point(16, 51);
            this.serverPortLabel.Name = "serverPortLabel";
            this.serverPortLabel.Size = new System.Drawing.Size(70, 12);
            this.serverPortLabel.TabIndex = 1;
            this.serverPortLabel.Text = "Port Num : ";
            // 
            // serverIPLabel
            // 
            this.serverIPLabel.AutoSize = true;
            this.serverIPLabel.Location = new System.Drawing.Point(7, 24);
            this.serverIPLabel.Name = "serverIPLabel";
            this.serverIPLabel.Size = new System.Drawing.Size(79, 12);
            this.serverIPLabel.TabIndex = 0;
            this.serverIPLabel.Text = "IP Addrass : ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DBCutButton);
            this.groupBox2.Controls.Add(this.DBButton);
            this.groupBox2.Controls.Add(this.passwordTextBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.userIDTextBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.DBNameTextBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.DBPortTextBox);
            this.groupBox2.Controls.Add(this.DBIPTextBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(13, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(303, 151);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DB";
            // 
            // DBCutButton
            // 
            this.DBCutButton.Enabled = false;
            this.DBCutButton.Location = new System.Drawing.Point(247, 85);
            this.DBCutButton.Name = "DBCutButton";
            this.DBCutButton.Size = new System.Drawing.Size(50, 50);
            this.DBCutButton.TabIndex = 16;
            this.DBCutButton.Text = "해제";
            this.DBCutButton.UseVisualStyleBackColor = true;
            this.DBCutButton.Click += new System.EventHandler(this.DBCutButton_Click);
            // 
            // DBButton
            // 
            this.DBButton.Location = new System.Drawing.Point(247, 22);
            this.DBButton.Name = "DBButton";
            this.DBButton.Size = new System.Drawing.Size(50, 50);
            this.DBButton.TabIndex = 15;
            this.DBButton.Text = "연결";
            this.DBButton.UseVisualStyleBackColor = true;
            this.DBButton.Click += new System.EventHandler(this.DBButton_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(83, 118);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(158, 21);
            this.passwordTextBox.TabIndex = 14;
            this.passwordTextBox.Text = "1234";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "Password : ";
            // 
            // userIDTextBox
            // 
            this.userIDTextBox.Location = new System.Drawing.Point(84, 93);
            this.userIDTextBox.Name = "userIDTextBox";
            this.userIDTextBox.Size = new System.Drawing.Size(157, 21);
            this.userIDTextBox.TabIndex = 12;
            this.userIDTextBox.Text = "Human";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "userID : ";
            // 
            // DBNameTextBox
            // 
            this.DBNameTextBox.Location = new System.Drawing.Point(84, 68);
            this.DBNameTextBox.Name = "DBNameTextBox";
            this.DBNameTextBox.Size = new System.Drawing.Size(157, 21);
            this.DBNameTextBox.TabIndex = 10;
            this.DBNameTextBox.Text = "Chatting_DB";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "DB Num : ";
            // 
            // DBPortTextBox
            // 
            this.DBPortTextBox.Location = new System.Drawing.Point(83, 44);
            this.DBPortTextBox.Name = "DBPortTextBox";
            this.DBPortTextBox.Size = new System.Drawing.Size(158, 21);
            this.DBPortTextBox.TabIndex = 8;
            this.DBPortTextBox.Text = "1433";
            // 
            // DBIPTextBox
            // 
            this.DBIPTextBox.Location = new System.Drawing.Point(83, 19);
            this.DBIPTextBox.Name = "DBIPTextBox";
            this.DBIPTextBox.Size = new System.Drawing.Size(158, 21);
            this.DBIPTextBox.TabIndex = 7;
            this.DBIPTextBox.Text = "210.119.12.76";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "Port Num : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "IP Addrass : ";
            // 
            // resultTextBox
            // 
            this.resultTextBox.Location = new System.Drawing.Point(322, 13);
            this.resultTextBox.Multiline = true;
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.Size = new System.Drawing.Size(243, 233);
            this.resultTextBox.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripLabel3,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.toolStripLabel4,
            this.toolStripSeparator2,
            this.toolStripLabel5,
            this.toolStripLabel6});
            this.toolStrip1.Location = new System.Drawing.Point(0, 253);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(580, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(82, 22);
            this.toolStripLabel1.Text = "DB 연결상태 :";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(59, 22);
            this.toolStripLabel3.Text = "연결 대기";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator1.Visible = false;
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(90, 22);
            this.toolStripLabel2.Text = "서버 연결상태 :";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(59, 22);
            this.toolStripLabel4.Text = "연결 대기";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator2.Visible = false;
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(66, 22);
            this.toolStripLabel5.Text = "접속인원 : ";
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(14, 22);
            this.toolStripLabel6.Text = "0";
            // 
            // ServerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 278);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.serverGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ServerMain";
            this.Text = "Server Control";
            this.serverGroupBox.ResumeLayout(false);
            this.serverGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox serverGroupBox;
        private System.Windows.Forms.Label serverPortLabel;
        private System.Windows.Forms.Label serverIPLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox resultTextBox;
        protected internal System.Windows.Forms.Button serverButton;
        private System.Windows.Forms.TextBox serverIPTextBox;
        private System.Windows.Forms.TextBox serverPortTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox userIDTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox DBNameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DBPortTextBox;
        private System.Windows.Forms.TextBox DBIPTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button serverCutButton;
        private System.Windows.Forms.Button DBCutButton;
        private System.Windows.Forms.Button DBButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
    }
}

