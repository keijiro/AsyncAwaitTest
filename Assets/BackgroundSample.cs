using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Experimental.Rendering;
using File = System.IO.File;

public sealed class BackgroundSample : MonoBehaviour
{
    [SerializeField] Texture _texture = null;

    const uint Width = 256;
    const uint Height = 256;
    const GraphicsFormat Format = GraphicsFormat.R8G8B8A8_UNorm;

#if false

    void Start()
      => AsyncGPUReadback.Request(_texture, 0, OnReadCallback);

    void OnReadCallback(AsyncGPUReadbackRequest req)
    {
        var image = req.GetData<byte>().ToArray();
        var png = ImageConversion.
          EncodeArrayToPNG(image, Format, Width, Height);
        File.WriteAllBytes("Output.png", png);
    }

#else

    async void Start()
    {
        var req = await AsyncGPUReadback.RequestAsync(_texture, 0);
        var image = req.GetData<byte>().ToArray();

        await Awaitable.BackgroundThreadAsync();

        var png = ImageConversion.
          EncodeArrayToPNG(image, Format, Width, Height);
        File.WriteAllBytes("Output.png", png);

        await Awaitable.MainThreadAsync();
    }

#endif
}
