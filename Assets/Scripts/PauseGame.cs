using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject ExplorerBagMenu;
    private bool isPaused = false;

    void Update()
    {
        toPause();
    }

    void toPause()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!isPaused)
            {
                //Pause
                Time.timeScale = 0f;
                ExplorerBagMenu.SetActive(true);
                isPaused = true;
            }
            else
            {
                //Resume
                ExplorerBagMenu.SetActive(false);
                Time.timeScale = 1f;
                isPaused = false;
            }
        }
    }
}
