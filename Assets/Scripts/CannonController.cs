using UnityEngine;
using UnityEngine.UI;
public class CannonController : MonoBehaviour
{
    private const float PowerIncrement = 5;
    private const float MaxPower = 35;
    private const float MinPower = 5;
    private const float AngleIncrement = 10;
    private const float MaxAngle = 90;
    private const float MinAngle = 0;

    [SerializeField]
    private Text _angleText;
    [SerializeField]
    private Text _powerText;
    [SerializeField]
    private Transform _cannonSpawn;
    [SerializeField]
    private GameObject _cannonBallPrefab;

    private float _power = 5;
    private float _angle = 0;

    public void Fire()
    {
        var cannonBall = Instantiate(_cannonBallPrefab, _cannonSpawn.position, Quaternion.identity) as GameObject;
        var cannonBallRigidbody = cannonBall.GetComponent<Rigidbody2D>();
        cannonBallRigidbody.velocity = Quaternion.Euler(0, 0, _angle) * Vector3.right * _power;
    }
    public void AngleUp()
    {
        if (_angle + AngleIncrement > MaxAngle) return;
        _angle += AngleIncrement;
        _angleText.text = _angle + "°";
        transform.rotation = Quaternion.Euler(0, 0, _angle);
    }
    public void AngleDown()
    {
        if (_angle - AngleIncrement < MinAngle) return;
        _angle -= AngleIncrement;
        _angleText.text = _angle + "°";
        transform.rotation = Quaternion.Euler(0, 0, _angle);
    }
    public void PowerUp()
    {
        if (_power + PowerIncrement > MaxPower) return;
        _power += PowerIncrement;
        _powerText.text = _power + "";
    }
    public void PowerDown()
    {
        if (_power - PowerIncrement < MinPower) return;
        _power -= PowerIncrement;
        _powerText.text = _power + "";
    }

    private void Start()
    {
        _angleText.text = _angle + "°";
        _powerText.text = _power + "";
    }
}
