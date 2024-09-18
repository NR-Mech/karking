#include <WiFi.h>
#include <HTTPClient.h>

const char* ssid = "REPLACE_WITH_YOUR_SSID";
const char* password = "REPLACE_WITH_YOUR_PASSWORD";

const char* serverName = "https://karking-api.zaqbit.com/cars";

unsigned long lastTime = 0;

// Set timer to 5 seconds
unsigned long timerDelay = 5000;

void setup() {
  Serial.begin(115200);

  WiFi.begin(ssid, password);
  Serial.println("Connecting to WiFi...");
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  Serial.println("");
  Serial.print("Connected to WiFi network with IP Address: ");
  Serial.println(WiFi.localIP());

  Serial.println("It will take 5 seconds before publishing the first reading.");
}

void loop() {
  // Send an HTTP POST request every 5 seconds
  if ((millis() - lastTime) > timerDelay) {
    if (WiFi.status() == WL_CONNECTED) {
      WiFiClient client;
      HTTPClient http;
    
      http.begin(client, serverName);

      http.addHeader("Content-Type", "application/json");
      http.addHeader("X-API-Key", "e46b113c7c914c9b8d3da8d91ac8e6f2");
      String httpRequestData = "api_key=tPmAT5Ab3j7F9&sensor=BME280&value1=24.25&value2=49.54&value3=1005.14";           
      int httpResponseCode = http.POST(httpRequestData);
      
      http.addHeader("Content-Type", "application/json");
      int httpResponseCode = http.POST("{\"placa\":\"PGV-0746\"}");
     
      Serial.print("HTTP Response code: ");
      Serial.println(httpResponseCode);

      http.end();
    }
    else {
      Serial.println("WiFi disconnected...");
    }
    lastTime = millis();
  }
}
