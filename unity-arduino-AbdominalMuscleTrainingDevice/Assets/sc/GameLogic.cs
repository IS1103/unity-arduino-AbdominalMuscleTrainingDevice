using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public ArduinoConnector arduinoConnector;
    public GameObject panel;
    public Text num,scoreTxt;
    public Item[] item;
    static public Action addScore;

    int score;
    int sec;
    int randomeIsLight;

    void Start()
    {
        num.text = "";
        addScore = AddScore;

        arduinoConnector.receiveEvent = ReceiveEvent;
    }

    private void ReceiveEvent(string msg)
    {
        AddScore();
    }

    private void AddScore()
    {
        score++;
        scoreTxt.text = score.ToString();
    }

    void Update()
    {
    }

    public void Restart()
    {
        panel.SetActive(false);
        num.text = "";
        scoreTxt.text = "";
        score = 0;
    }

    public void ClickNormal()
    {
        Restart();
        sec = 30;
        this.StartCoroutine(Game());
    }

    public void ClickHard()
    {
        Restart();
        sec = 60;
        this.StartCoroutine(Game());
    }

    public IEnumerator Game()
    {
        while (sec > 0)
        {
            num.text = sec.ToString();
            sec--;
            yield return new WaitForSeconds(1f);

            randomeIsLight = UnityEngine.Random.Range(0, 5);
            if (randomeIsLight < 3)
            {
                Debug.Log("green");
                item[UnityEngine.Random.Range(0, 5)].SetGreen();
            }
        }

        yield return null;
   }
}