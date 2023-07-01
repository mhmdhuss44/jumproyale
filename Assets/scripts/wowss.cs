using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("one"))
        {
            Debug.Log("Hey");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("one"))
        {
            Debug.Log("Exiting collision with object tagged 'one'");
        }
    }
}
