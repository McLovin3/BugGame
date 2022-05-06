using UnityEngine;

public class Moveable : MonoBehaviour
{
    public GameObject commonBug;
    public GameObject rareBug;
    public GameObject legendaryBug;
    public Animation moveAnimation;
    public float secondsToReset = 120f;

    private Vector3 initPosition;
    private bool moved = false;

    void Start()
    {
        initPosition = transform.position;
    }

    public void Move()
    {
        if (!moved)
        {
            moved = true;
            float randomiser = Random.Range(0f, 1f);

            if (randomiser > 0.25f)
            {
                Instantiate(commonBug, transform.position, Quaternion.identity);

            }
            else if (randomiser > 0.75f)
            {
                Instantiate(rareBug, transform.position, Quaternion.identity);

            }
            else if (randomiser > 0.90f)
            {
                Instantiate(legendaryBug, transform.position, Quaternion.identity);
            }

            moveAnimation.Play();
            Invoke("ResetMovement", secondsToReset);
        }
    }

    private void ResetMovement()
    {
        transform.position = initPosition;
        moved = false;
    }
}
