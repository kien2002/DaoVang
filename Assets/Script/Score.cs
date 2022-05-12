using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [SerializeField]
    GameObject panel;
    [SerializeField] Text timeText;
    [SerializeField] float duration, currentTime;
    public static Score instance;
    public Text scoreText;

    int score = 0;
   


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        scoreText.text ="$ :"  +score.ToString();
        panel.SetActive(false);
        currentTime = duration;
        timeText.text = currentTime.ToString();
        StartCoroutine(TimeIEn());
    }
    IEnumerator TimeIEn()
    {
        while (currentTime > 0)
        {
            timeText.text = currentTime.ToString();
            yield return new WaitForSeconds(1f);
            currentTime--;
        }
        OpenPanel();
    }
     void Update()
    {
       
    }
    public void AddPoints()
    {
        score += 500;
        scoreText.text ="$ :" + score.ToString();
    }
    void OpenPanel()
    {
        timeText.text = "";
        panel.SetActive(true);
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
