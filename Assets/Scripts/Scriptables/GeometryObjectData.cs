using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/"+nameof(GeometryObjectData) , fileName = nameof(GeometryObjectData))]
public class GeometryObjectData : ScriptableSingleton<GeometryObjectData>
{
    public static List<ClickColorData> ColorData => instance._colorData;

    
    
    [SerializeField] List<ClickColorData> _colorData;


}