
build: ## build a docker container
	docker build -t emjonesapp:0.0.1 .
  
run:
	docker run -ti --rm -d -p=5000:5000 --name="em_jones_app" emjonesapp:0.0.1

up: build run