using UnityEngine;

public class CannonController : MonoBehaviour
{
    private const float _angleIncrement = 5.0f;
    private float _moveIncrement = 0.5f;
    private float _cannonAngle = 0;
    private float _cannonPower = 30;

    public GameObject CannonBallPrefab;
    public Transform SpawnPoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            transform.root.position += new Vector3(_moveIncrement, 0, 0);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.root.position -= new Vector3(_moveIncrement, 0, 0);

    }

    public void AngleUp()
    {
        _cannonAngle += _angleIncrement;
        transform.rotation = Quaternion.Euler(0, 0, _cannonAngle);
        Debug.Log("Cannon Angle: " + _cannonAngle);
    }

    public void AngleDown()
    {
        _cannonAngle -= _angleIncrement;
        transform.rotation = Quaternion.Euler(0, 0, _cannonAngle);
        Debug.Log("Cannon Angle: " + _cannonAngle);
    }

    public void Fire()
    {
        GameObject cannonBall = Instantiate(CannonBallPrefab, SpawnPoint.position, Quaternion.identity);

        //Find direction
        Vector3 velocity = Quaternion.Euler(0,0,_cannonAngle) * Vector3.right;

        //Give it some Speed
        velocity *= _cannonPower;

        //actually fire
        Rigidbody2D cannonRigidbody = cannonBall.GetComponent<Rigidbody2D>();
        cannonRigidbody.velocity = velocity;
    }

    public void PowerIncrease()
    {
        _cannonPower += 5;
        Debug.Log("Power Increased: " + _cannonPower);
    }

    public void PowerDecrease()
    {
        _cannonPower -= 5;
        Debug.Log("Power Decreased: " + _cannonPower);
    }

}
