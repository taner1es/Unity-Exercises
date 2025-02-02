﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterStats))]
public class HealthUI : MonoBehaviour
{
    public GameObject uiPrefab;
    public Transform target;

    Transform ui;
    Image healthSlider;
    Transform cam;

    float visibleTime = 5f;
    float lastMadeVisibleTime;

    private void Start()
    {
        cam = Camera.main.transform;

        foreach(Canvas c in FindObjectsOfType<Canvas>())
        {
            if(c.renderMode == RenderMode.WorldSpace)
            {
                ui = Instantiate(uiPrefab, c.transform).transform;
                healthSlider = ui.GetChild(0).GetComponent<Image>();
                ui.gameObject.SetActive(false);
                break;
            }
        }

        GetComponent<CharacterStats>().OnHealthChanged += OnHealthChanged;
    }

    private void LateUpdate()
    {
        if (ui == null)
            return;

        ui.position = target.position;
        ui.forward = -cam.forward;

        if(Time.time - lastMadeVisibleTime >= visibleTime)
        {
            ui.gameObject.SetActive(false);
        }
    }

    void OnHealthChanged(int maxHealth, int currentHealht)
    {
        if (ui == null)
            return;

        ui.gameObject.SetActive(true);
        lastMadeVisibleTime = Time.time;

        float healthPercent = currentHealht / (float)maxHealth;
        healthSlider.fillAmount = healthPercent;
        if(currentHealht <= 0)
        {
            Destroy(ui.gameObject);
        }
    }
}
