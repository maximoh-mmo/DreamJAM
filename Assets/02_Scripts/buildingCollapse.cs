using UnityEngine;

public class BuildingCollapse : MonoBehaviour
{
    bool hulkMode = false;
    bool doRotate = false;
    public bool HulkMode { set {  hulkMode = value; } }

    private void Update()
    {
        if (doRotate == true && transform.rotation.z >= -65)
        {
                this.transform.Rotate(Vector3.back, 40 * Time.deltaTime);
        }
    }

    public void HulkSmash()
    {
        if (hulkMode == true)
        {   // z rotation == -65
            Debug.Log("may smash");
            doRotate = true;
        }
    }
}
