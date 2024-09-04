#include <Servo.h>

Servo myservo;

int angle = 0;
int redLed = 2;
int greenLed = 3;

void setup() {
  myservo.attach(4);
  pinMode(redLed, OUTPUT);
  pinMode(greenLed, OUTPUT);
}

void loop() {
  digitalWrite(redLed, HIGH);
  delay(2000);
  digitalWrite(redLed, LOW);
  digitalWrite(greenLed, HIGH);
  for (angle = 0; angle <= 120; angle += 2) {
    myservo.write(angle);
    delay(15);
  }
  delay(3000);
  digitalWrite(greenLed, LOW);
  digitalWrite(redLed, HIGH);
  for (angle = 120; angle >=0; angle -= 2) {
    myservo.write(angle);
    delay(15);
  }
}
