# Time Tween

## How to use

```csharp
// Create a tween
Timer.CreateTween(_duration, UpdateAction, EndAction);

// Use a tween
void UpdateAction(TimeTween t){
  var pos = Mathf.lerp(0, 1, t.percentage);
  ...
}

```

## Installation

Add the folowing line to your `manifest.json` 

```json
"com.grochoska.timetween": "https://github.com/RafaelGrochoska/TimeTween.git#1.0.1",
```
