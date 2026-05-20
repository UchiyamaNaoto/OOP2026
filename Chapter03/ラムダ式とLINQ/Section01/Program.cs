namespace Section01 {
    internal class Program {

        static void Main(string[] args) {
            var cities = new List<string> {
                "Tokyo",
                "New Delhi",
                "Bangkok",
                "London",
                "Paris",
                "Berlin",
                "Canberra",
                "Hong Kong",
            };

            //以下の条件を満たすものが存在するか調べる
            //【教科書P134～137を参考に】
            //・文字数が6文字以上
            //・o を含む
            //・最後が n
            var exists = cities.Exists(s => 6 <= s.Length && s.Contains('o') && s.EndsWith('n'));
            Console.WriteLine(exists);
        }
    }
}


