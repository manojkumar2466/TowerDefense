using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericMonoSingleton<T> : MonoBehaviour where T: GenericMonoSingleton<T>
{
    public static T Instance { get { return instance; } }

    private static T instance;

    private void Awake()
    {
        if (!instance)
        {
            instance = (T)this;
        }
        else if(instance)
        {
            Destroy(this.gameObject);
        }
    }


}
