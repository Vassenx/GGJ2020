using UnityEngine;

[SerializeField]
public class Repairable : MonoBehaviour
{
    public bool isFixed = false;
    public Tool[] toolsNeeded; //please order them
    [SerializeField] private ActSystem actSystem = null;
    private int curIndex = 0;

    //TODO: implement idea that order of tools used matter?
    public void Fix(Tool tool)
    {
        if (!isFixed && toolsNeeded[curIndex] == tool)
        {
            curIndex++;

            if (curIndex == toolsNeeded.Length)
            {
                isFixed = true;
                actSystem.UpdateAct(); //check if this finishes the act
                Debug.Log("I am repaired");
            }
        }
        else
        {
            curIndex = 0;
        }
    }
}