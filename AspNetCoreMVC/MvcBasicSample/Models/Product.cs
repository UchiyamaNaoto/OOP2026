namespace MvcBasicSample.Models;
// 商品1 件の名前と価格をまとめる
public class Product {
    public string Name { get; set; } = string.Empty;
    public int Price { get; set; } // 円単位の価格
}