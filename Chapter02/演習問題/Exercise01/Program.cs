
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            //歌データを入れるリストオブジェクトを生成
            var songs = new List<Song>();

            //"***** 曲の登録 *****"を出力
            Console.WriteLine("***** 曲の登録 *****");

            //何件入力があるかわからないので無限ループ
            while (true) {
                //"曲名："を出力
                Console.Write("曲名：");
                //入力された曲名を取得
                string? title = Console.ReadLine();

                //endが入力されたら登録終了()
                //P131を参考にしても良いがこういう書き方もある
                if (title.Equals("end", StringComparison.OrdinalIgnoreCase))
                    break;

                //"アーティスト名："を出力
                Console.Write("アーティスト名：");
                //入力されたアーティスト名を取得
                string? artistName = Console.ReadLine();

                //"演奏時間（秒）："を出力
                Console.Write("演奏時間（秒）：");
                //入力された演奏時間を取得
                int length = int.Parse(Console.ReadLine());

                //Songインスタンスを生成
                Song song = new Song(title, artistName, length);
                
                //歌データを入れるリストオブジェクトへ登録
                songs.Add(song);

                Console.WriteLine();    //改行
            }
            PrintSongs(songs);
        }
        //Mainメソッド内の　PrintSongs(songs);　をクリックして
        //Alt + Enterを押してメソッドを生成するを選択すると、
        //以下のメソッドが自動的に作成される
        // 2.1.4
        private static void PrintSongs(IEnumerable<Song> songs) {
            foreach (var song in songs) {
                Console.WriteLine($"{ song.Title},{song.ArtistName},{song.Length / 60}:{(song.Length % 60):00}");
            }
        }

    }
}
