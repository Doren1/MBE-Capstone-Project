const int flexSensor1 = A0;
const int flexSensor2 = A1;
const int flexSensor3 = A2;
const int tactSwitch = A3; // Tact switch pin

unsigned long lastPressTime1 = 0;
unsigned long lastPressTime2 = 0;
unsigned long lastPressTime3 = 0;
unsigned long lastSwitchPressTime = 0; // Store the last time the switch was pressed
const unsigned long debounceDelay = 3000; // 3 seconds debounce for flex sensors
const unsigned long switchDelay = 500;   // 1 second delay for switch press

void setup() {
  Serial.begin(9600); // Initialize serial communication
  pinMode(tactSwitch, INPUT); // Set tact switch pin as input
}

void loop() {
  int sensorValue1 = 2 * analogRead(flexSensor1);
  int sensorValue2 = 2 * analogRead(flexSensor2);
  int sensorValue3 = 2 * analogRead(flexSensor3);
  int switchState = digitalRead(tactSwitch);
  unsigned long currentTime = millis();

  // If the switch is pressed, check each flex sensor
  if (switchState == LOW && currentTime - lastSwitchPressTime > switchDelay) {
    lastSwitchPressTime = currentTime;

    // Check flex sensor 1
    if (sensorValue1 < 2020 && currentTime - lastPressTime1 > debounceDelay) {
      lastPressTime1 = currentTime;
    }

    // Check flex sensor 2
    if (sensorValue2 < 2020 && currentTime - lastPressTime2 > debounceDelay) {
      lastPressTime2 = currentTime;
      Serial.println("DOWN_PRESS");
    }

    // Check flex sensor 3
    if (sensorValue3 < 2020 && currentTime - lastPressTime3 > debounceDelay) {
      lastPressTime3 = currentTime;
      Serial.println("RIGHT_PRESS");
    }

    Serial.println("ALL_PRESS");
  } else {
    // If switch is not pressed, send "HOLD" messages as needed
    if (sensorValue1 < 1700) {
      Serial.println("LEFT_HOLD");
    }

    if (sensorValue2 < 1800) {
      Serial.println("DOWN_HOLD");
    }

    if (sensorValue3 < 1600) {
      Serial.println("RIGHT_HOLD");
    }


  }
}
