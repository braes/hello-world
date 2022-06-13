# How to build docker image

docker build -t hello-world -f .\HelloWorld\Dockerfile .

# How to run

docker run -p 8080:80  hello-world

Navigate to http://localhost:8080/count