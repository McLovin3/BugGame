using UnityEngine;
using UnityEngine.Events;

public class BugScript : MonoBehaviour
{
    public CharacterController controller;
    public float movementSpeed = 2.5f;
    public float moveWhenDistance = 10f;
    public float gravity = 9.81f;
    public int bugId = 1;
    public int value = 0;

    public UnityEvent<int, int> onBugCaught;
    private GameObject player;
    public EventsManager eventsManager;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= moveWhenDistance)
        {
            Vector3 direction = player.transform.position - transform.position;
            direction.y -= 0;
            controller.Move(direction.normalized * Time.deltaTime * -movementSpeed);
        }
    }

    public void Catch()
    {
        onBugCaught.Invoke(bugId, value);
        Destroy(gameObject);
    }
}