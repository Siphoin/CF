using System.Collections;
using UnityEngine;

namespace CoroutinesSystem
{
    public sealed class Coroutines : MonoBehaviour
    {
        private static Coroutines m_instance = null;
        private static Coroutines Instance { get
            {
                if (!m_instance)
                {
                    var obj = new GameObject("Coroutines Manager");
                    m_instance = obj.AddComponent<Coroutines>();
                    DontDestroyOnLoad(obj);
                }


                return m_instance;
            }
        
        }

        public static Coroutine StartRoutine (IEnumerator routine)
        {
            return Instance.StartCoroutine(routine);
        }

        public static void StopRoutine (Coroutine coroutine)
        {
            if (Instance)
            {
                Instance.StopCoroutine(coroutine);
            }
        }
    }
}