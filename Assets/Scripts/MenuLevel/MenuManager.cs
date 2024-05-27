using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject MenuPanel;

    [SerializeField]
    private AudioSource audioSorce;

    [SerializeField]
    private AudioClip butonClick;

    [SerializeField]
    private AudioClip StartSes;

    [SerializeField]
    private GameObject sesPaneli;

    bool sesPaneliAcikmi;

   

    void Start()
    {
        //-20 yerine -63
        sesPaneliAcikmi = false;
        sesPaneli.GetComponent<RectTransform>().localPosition = new Vector3(2, -20, 0); 

        MenuPanel.GetComponent<CanvasGroup>().DOFade(1, 1f);
        MenuPanel.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBack);

        audioSorce.PlayOneShot(StartSes);
    }

    public void ikinciLevelGec()
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSorce.PlayOneShot(butonClick);

        }


        SceneManager.LoadScene("GameLevel");
    }

    public void AyarlariYap()
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSorce.PlayOneShot(butonClick);

        }

        if (!sesPaneliAcikmi)
        {
            //160 yerine 170

            sesPaneli.GetComponent<RectTransform>().DOLocalMoveY(-65, 0.5f);
            sesPaneliAcikmi=true;

        }else
        {
            sesPaneli.GetComponent<RectTransform>().DOLocalMoveY(0, 0.5f);
            sesPaneliAcikmi = false;
        }

    }

    public void OyundanCik()
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSorce.PlayOneShot(butonClick);

        }

        Application.Quit();
    }




}
