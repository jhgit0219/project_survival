using UnityEngine;

public class SpriteBillboard : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        transform.rotation = Quaternion.Euler(Camera.main.transform.rotation.eulerAngles.x, 
            0f, 0f);
    }
}
