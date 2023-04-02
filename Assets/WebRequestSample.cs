using UnityEngine;
using UnityWebRequest = UnityEngine.Networking.UnityWebRequest;

public sealed class WebRequestSample : MonoBehaviour
{
    [SerializeField] string _uri = "https://unity.com";

    async void Start()
    {
        using var req = UnityWebRequest.Get(_uri);
        await req.SendWebRequest();
        Debug.Log($"{req.result}: {req.downloadedBytes} bytes");
    }
}
