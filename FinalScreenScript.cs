using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalScreenScript : MonoBehaviour
{
    public GameObject TimerText;
    // Start is called before the first frame update
    void Start()
    {
        TimerText.GetComponent<TextMeshProUGUI>().SetText($"{GameManager.FinalTime.ToString("F1")}s");
    }
}
