using System.Collections;
using UnityEngine;

public class CoroutineRunner: MonoBehaviour, IRounineRunner
{
    public void StartRoutine(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }

    public void StopRoutine(IEnumerator coroutine)
    {
        StopCoroutine(coroutine);
    }
}