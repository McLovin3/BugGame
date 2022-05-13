using UnityEngine;

public class BugScript : MonoBehaviour
{
    public CharacterController controller;
    public float movementSpeed = 2.5f;
    public float moveWhenDistance = 10f;
    public float gravity = 9.81f;
    public float timeToLive = 5f;
    //TODO CHANGE IDS TO INHERITANCE @OLIVIER
    public int bugId = 1;
    public int value = 0;

    private GameObject player;

    private void Start()
    {
        EventsManager.current.onBugCaught += onBugCaughtRegister;
        player = GameObject.FindGameObjectWithTag("Player");
        Invoke("DestroyBug", 5);
    }

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= moveWhenDistance)
        {
            Vector3 direction = player.transform.position - transform.position;
            //Get direction between x and y and rotates to that position
            transform.rotation = Quaternion.Euler(Vector3.up * Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg);
            controller.Move(direction.normalized * Time.deltaTime * -movementSpeed);
            controller.Move(Vector3.down * gravity * Time.deltaTime);
        }
    }

    private void onBugCaughtRegister(int id)
    {
        if (id == bugId)
        {
            EventsManager.current.registerBug(bugId);
            EventsManager.current.onBugCaught -= onBugCaughtRegister;
            Destroy(gameObject);
        }
    }

    private void DestroyBug()
    {
        EventsManager.current.onBugCaught -= onBugCaughtRegister;
        Destroy(gameObject);
    }
}