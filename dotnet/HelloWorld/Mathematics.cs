namespace HelloWorld{
    public class Mathematics{
        public void DataTypes(){
            //declare the variable
            int a; //a variable which can hold 4 bytes or 32 bit value, by default its zero
            a = 10; // assigning a value -> stored in stack as it a value type
            
         
            Console.WriteLine($"The value of a is {a}");
            string name; //declares a reference type
            name="Tibbs";
            Console.WriteLine($"They call me Mr. {name}");
        }

        public static void Conversion(){
            int a = 10;
            double b=10.55;
            int c;
            //implicit casting with no data loss
            b=a; 
            //explict casting methods
            c=(int)b; 
            // c= Convert.ToInt32(b);
            // c = Int32.Parse(b);
            string x ="101";
            // x = Convert.ToString(a); //boxing - converting value to reference 
            c = Convert.ToInt32(x); //unboxing - converting reference to value type

            Console.WriteLine($"a - {a} \nb - {b} \nc - {c}");
        }
    
        public static void Addition(){
            
            Console.Write("Enter num 1: ");
            double num1 = Convert.ToDouble( Console.ReadLine());
            Console.Write("Enter num 2: ");
            double num2 =  Convert.ToDouble( Console.ReadLine());
            Console.WriteLine($"The sum of {num1} and {num2} is {num1 + num2}");

        }
        public static void AdditionWithFilter(){
            double num1 = 0;
            double num2 = 0;
            input1:          
            Console.Write("Enter num 1: ");
            bool canConvert1 = double.TryParse( Console.ReadLine(), out num1); 
              while(!canConvert1){
                     Console.WriteLine("Please enter a number not a character.");  
                     goto input1;
            }

            input2:
            Console.Write("Enter num 2: ");
            bool canConvert2 = double.TryParse( Console.ReadLine(), out num2);
                while(!canConvert2){
                    Console.WriteLine("Please enter a number not a character.");  
                     goto input2;
                }
          
               Console.WriteLine($"The sum of {num1} and {num2} is {num1 + num2}");
        }
    }
}