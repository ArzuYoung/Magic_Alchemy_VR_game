using UnityEngine;

namespace Animation
{
    public class HandProceduralAnimation : MonoBehaviour
    {
        [SerializeField] private bool isLeftHand;
        [Space]
        [SerializeField] private Transform[] thumbFinger;
        [SerializeField] private Transform[] indexFinger;
        [SerializeField] private Transform[] middleFinger;
        [SerializeField] private Transform[] ringFinger;
        [SerializeField] private Transform[] littleFinger;

        private void Start()
        {
            SetDefaultHand();

            if (isLeftHand)
            {
                InputHandler.Instance.OnLeftGripButton_Down.AddListener(SetGripHand);
                InputHandler.Instance.OnLeftGripButton_Up.AddListener(SetDefaultHand);
            }
            else
            {
                InputHandler.Instance.OnRightGripButton_Down.AddListener(SetGripHand);
                InputHandler.Instance.OnRightGripButton_Up.AddListener(SetDefaultHand);
            }
        }

        private void SetDefaultHand()
        {
            thumbFinger[0].localRotation = Quaternion.Euler(0,0,54.605f);
            thumbFinger[1].localRotation = Quaternion.Euler(0,0,-11.859f);
            
            indexFinger[0].localRotation = Quaternion.Euler(0,0,4.273f);
            indexFinger[1].localRotation = Quaternion.Euler(-180f,180f,-180.275f);
            indexFinger[2].localRotation = Quaternion.Euler(-180f,180f,-181.433f);
            
            middleFinger[0].localRotation = Quaternion.Euler(0,0,0.109f);
            middleFinger[1].localRotation = Quaternion.Euler(0,0,-0.309f);
            middleFinger[2].localRotation = Quaternion.Euler(0,0,0.347f);
            
            ringFinger[0].localRotation = Quaternion.Euler(0,0,-2.744f);
            ringFinger[1].localRotation = Quaternion.Euler(0,0,-1.065f);
            ringFinger[2].localRotation = Quaternion.Euler(0,0,1.965f);
            
            littleFinger[0].localRotation = Quaternion.Euler(0,0,-6.572f);
            littleFinger[1].localRotation = Quaternion.Euler(-180f,-180f,178.076f);
            littleFinger[2].localRotation = Quaternion.Euler(-180f,-180f,180.955f);
        }

        private void SetGripHand()
        {
            thumbFinger[0].localRotation = Quaternion.Euler(-21.538f,-33.74f,61.207f);
            thumbFinger[1].localRotation = Quaternion.Euler(-39.266f,9.885f,-15.393f);
            
            indexFinger[0].localRotation = Quaternion.Euler(-35.275f,-3.03f,5.236f);
            indexFinger[1].localRotation = Quaternion.Euler(-151.022f,180.152f,-180.314f);
            indexFinger[2].localRotation = Quaternion.Euler(-135.202f,182.423f,-182.02f);
            
            middleFinger[0].localRotation = Quaternion.Euler(-28.879f,-0.06f,0.125f);
            middleFinger[1].localRotation = Quaternion.Euler(-41.578f,0.274f,-0.413f);
            middleFinger[2].localRotation = Quaternion.Euler(-37.156f,-0.263f,0.436f);
            
            ringFinger[0].localRotation = Quaternion.Euler(-35.219f,1.939f,-3.36f);
            ringFinger[1].localRotation = Quaternion.Euler(-34.662f,0.737f,-1.295f);
            ringFinger[2].localRotation = Quaternion.Euler(-21.612f,-0.771f,2.092f);
            
            littleFinger[0].localRotation = Quaternion.Euler(-48.556f,7.497f,-9.957f);
            littleFinger[1].localRotation = Quaternion.Euler(-160.063f,-179.302f,177.953f);
            littleFinger[2].localRotation = Quaternion.Euler(-129.278f,-181.168f,181.508f);
        }
    }
}
