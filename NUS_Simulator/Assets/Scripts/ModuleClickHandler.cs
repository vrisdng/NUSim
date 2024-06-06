using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class ModuleClickHandler : MonoBehaviour {
    private int clickedCount = 0;
    //[SerializeField] private GameObject progressBarPrefab; // Reference to the ProgressBar prefab
    //[SerializeField] private Transform progressBarParent;  // Parent transform to hold ProgressBars in UI
    [SerializeField] private ModuleData moduleData;        // Reference to the ModuleData ScriptableObject

    public void ClickOnModule() {
        if (clickedCount < 5) {
            Button clickedButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
            string clickedButtonModule = EventSystem.current.currentSelectedGameObject.name;
            clickedButton.interactable = false;

            Debug.Log("Button Clicked: " + clickedButtonModule);

            Module newModule = null;
            // Create new module
            switch (clickedButtonModule) {
                case "CS1101S":
                    newModule = new Module("CS1101S", 5, 1f);
                    break;
                case "CS2030S":
                    newModule = new Module("CS2030S", 5, 0.8f);
                    break;
                case "CS2030":
                    newModule = new Module("CS2030", 5, 0.8f);
                    break;
                case "CS2040":
                    newModule = new Module("CS2040", 5, 0.8f);
                    break;
                case "CS2040S":
                    newModule = new Module("CS2040S", 5, 0.8f);
                    break;
                case "CS1010":
                    newModule = new Module("CS1010", 5, 1f);
                    break;
                case "CS2001":
                    newModule = new Module("CS2001", 5, 0.8f);
                    break;
                case "CS2002":
                    newModule = new Module("CS2002", 5, 0.8f);
                    break;
                case "CS2003":
                    newModule = new Module("CS2003", 5, 0.8f);
                    break;
                default:
                    Debug.Log("Invalid module button clicked.");
                    break;
            }

            // Store the module in the ModuleData ScriptableObject
            moduleData.SetModule(clickedCount, newModule);
            Debug.Log("Module " + (clickedCount + 1) + " created: " + newModule.GetModuleName());
            clickedCount++;
        } else {
            Debug.Log("Maximum of 5 modules have already been created.");
            //TODO: Add a button to proceed to the next scene
            SceneManager.LoadScene("WorkingScene");
        }
    }
}
