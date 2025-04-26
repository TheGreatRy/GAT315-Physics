using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Exclude on Event Listener
    //[SerializeField] EventChannelSO onPlayerDeath;
    void Start()
    {
        //onPlayerDeath.AddListener(OnPlayerDeath);
    }
    #endregion
    public void OnPlayerDeath()
    {
        print("player ded oh naur");
    }

}
