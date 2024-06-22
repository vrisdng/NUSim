using System.Collections;
using System.Collections.Generic;
public class Semester {
    public string name;                 
    public Module[] availableModules;  
    public Module[] selectedModules;   

    public Semester(string semesterName, Module[] modules) {
        name = semesterName;
        availableModules = modules;
        selectedModules = new Module[5];  
    }
}
