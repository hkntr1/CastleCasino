using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    public List<CardGroup> pooledObjectsCards;
    public CardGroup cardsToPool;
    public int amountCardToPool;
    private void Awake()
    {
        SharedInstance = this;
    }
    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.transform.SetParent(transform);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
        pooledObjectsCards = new List<CardGroup>();
        CardGroup crd;
        for (int i = 0; i < amountCardToPool; i++)
        {
            crd = Instantiate(cardsToPool);
            crd.transform.SetParent(transform);
            crd.gameObject.SetActive(false);
            pooledObjectsCards.Add(crd);
        }
    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                pooledObjects[i].SetActive(true);
                return pooledObjects[i];
            }
        }
        return null;
    }
    public CardGroup GetPooledObjectCard()
    {
        for (int i = 0; i < amountCardToPool; i++)
        {
            if (!pooledObjectsCards[i].gameObject.activeInHierarchy)
            {
                StartCoroutine(DelayToCard(pooledObjectsCards[i].gameObject));
                return pooledObjectsCards[i];
            }
        }
        return null;
    }
    IEnumerator DelayToCard(GameObject card)
    {
        yield return new WaitForSeconds(.3f);
        card.SetActive(true);
    }
}