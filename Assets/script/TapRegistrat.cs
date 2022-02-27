
using UnityEngine;

public class TapRegistrat : MonoBehaviour
{
    public void TapOnScreen()
    {
        if (!StaticScript.isJumping && !StaticScript.isSideMoving && !StaticScript.endGame)
        {
            StaticScript.isJumping = true;
            EventManager.SendTapScreen();
        }
    }
}
