using System.ComponentModel.DataAnnotations;

namespace SelfOrderSystem.Models;

public class Order {
    public int Id { get; set; } // DB 内の注文ID
    public Guid PublicId { get; set; } = Guid.NewGuid();
    [Range(1, 999)]
    public int TableNumber { get; set; } // テーブル番号
    public DateTimeOffset OrderedAtUtc { get; set; } // UTC の注文日時
    public OrderStatus Status { get; set; } = OrderStatus.New;
    public List<OrderItem> Items { get; set; } = new();
}
