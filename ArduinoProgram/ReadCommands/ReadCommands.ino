/*
XAAAAAAA DDDDDDDD LLLCCCCC
X - wybór linii (0 - rozjazdy, 1 - semafory)
AAAAAAA - 7bit adres
DDDDDDDD - 1-8 bit danych do wpisania)
LLL - Długość danych (1-8 bit) (zakładamy że dane są minimalnej długości 1 bita, więc: 000 to 1 bit, 111 to 8 bitów danych)
CCCCC - bity CRC dla weryfikacji poprawności danych
*/

// Example serial byte read:
// 00000011 00000001 00010101
// junction, no.3, on, only 1 bit, control bits ok.
// First register (0-7)
//
// Another example:
// 10000011 00000010 01110101
// signal, from pin no.4, 4 bits (011 - LLL), reading from 2nd byte from lsb - 1010 - pin 4-HIGH, 5-LOW, 6-HIGH, 7-LOW, control bits ok.

int junctionDataPin = 2;
int junctionClockPin = 3;
int junctionLatchPin = 4;

int signalDataPin = 5;
int signalClockPin = 6;
int signalLatchPin = 7;

// Number of registers for junctions
const int junctionRegistersNumber = 3;
int junctionData[junctionRegistersNumber];

// Number of registers for signals
const int signalRegistersNumber = 3;
int signalData[signalRegistersNumber];


byte buffer[3]; // = {0b10000111, 0b00110100, 0b10110101};

void setup() {
  Serial.begin(9600);
  pinMode(junctionLatchPin, OUTPUT);
  pinMode(junctionClockPin, OUTPUT);
  pinMode(junctionDataPin, OUTPUT);
  pinMode(signalLatchPin, OUTPUT);
  pinMode(signalClockPin, OUTPUT);
  pinMode(signalDataPin, OUTPUT);
  
  //changeSignals(buffer);
  
}

void loop() {

  
  // Version for simulating in wokwi:
  // digitalWrite(signalLatchPin, LOW);
  //   for(int i = signalRegistersNumber; i >= 0; i--){
  //     shiftOut(signalDataPin, signalClockPin, MSBFIRST, signalData[i]);
  //   }
  // digitalWrite(signalLatchPin, HIGH);
  
  
  // Go off only if there is something to read
  if(Serial.available() > 0){
    Serial.readBytes(buffer, 3);
    // Check correctness of the control bits
    if((buffer[2] & 0b00011111) == 21){
      
      // For junctions (first bit = 0)
      if((((buffer[0] & 0b10000000) >> 7) == 0 && ((buffer[2] & 0b11100000) >> 5) == 0){
        changeJunctions(buffer);
      }
      // For signals
      else if(((buffer[0] & 0b10000000) >> 7) == 1){
        changeSignals(buffer);
      }

    }else{
      Serial.println("not ok, error.");
    }
    
    
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
  // First we are assigning to some variables important stuff got out of our buffer:
  // in which register should data be stored, length of the data and what position (bitwise) is our bit in register.
  int whichRegister = (buff[0] & 0b01111111) / 8;
  int length = ((buff[2] & 0b11100000) >> 5) + 1; // FROM 1 to 8 !!!
  int position = (buff[0] & 0b01111111) % 8; // Index - from 0 to 7
  
  // Let's check if we fit in one register - if modulo from adress + length >= 8 then two registers will be needed.
  if(position + length <= 8){
    // Which register to write to - take adress from buffer and divide by 8
    int registerBlock1 = signalData[whichRegister];
    // Check out this big brain - we are taking length of our data and iterating to it from 0 - that way we can check bit by bit and set it or clear it on position + i.
    for(int i = 0; i < length; i++){
      if((buff[1] & (1 << i)) != 0){
        bitSet(registerBlock1, position + i);
      }else{
        bitClear(registerBlock1, position + i);
      }
    }
    signalData[whichRegister] = registerBlock1;
  }
  // It gets more complicated if there are bits split into two registers
  else{
    int registerBlock1 = signalData[whichRegister];
    int registerBlock2 = signalData[whichRegister + 1];
    // Okay, let's do it for the first one
    for(int i = 0; i < 8 - position; i++){
      if((buff[1] & (1 << i)) != 0){
        bitSet(registerBlock1, position + i);
      }else{
        bitClear(registerBlock1, position + i);
      }
    }

    // FOR CLEARANCE!
    // (8 - position) is the number what we are left with in the second register!
    // Now the second one
    for(int i = 0; i < length - (8 - position); i++){
      if((buff[1] & (1 << i + (8 - position))) != 0){
        bitSet(registerBlock2, i);
      }else{
        bitClear(registerBlock2, i);
      }
    }
    signalData[whichRegister] = registerBlock1;
    signalData[whichRegister + 1] = registerBlock2;
  } 
  
}
