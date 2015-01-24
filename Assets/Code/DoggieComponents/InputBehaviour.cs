namespace Assets.Code.DoggieComponents
{
    public interface IInputBehaviour
    {
        bool CanShoot();
        void StartShoot();
        void StopShoot();
    }
}
