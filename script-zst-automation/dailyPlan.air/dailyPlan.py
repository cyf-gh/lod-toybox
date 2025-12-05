# -*- encoding=utf8 -*-
__author__ = "cyf-desktop"

from airtest.core.api import *

start = 0
dayCount = 30
currentDay = 0

auto_setup(__file__)

def touchTilExists(img):
    while (not exists(img)
    ):
        sleep(1.5)
    touch(img)    
    
def touchTextInput(img, tx ):
    touchTilExists(img)
    sleep(1.0)
    text(tx, False)

dayX = 540
dayY_Day0Top = 1920
dayY_Day0Bottom = 2260
hX = 757
dayY_AddOneDayTop = 2040
dayY_AddOneDayBottom = 2155

def setDay0():
    swipe((dayX,dayY_Day0Top), (dayX,dayY_Day0Bottom),0.1)
    swipe((dayX,dayY_Day0Top), (dayX,dayY_Day0Bottom),0.1)
    swipe((dayX,dayY_Day0Top), (dayX,dayY_Day0Bottom),0.1)
    swipe((dayX,dayY_Day0Top), (dayX,dayY_Day0Bottom),0.1)
    swipe((dayX,dayY_Day0Top), (dayX,dayY_Day0Bottom),0.1)
    swipe((dayX,dayY_Day0Top), (dayX,dayY_Day0Bottom),0.1)
    
def setHour0():
    swipe((hX,dayY_Day0Top), (hX,dayY_Day0Bottom),0.01)
    swipe((hX,dayY_Day0Top), (hX,dayY_Day0Bottom),0.01)
    swipe((hX,dayY_Day0Top), (hX,dayY_Day0Bottom),0.01)
    
def addHour3():
    swipe((hX,2244), (hX,1940),1)

def addHour16():
    addHour3()
    addHour3()
    addHour3()
    addHour3()
    addHour3()
    
def addOneDay():
    swipe((dayX,dayY_AddOneDayBottom), (dayX,dayY_AddOneDayTop),0.1)
    
def addDay():
    for i in range(start, currentDay):
        addOneDay()

for i in range(start, dayCount):
    print(currentDay)
    
    sleep(3)
    touchTilExists(Template(r"tpl1663653364558.png", record_pos=(0.359, 0.07), resolution=(1080, 2400)))


    touchTilExists(Template(r"tpl1653620639840.png", record_pos=(-0.022, -0.606), resolution=(1440, 3120)))

    touchTilExists(Template(r"tpl1653618773466.png", record_pos=(0.009, -0.426), resolution=(1440, 3120)))

    touchTilExists(Template(r"tpl1653618793618.png", record_pos=(-0.267, -0.499), resolution=(1440, 3120)))

    touchTilExists(Template(r"tpl1653618813627.png", record_pos=(-0.327, -0.462), resolution=(1440, 3120)))

    touchTilExists(Template(r"tpl1653618831794.png", record_pos=(0.422, -0.819), resolution=(1440, 3120)))

    touchTilExists(Template(r"tpl1653618849673.png", record_pos=(-0.361, 0.028), resolution=(1440, 3120)))


    setDay0()

    addDay()

    setHour0()

    addHour3()
    addHour3()

    touchTilExists(Template(r"tpl1653620301941.png", record_pos=(0.433, 0.47), resolution=(1440, 3120)))


    touchTilExists(Template(r"tpl1653620330695.png", record_pos=(-0.337, 0.121), resolution=(1440, 3120)))

    setDay0()

    addDay()    
    
    setHour0()

    addHour16()

    touchTilExists(Template(r"tpl1653620301941.png", record_pos=(0.433, 0.47), resolution=(1440, 3120)))

    touchTilExists(Template(r"tpl1653620370127.png", record_pos=(-0.005, 0.438), resolution=(1440, 3120)))
    
    currentDay += 1