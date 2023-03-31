using UnityEngine;

sealed class GCAllocCheck : MonoBehaviour
{
    [SerializeField] int _spawnCount = 1000;

    void Start()
    {
        var components = new [] { typeof(AwaitableTester) };
        for (var i = 0; i < _spawnCount; i++)
            new GameObject("AwaitableTester", components);
    }
}
