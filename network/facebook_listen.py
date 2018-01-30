from flask import Flask, request

from fbchat import Client
from fbchat.models import *

import pprint as pp


client = Client('EMAIL', 'PASSWORD')


app = Flask(__name__)

@app.route('/post', methods=['POST'])
def api_echo():
	if request.method == 'POST':

		msg_username = request.form['username']
		msg_content = request.form['content']

		msg_to_send = '<' + msg_username + '>: ' + msg_content

		client.send(Message(text=msg_to_send), thread_id=000000, thread_type=ThreadType.GROUP)

		return 'Message accepted!\n'




app.run(host='0.0.0.0', port=6503)
client.logout()