using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/"+nameof(GameData) , fileName = nameof(GameData))]
public class GameData : ScriptableSingleton<GameData>
{
    [SerializeField] float _obServableTime;

    public static float ObServableTime
    {
        get => instance._obServableTime;
        set
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (instance._obServableTime == value) return;
            
            instance._obServableTime = value;
            OnObservableTimeChanged?.Invoke(value);
        }
    }

    public static Action<float> OnObservableTimeChanged;
}
