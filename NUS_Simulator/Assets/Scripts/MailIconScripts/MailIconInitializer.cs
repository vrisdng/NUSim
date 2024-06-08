using UnityEngine;

public class MailIconInitializer : MonoBehaviour
{
    [SerializeField] private GameObject mailIconPrefab;

    void Start()
    {
        if (MailIconManager.Instance == null)
        {
            Instantiate(mailIconPrefab);
        }
        else
        {
            MailIconManager.Instance.SetMailIcon(mailIconPrefab);
        }
    }
}
