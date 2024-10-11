using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowScore : MonoBehaviour
{
    public TextMeshProUGUI score;

    void Start()
    {
        switch(PlayerInfo.stage)
        {
            case 1:
                score.text = PlayerInfo.current_score_song1.ToString();
                if(PlayerInfo.current_score_song1 > PlayerInfo.best_score_song1)
                {
                    PlayerInfo.best_score_song1 = PlayerInfo.current_score_song1;
                }
                PlayerInfo.current_score_song1 = 0;
                break;
            case 2:
                score.text = PlayerInfo.current_score_song2.ToString();
                if(PlayerInfo.current_score_song2 > PlayerInfo.best_score_song2)
                {
                    PlayerInfo.best_score_song2 = PlayerInfo.current_score_song2;
                }
                PlayerInfo.current_score_song2 = 0;
                break;
        }
    }
}
