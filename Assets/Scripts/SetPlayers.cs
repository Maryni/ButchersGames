using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayers : MonoBehaviour
{
    [SerializeField] private List<GameObject> players;

    public List<GameObject> PlayersList => players;
    
    public void SetPositionPlayerOnPoint(Vector3 point, int index)
    {
        players[index].transform.position.Set(point.x,point.y,point.z);
    }

    public void ActivatePlayer(int index)
    {
        players[index].SetActive(true);
    }
    public void DiactivatePlayer(int index)
    {
        players[index].SetActive(false);
    }
}
