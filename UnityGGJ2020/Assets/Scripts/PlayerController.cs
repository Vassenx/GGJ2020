using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 1;

    void FixedUpdate()
    {
        Vector2 curPos = GetComponent<Rigidbody2D>().position;
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1);

        Vector2 moveTo = curPos + (input * speed * Time.deltaTime);
        GetComponent<Rigidbody2D>().MovePosition(moveTo);
    }
}
