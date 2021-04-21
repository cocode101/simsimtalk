namespace Client
{
    partial class ChatRoom
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
            this.btnMember = new System.Windows.Forms.Button();
            this.btnFileSend = new System.Windows.Forms.Button();
            this.btnFileList = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnMsgSend = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // btnMember
            // 
            this.btnMember.Location = new System.Drawing.Point(0, 0);
            this.btnMember.Name = "btnMember";
            this.btnMember.Size = new System.Drawing.Size(75, 30);
            this.btnMember.TabIndex = 0;
            this.btnMember.Text = "인원";
            this.btnMember.UseVisualStyleBackColor = true;
            this.btnMember.Click += new System.EventHandler(this.btnMember_Click);
            // 
            // btnFileSend
            // 
            this.btnFileSend.Location = new System.Drawing.Point(194, 0);
            this.btnFileSend.Name = "btnFileSend";
            this.btnFileSend.Size = new System.Drawing.Size(75, 30);
            this.btnFileSend.TabIndex = 1;
            this.btnFileSend.Text = "파일전송";
            this.btnFileSend.UseVisualStyleBackColor = true;
            this.btnFileSend.Click += new System.EventHandler(this.btnFileSend_Click);
            // 
            // btnFileList
            // 
            this.btnFileList.Location = new System.Drawing.Point(269, 0);
            this.btnFileList.Name = "btnFileList";
            this.btnFileList.Size = new System.Drawing.Size(75, 30);
            this.btnFileList.TabIndex = 2;
            this.btnFileList.Text = "파일목록";
            this.btnFileList.UseVisualStyleBackColor = true;
            this.btnFileList.Click += new System.EventHandler(this.btnFileList_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(7, 392);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(262, 68);
            this.textBox2.TabIndex = 4;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // btnMsgSend
            // 
            this.btnMsgSend.Location = new System.Drawing.Point(269, 392);
            this.btnMsgSend.Name = "btnMsgSend";
            this.btnMsgSend.Size = new System.Drawing.Size(68, 68);
            this.btnMsgSend.TabIndex = 5;
            this.btnMsgSend.Text = "전송";
            this.btnMsgSend.UseVisualStyleBackColor = true;
            this.btnMsgSend.Click += new System.EventHandler(this.btnMsgSend_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Gainsboro;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 34);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(323, 354);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // ChatRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 466);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnMsgSend);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btnFileList);
            this.Controls.Add(this.btnFileSend);
            this.Controls.Add(this.btnMember);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ChatRoom";
            this.Text = "채팅방";
            this.Load += new System.EventHandler(this.ChatRoom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMember;
        private System.Windows.Forms.Button btnFileSend;
        private System.Windows.Forms.Button btnFileList;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnMsgSend;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}