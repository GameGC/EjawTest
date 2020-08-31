using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class InstantiationBehavior : IClickable
{
    static readonly PrimitiveType[] AvailableBundles = {
        PrimitiveType.Cube,
        PrimitiveType.Cylinder,
        PrimitiveType.Sphere
    };

    static readonly int AvailableBundlesLength = AvailableBundles.Length;

    
    static NameData _nameData;

    readonly List<AssetBundle> m_LoadedBundles = new List<AssetBundle>();

    [RuntimeInitializeOnLoadMethod]
    public static void Initialise()
    {
        string jsonData = Resources.Load<TextAsset>("Namings").text;
        _nameData = JsonUtility.FromJson<NameData>(jsonData);
    }
    
    public void OnClickCallbackReceived(in RaycastHit hitInfo)
    {
        int currentBundle = Random.Range(0, AvailableBundlesLength);
        string randomPrimitiveName = AvailableBundles[currentBundle].ToString();
        GetOrLoadAssetBundle(randomPrimitiveName,out var bundle);

        var prefab = bundle.LoadAsset<GameObject>(_nameData.ObjectNames[currentBundle]);
        Object.Instantiate(prefab, hitInfo.point, Quaternion.identity);
    }

    void GetOrLoadAssetBundle(string path,out AssetBundle bundle)
    {
        var existingBundle = m_LoadedBundles.SingleOrDefault(a => string.Equals(a.name,path,StringComparison.InvariantCultureIgnoreCase));
        if (existingBundle == null)
        {
            path = $"{Application.streamingAssetsPath}/{path}";
            bundle = AssetBundle.LoadFromFile(path);
            m_LoadedBundles.Add(bundle);
        }
        else bundle = existingBundle;
    }
}