using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
public class CardGroup : MonoBehaviour
{
    public List<Card> Cards;
    public bool isMove;
    public float moveSpeed = 2f;
    private void Start()
    {
        moveSpeed = 0.5f + (InputManager.instance.Level / 200f);
        transform.DOMove(new Vector3(-1, (InputManager.instance.currentFloor.transform.position.y) + 0.5f, 0), 0f);
        transform.DOMoveX(1, 1 / moveSpeed).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo).SetId("Yoyo");
        isMove = true;
    }
    public void Stop()
    {
        Vector3 pos = transform.position;
        DOTween.Kill("Yoyo",false);
        transform.position = pos;
        Debug.Log(pos);
        isMove = false;
    }
    public void FreezeGroup()
    {
        for (int i = 0; i < Cards.Count; i++)
        {
            Cards[i].Freeze();
        }
    }
    public void Rotate()
    {   
        for (int i = 0; i < Cards.Count; i++)
        {
            Cards[i].Rotate();
        }
    }
    public void MakeKinematic()
    {
        for (int i = 0; i < Cards.Count; i++)
        {
            Cards[i].MakeKinematic();
        }
    }
}
