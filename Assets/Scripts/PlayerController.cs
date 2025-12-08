using UnityEngine;

public class PlayerMoveAndAnimate : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody rb;
    private Animator anim;
    private Vector3 inputDir;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
            Debug.LogError("PlayerMoveAndAnimate: No Rigidbody found on this Player.");

        // IMPORTANT: Animator is often on a child (the model), not on the root
        anim = GetComponentInChildren<Animator>();
        if (anim == null)
            Debug.LogError("PlayerMoveAndAnimate: No Animator found (check child model).");
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        inputDir = new Vector3(x, 0f, z).normalized;

        float speed = inputDir.magnitude;              // 0 when stopped, 1 when moving (for GetAxisRaw)
        bool isMoving = speed > 0.01f;                 // tiny threshold to avoid flicker

        if (anim != null)
        {
            anim.SetFloat("Speed", speed);
            anim.SetBool("IsMoving", isMoving);
        }

        if (isMoving)
            transform.rotation = Quaternion.LookRotation(inputDir);
    }

    void FixedUpdate()
    {
        if (rb == null) return;
        rb.MovePosition(rb.position + inputDir * moveSpeed * Time.fixedDeltaTime);
    }
}
