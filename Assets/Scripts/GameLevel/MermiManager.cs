using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermiManager : MonoBehaviour
{
    //BURADA YAZILANA G�RE 15f OLMASI GEREK�R ANCAK BUNU BEN DE���T�RD�M

    float mermiHizi = 1000f;
     


    
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * mermiHizi);
    }
}
