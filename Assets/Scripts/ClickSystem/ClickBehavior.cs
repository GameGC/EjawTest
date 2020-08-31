using System.Linq;
using UnityEngine;

public class ClickBehavior : IClickable
{
    public void OnClickCallbackReceived(in RaycastHit hitInfo)
    {
        var model = hitInfo.transform.GetComponent<GeometryObjectModel>();
        var typeData = GeometryObjectData.ColorData.SingleOrDefault(m => m.ObjectType == model.ObjectType);
        ref int clickCount = ref model.ClickCount;
        clickCount++;
        
        if(clickCount>=typeData.MinClicksCount && clickCount<typeData.MaxClicksCount)
            model.ModelColor = typeData.Color;
    }
}
