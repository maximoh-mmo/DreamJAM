using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader3 : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("CityScene");
    }
}