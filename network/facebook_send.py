import urllib.request as ur
import urllib.parse as up

from fbchat import Client
from fbchat.models import *

import pprint as pp

import json

name_directory = {}

class EchoBot(Client):

	def onMessage(self, author_id, message_object, thread_id, thread_type, **kwargs):
		self.markAsDelivered(author_id, thread_id)
		self.markAsRead(author_id)

		try:
			username = name_directory[author_id]
		except KeyError:
			username = client.fetchUserInfo(author_id)[author_id].name
			name_directory[author_id] = username

		# If you're not the author, echo
		if author_id != self.uid:
			#self.send(message_object, thread_id=thread_id, thread_type=thread_type)
			data = {
				'username': username,
				'content': message_object.text,
				'channel': thread_id,
				'user_id': author_id,
				'source': 'facebook'
			}
			req = ur.Request('http://localhost:6500/post', json.dumps(data).encode('utf8'), 
								headers={'Content-Type': 'application/json'})
			with ur.urlopen(req) as response:
				res = response.read()


client = EchoBot('EMAIL', 'PASSWORD')

#message_id = client.send(Message(text='Triton Relay Initialized'), thread_id=1611438152279266, thread_type=ThreadType.GROUP)

client.listen(markAlive=False)


client.logout()