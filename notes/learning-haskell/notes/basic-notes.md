# Basic Haskell

## 语言限制

任何以大写字母开头的token都会被识别为数据结构。

编写时遇到以下错误：

```haskell
try/function.hs:3:31: error: Not in scope: data constructor ‘Na’
  |
3 |                         where Na = name
```



## 类型类

```haskell
ghci> :t (==)   
(==) :: (Eq a) => a -> a -> Bool
```

### => 符号

可比较大小的类型都属于**Eq**

```haskell
(xxx a) => a
```

 参数属于xxx类型，如可读（Read），可相等（Eq），数字（Num）

## 函数

### 匹配模式

```haskell
sayMe :: (Integral a) => a -> String   
sayMe 1 = "One!"   
sayMe 2 = "Two!"   
sayMe 3 = "Three!"   
sayMe 4 = "Four!"   
sayMe 5 = "Five!"   
sayMe x = "Not between 1 and 5"
```

匹配1-5并输出对应的英文。

```haskell
sayMe :: (Integral a) => a -> String   
sayMe x = "Not between 1 and 5"
1
sayMe 1 = "One!"   
sayMe 2 = "Two!"   
sayMe 3 = "Three!"   
sayMe 4 = "Four!"   
sayMe 5 = "Five!"   
1
```

则被1包裹起来的代码无法到达。

### 不完全匹配的函数（Non-exhaustive patterns）

```haskell
charName :: Char -> String   
charName 'a' = "Albert"   
charName 'b' = "Broseph"   
charName 'c' = "Cecil"
```

则

```haskell
charName 'h'
```

会提示（匹配到了）不完全的匹配函数模版（Non-exhaustive patterns in function charName  ）

### 忽略符号

```haskell
first :: (a, b, c) -> a   
first (x, _, _) = x  
```

_表示不关心参数。

>  Haskell对函数的处理。

>  我认为Haskell将函数参数看得很重要，函数参数成为函数的主要意义，而不是功能。相比较指令式编程，Haskell编写出的函数参数检查更加优雅易懂并且可维护。

### 门卫（guard）和 where

```haskell
bmiTell :: (RealFloat a) => a -> String   
bmiTell bmi   
    | bmi  18.5 = "You're underweight, you emo, you!"   
    | bmi  25.0 = "You're supposedly normal. Pffft, I bet you're ugly!"   
    | bmi  30.0 = "You're fat! Lose some weight, fatty!"   
    | otherwise   = "You're a whale, congratulations!" 
```



```haskell
bmiTell :: (RealFloat a) => a -> a -> String   
bmiTell weight height   
    | bmi  skinny = "You're underweight, you emo, you!"   
    | bmi  normal = "You're supposedly normal. Pffft, I bet you're ugly!"   
    | bmi  fat    = "You're fat! Lose some weight, fatty!"   
    | otherwise     = "You're a whale, congratulations!" 
    where bmi = weight / height ^ 2   
      (skinny, normal, fat) = (18.5, 25.0, 30.0)  
      
```



### Let(Let it be.)

> 引：
>
> let绑定与where绑定很相似。where绑定是在函数底部定义名字，对包括所有门卫在内的整个函数可见。let绑定则是个表达式，允许你在任何位置定义局部变量，而对不同的门卫不可见。正如haskell中所有赋值结构一样，let绑定也可以使用模式匹配。



```haskell
cylinder :: (RealFloat a) => a -> a -> a   
cylinder r h =  
    let sideArea = 2 * pi * r * h   
        topArea = pi * r ^2   
    in  sideArea + 2 * topArea  
```

等价于

```haskell
cylinder :: (RealFloat a) => a -> a -> a   
cylinder r h = sideArea + 2 * topArea
    where sideArea = 2 * pi * r * h   
        topArea = pi * r ^2   
```

