using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchiveManager : MonoBehaviour
{
    public GameObject[] lockCharacter;
    public GameObject[] unlockCharacter;

    enum Achive { UnlockDad, UnlockMom }
    Achive[] achives;

    private void Awake()
    {
        achives =(Achive[])Enum.GetValues(typeof(Achive));

        if (!PlayerPrefs.HasKey("MyData")) Init();
        
    }
    void Init()
    {
        PlayerPrefs.SetInt("MyData", 1);

        foreach (Achive achive in achives)
        {
            PlayerPrefs.SetInt(achive.ToString(), 1);
        }
        
    }

    void Start()
    {
        UnlockCharacter();
    }

    void UnlockCharacter()
    {
        for (int i = 0; i < lockCharacter.Length; i++)
        {
            string achivename = achives[i].ToString();
            bool isUnlock = PlayerPrefs.GetInt(achivename) == 1;
            lockCharacter[i].SetActive(!isUnlock);
            unlockCharacter[i].SetActive(isUnlock);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
