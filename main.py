from flask import Flask, request

import pprint as pp
import get_json as gj
import urllib.request as ur
import urllib.parse as up

ports = None # Global

class Message:

	def __init__(self, msg_json):			

		self.username = msg_json['username']
		self.content = msg_json['content']
		self.channel = msg_json['channel']
		self.user_id = msg_json['user_id']
		self.source = msg_json['source']

	def print_msg(self):
		print(self.content)


class Nexus:

	def __init__(self):
		self.discord = True
		self.irc = True
		self.facebook = True
		self.skype = False
		self.steam = False		
		self.twitter = False


	def relay(self, request):
		msg = Message(request)
		source = request['source']
		#print(source)

		data = up.urlencode({
			'username': msg.username,
			'content': msg.content
		})
		data = data.encode('UTF-8')


		# Relay incoming messages to Discord
		if (self.discord) and ('discord' != source):
			req = ur.Request('http://localhost:6502/post', data)
			with ur.urlopen(req) as response:
				discord_res = response.read()

		# Relay incoming messages to IRC
		if (self.irc) and ('irc' != source):
			req = ur.Request('http://localhost:6501/post', data)
			with ur.urlopen(req) as response:
				irc_res = response.read()

		if (self.facebook) and ('facebook' != source):
			req = ur.Request('http://localhost:6503/post', data)
			with ur.urlopen(req) as response:
				fb_res = response.read()

		return






app = Flask(__name__)

nexus = Nexus()

@app.route('/post', methods=['POST'])
def api_echo():
	if request.method == 'POST':
		#pp.pprint(request.get_json(),width=1)
#		msg = Message(request.get_json())
		nexus.relay(request.get_json())

		#print(request.get_json()['content'])
		return 'Message accepted!\n'

if __name__ == "__main__":
	ports = gj.get_JSON('ports.json')
	app.run(host='0.0.0.0', port=ports['main'])