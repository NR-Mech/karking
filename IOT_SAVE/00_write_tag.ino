#include <SPI.h>
#include <MFRC522.h>

MFRC522 _mfrc522(5, 2);
MFRC522::MIFARE_Key _key;          

int _blockIndex = 2;
byte _writeBlockData [16] = { "ERT8246" };

byte _bufferSize = 18;
byte _readBlockData[18];

void setup() 
{
  Serial.begin(9600);
  SPI.begin();
  _mfrc522.PCD_Init();
}

void loop()
{
  for (byte i=0; i<6; i++)
  {
    _key.keyByte[i] = 0xFF;
  }

  if (!_mfrc522.PICC_IsNewCardPresent()) return;
  if (!_mfrc522.PICC_ReadCardSerial()) return;

  Authenticate();
  _mfrc522.MIFARE_Write(_blockIndex, _writeBlockData, 16);
  _mfrc522.MIFARE_Read(_blockIndex, _readBlockData, &_bufferSize);

  String plate = String((char*)_readBlockData);
  Serial.print("Placa = ");
  Serial.print(plate);
  Serial.print("\n");
}

void Authenticate()
{
  _mfrc522.PCD_Authenticate(MFRC522::PICC_CMD_MF_AUTH_KEY_A, _blockIndex, &_key, &(_mfrc522.uid));
}
