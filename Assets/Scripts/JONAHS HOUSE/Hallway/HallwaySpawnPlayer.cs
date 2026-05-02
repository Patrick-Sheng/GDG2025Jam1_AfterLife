using UnityEngine;

public class HallwaySpawnPlayer : MonoBehaviour
{
    public GameObject Player;

    public GameObject FromJonahsRoom;
    public GameObject FromLuciasRoom;
    public GameObject FromBathroom;
    public GameObject FromMainRoom;
    void Start()
    {
        if (StaticManager.goingFromRoom != null)
        {
            if (StaticManager.goingFromRoom == "FromJonahsRoom")
            {
                Player.transform.position = FromJonahsRoom.transform.position;
                StaticManager.goingFromRoom = null;
            }
            else if (StaticManager.goingFromRoom == "FromLuciasRoom")
            {
                Player.transform.position = FromLuciasRoom.transform.position;
                StaticManager.goingFromRoom = null;
            }
            else if (StaticManager.goingFromRoom == "FromBathRoom")
            {
                Player.transform.position = FromBathroom.transform.position;
                StaticManager.goingFromRoom = null;
            }
            else if (StaticManager.goingFromRoom == "FromMainRoom")
            {
                Player.transform.position = FromMainRoom.transform.position;
                StaticManager.goingFromRoom = null;
            }

            
        }
    }

}
