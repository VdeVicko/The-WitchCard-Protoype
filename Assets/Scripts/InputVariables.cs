using UnityEngine;
using UnityEngine.InputSystem;
public class InputVariables : MonoBehaviour
{
    [Header("input")]
    protected InputActionMap playerInputMap;
    [SerializeField] private InputActionAsset playerInputAsset;
    [SerializeField] protected PlayerInput playerInput;
    [SerializeField] protected GameObject player;
        

    protected void GetInputComponents()
    {
        playerInputMap = playerInputAsset.FindActionMap("Gameplay");
        player = GameObject.FindGameObjectWithTag("Player");
        playerInput = player.GetComponent<PlayerInput>();
    }

    public GameObject GetPlayer()
    {
        return player;
    }
   
}
