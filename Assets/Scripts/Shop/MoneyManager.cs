using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;

    [SerializeField]
    private TextMeshProUGUI text;

    private int cash;

    private void Awake()
    {
        if (instance)
        {
            Destroy(instance);
        }

        instance = this;
    }

    void Start()
    {
        cash = PlayerPrefs.GetInt("Cash", 30);

        text.text = cash.ToString();
    }

    public int GetCash()
    {
        return cash;
    }

    public void SetCash(int amount)
    {
        cash += amount;

        text.text = cash.ToString();
    }
}
