using UnityEngine;

public interface IClickable
{
    void OnClickCallbackReceived(in RaycastHit hitInfo);
}
