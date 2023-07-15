using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerCar;
    public GameObject StartPoint;
    public GameObject[] Checkpoints;
    public int NoLaps;
    public GameObject CheckpointsText;
    public GameObject LapText;
    public GameObject TimerText;

    private Dictionary<int, bool> checkpointsDriven;
    private int lapsDriven;
    private float timer;
    private bool raceStarted;
    private bool raceFinished;

    public static float FinalTime;

    // Start is called before the first frame update
    void Start()
    {
        checkpointsDriven = new Dictionary<int, bool>();
        lapsDriven = 0;
        FinalTime = 0f;
        timer = 0f;
        raceStarted = false;
        raceFinished = false;
        
        for (var i = 0; i < Checkpoints.Length; i++)
        {
            checkpointsDriven.Add(i, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!raceStarted || raceFinished) return;
        
        timer += Time.deltaTime;
        TimerUI();
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetCar();
        }
    }

    private void StartRace()
    {
        raceStarted = true;
        UpdateCheckpointsText();
        UpdateLapText();
    }

    private void UpdateCheckpointsText()
    {
        var drivenCheckpoints = checkpointsDriven.Values.Count(checkpointDriven => checkpointDriven);
        var text = "Checkpoints " + drivenCheckpoints.ToString() + "/" + Checkpoints.Length.ToString();
        
        Debug.LogWarning(text);
        CheckpointsText.GetComponent<TextMeshProUGUI>().SetText(text);
    }

    private void UpdateLapText()
    {
        var text = "Laps " + lapsDriven.ToString() + "/" + NoLaps.ToString();
        
        Debug.LogWarning(text);
        LapText.GetComponent<TextMeshProUGUI>().SetText(text);
    }

    private void StartNewLap()
    {
        for (var i = 0; i < Checkpoints.Length; i++)
        {
            checkpointsDriven[i] = false;
        }

        UpdateCheckpointsText();
        UpdateLapText();
    }

    private void FinishRace()
    {
        raceFinished = true;
        FinalTime = timer;
        SceneManager.LoadScene("Final Screen");
    }
    
    public void OnCheckpointReached(int checkpointIndex)
    {
        if (raceFinished) return;
        
        if (checkpointIndex == 0)
        {
            lapsDriven++;
            
            if (lapsDriven == 1)
            {
                StartRace();
            }   
            else if (lapsDriven > NoLaps)
            {
                FinishRace();
            }
            else
            {
                Debug.LogWarning("Starting new lap");
                StartNewLap();
            }
            
            return;
        }
        
        checkpointsDriven[checkpointIndex] = true;
        UpdateCheckpointsText();
    }

    private void TimerUI()
    {
        TimerText.GetComponent<TextMeshProUGUI>().SetText($"{timer.ToString("F1")}s");
    }

    private void ResetCar()
    {
        Debug.LogWarning("Attempting to reset car");
        for (var i = 0; i < Checkpoints.Length; i++)
        {
            if (checkpointsDriven[i]) continue;
            if (i == 0) return;
            PlayerCar.transform.position = Checkpoints[i-1].transform.position;
            PlayerCar.transform.rotation = Checkpoints[i-1].transform.rotation;
            break;
        }
    }
}
