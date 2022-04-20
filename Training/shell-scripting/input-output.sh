#! /usr/bin/bash 

#Inputs and Outputs 
#In Linux Everything is consider a file including hardware
:'
    0 - Input - Keyboard (stdin)
    1 - Output - Screen (stdout)
    2 - Error - Screen (stderr)
'
#Standard Inputs
:'
    Standard input is the default input method, which is used by all commands to read its input.
    It is denoted by zero number (0).
    Also known as stdin.
    The default standard input is the keyboard.
    < is input redirection symbol and syntax is:
'
    command < filename


#use the cat command as follows to display /etc/passwd on screen:

    cat < /etc/passwd

#Standard Outputs

:'
    Standard output is used by a command to writes (display) its output.
    The default is the screen.
    It is denoted by one number (1).
    Also known as stdout.
    The default standard output is the screen.
    > is output redirection symbol and syntax is:
'
    command > output.file.name

 #Example 

    ls 
 #save the output to a file called output.txt
    ls > /tmp/output.txt   


#Standard Errors
:'
    Standard error is the default error output device, which is used to write all system error messages.
    It is denoted by two number (2).
    Also known as stderr.
    The default standard error device is the screen or monitor.
    2> is input redirection symbol and syntax is:
'

    command 2> errors.txt

    find / -iname "*.conf" 2>fileerrors.txt
    cat fileerrors.txt

#Empty File Creation

    >newfile.name


#Here Documents 
:'
This type of redirection tells the shell to read input from the current source (HERE) until a line containg only word (HERE) is seen. HERE word is not subjected to 
variable name, parameter expansion, arithmetic expansion, pathname expansion, or command substitution. 
All of the lines read up to that point are then used as the standard input for a command. Files are processed in this manner are commonly called here documents.
If you do not want variable name, parameter expansion, arithmetic expansion, pathname expansion, or command substitution quote HERE in a single quote:
'
:'
    command <<HERE
    text1
    text2
    textN
    $varName
    HERE 
'
#Example 
echo 'this is a test.' | WC -W 

    

