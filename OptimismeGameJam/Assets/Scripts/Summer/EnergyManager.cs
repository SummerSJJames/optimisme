using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyManager : MonoBehaviour
{
    float timer;

    [SerializeField] float maxEnergy;
    [SerializeField] Image energyBar;

    private void Start()
    {
        timer = maxEnergy;
    }

    private void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        else Debug.Log("Game over");

        EnergyFiller();
    }

    public void EnergyFiller()
    {
        energyBar.fillAmount = timer / maxEnergy;
    }
    public void LoseEnergy()
    {

    }

    public void GainEnergy()
    {

    }

}
