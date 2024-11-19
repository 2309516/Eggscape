using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 offset;
    private bool isDragging = false;
    private Rigidbody rb;
    public float dragStrength = 1.5f;
    public float moveSpeed = 5f;
    public LayerMask draggableLayer;
    public LayerMask collisionLayer;
    private Transform player;
    private Vector3 initialObjectPosition;
    private float objectDistanceFromCamera;
    public float moveVerticalAmount = 0.1f; 
    [Range(1f, 1000f)]
    public float dragSpeed =300f;
    [Range(1f, 1000f)]
    public float moveSpeedSlider = 100f;

    private void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
        player = Camera.main.transform;
    }

    private void OnMouseDown()
    {
        if (mainCamera != null)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, draggableLayer))
            {
                if (hit.collider == GetComponent<Collider>())
                {
                    offset = transform.position - hit.point;
                    isDragging = true;
                    objectDistanceFromCamera = Vector3.Distance(transform.position, player.position);

                    if (rb != null)
                    {
                        rb.useGravity = false;
                        rb.isKinematic = false;
                        rb.constraints = RigidbodyConstraints.FreezeRotation;
                    }
                }
            }
        }
    }

    private void OnMouseDrag()
    {
        if (isDragging && mainCamera != null)
        {
            Vector3 cameraForward = mainCamera.transform.forward;
            Vector3 targetPosition = player.position + cameraForward * objectDistanceFromCamera;
            targetPosition.y = transform.position.y;

            if (rb != null)
            {               
                Vector3 direction = targetPosition - transform.position;
                Vector3 velocity = direction.normalized * dragSpeed * Time.deltaTime;                
                rb.velocity = velocity;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, targetPosition, dragSpeed * Time.deltaTime);
            }
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;

        if (rb != null)
        {
            rb.useGravity = true;
            rb.constraints = RigidbodyConstraints.None;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            MoveObjectVertically(moveVerticalAmount);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            MoveObjectVertically(-moveVerticalAmount);
        }
    }

    private void MoveObjectVertically(float verticalMovement)
    {
        if (rb != null)
        {
            Vector3 verticalMove = new Vector3(0f, verticalMovement, 0f);
            rb.MovePosition(transform.position + verticalMove);
        }
        else
        {
            transform.position += new Vector3(0f, verticalMovement, 0f);
        }
    }
}
