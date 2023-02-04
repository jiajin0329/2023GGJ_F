using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueFillAmount : ValueUI {
    [SerializeField] Image image;

    void Awake() {
        if(values != null) {
            values.StartEvent.AddListener(Refresh);
            values.ChangeEvent.AddListener(Refresh);
        }
    }

    void Refresh() {
        if(values.current != 0)
            image.fillAmount = values.current / (float)values.max;
        else
            image.fillAmount = 0f;
    }
}