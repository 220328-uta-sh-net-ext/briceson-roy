#! /usr/bin/bash 

quit_game=0

while [ $quit_game -ne 1 ]
do 
    read -p "Enter A Number!" number
    if [[ $number -le 0 || $number -gt 20 ]]
    then
        echo "Please enter a number between 1 and 20."
    else 
        if test $((number % 5)) -eq 0 && test $((number % 3)) -eq 0;
            then
                echo "fizzbuzz"
        elif test $((number % 5)) -eq 0
            then
                echo "fizz"
        elif test $((number % 3)) -eq 0
            then   
                echo "buzz"
        else
            echo "ka-boom! you lose..."
        fi
    fi
    read -p "continue the game? Hit 1 to quit " quit_game
done