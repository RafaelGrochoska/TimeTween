using System;
using UnityEngine;


namespace Grochoska.TimeTween
{
    public static class Timer
    {
        public static TimeTween CreateTween(float duration, Action<TimeTween> whileRunning = null,
            Action onEnd = null)
        {
            Debug.Assert(duration != 0, "You can't create a Timer with duration <= 0. Aborting...");
            if (duration <= 0) return null;

            var countdown = new TimeTween(duration);

            if (onEnd != null) countdown.AddListenerOnEnd(onEnd);
            if (whileRunning != null) countdown.AddRoutine(whileRunning);
            return countdown;
        }
    }
}