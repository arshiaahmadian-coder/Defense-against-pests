using Unity.VisualScripting;
using UnityEngine;

public class PhysicsControl : MonoBehaviour
{
    public Rigidbody rb;
    private Player player;
    private void Start()
    {
        player = GetComponent<Player>();
    }

    public void ResetVelocity()
    {
        rb.linearVelocity = Vector2.zero;
    }
}
