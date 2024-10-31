#include <SPI.h>
#include <MFRC522.h>

#include <WiFi.h>
#include <HTTPClient.h>
#include <WiFiClientSecure.h>

#include <ESP32Servo.h>

#define SERVO_PIN 25
#define GREEN_PIN 12
#define RED_PIN 32
#define BUZZER_PIN 13

Servo servo;
int angle = 0;

// Motor COM fita -> 0 e 90
// Motor SEM fita -> 15 e 120
int minAngle = 0;
int maxAngle = 100;

MFRC522 _mfrc522(5, 2);
MFRC522::MIFARE_Key _key;          

int _blockIndex = 2;
byte _bufferSize = 18;
byte _readBlockData[18];

// const char* ssid = "NOVA ROMA - ALUNOS";
// const char* password = "Alunos@NR!2022!";
const char* ssid = "Zaqueu";
const char* password = "Zaqueu2023";
const char* serverName = "https://karking-api.zaqbit.com/vehicles";

void setup() 
{
  Serial.begin(9600);
  SPI.begin();
  _mfrc522.PCD_Init();

  WiFi.begin(ssid, password);
  Serial.println("Conectando...");
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  Serial.println("");
  Serial.print("Online!");

	ESP32PWM::allocateTimer(0);
	ESP32PWM::allocateTimer(1);
	ESP32PWM::allocateTimer(2);
	ESP32PWM::allocateTimer(3);
	servo.setPeriodHertz(50);
	servo.attach(SERVO_PIN, 500, 2400);

  pinMode(GREEN_PIN, OUTPUT);
  pinMode(RED_PIN, OUTPUT);
  pinMode(BUZZER_PIN, OUTPUT);
}

void loop()
{
  digitalWrite(RED_PIN, HIGH);

  for (byte i=0; i<6; i++)
  {
    _key.keyByte[i] = 0xFF;
  }

  if (!_mfrc522.PICC_IsNewCardPresent()) return;
  if (!_mfrc522.PICC_ReadCardSerial()) return;

  Authenticate();
  _mfrc522.MIFARE_Read(_blockIndex, _readBlockData, &_bufferSize);

  String plate = String((char*)_readBlockData);
  Serial.print("Placa = ");
  Serial.print(plate);
  Serial.print("\n");

  digitalWrite(RED_PIN, LOW);
  digitalWrite(GREEN_PIN, HIGH);
  digitalWrite(BUZZER_PIN, HIGH);
  delay(500);
  digitalWrite(BUZZER_PIN, LOW);

  for (angle = minAngle; angle <= maxAngle; angle += 2) {
    servo.write(angle);
    delay(15);
  }

  delay(3000);

  digitalWrite(GREEN_PIN, LOW);
  digitalWrite(RED_PIN, HIGH);
  for (angle = maxAngle; angle >= minAngle; angle -= 2) {
    servo.write(angle);
    delay(15);
  }

  if (WiFi.status() == WL_CONNECTED) {
    WiFiClientSecure *client = new WiFiClientSecure;
    HTTPClient https;

    client->setInsecure();
    https.begin(*client, serverName);

    https.addHeader("Content-Type", "application/json");
    https.addHeader("X-API-Key", "e46b113c7c914c9b8d3da8d91ac8e6f2");
    
    int httpResponseCode = https.POST("{\"plate\":\"" + plate + "\"}");
    
    Serial.print("HTTP Response code: ");
    Serial.print(httpResponseCode);
    Serial.println(https.getString());

    https.end();
  }
  else {
    Serial.println("Off-line...");
  }

  _mfrc522.PICC_HaltA();
  _mfrc522.PCD_StopCrypto1();
}

void Authenticate()
{
  _mfrc522.PCD_Authenticate(MFRC522::PICC_CMD_MF_AUTH_KEY_A, _blockIndex, &_key, &(_mfrc522.uid));
}
