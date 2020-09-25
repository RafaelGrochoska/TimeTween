using System;
using UnityEngine;
using System.Collections;
using System.Globalization;

namespace Grochoska.TimeTween
{
    public class TimeTween
    {
        public enum StringType
        {
            RemainingMinutes,
            RemainingSeconds
        }

        private readonly float _duration = 0;
        private readonly float _startTime = 0;

        public bool hasEnded => percentage == 1;
        public float elapsedTime => Time.time - _startTime;
        public float remainingTime => _duration - elapsedTime;
        public float percentage => Mathf.Clamp01(elapsedTime / _duration);

        private Coroutine _update = null;
        private Action _onEnd = null;

        internal TimeTween(float duration)
        {
            _startTime = Time.time;
            _duration = duration;
        }

        public void CancelUpdate()
        {
            TimerRoutiner.Instance.StopCoroutine(_update);
        }

        public void CancelEnd()
        {
            _onEnd = null;
        }

        public void CancelAll()
        {
            CancelUpdate();
            CancelEnd();
        }

        public void AddRoutine(Action<TimeTween> action)
        {
            _update = TimerRoutiner.Instance.StartCoroutine(Routine(action));
        }

        public void AddListenerOnEnd(Action action)
        {
            _onEnd = action;
        }


        private IEnumerator Routine(Action<TimeTween> action)
        {
            while (!hasEnded)
            {
                action.Invoke(this);
                yield return null;
            }

            _onEnd?.Invoke();
            yield return null;
        }

        /// <summary>
        /// Returns the remaining time in minutes
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ToString(StringType.RemainingMinutes);
        }

        /// <summary>
        /// Returns the remaining time
        /// </summary>
        /// <param name="type">Remaining Minutes || Remaining Seconds</param>
        /// <returns></returns>
        public string ToString(StringType type)
        {
            switch (type)
            {
                case StringType.RemainingMinutes:
                    var time = remainingTime;
                    var minutes = (int) (time / 60.0f);
                    var seconds = (int) (time % 60);

                    return $"{minutes:00}:{seconds:00}";
                case StringType.RemainingSeconds:
                    return remainingTime.ToString(CultureInfo.CurrentCulture);
                default:
                    return string.Empty;
            }
        }
    }
}