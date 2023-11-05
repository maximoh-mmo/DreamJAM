using UnityEngine;
using System.Collections;
public class Teleporter : MonoBehaviour
{
    [SerializeField]GameObject _PortalExit;
    GameObject _collided;
    bool isReady = true;
    float cooldown = 1f;
    public bool IsReady { set { isReady = value; } }
    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log(coll.gameObject.name);
        _collided = coll.gameObject;
        if (_collided.tag == "Player")
        {
            Debug.Log("player Detected!!!");
            if (isReady) {
                doCooldown();
                _PortalExit.GetComponent<Teleporter>().IsReady = false;
                _PortalExit.GetComponent<Teleporter>().doCooldown();
                GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
                coll.transform.position = new Vector3(_PortalExit.transform.position.x, _PortalExit.transform.position.y, 0);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
    public void doCooldown()
    {
        StartCoroutine(Cooldown());
    }
    IEnumerator Cooldown()
    {
        Debug.Log("Teleported");
        yield return new WaitForSeconds(cooldown);
        isReady = true;
        Debug.Log("IsReady = " + isReady);
    }
}
