using System;
using UnityEngine;

public class GeometryObjectModel : MonoBehaviour,IModelColor
{
   public Color ModelColor
   {
      get => renderer.material.color;
      set => renderer.material.color = value;
   }

   [NonSerialized]
   public int ClickCount;

   public string ObjectType;
   
   [SerializeField] new MeshRenderer renderer;

   void Start () => ColorChangeSystem.AddObjectWithColor(this);

   void OnDisable () => ColorChangeSystem.RemoveObjectWithColor(this);
}
