namespace FishLibrary
{
    public interface ITokenManager
    {
        ChickenLeg ChickenLeg { get; }

        void SetChickenLeg(ChickenLeg pChickenLeg);
    }
}