using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Collider2D))]
public class Speaker : MonoBehaviour
{
    private Collider2D col;
    private DialogTree[] dialogTrees;
    public new string name = "WARNING: must match json";

    private void Start()
    {
        col = GetComponent<Collider2D>();
        col.isTrigger = true;

        dialogTrees = JsonConverter.allDialogTrees?.FindAll(x => x.colliderName.ToLower().Equals(name.ToLower())).ToArray<DialogTree>();
        if (dialogTrees.Length == 0)
        {
            Debug.LogAssertion("There is no dialog associated with this tree. Maybe the name: " + name + " does not match the json colliderName.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var bestDialog = GetBestDialog();
            if (bestDialog != null)
            {
                DialogSystem.instance.StartDialog(bestDialog);
            }
        }
    }

    //Figures out which dialog tree is best at the moment based on pre-conditions of each dialog
    //Requires the condition list to be known, as IsSatisified is a hardcoded switch statement
    private DialogTree GetBestDialog()
    {
        //only get trees where all the pre-conditions are satisified
        var bestDialogs = dialogTrees.Where(tree => !tree.preconditions.Any(cond => !IsSatisfied(cond))); //TODO: and act filter
        bestDialogs.OrderBy(x => x.priority);

        return bestDialogs.First();
    }

    //TODO fill out conditions we will use
    private bool IsSatisfied(string condition)
    {
        switch (condition)
        {
            case "carrot":
                return true;
            case "act1":
                /*if (Act != 1)
                    return false;
                else
                    return true;*/
                return true;
            default:
                Debug.Log("Dialog pre-condition not set correctly for condition: " + condition);
                return false;
        }
    }
}
