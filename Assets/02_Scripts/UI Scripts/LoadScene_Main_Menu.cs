using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene_Main_Menu : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("TitleScreen");
    }

}
