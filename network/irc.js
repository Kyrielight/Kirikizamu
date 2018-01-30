var irc = require('irc')
var request = require('request')

freenode = 'chat.freenode.net'
nick = 'Kirikizamu'

address = 'http://localhost:6500/post'

var irc_client = new irc.Client(freenode, nick, {
	userName: 'einzbern',
	realName: 'Ilya',
	autoRejoin: true,
    channels: ['#testingme'],
    secure: true,
    port: 6697,
    stripColors: true,
});


irc_client.addListener('raw', function(msg) {
	if (msg.command == 'PRIVMSG') {
		console.log(msg)

		var message = {
			username: msg['nick'],
			content: msg['args'][1],
			channel: msg['args'][0],
			user_id: msg['prefix'],
			source: 'irc'
		}

		request({
			url: address,
			method: 'POST',
			json: true,
			body: message
		}, function(error, response, body) {
		//pass
		})

	}

})
	
console.log("Listener engaged.")