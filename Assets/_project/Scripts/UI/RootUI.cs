using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootUI : MonoBehaviour
{
    public static RootUI instance;

    [SerializeField]
    private MainGameUI mainGame;

    private void Awake()
    {
        if (instance)
        {
            Destroy(this);
            return;
        }

        instance = this;
    }

    public MainGameUI GetMainGameUI() 
    { 
        return mainGame; 
    }
}
