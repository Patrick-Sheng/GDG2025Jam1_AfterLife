using UnityEngine;

public class changecolliderBasedOnAnimation : MonoBehaviour
{
    public BoxCollider2D left;
    public BoxCollider2D right;
    public BoxCollider2D normal;

    private void Start()
    {
        normal.enabled = true;
    }
    public void LeftAnim()
    {
        //normal.enabled = false;
        //right.enabled = false;
        //left.enabled = true;

    }
    public void RightAnim()
    {
       // normal.enabled = false;
       // right.enabled = true;
       // left.enabled = false;
    }
    public void NormalAnim()
    {
      //  normal.enabled = true;
       // right.enabled = false;
       // left.enabled = false;
    }


}
