# -*- encoding=utf8 -*-
__author__ = "cyf-thinkpad"

from airtest.core.api import *

auto_setup(__file__)
fpdmPt=exists(Template(r"tpl1665738119460.png", record_pos=(0.002, -0.046), resolution=(1127, 779)))
fpdmPt.x+=200

touch(fpdmPt)

text("fpdm")