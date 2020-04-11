using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary
{
    //  represents the state of the engine
    public enum EngineState
    { engineAlive, engineDead }
    //  the abstract class Car
    public abstract class Car
    {
        public string PetName { get; set; }
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }

        protected EngineState egnState = EngineState.engineAlive;
        public EngineState EngineState => egnState;
        public abstract void TurboBoost();

        public Car() { }
        public Car(string name, int maxSp, int currSp)
        {
            PetName = name;
            MaxSpeed = maxSp;
            CurrentSpeed = currSp;
        }
    }
}
