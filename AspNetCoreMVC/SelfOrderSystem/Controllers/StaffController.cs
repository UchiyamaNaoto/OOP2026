using Microsoft.AspNetCore.Mvc; // Controller を使用
using Microsoft.EntityFrameworkCore; // EF Core の非同期処理を使用
using SelfOrderSystem.Data; // AppDbContext を使用

namespace SelfOrderSystem.Controllers;

public class StaffController : Controller {

    private readonly AppDbContext _db; // DB への接続を担当

    public StaffController(AppDbContext db) {
        _db = db; // DI で受け取ったものを保存
    }

    [HttpGet] // 注文一覧を表示するGET リクエスト
    public async Task<IActionResult> Index() {

        var orders = await _db.Orders
                            .AsNoTracking()                 // 表示専用なので追跡しない
                            .Include(o => o.Items)          // 注文明細を一緒に取得
                            .ThenInclude(i => i.Product)    // 明細に対応する商品を取得
                            .OrderByDescending(o => o.OrderedAtUtc) // 新しい順
                            .Take(50) // 最大50 件
                            .ToListAsync(); // 注文一覧を取得

        return View(orders); // Views/Staff/Index.cshtml に渡す
    }
}