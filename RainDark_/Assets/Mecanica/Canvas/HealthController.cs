using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public float health = 1;
    public float healthMax = 100;

    public Image healthBar;

    void Update(){
        UpdateHealthBar();
    }

    void UpdateHealthBar() {
        healthBar.fillAmount = health / healthMax;
    }
}
