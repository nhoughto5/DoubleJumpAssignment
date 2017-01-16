using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
 * This class sets the content fill percentage
 * for the health bar.
 * */
public class HealthBar : MonoBehaviour {

    [SerializeField]
    private Image content;

    public void setFillAmount(float fillAm)
    {
        content.fillAmount = fillAm;
    }
}
