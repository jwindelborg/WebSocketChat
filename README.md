# WebSocketChat

This code is forked by [rosenbjerg/WebSocketChat](https://github.com/rosenbjerg/WebSocketChat) and licensed under [AGPL-3.0](LICENSE).

## How to deploy and run

* Install docker
* Go to src folder and build `docker build -t chatroom .`
* Start docker service `docker run -p 5000:5000 -d --restart always --name chatroom chatroom`
