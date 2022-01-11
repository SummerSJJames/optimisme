using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyManager : MonoBehaviour
{
    float timer;

    [SerializeField] float maxEnergy;
    [SerializeField] Image energyBar;

    [SerializeField]GameObject levelManager;
    LevelLoader levelLoader;
    
    int dead;

    private void Start()
    {
        dead = 0;
        levelLoader = levelManager.GetComponent<LevelLoader>();
        timer = maxEnergy;
    }

    private void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        else if (dead <= 0) 
            dead++;
        if (dead == 1)
            StartCoroutine(LevelLoader.LoadLevel(1));
        EnergyFiller();
    }

    public void EnergyFiller()
    {
        energyBar.fillAmount = timer / maxEnergy;
    }

    public void ResetTimer()
    {
        timer = maxEnergy;
    }
}
