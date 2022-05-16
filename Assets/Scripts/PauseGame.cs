using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject ExplorerBagMenu;
    private bool isPaused = false;

    void Start()
    {
        Cursor.visible = false;
    }


    void Update()
    {
        toPause();
    }

    void toPause()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Cursor.visible = !Cursor.visible;
            if (!isPaused)
            {
                //Pause
                Time.timeScale = 0f;
                SoundManager.current.PlaySFX(SoundManager.current.openMenuSfx);
                ExplorerBagMenu.SetActive(true);
                isPaused = true;
            }
            else
            {
                //Resume
                SoundManager.current.PlaySFX(SoundManager.current.closeMenuSfx);
                ExplorerBagMenu.SetActive(false);
                Time.timeScale = 1f;
                isPaused = false;
            }
        }
    }
}
