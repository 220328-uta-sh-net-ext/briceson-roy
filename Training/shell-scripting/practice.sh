#! /usr/bin/bash 

directory="$?"
if [ -f "$directory" ]
then    ls $directory/*
fi