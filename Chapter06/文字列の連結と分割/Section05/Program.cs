using System.Text;

namespace Section05 {
    internal class Program {
        static void Main(string[] args) {
            //var sb = new StringBuilder();
            string text = "";
            foreach (var word in GetWords()) {
                //sb.Append(word);
                text += word;
            }
            Console.WriteLine(text);

        }

        private static IEnumerable<string> GetWords() {
            return ["Orange", "Lemon", "Strawberry"];
        }
    }
}
