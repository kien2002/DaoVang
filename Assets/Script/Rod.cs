using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rod : MonoBehaviour
{
    [SerializeField]
    private string tag;
   
    public int slowDown; //can nang lam cham day
 
    public int dollar;
    void Awake()
    {
        this.tag = tag;
    }
}
