using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

// For ModuleSelectScene
public class ModuleClickHandler : MonoBehaviour {
    private int clickedCount = 0;
    //[SerializeField] private GameObject progressBarPrefab; // Reference to the ProgressBar prefab
    //[SerializeField] private Transform progressBarParent;  // Parent transform to hold ProgressBars in UI
    [SerializeField] public ModuleData moduleData;        // Reference to the ModuleData ScriptableObject

    public void ClickOnModule() {
        if (clickedCount < 5) {
            Button clickedButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
            string clickedButtonModuleName = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text; 
            clickedButton.interactable = false;

            Debug.Log("Button Clicked: " + clickedButtonModuleName);

            Module newModule = null;
            // Create new module
            switch (clickedButtonModuleName) {
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
                case "MA1521":
                    newModule = new Module("MA1521", 5, 0.8f);
                    break;
                case "MA1522":
                    newModule = new Module("MA1522", 5, 0.8f);
                    break;
                case "GEA1000":
                    newModule = new Module("GEA1000", 5, 0.8f);
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
            //SceneManager.LoadScene("WorkingScene");
        }
    }
}
