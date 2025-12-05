# -*- encoding=utf8 -*-
__author__ = "cyf-desktop"

from airtest.core.api import *

auto_setup(__file__)



from poco.drivers.android.uiautomation import AndroidUiautomationPoco
poco = AndroidUiautomationPoco(use_airtest_input=True, screenshot_each_action=False)

def touchTilExists(img):
    while (not exists(img)):
        sleep(0.1)
    touch(img)    




for nnum in range(0,30000):
    touch(Template(r"tpl1666522226239.png", record_pos=(-0.001, -0.087), resolution=(1080, 2400)))
    touch(Template(r"tpl1666104934216.png", record_pos=(-0.373, -0.393), resolution=(1080, 2400)))
    for num in range(0,30):
        touch(Template(r"tpl1682768430135.png", record_pos=(-0.173, -0.851), resolution=(1080, 2400)))
        touch(Template(r"tpl1679917929528.png", record_pos=(-0.378, -0.853), resolution=(1080, 2400)))


    
        touch(Template(r"tpl1682768436447.png", record_pos=(0.244, -0.844), resolution=(1080, 2400)))
        touch(Template(r"tpl1682768455961.png", record_pos=(0.028, -0.853), resolution=(1080, 2400)))
    
    touch(Template(r"tpl1666522248237.png", record_pos=(-0.446, -0.975), resolution=(1080, 2400)))

