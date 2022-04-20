#! /usr/bin/bash 

#Conditions
#Arithmatic Operations
echo $((5 + 2)) #Addition
echo $((5 - 2)) #Subtraction
echo $((6 / 2)) #Division
echo $((6 * 2)) #Multiplication
echo $((19 % 4)) #Modulus
echo $((2**2)) #Exponentation

#Logic Operation
echo $(( 5 > 12 )) #false = evaluates to 0
echo $(( 5 == 10 )) #false NOTE! use == for comparison = is for assignment
echo $(( 5 != 2 )) #true = evaluates to 1
echo $(( 1 < 2 )) #true
echo $((5 == 5)) #true

#&& = and
#|| = or
#! = not

#Decimals operations
float=2.5
num1=7

echo "$float+$num1" | bc


#Test Command
#use the test command to check file types and compare values
#test condition
# -gt means greater than in test
test 5 -gt 2 && echo "True"
# -ge means greater or equal to
# -lt means less than in test
test 1 -lt 2 && echo "True"
# -le means less then or equal to
# -eq means equal with the test
test $((5+10)) -eq 10 && echo "True" || echo "False"


#Structure based on condition
:'
if condition
then
    command1
    command2
    ...
    commandN
fi
'
#example
# read -p "Enter a password:" pass
# if test "$pass" == "Zenonzard"
# then
#      echo "Password verified."
# fi


#if...else...fi
:'
    if command
           then
                       command executed successfully
                       execute all commands up to else statement
                       or to fi if there is no else statement

           else
                       command failed so
                       execute all commands up to fi
           fi
'
#example
read -p "Enter a password:" pass
if test "$pass" = "jerry"
then
     echo "Password verified."
else
     echo "Access denied."	
fi

#Nested ifs
:'
    if condition
	then
		if condition
		then
			.....
			..
			do this
		else
			....
			..
			do this
		fi
	else
		...
		.....
		do this
	fi
'

#Multilevel if-then-else
:'
 if condition
           then
                       condition is true
                       execute all commands up to elif statement
           elif condition1 
           then
                       condition1 is true
                       execute all commands up to elif statement  
           elif condition2
           then
                       condition2 is true
                       execute all commands up to elif statement          
           elif conditionN
           then
                       conditionN is true
                       execute all commands up to else statement          
           else
                       None of the above conditions are true
                       execute all commands up to fi
           fi
'

