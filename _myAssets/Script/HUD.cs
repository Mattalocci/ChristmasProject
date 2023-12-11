using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour {

    public Image lifepointValue;
    public CanvasGroup effectPanel;



    /*****************************************/

    /*****************************************/


    public void UpdateLifepoint (float current_value, float max_value) {
        lifepointValue.fillAmount = current_value / max_value;
    }


}
