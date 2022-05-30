using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Animator animator;
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
            animator.SetBool("isPickup", true);
            Invoke("StopPickup", 1);
            if (isNearBug)
            {
                EventsManager.current.BugCaught(bug.bugId);
                isNearBug = false;
                bug = null;
            }
        }
    }

    void StopPickup()
    {
        animator.SetBool("isPickup", false);
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
