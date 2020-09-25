# Time Tween

```csharp
// Create a tween
Timer.CreateTween(_duration, UpdateAction, EndAction);

// Use a tween
void UpdateAction(TimeTween t){
  var pos = Mathf.lerp(0, 1, t.percentage);
  ...
}

```
