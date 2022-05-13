using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [Header("Volume Settings")]
    public TMP_Text volumeText = null;
    public Slider volumeSlider = null;

    private float defaultVolume = 1f;

    [Header("Graphic Settings")]
    public TMP_Text brightnessText = null;
    public Slider brightnessSlider = null;

    private float defaultBright = 1;
    private bool isFullscreen;
    private float brightnessLevel;

    [Header("Toggle Settings")]
    public Toggle fullscreenToggle = null;

    [Header("Confirmation Pop-up")]
    public GameObject confirmationPop = null;

    [Header("Put the new game scene string here")]
    public string newGame;

    public void NewGameYes()
    {
        SceneManager.LoadScene(newGame);
    }

    /*Bonus si on a le temps: ajout de scene pour d'autres niveaux

    public void VolcanoSelect() { }
    public void IcebergSelect() { }
*/

    public void ExitBtn()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeText.text = volume.ToString("0.0");
    }

    public void VolumeApply()
    {
        //PlayerPrefs pour sauvegarder les settings
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(ConfirmationBox());
    }

    public void SetBrightness(float bright)
    {
        brightnessLevel = bright;
        brightnessText.text = bright.ToString("0.0");
        //Screen.brightness = brightnessLevel; -> marche seulement sur iOS malheureusement
    }

    public void SetFullscreen(bool isFullScrn)
    {
        isFullscreen = isFullScrn;
    }

    public void GraphicApply()
    {
        PlayerPrefs.SetFloat("masterBrightness", brightnessLevel);
        PlayerPrefs.SetInt("masterFullscreen", isFullscreen ? 1 : 0);
        Screen.fullScreen = isFullscreen;
        StartCoroutine(ConfirmationBox());
    }

    public void ResetBtn(string MenuType)
    {
        if (MenuType == "Audio")
        {
            AudioListener.volume = defaultVolume;
            volumeSlider.value = defaultVolume;
            volumeText.text = defaultVolume.ToString("0.0");
            VolumeApply();
        }

        if (MenuType == "Graphic")
        {
            brightnessText.text = defaultBright.ToString("0.0");
            brightnessSlider.value = defaultBright;
            fullscreenToggle.isOn = false;
            Screen.fullScreen = false;
            GraphicApply();
        }
    }

    //Pour faire attendre + saving logo
    public IEnumerator ConfirmationBox()
    {
        confirmationPop.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        confirmationPop.SetActive(false);
    }
}
