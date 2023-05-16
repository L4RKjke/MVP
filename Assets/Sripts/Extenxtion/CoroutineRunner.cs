using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class CoroutineRunner: MonoBehaviour
{
    public static CoroutineRunner Instance;

    private List<Coroutine> _coroutines = new List<Coroutine>();    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }

        Destroy(gameObject);
    }

    public void StartRoutine(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }

    public void StopRoutine(IEnumerator coroutine)
    {
        StopCoroutine(coroutine);
    }
}