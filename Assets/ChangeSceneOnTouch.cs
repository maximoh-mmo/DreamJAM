using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnTouch : MonoBehaviour
{
    public string sceneToLoad; // The name of the scene to load when the player touches the portal.

    private bool isPlayerTouchingPortal = false;

    private void Update()
    {
        // Check if the player is touching the portal and the player presses a button (e.g., 'E') to trigger the scene change.
        if (isPlayerTouchingPortal && Input.GetKeyDown(KeyCode.E))
        {
            ChangeScene();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player (or another GameObject with a collider) has touched the portal.
        if (other.CompareTag("Character"))
        {
            isPlayerTouchingPortal = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Reset the player touching flag when the player leaves the portal.
        if (other.CompareTag("Character"))
        {
            isPlayerTouchingPortal = false;
        }
    }

    private void ChangeScene()
    {
        // Load the specified scene.
        SceneManager.LoadScene("Beach Level");
    }
}