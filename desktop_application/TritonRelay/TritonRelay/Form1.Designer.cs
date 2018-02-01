namespace TritonRelay {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.message_content = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.send_message = new System.Windows.Forms.Button();
            this.all_chat = new System.Windows.Forms.CheckBox();
            this.administration = new System.Windows.Forms.CheckBox();
            this.userlist = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // message_content
            // 
            this.message_content.Location = new System.Drawing.Point(231, 12);
            this.message_content.Multiline = true;
            this.message_content.Name = "message_content";
            this.message_content.Size = new System.Drawing.Size(533, 343);
            this.message_content.TabIndex = 2;
            this.message_content.TextChanged += new System.EventHandler(this.message_content_TextChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 361);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(751, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // send_message
            // 
            this.send_message.Location = new System.Drawing.Point(13, 302);
            this.send_message.Name = "send_message";
            this.send_message.Size = new System.Drawing.Size(212, 53);
            this.send_message.TabIndex = 6;
            this.send_message.Text = "Send Message";
            this.send_message.UseVisualStyleBackColor = true;
            this.send_message.Click += new System.EventHandler(this.send_message_Click);
            // 
            // all_chat
            // 
            this.all_chat.AutoSize = true;
            this.all_chat.Location = new System.Drawing.Point(13, 12);
            this.all_chat.Name = "all_chat";
            this.all_chat.Size = new System.Drawing.Size(139, 21);
            this.all_chat.TabIndex = 7;
            this.all_chat.Text = "All Triton Gaming";
            this.all_chat.UseVisualStyleBackColor = true;
            this.all_chat.CheckedChanged += new System.EventHandler(this.all_chat_CheckedChanged);
            // 
            // administration
            // 
            this.administration.AutoSize = true;
            this.administration.Location = new System.Drawing.Point(13, 39);
            this.administration.Name = "administration";
            this.administration.Size = new System.Drawing.Size(119, 21);
            this.administration.TabIndex = 8;
            this.administration.Text = "Administration";
            this.administration.UseVisualStyleBackColor = true;
            this.administration.CheckedChanged += new System.EventHandler(this.administration_CheckedChanged);
            // 
            // userlist
            // 
            this.userlist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userlist.FormattingEnabled = true;
            this.userlist.Items.AddRange(new object[] {
            "Annie Chai",
            "Jarek Lu",
            "Poom Sethabutr",
            "Xuân Anh Nguyễn"});
            this.userlist.Location = new System.Drawing.Point(13, 271);
            this.userlist.Name = "userlist";
            this.userlist.Size = new System.Drawing.Size(212, 24);
            this.userlist.TabIndex = 9;
            this.userlist.SelectedIndexChanged += new System.EventHandler(this.userlist_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(776, 395);
            this.Controls.Add(this.userlist);
            this.Controls.Add(this.administration);
            this.Controls.Add(this.all_chat);
            this.Controls.Add(this.send_message);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.message_content);
            this.Name = "Form1";
            this.Text = "Triton Gaming Announcement Relay";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox message_content;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button send_message;
        private System.Windows.Forms.CheckBox all_chat;
        private System.Windows.Forms.CheckBox administration;
        private System.Windows.Forms.ComboBox userlist;
    }
}

