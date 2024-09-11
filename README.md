# karking

Karking

## Erro na lib MFRC522 + ESP32

in the file: /Arduino/libraries/MFRC522/src/MFRC522Extended.cpp

Line: 824 and 847
replace: if (backData && (backLen > 0))
by : if (backData && backLen != nullptr)
