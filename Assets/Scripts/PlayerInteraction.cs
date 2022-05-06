using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private bool isNearMoveable = false;
    private Moveable moveable;

    void Update()
    {
        if (isNearMoveable && Input.GetKeyDown(KeyCode.F))
        {
            moveable.Move();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Moveable"))
        {
            isNearMoveable = true;
            moveable = other.gameObject.GetComponent<Moveable>();
            Debug.Log(moveable);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Moveable"))
        {
            isNearMoveable = false;
            moveable = null;
        }
    }
}
