using UnityEngine;
using System.Collections;

public class MailIconManager : MonoBehaviour
{
    public static MailIconManager Instance { get; private set; }

    [SerializeField] private GameObject mailIcon;
    private float _MAIL_INTERVAL = 2f; // Example interval

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Ensure this object persists across scenes
        }
    }

    private void Start()
    {
        mailIcon.SetActive(false);
        StartCoroutine(ToggleMailIcon());
    }

    private IEnumerator ToggleMailIcon()
    {
        while (true)
        {
            yield return new WaitForSeconds(_MAIL_INTERVAL);
            if (mailIcon != null)
            {
                mailIcon.SetActive(true);
            }
            yield return new WaitForSeconds(_MAIL_INTERVAL);
            if (mailIcon != null)
            {
                mailIcon.SetActive(false);
            }
        }
    }

    public void SetMailIcon(GameObject newMailIcon)
    {
        mailIcon = newMailIcon;
    }
}
