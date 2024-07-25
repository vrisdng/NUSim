using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Image soundOnIcon;
    [SerializeField] private Image soundOffIcon;
    private bool muted = false;
    
    void Start()
    {
        if (PlayerPrefs.HasKey("Muted"))
        {
            Load();
        }
        else
        {
            PlayerPrefs.SetInt("Muted", 0);
            Save();
        }

        UpdateIcon();
        AudioListener.pause = muted;
    }

    public void OnClick()
    {
        muted = !muted;
        AudioListener.pause = muted;
        Save();
        UpdateIcon();
    }

    private void UpdateIcon()
    {
        if (muted)
        {
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;
        }
        else
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("Muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("Muted", muted ? 1 : 0);
    }
}
