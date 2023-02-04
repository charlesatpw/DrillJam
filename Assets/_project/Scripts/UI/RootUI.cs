using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootUI : MonoBehaviour
{
    [SerializeField]
    private MainGameUI mainGame;

    public MainGameUI GetMainGameUI() 
    { 
        return mainGame; 
    }
}
