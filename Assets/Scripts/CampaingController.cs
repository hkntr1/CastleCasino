using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CampaingController : MonoBehaviour
{
    public List<Button> Levels;
    void Start()
    {
        int countOfLevels=PlayerPrefs.GetInt("level",1);
        for (int i = 0; i < countOfLevels; i++)
        {
            Levels[i].interactable = true;
        }
    }

   
}
