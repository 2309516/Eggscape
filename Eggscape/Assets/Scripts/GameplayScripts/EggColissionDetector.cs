using UnityEngine;
using UnityEngine.SceneManagement;
public class EggCollisionDetector : MonoBehaviour
{    
    public GameObject objectToDetect;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject == objectToDetect)
        {
            SceneManager.LoadScene(3);
            Debug.Log("Collision detected with the specified object: " + objectToDetect.name);

        }
    }
}
