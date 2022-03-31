#! /usr/bin/bash 

read -p "Enter A Number!" number

if test $number -gt 0 && test $number -lt 21
then
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
        echo "boom"
    fi
else
echo "Please enter a number between 1 and 20."
fi