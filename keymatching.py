import serial
from pynput.keyboard import Controller, Key
import time

# 시리얼 포트를 설정합니다.
ser = serial.Serial('/dev/cu.usbmodem1301', 9600)  # 포트 이름은 환경에 맞게 변경하세요.
keyboard = Controller()

while True:
    if ser.in_waiting > 0:
        message = ser.readline().decode().strip()

        # Arduino에서 받은 메시지에 따라 키 입력을 제어합니다.
        if message == "LEFT_PRESS":
            keyboard.press('e')
            time.sleep(0.1)
            keyboard.release('e')
        elif message == "LEFT_HOLD":
            # 키를 누른 상태로 2초간 유지
            keyboard.press('e')
            keyboard.release('e')
        elif message == "DOWN_PRESS":
            keyboard.press('w')
            time.sleep(0.1)
            keyboard.release('w')
        elif message == "DOWN_HOLD":
            # 키를 누른 상태로 2초간 유지
            keyboard.press('w')
            keyboard.release('w')
        elif message == "RIGHT_PRESS":
            keyboard.press('q')
            time.sleep(0.1)
            keyboard.release('q')
        elif message == "RIGHT_HOLD":
            # 키를 누른 상태로 2초간 유지
            keyboard.press('q')
            keyboard.release('q')
        elif message == "ALL_PRESS":
            keyboard.press('r')
            keyboard.release('r')