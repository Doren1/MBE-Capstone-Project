using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToSongSelect : MonoBehaviour
{
    // 노래 선택 화면 
    public void SceneChange()
    {
        SceneManager.LoadScene("SongSelect");
    }
}
