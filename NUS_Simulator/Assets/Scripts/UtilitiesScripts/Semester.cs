using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
public class Semester {
    public string name;                 
    public List<Module> selectedModules;

    public Semester(string semesterName) {
        this.name = semesterName;
        this.selectedModules = new List<Module>();
    }

}
