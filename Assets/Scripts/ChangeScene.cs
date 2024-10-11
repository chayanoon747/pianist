using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void changeToStage1()
    {
        PlayerInfo.stage = 1;
        SceneManager.LoadScene("StageScene");
    }
    public void changeToStage2()
    {
        PlayerInfo.stage = 2;
        SceneManager.LoadScene("StageScene");
    }
    public void changeToEnd()
    {
        SceneManager.LoadScene("EndScene");
    }
    public void changeToLobby()
    {
        SceneManager.LoadScene("LobbyScene");
    }
}
