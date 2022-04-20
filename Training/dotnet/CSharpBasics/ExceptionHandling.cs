namespace CSharpBasics
{
    public class ExceptionHandling{
        public static float Division(int num, int dem){
           float quotient=0;
           try{
                 quotient = num/dem;
           
           }
            catch(DivideByZeroException ex){
                //Log the Logic in the NLog
                Console.WriteLine(ex.Message);
            }
            catch(ArithmeticException ex){
                //Logging Logic
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex){
                Console.WriteLine(ex.Message);
            }
            //finally block will run code regardless of an exception
            finally{
                Console.WriteLine("Have a good one!");
            }
            return quotient;
        }

        public class Temperature
        {
            float temperature = 0;
            public static void CheckTemperature(float temp){
                if(temp < 30){
                    throw new TemperatureException("Too cold for this divice! please move to a place between 65 - 80 degrees");
                }
                else{
                    Console.WriteLine("Device in optimal position");
                }
            }
        }

        public class TemperatureException : ApplicationException
        {
            public TemperatureException(string message):base(message){

            }
        }
    }
}