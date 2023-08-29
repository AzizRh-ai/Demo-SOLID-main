using UnityEngine;

// Handles player input
public class PlayerController : MonoBehaviour
{
    //[SerializeField] private SerializableInterface<IMove> _playerMovementInterface;
    //[SerializeField] private SerializableInterface<IHealth> _playerHealtInterface;
    //private IMove _playerMovement => _playerMovementInterface.Value;
    //private IHealth _playerHealth => _playerHealtInterface.Value;

    // TODO : Test sans dépendance externe, voir code Julien et package utilisé https://github.com/Simplon-Nice-Meta-AR-VR/Demo-SOLID
    [SerializeField] private GameObject _playerObject;

    private IMove _playerMovement;
    private IHealth _playerHealth;
    private IScore _playerScore;
    private int _score = 0;

    void Start()
    {
        _playerMovement = _playerObject.GetComponent<IMove>();
        _playerHealth = _playerObject.GetComponent<IHealth>();
        _playerScore = _playerObject.GetComponent<IScore>();

        if (_playerMovement == null || _playerHealth == null || _playerScore == null)
        {
            Debug.LogError("composant manquant dans player");
        }

        Initialize(_playerMovement, _playerHealth, _playerScore);
    }

    public void Initialize(IMove playerMovement, IHealth playerHealth, IScore playerScore)
    {
        _playerMovement = playerMovement;
        _playerHealth = playerHealth;
        _playerScore = playerScore;
    }


    void Update()
    {
        // Move input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        _playerMovement.Move(new Vector2(horizontalInput, verticalInput));

    }


    private void OnCollisionEnter(Collision collision)
    {
        Food food = collision.gameObject.GetComponent<Food>();

        if (food != null)
        {
            _score += food.Score;

            if (food != null)
            {
                _score += food.Score;
                _playerHealth.ChangeHealth(food.Score);

                // Debug.Log("Score: " + _score);
                Destroy(collision.gameObject);
            }
        }
    }
}

