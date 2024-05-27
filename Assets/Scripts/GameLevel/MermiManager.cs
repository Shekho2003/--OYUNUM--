using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermiManager : MonoBehaviour
{
    //BURADA YAZILANA GÖRE 15f OLMASI GEREKÝR ANCAK BUNU BEN DEÐÝÞTÝRDÝM

    float mermiHizi = 1000f;
     


    
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * mermiHizi);
    }
}
