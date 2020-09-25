using UnityEngine;
using UnityEngine.SceneManagement;

namespace Grochoska.TimeTween
{
    internal class TimerRoutiner : MonoBehaviour
    {
        /// <summary>
        /// Returns the instance of the currently running Timer Routiner
        /// </summary>
        internal static TimerRoutiner Instance { get; private set; } = null;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Setup()
        {
            if (Instance != null) return;

            var routiner = new GameObject("[TIMER ROUTINER]");
            DontDestroyOnLoad(routiner.gameObject);

            Instance = routiner.AddComponent<TimerRoutiner>();

            SceneManager.sceneLoaded += (s, mode) =>
            {
                if (mode == LoadSceneMode.Single)
                    Instance.StopAllCoroutines();
            };
        }
    }
}