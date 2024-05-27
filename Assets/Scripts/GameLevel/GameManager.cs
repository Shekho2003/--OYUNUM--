using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using DG.Tweening.Core.Easing;


public class GameManager : MonoBehaviour
{
    CorrectManager correctManager;
    TimerManager timerManager;
    [SerializeField]
    private GameObject baslatÝmage;

    public GameObject dogruÝmage, yanlisÝmage;

    [SerializeField]
    private Text soruText,birinciSonucText,ikinciSonucText,ucuncuSonucText;

    [SerializeField]
    private Text dogruAdetText, yanlisAdetText, puanText;


    //yenii

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip dogruSes;

    [SerializeField]
    private AudioClip yanlýsSes;

    [SerializeField]
    private AudioClip StartSes;


    //yenii

    string hangiOyun;

    int birinciCarpan;
    int ikinciCarpan;
    int ucuncuCarpan;

    public int dogruSonuc;
    int birinciYanlisSonuc;
    int ikinciYanlisSonuc;

   public int dogruAdet, yanlisAdet, toplamPuan;


    PlayerManager playerManager;

    private void Awake()
    {
        timerManager = FindObjectOfType<TimerManager>();
        correctManager = FindObjectOfType<CorrectManager>();
        playerManager = Object.FindObjectOfType<PlayerManager>();
        
    }



    void Start()
    {

        dogruAdet = 0;
        yanlisAdet = 0;
        toplamPuan = 0;

        dogruÝmage.GetComponent<RectTransform>().localScale = Vector3.zero;
        yanlisÝmage.GetComponent<RectTransform>().localScale = Vector3.zero;


        if (PlayerPrefs.HasKey("hangiOyun"))
        {

            hangiOyun = PlayerPrefs.GetString("hangiOyun");

        }

        StartCoroutine(baslaYaziRourine());

        audioSource.PlayOneShot(StartSes);

    }

    IEnumerator baslaYaziRourine()
    {
        baslatÝmage.GetComponent<RectTransform>().DOScale(1.3f, 0.5f);
        yield return new WaitForSeconds(0.6f);
        baslatÝmage.GetComponent<RectTransform>().DOScale(0f, 0.5f).SetEase(Ease.InBack);
        baslatÝmage.GetComponent<CanvasGroup>().DOFade(0f, 1f);
        yield return new WaitForSeconds(0.6f);

        OyunaBasla();

    }

    void OyunaBasla()
    {

        playerManager.rotadegissinmi = true;

        SoruyuYazdir();

    }

    void BirinciCarpaniAyarla()
    {

        switch (hangiOyun)
        {
            
            case "iki":
                birinciCarpan = 2;
                break;

            case "üç":
                birinciCarpan = 3;
                break;

            case "dört":
                birinciCarpan = 4;
                break;

            case "beþ":
                birinciCarpan = 5;
                break;

            case "altý":
                birinciCarpan = 6;
                break;

            case "yedi":
                birinciCarpan = 7;
                break;

            case "sekiz":
                birinciCarpan = 8;
                break;

            case "dokuz":
                birinciCarpan = 9;
                break;

            case "on":
                birinciCarpan = 10;
                break;

            case "karýþýk":
                birinciCarpan = Random.Range(2, 11);
                break;
         
        }

        //Debug.Log(birinciCarpan);

    }


    public void SoruyuYazdir()
    {
        BirinciCarpaniAyarla();


        ikinciCarpan = Random.Range(2, 11);

        ucuncuCarpan = Random.Range(2, 11);

        int rastgeleDeger = Random.Range(1, 100);

        if (rastgeleDeger <= 50)
        {
            soruText.text = "[" + birinciCarpan.ToString() + "x" + ikinciCarpan.ToString() + "]" + "+" + ucuncuCarpan.ToString() + "=" + "?";
        }else
        {
            soruText.text = "[" + ikinciCarpan.ToString() + "x" + birinciCarpan.ToString() + "]" + "+" + ucuncuCarpan.ToString() + "=" + "?";
        }

        dogruSonuc = birinciCarpan * ikinciCarpan + ucuncuCarpan;
        

        SonuclarYazdir();

    }

    void SonuclarYazdir()
    {
        birinciYanlisSonuc = dogruSonuc + Random.Range(2, 10);

        if (dogruSonuc > 10)
        {
            ikinciYanlisSonuc = dogruSonuc - Random.Range(2, 8);
        }else
        {
            ikinciYanlisSonuc = Mathf.Abs(dogruSonuc - Random.Range(1, 5));
        }


        int rastgeleDeger = Random.Range(1, 100);

        if (rastgeleDeger <= 33)
        {
            birinciSonucText.text = dogruSonuc.ToString();
            ikinciSonucText.text = birinciYanlisSonuc.ToString();
            ucuncuSonucText.text = ikinciYanlisSonuc.ToString();

        }else if (rastgeleDeger <= 66)
        {
            ikinciSonucText.text = dogruSonuc.ToString();
            birinciSonucText.text = birinciYanlisSonuc.ToString();
            ucuncuSonucText.text = ikinciYanlisSonuc.ToString();


        }else
        {
            ucuncuSonucText.text = dogruSonuc.ToString();
            ikinciSonucText.text = birinciYanlisSonuc.ToString();
            birinciSonucText.text = ikinciYanlisSonuc.ToString();


        }


    }

    public void SonucuKontrolEt(int sayi)
    {

        dogruÝmage.GetComponent<RectTransform>().localScale = Vector3.zero;
        yanlisÝmage.GetComponent<RectTransform>().localScale = Vector3.zero;


        if (sayi == dogruSonuc)
        {
            timerManager.kalanSoruSure = 10;
            timerManager.soruSureText.text = "";
            correctManager.updated = true;
            dogruÝmage.gameObject.SetActive(true);
            yanlisÝmage.gameObject.SetActive(true);

            correctManager.control();

            dogruAdet++;
            toplamPuan += 20;
            dogruÝmage.GetComponent<RectTransform>().DOScale(1, .1f);

            //dogru...
            audioSource.PlayOneShot(dogruSes);        
        } else
          {
            timerManager.kalanSoruSure = 10;
            timerManager.soruSureText.text = "";
            correctManager.updated = true;
            dogruÝmage.gameObject.SetActive(true);
            yanlisÝmage.gameObject.SetActive(true);

            correctManager.control();
            yanlisAdet++;
            yanlisÝmage.GetComponent<RectTransform>().DOScale(1, .1f);

            //yanlýþ
            audioSource.PlayOneShot(yanlýsSes);       
          }
        

        dogruAdetText.text = dogruAdet.ToString()+ " DOÐRU";
        yanlisAdetText.text = yanlisAdet.ToString() + " YANLIÞ";
        puanText.text = toplamPuan.ToString() + " PUAN";

        //tekrar Soru Yazdýrmak için
        SoruyuYazdir();

    }

    


}


