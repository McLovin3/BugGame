using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private bool isNearMoveable = false;
    private Moveable moveable;

    private bool isNearBug = false;
    private BugScript bug;

    void Update()
    {
        if (isNearMoveable && Input.GetKeyDown(KeyCode.F))
        {
            moveable.Move();
        }

        if (Input.GetMouseButtonDown(0))
        {
            //player animation
            if (isNearBug)
            {
                bug.Catch();
                isNearBug = false;
                bug = null;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Moveable"))
        {
            isNearMoveable = true;
            moveable = other.gameObject.GetComponent<Moveable>();
        }

        else if (other.CompareTag("Bug"))
        {
            isNearBug = true;
            bug = other.gameObject.GetComponent<BugScript>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Moveable"))
        {
            isNearMoveable = false;
            moveable = null;
        }

        else if (other.CompareTag("Bug"))
        {
            isNearBug = false;
            bug = null;
        }
    }
}
