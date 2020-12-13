# LabeledEnum
Enumと文字列の相互変換を拡張する。

## 使い方
使いたいEnumにラベルをつけておく。

```csharp
enum Orientation
{
    [EnumLabel("縦")]
    Vertical,
    [EnumLabel("横")]
    Horizontal,
}
```

Enumからラベルとして指定した文字列に変換する。
```csharp
using LabeledEnum;

string vertical = Orientation.Vertical.ToLabelString(); // -> "縦"
string vertical = Orientation.Horizontal.ToLabelString(); // -> "横"
```

ラベルの文字列からEnumに変換する。
```csharp
using LabeledEnum;

bool result = EnumLabel.TryParse("縦", out Orientation orientation1);
Orientation Orientation2 = EnumLabel.Parse<Orientation>("横");
```