using UnityEngine;

public class BuildingCollapse : MonoBehaviour
{
    bool hulkMode = false;
    public bool HulkMode { set {  hulkMode = value; } }
    public void HulkSmash()
    {
        if (hulkMode == true)
        {
            Debug.Log("may smash");
        }
    }
}
