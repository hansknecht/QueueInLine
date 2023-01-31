# EasyNetQ
Sample code for EasyNetQ and RabbitMQ course.

## Starting RabbitMQ server with managment. 
I have included a compose.yaml file. From the root run
``` bash
docker compose up -d
```

To build each project with docker you need to start at the root level of the solution and call the image step with
``` bash
docker image build -f <Project>/Dockerfile -t <imageName> .
```


To run use

``` bash
docker container run --net host subscriber
```
