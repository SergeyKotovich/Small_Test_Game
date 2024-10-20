using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _jumpSound;
    [SerializeField] private AudioClip _doorSound;
    [SerializeField] private AudioClip _buttonPressed;
    
    public void PlaySoundDoor()
    {
        _audioSource.PlayOneShot(_doorSound); 
    }
    
    public void PlaySoundJump()
    {
        _audioSource.PlayOneShot(_jumpSound); 
    }

    public void PlayButtonPressedSound()
    {
        _audioSource.PlayOneShot(_buttonPressed); 
    }
}
