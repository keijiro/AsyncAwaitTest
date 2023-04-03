using UnityEngine;
using System;
using System.Reflection;

public sealed class AsyncClass
{
    public async void AsyncMethod1()
    {
        await Awaitable.WaitForSecondsAsync(1);
    }

    public async Awaitable AsyncMethod2()
    {
        await Awaitable.WaitForSecondsAsync(1);
    }

    public async Awaitable<int> AsyncMethod3()
    {
        await Awaitable.WaitForSecondsAsync(1);
        return 1;
    }
}

public sealed class ReflectionTest : MonoBehaviour
{
    public async void AsyncMethod1()
    {
        await Awaitable.WaitForSecondsAsync(1);
    }

    public async Awaitable AsyncMethod2()
    {
        await Awaitable.WaitForSecondsAsync(1);
    }

    public async Awaitable<int> AsyncMethod3()
    {
        await Awaitable.WaitForSecondsAsync(1);
        return 1;
    }

    [SerializeField] UnityEngine.Events.UnityEvent _unityEvent = null;

    void Start()
    {
        var type = typeof(AsyncClass);
        foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance))
            Debug.Log(method);

        _unityEvent.Invoke();
    }
}
