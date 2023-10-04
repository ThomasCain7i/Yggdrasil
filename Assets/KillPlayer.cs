using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    // Tag to identify the player GameObject
    public string playerTag = "Player";

    // Function to reload the current scene
    public void ReloadScene()
    {
        // Get the current scene's name
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Reload the current scene
        SceneManager.LoadScene(currentSceneName);
    }

    // This method is called when a collider enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag(playerTag))
        {
            // Reload the scene
            ReloadScene();
        }
    }
}
