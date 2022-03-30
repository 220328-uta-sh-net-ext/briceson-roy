#! /usr/bin/bash 


# echo "Enter your name"
# read name #takes the input typed in by user and saves it in the variable after!
# echo Hello $name!


# echo "Rider Times!"
# read rider1 rider2 #you can take multiple inputs
# echo $rider1 turns to two! Kamen Rider $rider2! Its never over!

#Array - multiple collection of values in an indexed format
# echo "Rider Time"
# read -a riders
# echo "Rider Rollcall! ${riders[3]}"

#The REPLY system variable
# echo "Rider Time!"
# read
# echo "Kamen Rider! $REPLY!"


read -p 'Username: ' username
# -sp tag will not display the input
read -sp 'Password: ' password
echo username is $username
echo password is $password