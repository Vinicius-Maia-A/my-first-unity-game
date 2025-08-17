using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton instance of GameManager
    public static GameManager Instance;

    // InputManager instance to handle player inputs
    public InputManager inputManager { get; private set; }

    private void Awake()
    {
        if(Instance != null) Destroy(this.gameObject);
        Instance = this;

        inputManager = new InputManager();
    }
}