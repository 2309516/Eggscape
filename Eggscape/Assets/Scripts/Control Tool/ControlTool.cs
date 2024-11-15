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
                    /*if(gameObject.transform.parent != player.transform)
                    {
                        gameObject.transform.parent = player.transform;
                    }*/

                    if (rb != null)
                    {

                        rb.useGravity = false;
                        rb.isKinematic = false;
                        rb.constraints = RigidbodyConstraints.FreezeRotation;
                        //rb.constraints = RigidbodyConstraints.FreezePosition;
                    }
                }
            }
        }
    }

    void OnMouseDrag()
    {
        if (isDragging && mainCamera != null)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, draggableLayer))
            {
                if (hit.collider == GetComponent<Collider>())
                {
                    Vector3 targetPosition = hit.point + offset;
                    targetPosition.z = transform.position.z;

                    if (rb != null)
                    {
                        Collider[] colliders = Physics.OverlapSphere(targetPosition, 0.5f, collisionLayer);

                        if (colliders.Length == 0)
                        {
                            rb.MovePosition(Vector3.Lerp(rb.position, targetPosition, dragStrength * Time.deltaTime));
                        }
                        else
                        {
                            Vector3 closestPoint = hit.collider.ClosestPointOnBounds(targetPosition);
                            rb.MovePosition(closestPoint);
                        }
                    }
                    else
                    {
                        transform.position = Vector3.Lerp(transform.position, targetPosition, dragStrength * Time.deltaTime);
                    }
                }
            }
        }
    }

    void OnMouseUp()
    {
        isDragging = false;

        /*if(gameObject.transform.parent != null)
        {
            gameObject.transform.parent = null;
        }*/
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
            MoveObjectAwayFromPlayer();
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            MoveObjectTowardsPlayer();
        }
    }

    void MoveObjectAwayFromPlayer()
    {
        if (rb != null)
        {
            Vector3 direction = (transform.position - player.position).normalized;
            Vector3 targetPosition = transform.position + direction * moveSpeed * Time.deltaTime;
            Collider[] colliders = Physics.OverlapSphere(targetPosition, 0.5f, collisionLayer);

            if (colliders.Length == 0)
            {
                rb.MovePosition(targetPosition);
            }
            else
            {
                Vector3 closestPoint = colliders[0].ClosestPointOnBounds(targetPosition);
                rb.MovePosition(closestPoint);
            }
        }
    }

    void MoveObjectTowardsPlayer()
    {
        if (rb != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            Vector3 targetPosition = transform.position + direction * moveSpeed * Time.deltaTime;
            Collider[] colliders = Physics.OverlapSphere(targetPosition, 0.5f, collisionLayer);

            if (colliders.Length == 0)
            {
                rb.MovePosition(targetPosition);
            }
            else
            {
                Vector3 closestPoint = colliders[0].ClosestPointOnBounds(targetPosition);
                rb.MovePosition(closestPoint);
            }
        }
    }
}
