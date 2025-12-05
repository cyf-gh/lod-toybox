# 排序算法

# 比较算法（comparison sorts）

## swap与move
常见的两种原子操作，move需要额外的单个空间，而位运算版的swap不需要任何的额外空间。

# O(n^2)复杂度排序 傻瓜遍历

## 冒泡排序 (bubble sort)
### 性质
#### 一般的
* 结束条件为一次没有任何swap的遍历(cross)
* 最后一次遍历不会产生任何swap操作
#### 优化过后的
* 冒泡停止的位置右侧的元素全部排序完成
* 结束条件为停止位置为0

## 插入排序 (insertion sort)
### 性质
* 尽可能将左边的元素往右挤
* 与优化版的冒泡有些类似, 但不进行swap, 而是储存值移动元素

# O(nlogn)复杂度排序 分治(divide and conquer)

## 希尔排序（shell sort）
**效率取决于增量的决定**
### 性质
* 插入排序的一种
* 性能取决于增量序列的选择
> 希尔排序的增量序列的选择与证明是个数学难题，我们选择的这个增量序列是比较常用的，也是希尔建议的增量，称为希尔增量，但其实这个增量序列不是最优的。此处我们做示例使用希尔增量。

[维基百科的增量序列大全表](https://en.wikipedia.org/wiki/Shellsort) 见Gap sequences项
* 核心排序可以使用swap或是元素移动

## 归并排序（merge sort）
### 递归特征
* 停止常量式：左下标不小于右下标时（ p >= q ）
* 执行最小单元（2个）的归并排序，接着继续往上合并
* 有额外的空间复杂度
> n A hybrid block merge sort is O(1) mem.

## 快速排序(quick sort)
### 稳定性
不确定，存在稳定版本。
### 性质
* 每次选中一个主元（pivot element），使得在partition后得到如下原数列
( lo ~ ( p - 1 ) )[any] < p < ( ( p + 1 ) ~ hi )[any]
### 递归特征
* lo与hi相等时递归结束

# 非比较算法（non-comparison sorts）
