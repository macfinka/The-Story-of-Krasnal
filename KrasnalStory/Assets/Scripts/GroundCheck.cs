using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public int floorCount { get; private set; }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Floor"))
        {
            floorCount++;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Floor"))
        {
            floorCount--;
        }
    }

    public bool IsGrounded()
    {
        if (floorCount > 0)
        {
            return true;
        }
        return false;
    }
}
