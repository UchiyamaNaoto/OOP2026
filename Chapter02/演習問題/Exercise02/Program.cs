
namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            PrintInchToMeterList(1, 10);
        }

        // インチからメートルへの対応表を出力
        private static void PrintInchToMeterList(int start, int stop) {
            for (int feet = start; feet <= stop; feet++) {
                double meter = InchConverter.ToMeter(feet);
                Console.WriteLine($"{feet}inch = {meter:0.0000}m");
            }
        }
    }
}
