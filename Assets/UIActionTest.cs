using UnityEngine;
using UnityEngine.UI;

public sealed class UIActionTest : MonoBehaviour
{
    public async void OnClickButtonAsync()
    {
        var button = GetComponent<Button>();
        var text = GetComponentInChildren<Text>();
        var image = GetComponentsInChildren<Image>()[1];

        button.interactable = false;
        text.enabled = false;
        image.enabled = true;

        var rect = image.GetComponent<RectTransform>();

        for (var i = 0; i < 100; i++)
        {
            await Awaitable.WaitForSecondsAsync(0.02f);
            rect.eulerAngles = new Vector3(0, 0, i * 10);
        }

        text.enabled = true;
        text.text = "Loaded!";
        image.enabled = false;
    }
}
