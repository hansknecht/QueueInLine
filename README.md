# EasyNetQ
Sample code for EasyNetQ and RabbitMQ course.

This code pattern was originally modeled after the "Asynchronous Messaging with RabbitMQ and EasyNetQ" on Pluralsight Skills.
By Stephen Haunts. 

That code requires some additional updates to make current. This includes an upgrade to the latest version of EasyNetQ. I am also adding Docker support and instructions. 


## Starting RabbitMQ server with managment. 
I have included a compose.yaml file. From the root run
``` bash
docker compose up -d
```

## Build each project
To build each project with docker you need to start at the root level of the solution and call the image step with
``` bash
docker image build -f <Project>/Dockerfile -t <imageName> .
```

View with 
``` bash
docker image ls
```

To run the individual publishers
``` bash
docker container run --net host <imageName>
```

To run Subscribe you need to include the interactive *-it* option

``` bash
docker container run -it --net host <imageName>
```

# Areas
## 1. Shared Code
This is the message formats needed

## 2. Quick Start
This is a test that messages are moving from one end point to another

## 3. Publish and Subscribe
This demonstrates the overall patter


