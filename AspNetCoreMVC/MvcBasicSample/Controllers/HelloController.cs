using Microsoft.AspNetCore.Mvc; // MVC の機能を使用
using MvcBasicSample.Models; // Product を使用

namespace MvcBasicSample.Controllers;
public class HelloController : Controller {
    public IActionResult Index() {
        // Product を複数まとめる一覧を作る
        var products = new List<Product>
        {
            new Product
            {
                Name = "ハンバーガー", // 1 件目の商品名
                Price = 500 // 1 件目の価格
            },
            new Product
            {
                Name = "紅茶", // 2 件目の商品名
                Price = 450 // 2 件目の価格
            },
            new Product
            {
                Name = "ハンバーガー", // 1 件目の商品名
                Price = 500 // 1 件目の価格
            },
            new Product
            {
                Name = "紅茶", // 2 件目の商品名
                Price = 450 // 2 件目の価格
            },
            new Product
            {
                Name = "ハンバーガー", // 1 件目の商品名
                Price = 500 // 1 件目の価格
            },
            new Product
            {
                Name = "紅茶", // 2 件目の商品名
                Price = 450 // 2 件目の価格
            },
            new Product
            {
                Name = "ハンバーガー", // 1 件目の商品名
                Price = 500 // 1 件目の価格
            },
            new Product
            {
                Name = "紅茶", // 2 件目の商品名
                Price = 450 // 2 件目の価格
            },
            new Product
            {
                Name = "ハンバーガー", // 1 件目の商品名
                Price = 500 // 1 件目の価格
            },
            new Product
            {
                Name = "紅茶", // 2 件目の商品名
                Price = 450 // 2 件目の価格
            },
        };
        return View(products); // 商品の一覧をView へ渡す
    }
}

