using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{
    [SerializeField] GameObject _character;
    Camera _camera;
    private void Start()
    {
        _camera = GetComponent<Camera>();
    }
    void Update()
    {
        _camera.transform.position = new Vector3(_character.transform.position.x, _camera.transform.position.y, -10);
    }
}
