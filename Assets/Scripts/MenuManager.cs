using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [Header("Volume Settings")]
    [SerializeField] private TMP_Text volumeText = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private float defaultVolume = 1f;

    [Header("Graphic Settings")]
    [SerializeField] private TMP_Text brightnessText = null;
    [SerializeField] private Slider brightnessSlider = null;
    [SerializeField] private int defaultBright = 4;
    public int mainBright = 4;

    [Header("Toggle Settings")]
    [SerializeField] private Toggle fullscreenToggle = null;

    [Header("Confirmation Pop-up")]
    [SerializeField] private GameObject confirmationPop = null;

    [Header("Put the new game scene string here")]
    public string newGame;

    public void NewGameYes()
    {
        SceneManager.LoadScene(newGame);
    }

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
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        //Confirmation Pop-up
        StartCoroutine(ConfirmationBox());
    }

    public void SetBrightness(float bright)
    {
        mainBright = Mathf.RoundToInt(bright);
        brightnessText.text = bright.ToString("0");
    }

    public void GraphicApply()
    {
        if(fullscreenToggle.isOn)
        {
            //smt
        }
        else
        {
            //smt
        }
        //SetFloat
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

        if(MenuType == "Graphic")
        {
            brightnessText.text = defaultBright.ToString("0");
            brightnessSlider.value = defaultBright;
            mainBright = defaultBright;
            fullscreenToggle.isOn = false;
            GraphicApply();
        }
    }

    public IEnumerator ConfirmationBox()
    {
        confirmationPop.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        confirmationPop.SetActive(false);
    }
}
