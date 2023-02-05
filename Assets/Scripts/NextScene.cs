using System.Collections;

using UnityEngine;
// add this line to use the SceneManagment library
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{

    [SerializeField] private string loadLevel;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(loadLevel);
        }
    }
}