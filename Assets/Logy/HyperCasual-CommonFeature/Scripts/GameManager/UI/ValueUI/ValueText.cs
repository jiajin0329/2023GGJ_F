using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ValueText : ValueUI {
    [SerializeField] TMP_Text Text;
    [SerializeField] string beginningString;
    
    void Awake() {
        if(values != null) {
            values.StartEvent.AddListener(Refresh);
            values.ChangeEvent.AddListener(Refresh);
        }
    }

    public void Refresh(string set) {
        Text.text = set;
    }

    void Refresh() {
        Text.text = beginningString + values.current.ToString();
    }
}