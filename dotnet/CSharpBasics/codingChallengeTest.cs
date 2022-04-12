using System;

namespace CSharpBasics{
    public class CodingChallengeTest{
        public static bool Anagram(string s1, string s2){
            //first determine whether or not the lengths are even
             if( s1.Length != s2.Length){
                 return false;
             }

            //spit the strings
            char[] splitString1 = s1.ToCharArray();
            int temp1 = 0;
            char[] splitString2 = s2.ToCharArray();
            int temp2 = 0;
            //sort s1 out
            for(int i = 0; i <= splitString1.Length-1; i++){
                for (int j = i + 1; j < splitString1.Length; j++){
                    if(splitString1[i] >splitString1[j]){
                        temp1 = splitString1[i];
                        splitString1[i] = splitString1[j];
                        splitString1[j] = Convert.ToChar(temp1); 
                    }
                }
            }

            // foreach (var letter in splitString1){
            //     Console.WriteLine(letter);
            // }
            //sort s2 out
            for(int i = 0; i <= splitString2.Length-1; i++){
                for (int j = i + 1; j < splitString2.Length; j++){
                    if(splitString2[i] >splitString2[j]){
                        temp2 = splitString2[i];
                        splitString2[i] = splitString2[j];
                        splitString2[j] = Convert.ToChar(temp2); 
                    }
                }
            }
            // foreach (var letter in splitString2){
            //     Console.WriteLine(letter);
            // }

            //and Compare the lengths and positions of the chars
            for(int i = 0; i < splitString1.Length; i++){
                if (splitString1[i].ToString() != splitString2[i].ToString()) {  
                    return false;  
                }   
            }
            return true;
        }

        public static bool Palindrome(string s){
            string reverseS = String.Empty;
            
            
            Console.WriteLine(s);
            //reverse the input string
            char[] splitString = s.ToCharArray();
            for(int i = splitString.Length - 1; i >= 0; i--)
            {
                 reverseS += splitString[i];
                 
            }
            Console.WriteLine(reverseS);
            //check if they're similar to the input
            if(s == reverseS){
               return true;
            }
            else{
                return false;
            }
        }
    }
}