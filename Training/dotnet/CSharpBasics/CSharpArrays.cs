namespace CSharpBasics
{
    public class CsharpArrays{

        


        public static void Arrays_1D(){
            int[]scores; // declare the array
            string[] employees = new string[10];

            scores = new int[5]; //initializes array with 20 bytes of memory
            //make the elements
            scores[0] = 50;
            scores[3] = 78;
            //call the elements
            //Calling a single element in an array
            Console.WriteLine($"This student scored {scores[0]}%");

            //reading the entire array
            //incrementing
            for (int i = 0; i < scores.Length; i++) //use a for loop
            {
                Console.Write(scores[i] + " ");
            }
            //decrementing
            for (int i = scores.Length -1;  i >=0; i--){
                Console.Write(scores[i] + " ");
            }
            //forward with foreach loop
            foreach(var score in scores){ 
                Console.WriteLine(score);
            }
            //backward with foreach loop
            Array.Reverse(scores);
            foreach(var score in scores){ 
                Console.WriteLine(score);
            }
        }

       

         public static void Arrays_Multi(){
            int[,] twoDArray = new int[2,3];
            int[,,] threeDArray = new int[3, 3, 3];
      
            Console.WriteLine($"{twoDArray.Rank}");
            Console.WriteLine($"{twoDArray.Length}");

            twoDArray[0,0]=1;
            twoDArray[1, 0]=2;

            //reading an element
            Console.WriteLine(twoDArray[1,2]);

            // for (int i = 0; i < 2; i++){
            //     for (int j = 0; j < 3; j++){
            //         Console.Write(twoDArray[i,j] + " ");
            //     }
            //     Console.WriteLine();
            // }

            foreach (var item in twoDArray){
                Console.Write(item + " ");
            }
        }

        public static int[] Reverse(int [] x){
            int[] reversed = new int[x.Length];
            for (int i = x.Length-1; i >= 0; i--){
                reversed[x.Length-1-i]=x[i];
            }
            return reversed;
        }
    
    
        public static void  JaggedArrays(){

            int [][] jaggedArray = new int[2][];
            jaggedArray[0] = new int [3]; //inititalizes first row has 3 rows
            jaggedArray[1] = new int[5]; // initializes second row has 5 rows
            //1st
            jaggedArray[0][0] = 89;
            jaggedArray[0][1] = 55;
            jaggedArray[0][2] = 90;
            //2nd
            jaggedArray[1][0] = 55;
            jaggedArray[1][1] = 63;
            jaggedArray[1][2] = 21;
            jaggedArray[1][3] = 78;
            jaggedArray[1][4] = 87;
            //read
            Console.WriteLine($"{jaggedArray.Rank}");
            Console.WriteLine($"{jaggedArray.Length}");

            
             for (int i = 0; i < jaggedArray.Length; i++){
                 for (int j = 0; j < jaggedArray[i].Length; j++){
                     Console.Write(jaggedArray[i][j] + " ");
                }
                 Console.WriteLine();
            }
        }

         public static void ReadArray(int[] array){
            foreach (var item in array){
             Console.Write(item + " ");
            }
        }

         public static void MoveIt(int[] y){
        ReadArray(y);
          for( int i = 0; i < y.Length; i++){
              if(y[i] ==0 ){
                for(int j = i; j < y.Length-1; j++){
                    int temp = y[j];
                    y[j] = y[j+1];
                    y[j+1]=temp;
                }
              }
          }
           ReadArray(y);
      } 

        
        public static void Test(){
           int i;
    for (i = 0; i < 5; i++)
    {
    }
    Console.WriteLine(i);
        }
    }
    
}