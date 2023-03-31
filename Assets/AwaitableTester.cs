using UnityEngine;
using CancellationToken = System.Threading.CancellationToken;
using OperationCanceledException = System.OperationCanceledException;

public sealed class AwaitableTester : MonoBehaviour
{
    public static int Counter;

    async void Start()
    {
        while (true)
        {
            await Awaitable.NextFrameAsync();
            await IncrementAsync();
        }
    }

    /*
    async Awaitable Update()
    {
        await IncrementAsync();
    }
    */

    async Awaitable IncrementAsync()
    {
        await Awaitable.NextFrameAsync();
        Counter++;
    }
}
