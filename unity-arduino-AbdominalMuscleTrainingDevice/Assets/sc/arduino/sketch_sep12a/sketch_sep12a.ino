int bits[] ={12,11,10,9,8};
int i = 0;
int state;

void setup()
{
  for(i=0;i<5;i++){
    pinMode(bits[i], INPUT_PULLUP);
  }
  
  pinMode(13, OUTPUT);
  Serial.begin(9600);
}


void loop()
{
  for(i=0;i<5;i++){
    state = digitalRead(bits[i]);
    delay(100);
    if(state == 0){
      digitalWrite(13, HIGH);
        Serial.println(i);
      state = -1;
    }
  }
}
