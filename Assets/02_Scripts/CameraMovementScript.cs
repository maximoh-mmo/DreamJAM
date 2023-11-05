using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovementScript : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    [SerializeField] GameObject _character;
    Camera _camera;
    private void Start()
    {
        _camera = GetComponent<Camera>();
    }
    void Update()
    {
        _camera.transform.position = new Vector3(_character.transform.position.x, _character.transform.position.y, -15);
    }


}


