using TMPro;
using UnityEngine;

public class displayValue : MonoBehaviour
{
    private static TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
    }
    public static void changeText(float val)
    {
        text.text = val.ToString();
    }
}
