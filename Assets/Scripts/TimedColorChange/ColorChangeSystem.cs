using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using static System.TimeSpan;
using Random = UnityEngine.Random;

public class ColorChangeSystem : MonoBehaviour
{
    CompositeDisposable m_Disposables;
    List<IModelColor> m_List = new List<IModelColor>();

    static ColorChangeSystem instance;

    void OnEnable()
    {
        instance = this;
        m_Disposables = m_Disposables ?? new CompositeDisposable();
    }

    void OnDisable()
    {
        instance = null;
        m_Disposables?.Dispose();
    }

    public static void AddObjectWithColor(IModelColor modelColor) => instance.m_List.Add(modelColor);
    
    // ReSharper disable once Unity.NoNullPropagation
    public static void RemoveObjectWithColor(IModelColor modelColor) => instance?.m_List?.Remove(modelColor);


    void Start()
    {
        IDisposable disposable =  Observable.Timer (FromSeconds(GameData.ObServableTime))
            .Repeat () 
            .Subscribe (_=>OnUpdate()).AddTo (m_Disposables);

        GameData.OnObservableTimeChanged += newTime =>
        {
            disposable.Dispose();
            disposable =  Observable.Timer (FromSeconds(GameData.ObServableTime))
                .Repeat () 
                .Subscribe (_=>OnUpdate()).AddTo (m_Disposables);
        };
    }

    void OnUpdate()
    {
        foreach (var model in m_List)
        {
            var vectorValue = Random.onUnitSphere;
            model.ModelColor = new Color(vectorValue.x,vectorValue.y,vectorValue.z);
        }
    }
}
