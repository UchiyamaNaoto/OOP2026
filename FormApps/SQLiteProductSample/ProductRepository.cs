using Microsoft.Data.Sqlite;

namespace SQLiteProductSample;

// Productsテーブルに対するDB操作をまとめたクラス
// CRUD（Create / Read / Update / Delete）を担当する
public class ProductRepository
{
    // 全商品を取得する。Read（SELECT）に相当する
    public List<Product> GetAll() {

        var products = new List<Product>();

        using var connection = Database.GetConnection();
        connection.Open();

        // SQLを実行するためのコマンドオブジェクトを作る
        using var command = connection.CreateCommand();

        // Productsテーブルを作るSQL
        command.CommandText =
            """
            SELECT Id, Name, Price
            FROM Products
            ORDER BY Id;
            """;

        // SELECTを実行し、複数行の検索結果を読み取る
        using var reader = command.ExecuteReader();

        while (reader.Read()) {
            products.Add(new Product {
                Id = reader.GetInt32(0),    // 0列目: Id
                Name = reader.GetString(1), // 1列目: Name
                Price = reader.GetInt32(2)  // 2列目: Price
            });
        }
        return products;

    }
}
