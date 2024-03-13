using ActionCommandGame.Model.Abstractions;

namespace ActionCommandGame.Model
{
    public class NegativeGameEvent: IIdentifiable, IHasProbability
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SecurityWithGearDescription { get; set; }
        public string SecurityWithoutGearDescription { get; set; }
        public int SecurityLoss { get; set; }
        public int Probability { get; set; }
    }
}
