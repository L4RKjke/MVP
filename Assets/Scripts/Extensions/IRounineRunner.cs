using System.Collections;

public interface IRounineRunner
{
    void StartRoutine(IEnumerator coroutine);

    void StopRoutine(IEnumerator coroutine);
}