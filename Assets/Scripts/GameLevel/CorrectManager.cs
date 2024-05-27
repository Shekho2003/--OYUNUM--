using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectManager : MonoBehaviour
{
    TimerManager timerManager;
    public GameObject correct,noCorrect;
    public bool updated;
    private void Start()
    {
        timerManager=FindObjectOfType<TimerManager>();
    }
    public void control()
    {
        StartCoroutine(waitTime());
    }

    private void FixedUpdate()
    {
        if (updated)
        {
            timerManager.soruSureText.text = "";
        }
    }
    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(2);
        correct.SetActive(false);
        noCorrect.SetActive(false);
        updated = false;
    }
}
