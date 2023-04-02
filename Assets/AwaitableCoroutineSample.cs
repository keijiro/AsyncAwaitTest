using UnityEngine;
using System.Collections;

public sealed class AwaitableCoroutineSample : MonoBehaviour
{
#if true

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("One");

        yield return null;
        Debug.Log("Two");
    }

#else

    async void Start()
    {
        await Awaitable.WaitForSecondsAsync(1);
        Debug.Log("One");

        await Awaitable.NextFrameAsync();
        Debug.Log("Two");
    }

#endif
}
