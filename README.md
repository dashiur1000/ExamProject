```
docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management
```
```
docker run -d --name mysql-db -p 3306:3306 -e MYSQL_ROOT_PASSWORD=root -e MYSQL_DATABASE=exam_db mysql:8.0
```
```
docker exec -it mysql-db mysql -uroot -proot
```
```
docker run -d --name elasticsearch -p 9200:9200 -p 9300:9300 -e "discovery.type=single-node" -e "xpack.security.enabled=false" elasticsearch:8.11.3
```
```
docker run -d --name kibana -p 5601:5601 --link elasticsearch:elasticsearch -e "ELASTICSEARCH_HOSTS=http://elasticsearch:9200" kibana:8.11.3
```
```
cd CSharpProducer 
```
```
dotnet run
```
```
http://localhost:15672/#/
```
```
http://localhost:5601/app/dev_tools#/console
```
```
cd ..
```
```

```