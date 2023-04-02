using UnityEngine;
using UnityEngine.Rendering;

public sealed class AsyncReadbackSample : MonoBehaviour
{
    [SerializeField] Texture _texture = null;

#if false

    void Start()
    {
        var frameCount = Time.frameCount;
        AsyncGPUReadback.Request(_texture, 0, OnReadCallback);
    }

    void OnReadCallback(AsyncGPUReadbackRequest req)
    {
        Debug.Log(frameCount);
        Debug.Log(req.GetData<Color32>()[0]);
    }

#else

    async void Start()
    {
        var frameCount = Time.frameCount;
        var req = await AsyncGPUReadback.RequestAsync(_texture, 0);

        Debug.Log(frameCount);
        Debug.Log(req.GetData<Color32>()[0]);
    }

#endif
}
