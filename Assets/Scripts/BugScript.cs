using UnityEngine;

public class BugScript : MonoBehaviour
{
    public CharacterController controller;
    public float movementSpeed = 2.5f;
    public float moveWhenDistance = 10f;
    public float gravity = 9.81f;
    public int bugId = 1;
    public int value = 0;

    //public UnityEvent<int, int> onBugCaught;
    private GameObject player;

    private void Start()
    {
        EventsManager.current.onBugCaught += onBugCaughtRegister;
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

    private void onBugCaughtRegister(int id)
    {
        if (id == bugId)
        {
            EventsManager.current.registerBug(bugId);
            Destroy(gameObject);
        }
    }
}