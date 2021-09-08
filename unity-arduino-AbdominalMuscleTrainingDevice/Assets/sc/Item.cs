using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Image sprite;
    public bool playing;
    public float timeTemp;
    public int sec; 
    void Start()
    {
        sprite = this.GetComponent<Image>();
    }

    void Update()
    {
        if (playing)
        {
            timeTemp += Time.deltaTime;
            if (timeTemp > 1)
            {
                sec++;
                if (sec >= 3)
                {
                    //關掉
                    sprite.color = Color.white;
                    playing = false;
                }
                timeTemp = 0;
            }
        }
    }

    public void SetGreen() {
        sec = 1;
        sprite.color = Color.yellow;
        playing = true;
    }

    public void GetScore()
    {
        if (sprite.color == Color.yellow)
        {
            sprite.color = Color.white;
            GameLogic.addScore();
        }
    }
}
