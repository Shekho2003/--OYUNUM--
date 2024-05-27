using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesKontrolManager : MonoBehaviour
{
    private void Start()
    {
        sesAc();
    }

    public void sesAc() 
    {
        PlayerPrefs.SetInt("sesDurumu", 1);
    }

    public void sesKapat()
    {
        PlayerPrefs.SetInt("sesDurumu", 0);
    }


}
