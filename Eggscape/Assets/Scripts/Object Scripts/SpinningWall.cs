using UnityEngine;

public class SpinObject : MonoBehaviour
{    
    [Range(0f, 500f)]
    public float rotationSpeed = 100f;
    
    void Update()
    {       
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
