﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuyQuestion : MonoBehaviour {

    private Text textName;

    private GameObject gameManager;

    public string name = null;
    public int price = -1;
    public int code = -1;

    private int money;
    private int item;

    private void Update()
    {
        textName = GetComponentInChildren <Text>();
        textName.text = name + "을(를) 구매하시겠습니까?\n" + price + "원이 소모됩니다.";
    }

    public void Buy()
    {
        gameManager = GameObject.Find("GameManager");

        var gm = gameManager.gameObject.GetComponent<GameManager>();
        money = gm.money;
        item = gm.item[code];

        if (money >= price)
        {
            money -= price;
            gm.money -= price;
            gm.item[code] += 1;
        }
        else
        {
            Debug.Log("" + gm.money + " / " + money);
        }

        enabled = false;
    }

    public void Cancle()
    {
        this.gameObject.SetActive(false);
    }
}
