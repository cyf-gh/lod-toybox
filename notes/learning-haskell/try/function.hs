someOneWantToAddTwoNumbers :: String -> Double -> Double -> String
someOneWantToAddTwoNumbers name num1 num2 = "Guy:[" ++ na ++ "] got a sum:["++ summ num1 num2 ++"]"
                        where na = name
                              summ num11 num22 = show( num1 + num2 )

main = 
    print (someOneWantToAddTwoNumbers "bob" 1.0 2.0 )