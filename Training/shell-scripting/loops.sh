#! /usr/bin/bash 

#For loop syntax
:'
    for var in item1 item2 ... itemN
            do
                    command1
                    command2
                    ....
                    ...
                    commandN
            done
'

#numerical loop syntax
:'
    for var in list-of-values
            do
                    command1
                    command2
                    ....
                    ...
                    commandN
            done
'

#Nested loops syntax
for (( i = 1; i <= 5; i++ ))      ### Outer for loop ###
do

    for (( j = 1 ; j <= 5; j++ )) ### Inner for loop ###
    do
          echo -n "$i "
    done

  echo "" #### print the new line ###
done

#While Loops syntax
:'
    while [ condition ]
           do
                 command1
                 command2
                 ..
                 ....
                 commandN
           done
'

#example 
n=1

# continue until $n equals 5
while [ $n -le 5 ]
do
	echo "Welcome $n times."
	n=$(( n+1 ))	 # increments $n
done


#Infinite Loops
:'
while :
    do
	    echo "Do something; hit [CTRL+C] to stop!"
    done
'

#Until Loops
:'
    until [ condition ]
do
   command1
   command2
   ...
   ....
   commandN
done
'

#example
i=1
until [ $i -gt 6 ]
do
	echo "Welcome $i times."
	i=$(( i+1 ))
done

#Select Loops 
#Comes in two syntax
:'
select varName in list
do
    command1
    command2
    ....
    ......
    commandN
done
'
#OR 

:'
    select varName in list
do
	case $varName in
		pattern1)
			command1;;
		pattern2)
			command2;;
		pattern1)
			command3;;
		*)
			echo "Error select option 1..3";;
	esac			
done
'

#NOTE to exit a select loop you can use ctrl + C

#The break statement can be used to escape a FOR, WHILE or UNTIL Loop

 #break in a For Loop
 match=$1  # fileName
found=0   # set to 1 if file found in the for loop

# show usage
[ $# -eq 0 ] && { echo "Usage: $0 fileName"; exit 1; }

# Try to find file in /etc
for f in /etc/*
do

	if [ $f == "$match" ]
	then
	 	echo "$match file found!"
	 	found=1 # file found
		break   # break the for looop
	fi
done

# noop file not found
[ $found -ne 1 ] && echo "$match file not found in /etc directory"


#break in While Loop
while :
do
	read -p "Enter number ( -9999 to exit ) : " n
        
        # break while loop if input is -9999  
	[ $n -eq -9999 ] && { echo "Bye!"; break; }

	isEvenNo=$(( $n % 2 ))  # get modules 
        [ $isEvenNo -eq 0 ] && echo "$n is an even number." || echo "$n is an odd number."

done

#The Continue statement is used to resume the next iteration of the enclosing FOR, WHILE or UNTIL loop

:'
for i in something
do
	[ condition ] && continue
	cmd1
	cmd2
	
done
'

#Or

:'
    for i in something
do
	[ condition ] && continue
	cmd1
	cmd2
	
done
'