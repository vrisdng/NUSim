using TMPro;
using UnityEngine;
using UnityEngine.UI;

public static class Utils 
{
    public static void SetVisibility(GameObject gameObject, bool isVisible)
    {
        gameObject.SetActive(isVisible);
    }

    public static void SetVisibility(Button button, bool isVisible)
    {
        button.gameObject.SetActive(isVisible);
    }

    public static void SetText(TextMeshProUGUI textComponent, string text)
    {
        textComponent.text = text;
    }
}
