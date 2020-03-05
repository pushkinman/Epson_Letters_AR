﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int numberOfPlayers;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one GameManager in scene");
        }
        else
        {
            instance = this;
        }
        numberOfPlayers = 0;
    }

    #region Player tracking

    private const string PLAYER_ID_PREFIX = "Player ";

    public static Dictionary<string, Player> players = new Dictionary<string, Player>();
    public static List<Player> playersList = new List<Player>();

    public static void RegisterPlayer(string _netID, Player _player)
    {
        string _playerID = PLAYER_ID_PREFIX + _netID;
        players.Add(_playerID, _player);
        _player.transform.name = _playerID;
        playersList.Add(_player);
    }

    public static void UnRegisterPlayer(string _playerID)
    {
        players.Remove(_playerID);
    }

    public static Player GetPlayer(string _plauerID)
    {
        return players[_plauerID];
    }

    //private void OnGUI()
    //{
    //    GUILayout.BeginArea(new Rect(200, 200, 200, 500));

    //    GUILayout.BeginVertical();

    //    foreach(string _playerID in players.Keys)
    //    {
    //        GUILayout.Label(_playerID + " - " + players[_playerID].transform.name);
    //    }

    //    GUILayout.EndVertical();
    //    GUILayout.EndArea();

    //}

    private void Update()
    {
        Debug.Log(players.Count);
    }

    #endregion


}
