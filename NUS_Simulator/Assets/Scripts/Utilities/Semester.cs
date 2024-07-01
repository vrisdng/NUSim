using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
public class Semester {
    private string name;                 
    private List<Module> selectedModules;
    private Boolean isCompleted;

    public Semester(string semesterName) {
        this.name = semesterName;
        this.selectedModules = new List<Module>();
        this.isCompleted = false;
    }

    public Boolean IsCompleted() {
        return this.isCompleted;
    }

    public void SetCompleted(Boolean boolian) {
        this.isCompleted = boolian;
    }

    public string GetName() {
        return this.name;
    }

    public List<Module> GetSelectedModules() {
        return this.selectedModules;
    }

}
