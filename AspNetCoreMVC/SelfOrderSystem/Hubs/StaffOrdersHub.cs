using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;

namespace SelfOrderSystem.Hubs;

// 店舗画面と注文状況画面が接続するHub
public class StaffOrdersHub : Hub {

    // 指定した注文だけの通知を受けるグループへ参加
    public async Task JoinOrder(string publicId) {
        if (!Guid.TryParse(publicId, out var id))
            throw new HubException("注文ID が正しくありません");
        // 同じ注文ID のブラウザを同じグループへ登録
        await Groups.AddToGroupAsync(
        Context.ConnectionId, $"order-{id:N}");
    }
}
