using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BIgStone : MonoBehaviour,IDamagableE
{
    public List<Stone1> Stones;
    private int CurrentI = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DieOut()
    {
        if (CurrentI < Stones.Count)
        {
            Stones[CurrentI].DieOut();
            CurrentI++;
        }
    }
}
