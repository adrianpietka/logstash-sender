# Logstash Sender

PoC of how to send some JSON logs to logstash via the TCP input.

The log message should be a stringified JSON object in the @message field.

*Via .NET C#*

## App configuration

App.config file:

```xml
<appSettings>
   <add key="repeat" value="10" />
   <add key="timeout" value="1" />
   <add key="logstashHost" value="192.168.2.2" />
   <add key="logstashPort" value="5000" />
</appSettings>
```

It assumes the logstash host is on 192.168.2.2 and the TCP listening input is 5000.

## Logstash configuration

The logstash.conf should look like the example:

```
input {
   tcp {
      port => 5000
      codec => "json"
   }
}

output {
   elasticsearch {
      hosts => "elasticsearch:9200"
   }
}
```

## Sended data

```json
{"Id": 4, "DateTime": "2016-06-30T20:32:42.9312186+02:00", "Message": "Test Message: 4"}
```

Sending one JSON log per line.

## Indexed data

```json
{
   "_index": "logstash-2016.06.30",
   "_type": "myApp",
   "_id": "AVWilaOB3ZxJrxsU5D_D",
   "_score": null,
   "_source": {
      "Id": 4,
      "DateTime": "2016-06-30T20:32:42.9312186+02:00",
      "Message": "Test Message: 4",
      "@version": "1",
      "@timestamp": "2016-06-30T18:32:42.931Z",
      "host": "192.168.2.3",
      "port": 63600
   },
   "fields": {
      "DateTime": [
         1467311562931
      ],
      "@timestamp": [
         1467311562931
      ]
   },
   "sort": [
      1467311562931
   ]
}
```