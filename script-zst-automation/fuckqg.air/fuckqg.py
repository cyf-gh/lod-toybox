# -*- encoding=utf8 -*-
__author__ = "cyf-desktop"

from airtest.core.api import *
import random

auto_setup(__file__)


def swipeMotherFucker():
    x = 690
    ytop = 2000
    ybtm = 620
    swipe((x,ytop), (x,ybtm),0.5)

def fakeReading():
    x = 690
    ytop = 2000
    ybtm = 620
    swipe((x,ytop), (x,ybtm),0.5)
    swipe((x,ybtm), (x,ytop),0.333)
    slp = 60+random.random()*60
    #slp = 1
    print( slp )
    sleep( slp )
    touch(Template(r"tpl1683207107581.png", record_pos=(-0.432, -0.965), resolution=(1080, 2400)))


def fakeWatching():
    x = 690
    ytop = 2000
    ybtm = 620
    slp = 120 + random.random() * 60
    print( slp )
    sleep( slp )
    touch(Template(r"tpl1683207107581.png", record_pos=(-0.432, -0.965), resolution=(1080, 2400)))
    
# 进入强国
touch(Template(r"tpl1683207143523.png", record_pos=(-0.275, -0.848), resolution=(1080, 2400)))

for nnnn in range(0,2):
    touch((600,650), 2)
    fakeReading()
    touch((600,900), 2)
    fakeReading()
    touch((600,1300), 2)
    fakeReading()
    touch((600,1700), 2)
    fakeReading()
    swipeMotherFucker()
    
    
    
touch(Template(r"tpl1683207542874.png", record_pos=(0.196, 1.015), resolution=(1080, 2400)))

for nnnn in range(0,3):
    touch((600,1200), 2)
    fakeWatching()
    touch((600,1600), 2)
    fakeWatching()
    swipeMotherFucker()
    swipeMotherFucker()
