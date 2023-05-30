using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using MoreMountains.Feedbacks;
using Unity.VisualScripting;
using UnityEditor;

public class InputManager : MonoBehaviour
{
    public CardGroup Cards;
    public int currentCardIndex;
    public List<int> levelNeed;
    public int Level;
    public CardGroup cardGroupPrefab;
    public GameObject floor;
    public GameObject currentFloor;
    public MMFeedbacks mm;
    public List<GameObject> floorList;
    public List<CardGroup> cardGroups;
    public Bomb Bomb;
    public Bomb currentBomb;
    public bool isLimitless;
    float lastDistance;
    [System.Serializable]
    public class District
    {
        public List<CardGroup> districtGrids;
    }
    public List<District> district;
    #region Singleton
    public static InputManager instance;
    void Awake()
    {
        instance = this;
    }
    #endregion
    private void Update()
    {
        if (StateManager.instance.eState == StateManager.GameState.Game)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!Cards.isMove)
                {
                    Cards.FreezeGroup();
                    currentCardIndex++;
                    if (currentCardIndex == levelNeed[levelNeed.Count-1])
                    {
                        StateManager.instance.UpdateGameState(StateManager.GameState.Win);
                    }
                    else
                    {
                        Cards = ObjectPool.SharedInstance.GetPooledObjectCard();
                        district[Level].districtGrids.Add(Cards);
                        if (currentCardIndex == levelNeed[Level])
                        {
                            if (isLimitless)
                            {
                                if (PlayerPrefs.GetInt("HIGH") <= Level)
                                {
                                    PlayerPrefs.SetInt("HIGH", Level);
                                }
                                if (Level == 2)
                                {
                                  currentBomb = Instantiate(Bomb, currentFloor.transform.position + Vector3.up, Quaternion.identity);
                                }
                                LimitlessController.onScoreUp?.Invoke();

                            }
                            Level++;
                            if (Level >= 3)
                            {
                                for (int i = 0; i < district[Level - 2].districtGrids.Count; i++)
                                {
                                    district[Level - 3].districtGrids[i].MakeKinematic();
                                }

                            }
                            currentFloor = ObjectPool.SharedInstance.GetPooledObject();
                            if (floorList.Count >= 2)
                            {
                                lastDistance = floorList[floorList.Count - 1].transform.position.y - floorList[floorList.Count - 2].transform.position.y;
                                currentFloor.transform.position = floorList[floorList.Count - 1].transform.position + Vector3.up * (lastDistance + 0.6f);
                            }
                            else
                            {
                                currentFloor.transform.position = Vector3.up * 1f;
                            }
                            floorList.Add(currentFloor);
                            currentFloor.transform.DOScale(new Vector3(0.285f, 2.45f, 0.055f), 0.4f).SetEase(Ease.InOutBack);
                            CameraController.onFloorUp?.Invoke();
                        }
                    }
                }
                else
                {
                    Cards.Stop();
                    Cards.Rotate();
                }
            }
        }
        
    }
}
