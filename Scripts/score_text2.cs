using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class score_text2 : MonoBehaviour
{
    public Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = Convert.ToString(coin_events.scores);
        coin_events.scores = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
