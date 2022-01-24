namespace Wreath.Model
{
    /// <summary>
    /// Table transitions class based on delegates
    /// </summary>
    public class TransitionBase
    {
        public TransitionBase(Transition transition, string name, uint id)
        {
            TransitionMethod = transition;
            Name = name;
            Id = id;
        }

        public void MakeTransition()
        {
            TransitionMethod(Id);
        }

        public delegate void Transition(uint id);

        public Transition TransitionMethod { get; set; }
        public string Name { get; set; }
        public uint Id { get; set; }
    }
}