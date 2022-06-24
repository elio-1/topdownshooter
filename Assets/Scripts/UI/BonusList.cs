using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusList : MonoBehaviour
{

    public List<Bonus> bonusList = new List<Bonus>();
    public static List<GameObject> bonusGameObjectList = new List<GameObject>();
    [SerializeField] GameObject _bonusPrefab;
    public int counter = 0;
    private void Awake()
    {
        InstantiateAllBonuses();
        Display3RandomBonuses();
        counter = 0;
    }


    public void InstantiateAllBonuses()
    {
        foreach ( Bonus bonus in bonusList)
        {
           GameObject element =  Instantiate(_bonusPrefab);
            element.transform.SetParent(transform);
            element.GetComponent<IBonus>().InitializeBonus(bonus);
            bonusGameObjectList.Add(element);
            element.SetActive(false);
        }
    }
    public void Display3RandomBonuses()
    {



        int rdm = Random.Range(0, bonusGameObjectList.Count +1);
        int rdm2 = Random.Range(0, bonusGameObjectList.Count + 1 );
        int rdm3 = Random.Range(0, bonusGameObjectList.Count + 1 );

        Debug.Log( rdm + "|| >> " + rdm2 + "|| >> " + rdm3 );

        if (counter < 2)
        {
            foreach (GameObject bonus in bonusGameObjectList)
            {

                    if (bonusGameObjectList.IndexOf(bonus) == rdm )
                    {
                    
                        bonus.SetActive(true);
                        counter++;
                    }
                    else if (bonusGameObjectList.IndexOf(bonus) == rdm2)
                    {

                        bonus.SetActive(true);
                        counter++;
                    }
                    else if (bonusGameObjectList.IndexOf(bonus) == rdm3)
                    {

                        bonus.SetActive(true);
                        counter++;
                    }
                    else
                    {
                        bonus.SetActive(false);
                    }

            }

        }
        
    }
    

     public void SetInactiveAllBonuses()
            {
            //foreach (GameObject bonus in bonusGameObjectList)
            //{   
            //        bonus.SetActive(false);
            //}
            counter = 0;
        }
}

