using UnityEngine;

public class BuildingCollapse : MonoBehaviour
{
    bool hulkMode = false;
    [SerializeField] bool doRotate = false;
    [SerializeField] float fallspeed = 70;
    public bool HulkMode { set {  hulkMode = value; } }

    private void Update()
    {
        if (doRotate == true)
        {
                transform.Rotate(Vector3.back, fallspeed * Time.deltaTime);
        }
        if (transform.eulerAngles.z != 0)
        {
            if (transform.eulerAngles.z < 295)
            {
                doRotate = false;
            }
        }
    }

    public void HulkSmash()
    {
        if (hulkMode == true)
        {   
            doRotate = true;
        }
    }
}
