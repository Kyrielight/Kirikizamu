using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TritonRelay {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void send_message_Click(object sender, EventArgs e) {
            if (userlist.SelectedItem != null && message_content.Text != null) {
                SendMessage message = new SendMessage(
                    userlist.SelectedItem.ToString(),
                    message_content.Text.ToString());
                //message_content.Text = "Message sent!";
                MessageBox.Show("Your message has been sent!");
            } else {
                MessageBox.Show("Please select a username!");
            }
 
        }

        private void message_content_TextChanged(object sender, EventArgs e) {

        }

        private void all_chat_CheckedChanged(object sender, EventArgs e) {
            // MessageBox.Show("Warning: Do NOT use this unless it is an absolute emergency.");

        }

        private void administration_CheckedChanged(object sender, EventArgs e) {
  
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void userlist_SelectedIndexChanged(object sender, EventArgs e) {

        }
    }
}
