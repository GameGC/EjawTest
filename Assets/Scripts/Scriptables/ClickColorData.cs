using System;
using UnityEngine;

[Serializable]
public struct ClickColorData
{
    public string ObjectType;
    public int MinClicksCount;
    public int MaxClicksCount;
    public Color Color;
}
