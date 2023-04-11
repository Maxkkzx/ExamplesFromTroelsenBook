namespace CarLibrary
{
    public enum EngineState
    { engineAlive, engineDead }

    public abstract class Car
    {
        public string PetName { get; set; }
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        protected EngineState egnState = EngineState.engineAlive;
        public EngineState EngineState => egnState;
        public abstract void TurboBoost();
        public Car() { }
        public Car(string petName,  int maxSpeed, int currentSpeed)
        {
            PetName = petName;
            CurrentSpeed = currentSpeed;
            MaxSpeed = maxSpeed;
        }

    }
}