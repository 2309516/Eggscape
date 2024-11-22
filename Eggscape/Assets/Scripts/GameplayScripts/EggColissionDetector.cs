using UnityEngine;

public class EggCollisionDetector : MonoBehaviour
{    
    public GameObject objectToDetect;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject == objectToDetect)
        {
            Debug.Log("Collision detected with the specified object: " + objectToDetect.name);

        }
    }
}
