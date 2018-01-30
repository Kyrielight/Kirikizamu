const express = require('express')
const app = express()

var bodyParser = require('body-parser');
app.use(bodyParser.json());   //
app.use(bodyParser.urlencoded({ extended: true })); // Support URL-encoded bodies 

app.use(express.json());       // to support JSON-encoded bodies
app.use(bodyParser.urlencoded({ extended: true })); // to support URL-encoded bodies


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
	

// Listen to incoming requests
app.post('/post', (req, res) => {
  //console.log('Discord POST received');

  msg_username = req.body.username;
  msg_content = req.body.content;
  msg_to_send = `<${msg_username}>: ${msg_content}`;

  irc_client.say('#testingme', msg_to_send);


  res.writeHead(200, {'Content-Type': 'text/xml'});
  res.end("Successful post");
})


console.log("Listener engaged.")

app.listen(6501, () => console.log('IRC listening on 6501'))