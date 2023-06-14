﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
	[SerializeField] public Slider slider;
	[SerializeField] public Image fill;

	public void SetMaxHealth(float health)
	{
		slider.maxValue = health;
		slider.value = health;
	}

    public void SetHealth(float health)
	{
		slider.value = health;
	}

}