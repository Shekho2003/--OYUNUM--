using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    CorrectManager correctManager;
    GameManager gameManager;
    
    public Text sureText,soruSureText;

    public int kalanSure, kalanSoruSure;

    bool sureSaysinmi;

    [SerializeField]
    private GameObject sonucPaneli;

    [SerializeField]
    private GameObject sonuclarObje, zamanObje, dogruYanlisObje, playerObje, puanObje;

    

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        correctManager=FindObjectOfType<CorrectManager>();
        kalanSure = 60;
        kalanSoruSure = 10;
        sureSaysinmi = true;

        sonucPaneli.SetActive(false);

        sonuclarObje.SetActive(true);
        zamanObje.SetActive(true);
        dogruYanlisObje.SetActive(true);
        playerObje.SetActive(true);
        puanObje.SetActive(true);

        StartCoroutine(SureTimerRoutine());
        
    }

    IEnumerator SureTimerRoutine()
    {
        while (sureSaysinmi) 
        {
            yield return new WaitForSeconds(1f);

            if (kalanSure < 10) 
            {
                sureText.text= "0" + kalanSure.ToString();
            }else
            {
                sureText.text = kalanSure.ToString();
            }

            if (kalanSure <= 0)
            {
                sureSaysinmi=false;
                sureText.text = "";

                EkraniTemizle();

                sonucPaneli.SetActive(true);

            }

            kalanSure--;
            if (kalanSoruSure < 0)
            {
                gameManager.SonucuKontrolEt(gameManager.dogruSonuc - 1);

                kalanSoruSure = 10;
                soruSureText.text = "";
                gameManager.SoruyuYazdir();
                gameManager.dogruÝmage.gameObject.SetActive(true);
                gameManager.yanlisÝmage.gameObject.SetActive(true);
                correctManager.control();

            }
            else
            {
                if(!correctManager.updated)
                {
                    soruSureText.text = kalanSoruSure.ToString();

                }
            }

            kalanSoruSure--;



        }
    }

    void EkraniTemizle()
    {

        sonuclarObje.SetActive(false);
        zamanObje.SetActive(false);
        dogruYanlisObje.SetActive(false);
        playerObje.SetActive(false);
        puanObje.SetActive(false);

    }



}
