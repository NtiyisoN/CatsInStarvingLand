﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Text ItemCountText;
    public Image ItemUIImage;
    public Sprite DefultImage;
    public Button DiscardButton;

    private Inventory myManager;

    // Start is called before the first frame update
    void Start()
    {
        this.myManager = FindObjectOfType<Inventory>();
        DiscardButton.onClick.AddListener(RemoveObjects);
    }

    public bool updateItem(GameResources.PickedUpItemName ItemName, int count)
    {
        if (count>0) {
            ItemCountText.text = count.ToString();
        } else {
            ItemCountText.text = "";
        }
        ItemCountText.color = Color.black;
        Debug.Log("itemCount:" + count.ToString());
        if(ItemName != GameResources.PickedUpItemName.DEFAULT)
        {
            ItemUIImage.sprite = findImageWithItemName(ItemName);
        } else
        {
            ItemUIImage.sprite = DefultImage;
        }
        
        return true;
    }

    Sprite findImageWithItemName(GameResources.PickedUpItemName ItemName)
    {
        //Resources.load();
        //Load Sprite From The Resources Folder and use

        string spriteName = "InventoryUIs/" + ItemName.ToString();
        //string spriteName = "InventoryUIs/PLANT";
        return Resources.Load<Sprite>(spriteName);
    }

    public void clickItem()
    {
        Debug.Log("clickItem");
        myManager.WhatItemAtThisIndex(getMySlotIndexID());
    }

    private int getMySlotIndexID() {
        return this.myManager.slotGetIndexID(this.GetHashCode());
    }

    public void RemoveObjects()
    {
        ////Remove obj
        //getMySlotIndexID();

        //DiscardButton.gameObject.SetActive(false);
    }

}
