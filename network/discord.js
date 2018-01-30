var request = require('request')

const Discord = require('discord.js');
const client = new Discord.Client();

address = 'http://localhost:6500/post'


const express = require('express')
const app = express()

var bodyParser = require('body-parser');
app.use(bodyParser.json());   //
app.use(bodyParser.urlencoded({ extended: true })); // Support URL-encoded bodies 

app.use(express.json());       // to support JSON-encoded bodies
app.use(bodyParser.urlencoded({ extended: true })); // to support URL-encoded bodies


client.on('ready', () => {
  console.log('Discord bot initialized');
});

client.on('message', message => {

  	//message.channel.send('pong');
  	if (message.author.id != client.user.id) {

  		var message = {
	  		username: message.author.username,
  			content: message.content,
    		channel: message.channel.name,
    		user_id: message.author.id,
    		source: 'discord'
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

});


// Listen to incoming requests
app.post('/post', (req, res) => {
  console.log('Discord POST received');
  console.log(req.body.xkey)

  var channel = client.guilds.array();
  console.log(channel[0].channels[0].name);

  //client.guilds.array()[0].defaultChannel.sendMessage("Hi!")

  res.writeHead(200, {'Content-Type': 'text/xml'});
  res.end("Successful post");

})


client.login('MzgwMTMzNTE1MTUwNDkxNjUx.DVFRcA.aPHBeisowbn6vy8fMuKhD20OUCM');

app.listen(6502, () => console.log('Discord listening on 6502'))