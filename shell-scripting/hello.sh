#single line comment
: '
multi
lint
comment
'

#Shebang / hash bang -> mentions which shell to be used and location in OS
#! /usr/bin/bash 

#prints Hello World when file is run use the "echo" command
echo "Hello World"

#Variables 
#These are system defined variables. NOTE! they are in all caps
#Can be written with or without quotes after the echo command
echo My home directory is $HOME
echo "My shell version is $BASH"
echo "My shell version is $BASH_VERSION"
echo "My current directory is  $PWD"

#User Defined Variables (UDV)
hero=Zero
echo $hero

_USD=10
echo value is $_USD
# same variable can be changed
_USD=42
echo changed value is $_USD

#constants
pi=3.14 #or readonly pi=3.14
# readonly can't be unset or deleted
readonly pi
# unset removes value from a variable
unset pi
#pi=22.7
echo the value of pi is $pi


