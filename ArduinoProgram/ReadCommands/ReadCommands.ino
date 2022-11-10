/*
XAAAAAAA DDDDDDDD LLLCCCCC
X - wybór linii (0 - rozjazdy, 1 - semafory)
AAAAAAA - 7bit adres
DDDDDDDD - 1-8 bit danych do wpisania)
LLL - Długość danych (1-8 bit) (zakładamy że dane są minimalnej długości 1 bita, więc: 000 to 1 bit, 111 to 8 bitów danych)
CCCCC - bity CRC dla weryfikacji poprawności danych
*/

int junctionDataPin = 2;
int junctionClockPin = 4;
int junctionLatchPin = 3;

int signalDataPin = 5;
int signalClockPin = 6;
int signalLatchPin = 7;

const int junctionRegistersNumber = 3;
int junctionData[junctionRegistersNumber];

const int signalRegistersNumber = 3;
int signalData[signalRegistersNumber];

byte buffer[3];

void setup() {
  Serial.begin(9600);
  pinMode(junctionLatchPin, OUTPUT);
  pinMode(junctionClockPin, OUTPUT);
  pinMode(junctionDataPin, OUTPUT);
}

// Example serial byte read:
// 00000011 00000001 00010101
// junction, no.3, on, only 1 bit, control bits ok
// First register (0-7)

void loop() {

  //Go off only if there is something to read
  if(Serial.available() > 0){
    Serial.readBytes(buffer, 3);
    //Check correctness of the control bits
    if((buffer[2] & 0b00011111) == 21){
      
      //For junctions (first bit = 0)
      if((((buffer[0] & 0b10000000) >> 7) == 1 && ((buffer[2] & 0b11100000) >> 5) == 0){
        changeJunctions(buffer);
      }
      //For signals
      else if((buffer[0] & 0b10000000) == 1){
        changeSignals(buffer);
      }

    }else{
      Serial.println("not ok, error.");
    }
    //count up routine
    digitalWrite(junctionLatchPin, LOW);
    for(int i = junctionRegistersNumber; i >= 0; i--){
      shiftOut(junctionDataPin, junctionClockPin, MSBFIRST, junctionData[i]);
    }
    digitalWrite(junctionLatchPin, HIGH);
  }
}

void changeJunctions(byte buff[]){
  //Which register to write to - take adress from buffer and divide by 8
  int registerBlock = junctionData[(buff[0] & 0b01111111)/8];
  //Next change one bit respectively to the second byte of buffer
  if(buff[1]){
    bitSet(registerBlock, (buff[0] & 0b01111111)%8);
  }else{
    bitClear(registerBlock, (buff[0] & 0b01111111)%8);
  }
  junctionData[(buff[0] & 0b01111111)/8] = registerBlock;
}

void changeSignals(byte buff[]){
  
}
