﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Photon.Pun;

public class PlaceableItem : PickedUpItems, IPointerClickHandler
{
    public Vector2Int index;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("click a placeable item");
        //find local player
        PlayerComponent m_player = GameManagerForNetwork.Instance.LocalPlayer.GetComponent<PlayerComponent>();

        PickedUpItems holdedItem = m_player.GetWhatsInHand();

        //pick up a placeable item when  nothing in hands.
        if (holdedItem == null)
        {
            photonView.RPC("RpcPickUpItem", RpcTarget.AllBuffered, m_player.m_ID);
        }
    }

    [PunRPC]
    public void RpcPickUpItem(int playerID)
    {
        PlayerComponent m_player = WorldManager.Instance.getPlayer(playerID);
        m_player.PickedUp(this);
        WorldManager.Instance.clearObjectAt(index.x, index.y);
    }
}