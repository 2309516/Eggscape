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

    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
        player = Camera.main.transform;
    }

    void OnMouseDown()
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

    void OnMouseDrag()
    {
        if (isDragging && mainCamera != null)
        {
            Vector3 cameraForward = mainCamera.transform.forward;
            Vector3 targetPosition = player.position + cameraForward * objectDistanceFromCamera;
            targetPosition.y = transform.position.y;
            if (rb != null)
            {
                rb.MovePosition(Vector3.Lerp(rb.position, targetPosition, dragStrength * Time.deltaTime));
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, targetPosition, dragStrength * Time.deltaTime);
            }
        }
    }

    void OnMouseUp()
    {
        isDragging = false;

        if (rb != null)
        {
            rb.useGravity = true;
            rb.constraints = RigidbodyConstraints.None;
        }
    }

    void Update()
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

    void MoveObjectVertically(float verticalMovement)
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
