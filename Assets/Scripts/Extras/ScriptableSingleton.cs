using UnityEngine;


public class ScriptableSingleton<T> : ScriptableObject where T: Object
{
    protected static T instance
    {
        get
        {
            if (!m_Instance) m_Instance = Resources.Load<T>(typeof(T).Name);
            return m_Instance;
        }
    }
    static T m_Instance;
}