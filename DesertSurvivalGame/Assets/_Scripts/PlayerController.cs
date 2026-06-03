using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float speed;

    private float hor;
    private float ver;

    [HideInInspector] public bool isMoving;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ReadInput();
        isMoving = hor != 0 || ver != 0;
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void ReadInput()
    {
        hor = Input.GetAxisRaw("Horizontal");
        ver = Input.GetAxisRaw("Vertical");
    }
    private void Move()
    {
        rb.linearVelocity = new Vector2(hor, ver).normalized * speed;
    }
}
