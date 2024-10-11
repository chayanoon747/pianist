using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowBestScore2 : MonoBehaviour
{

    public TextMeshProUGUI score;
   
    void Start()
    {
        score.text = PlayerInfo.best_score_song2.ToString();
    }

}
