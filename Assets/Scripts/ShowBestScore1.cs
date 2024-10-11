using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowBestScore1 : MonoBehaviour
{

    public TextMeshProUGUI score;
   
    void Start()
    {
        score.text = PlayerInfo.best_score_song1.ToString();
    }

}
