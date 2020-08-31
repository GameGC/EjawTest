using System.Globalization;
using TMPro;
using UnityEngine;

public class ObservableTimeView : MonoBehaviour
{
    [SerializeField] TMP_InputField InputField;

    void Start()
    {
        InputField.text = GameData.ObServableTime.ToString(CultureInfo.InvariantCulture);
        InputField.onValueChanged.AddListener(OnChanged);
    }

    void OnChanged(string newValue)
    {
        if (double.TryParse(InputField.text, out double temp)) 
            GameData.ObServableTime = (float)temp;
    }
}
