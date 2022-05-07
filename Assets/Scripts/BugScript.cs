using UnityEngine;
using UnityEngine.Events;

public class BugScript : MonoBehaviour
{
    public GameObject player;
    public CharacterController controller;
    public float movementSpeed = 2.5f;
    public int bugId = 1;
    public int value = 0;

    private UnityEvent<int, int> bugCaught = new UnityEvent<int, int>();

    private void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        controller.Move(direction.normalized * Time.deltaTime * -movementSpeed);
    }

    public void Catch()
    {
        bugCaught.Invoke(bugId, value);
        Destroy(gameObject);
    }
}