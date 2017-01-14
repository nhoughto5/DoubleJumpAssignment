using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    [SerializeField]
    private Image content;

    public void setFillAmount(float fillAm)
    {
        content.fillAmount = fillAm;
    }
}
