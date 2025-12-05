# -*- encoding=utf8 -*-
__author__ = "cyf-desktop"

from airtest.core.api import *
import random

auto_setup(__file__)

logs_xdl = [
"开户",
"开户尽职调查",
"准备开户等业务材料",
"协助团队老师业务",
"联系营销客户",
    "协助团队老师业务",
"联系营销客户",
"受益人解控",
"普惠营销",
"开户",
]

logs_cyf = [
"协助团队老师业务",
"联系营销客户",
"受益人解控",
"普惠营销",
"开户",
"管委会对账单检查"
"协助客户柜面预约"
]

start = 0
dayCount = 30
currentDay = 0

def touchTilExists(img):
    while (not exists(img)
    ):
        sleep(1.0)
    touch(img)    


dayX = 890#1209
dayY_Day0Top = 1920
dayY_Day0Bottom = 2260

dayY_AddOneDayTop = 2053
dayY_AddOneDayBottom = 2120
    
def setDay0():
    swipe((dayX,dayY_Day0Top), (dayX,dayY_Day0Bottom),0.1)
    swipe((dayX,dayY_Day0Top), (dayX,dayY_Day0Bottom),0.1)
    swipe((dayX,dayY_Day0Top), (dayX,dayY_Day0Bottom),0.1)
    swipe((dayX,dayY_Day0Top), (dayX,dayY_Day0Bottom),0.1)
    swipe((dayX,dayY_Day0Top), (dayX,dayY_Day0Bottom),0.1)
    swipe((dayX,dayY_Day0Top), (dayX,dayY_Day0Bottom),0.1)
    
def addOneDay():
    swipe((dayX,dayY_AddOneDayBottom), (dayX,dayY_AddOneDayTop),0.1)
    
def addDay():
    for i in range(start, currentDay):
        addOneDay()   



touchTilExists(Template(r"tpl1652506699457.png", record_pos=(0.001, -0.683), resolution=(1440, 3120)))
touchTilExists(Template(r"tpl1658822403756.png", record_pos=(-0.3, -0.415), resolution=(1080, 2400)))

for i in range(start, dayCount):
    print(currentDay)
    touchTilExists(Template(r"tpl1652506740387.png", record_pos=(0.008, 0.159), resolution=(1440, 3120)))

    touchTilExists(Template(r"tpl1655390854654.png", record_pos=(-0.274, -0.303), resolution=(1440, 3120)))

    sleep(1.0)

    text(random.choice(logs_xdl))

    touchTilExists(Template(r"tpl1653656785790.png", record_pos=(-0.341, -0.604), resolution=(1440, 3120)))

    setDay0()

    addDay()

    touchTilExists(Template(r"tpl1653656831538.png", record_pos=(0.424, 0.472), resolution=(1440, 3120)))

    touchTilExists(Template(r"tpl1652506857996.png", record_pos=(-0.019, 0.445), resolution=(1440, 3120)))

    currentDay += 1