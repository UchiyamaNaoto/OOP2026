
namespace DistanceConverter {
    internal class Program {
        static void Main(string[] args) {
            if(args.Length >= 1) {
                if ( args[0] == "-tom") {
                    PrintFeetToMeterList(1, 10);
                } else if (args[0] == "-tof") {
                    PrintMeterToFeetList(1, 10);
                } else {
                    Console.WriteLine("引数エラー");
                }
            } else {
                Console.WriteLine("引数エラー");
            }
        }

        // フィートからメートルへの対応表を出力
        static void PrintFeetToMeterList(int start, int stop) {
            for (int feet = start; feet <= stop; feet++) {
                double meter = FeetToMeter(feet);
                Console.WriteLine($"{feet}ft = {meter:0.0000}m");
            }
        }

        // メートルからフィートへの対応表を出力
        static void PrintMeterToFeetList(int start, int stop) {
            for (int meter = start; meter <= stop; meter++) {
                double feet = MeterToFeet(meter);
                Console.WriteLine($"{meter}m = {feet:0.0000}ft");
            }
        }

        //フィートからメートルを求める
        static double FeetToMeter(int feet) {
            return feet * 0.3048;
        }

        // メートルからフィートを求める
        static double MeterToFeet(int meter) {
            return meter / 0.3048;
        }
    }
}
