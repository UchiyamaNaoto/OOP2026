List<IGreetingBase> list = [
        new GreetingMorning(),
        new GreetingAfternoon(),
        new GreetingEvening(),
    ];

foreach (var obj in list) {
    string msg = obj.GetMessage();
    Console.WriteLine(msg);
}

//インターフェイス
interface IGreetingBase {
    string GetMessage() => "";
}

//IGreetingBaseを実装したクラス群
class GreetingMorning : IGreetingBase {
    public string GetMessage() => "おはよう";
}

class GreetingAfternoon : IGreetingBase {
    public string GetMessage() => "こんにちは";
}

class GreetingEvening : IGreetingBase {
    public string GetMessage() => "こんばんは";
}
